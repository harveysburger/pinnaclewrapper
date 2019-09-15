using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PinnacleWrapper;
using PinnacleWrapper.Data;
using PinnacleWrapper.Enums;

namespace SampleConsoleApp
{
    internal class Program
    {
        private static readonly NLog.ILogger Logger = NLog.LogManager.GetCurrentClassLogger();
        private const int SampleSportId = 29;

        private static async Task Main(string[] args)
        {
            Logger.Info("Starting...");

            try
            {
                AppConfig config;

                /*
                 add a appsettings.json file that looks like this or feed the settings in some other ways 
                         {
                          "Username": "username",
                          "Password": "password",
                          "Currency": "GBP",
                          "OddsFormat": "DECIMAL",
                          "BaseUrl": "https://api.pinnacle.com/"
                        }
                 */
                using (var r = new StreamReader("appsettings.json"))
                {
                    var json = r.ReadToEnd();
                    config = JsonConvert.DeserializeObject<AppConfig>(json);
                }

                using (var httpClient =
                    HttpClientFactory.GetNewInstance(config.Username, config.Password, true, config.BaseUrl))
                {
                    var api = new PinnacleClient(config.Currency, config.OddsFormat, httpClient);

                    long lastFixture = 0;
                    long lastLine = 0;

                    var fixtures = await api.GetFixtures(new GetFixturesRequest(SampleSportId, lastFixture));

                    var lines = await api.GetOdds(new GetOddsRequest(fixtures.SportId, fixtures.Leagues.Select(i => i.Id).ToList(), lastLine, false));

                    var leagues = await api.GetLeagues(SampleSportId);

                    // Subsequent calls to GetOdds or GetFixtures should pass these 'Last' values to get only what changed since instead of the full snapshot
                    lastFixture = fixtures.Last;
                    lastLine = lines.Last;

                    SaveResultsToOutputFolder(fixtures, lines, leagues);

                    var betResponse = await PlaceRandomBet(lines, api);
                    Console.WriteLine($"Status={betResponse.Status}, BetId={betResponse.BetId}, ErrorCode={betResponse.ErrorCode}, UniqueRequestId={betResponse.UniqueRequestId}");
                }

                Console.WriteLine("Done!");
                Logger.Info("Done!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Error(e, "Exception in Task Run.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static async Task<PlaceBetResponse> PlaceRandomBet(GetOddsResponse lines, PinnacleClient api)
        {
            int fullMatchPeriodNumber = 0;

            var eventsWithFullMatchMoneyLines = 
                lines.Leagues.SelectMany(l => 
                    l.Events.Where(e => e.Periods.Any(p =>
                    p.Status == (int) PeriodStatus.Online && p.MoneyLine?.Home > 1.0m &&
                    p.Number == fullMatchPeriodNumber))
                    ).ToList();
            
            var randomIndex = new Random().Next(0, eventsWithFullMatchMoneyLines.Count()-1);

            var randomEvent = eventsWithFullMatchMoneyLines[randomIndex];

            var request = new PlaceBetRequest
            {
                AcceptBetterLine = true,
                LineId = randomEvent.Periods.First(p => p.Number == fullMatchPeriodNumber).LineId,
                PeriodNumber = fullMatchPeriodNumber,
                TeamType = TeamType.Team1,
                Stake = 25,
                WinRiskType = WinRiskType.Risk,
                OddsFormat = OddsFormat.DECIMAL,
                SportId = SampleSportId,
                UniqueRequestId = Guid.NewGuid(),
                EventId =  randomEvent.Id,
                BetType = BetType.MoneyLine,
            };

            return await api.PlaceBet(request);
        }

        private static void SaveResultsToOutputFolder(GetFixturesResponse fixtures, GetOddsResponse lines,
            List<League> leagues)
        {
            CleanOutputFolder();

            foreach (var league in fixtures.Leagues)
            foreach (var fixture in league.Events)
                FlushToFile(@"Output\Fixtures.json", JsonConvert.SerializeObject(fixture));

            foreach (var league in lines.Leagues)
            foreach (var line in league.Events.Where(e => e.Periods.Any()))
                FlushToFile(@"Output\Lines.json", JsonConvert.SerializeObject(line));

            foreach (var league in leagues) FlushToFile(@"Output\Leagues.json", JsonConvert.SerializeObject(league));

            Logger.Info("Results saved in \\Output\\");
        }

        private static void CleanOutputFolder()
        {
            if (!Directory.Exists(@"Output"))
                Directory.CreateDirectory(@"Output");

            foreach (var file in Directory.GetFiles(@"Output\")) File.Delete(file);
        }

        private static void FlushToFile(string fileName, string content, bool addLineBreak = true)
        {
            if (addLineBreak)
                content = $"{content}\n";

            // yeah yeah.... terrible way to save to disk... lazy sample app...
            File.AppendAllText(fileName, content);
        }
    }
}