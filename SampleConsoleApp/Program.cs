﻿using System;
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
    class Program
    {
        private static readonly NLog.ILogger Logger = NLog.LogManager.GetCurrentClassLogger(); 
        private const int SampleSportId = 33;

        static async Task Main(string[] args)
        {
            Logger.Info("Starting...");

            try
            {
                AppConfig configuration;

                using (StreamReader r = new StreamReader("appsettings.json"))
                {
                    string json = r.ReadToEnd();
                    configuration = JsonConvert.DeserializeObject<AppConfig>(json);
                }

                var api = new PinnacleClient(configuration.Username, configuration.Password,
                    configuration.Currency, OddsFormat.AMERICAN, configuration.BaseUrl);
                long lastFixture = 0;
                long lastLine = 0;

                var fixtures = await api.GetFixtures(new GetFixturesRequest(SampleSportId, lastFixture))
                    .ConfigureAwait(true);

                var lines = await api.GetOdds(new GetOddsRequest(fixtures.SportId,fixtures.Leagues.Select(i => i.Id).ToList(), lastLine, false))
                    .ConfigureAwait(true);

                var leagues = await api.GetLeagues(SampleSportId)
                    .ConfigureAwait(true);

                // Subsequent calls to GetOdds or GetFixtures should pass these 'Last' values to get only what changed since instead of the full snapshot
                lastFixture = fixtures.Last;
                lastLine = lines.Last;

                SaveResultsToOutputFolder(fixtures, lines, leagues);

                Console.WriteLine("Done!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Error(e, "Exception in Task Run.");
            }

            Logger.Info("Done!");
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void SaveResultsToOutputFolder(GetFixturesResponse fixtures, GetOddsResponse lines, List<League> leagues)
        {
            CleanOutputFolder();

            foreach (var league in fixtures.Leagues)
            {
                foreach (var fixture in league.Events)
                {
                    FlushToFile(@"Output\Fixtures.json", JsonConvert.SerializeObject(fixture));
                }
            }

            foreach (var league in lines.Leagues)
            {
                foreach (var line in league.Events.Where(e => e.Periods.Any()))
                {
                    FlushToFile(@"Output\Lines.json", JsonConvert.SerializeObject(line));
                }
            }

            foreach (var league in leagues)
            {
                FlushToFile(@"Output\Leagues.json", JsonConvert.SerializeObject(league));
            }

            Logger.Info("Results saved in \\Output\\");
        }

        private static void CleanOutputFolder()
        {
            if (!Directory.Exists(@"Output"))
                Directory.CreateDirectory(@"Output");

            foreach (var file in Directory.GetFiles(@"Output\"))
            {
                File.Delete(file);
            }
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