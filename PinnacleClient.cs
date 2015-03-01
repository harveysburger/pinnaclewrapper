using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PinnacleWrapper
{
    public class PinnacleClient
    {
        private HttpClient _httpClient;

        private string _clientId;
        private string _password;

        public string CurrencyCode { get; private set; }
        public OddsFormat OddsFormat { get; private set; }

        private const int MinimumFeedRefreshWithLast = 5;   // minimum time in seconds between calls when supplying the last timestamp parameter
        private const int MinimumFeedRefresh = 60;          // minimum time in seconds between calls without last timestamp parameter

        private DateTime? _lastFeedRequest;

        private const string BaseAddress = "https://api.pinnaclesports.com/v1/";

        public PinnacleClient(string clientId, string password, string currencyCode, OddsFormat oddsFormat)
        {
            _clientId = clientId;
            _password = password;
            CurrencyCode = currencyCode;
            OddsFormat = oddsFormat;

            _httpClient = new HttpClient {BaseAddress = new Uri(BaseAddress)};
            
            // put auth header into httpclient
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(string.Format("{0}:{1}", 
                        , _password))));
        }

        protected T GetXmlAsync<T>(string requestType, params object[] values)
            where T : XmlResponse
        {
            var response = _httpClient.GetAsync(string.Format(requestType, values)).Result;

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var xmlFormatter = new XmlMediaTypeFormatter { UseXmlSerializer = true };
            var apiResponse = response.Content.ReadAsAsync<T>(new[] { xmlFormatter }).Result;

            if (apiResponse.IsValid)
            {
                return apiResponse;
            }

            throw new Exception("Pinnacle Sports API error: " + apiResponse.Error.Message);
        }

        public List<Sport> GetSports()
        {
            return GetXmlAsync<SportsResponse>("sports").Sports;
        }

        public List<League> GetLeagues(int sportId)
        {
            return GetXmlAsync<LeaguesResponse>("leagues?sportid={0}", sportId).Leagues;
        }

        public List<Currency> GetCurrencies()
        {
            return GetXmlAsync<CurrenciesResponse>("currencies").Currencies;
        }
        
        #region GetFeed

        protected string GetFeedRequestUri(int sportId, int[] leagueId, OddsFormat format, string currency, long lastTimestamp, int isLive)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("feed?sportid={0}", sportId);
            sb.AppendFormat("&leagueid={0}", string.Join("-", leagueId));
            sb.AppendFormat("&oddsformat={0}", (int)format);
            sb.AppendFormat("&currencycode={0}", currency);

            if (lastTimestamp > 0)
            {
                sb.AppendFormat("&last={0}", lastTimestamp);
            }

            if (isLive == 0 || isLive == 1)
            {
                sb.AppendFormat("&islive={0}", isLive);
            }

            return sb.ToString();
        }

        protected bool IsFairFeedRequest(long lastTimestamp)
        {
            if (_lastFeedRequest.HasValue)
            {
                var minRequestInterval = (lastTimestamp > 0 ? MinimumFeedRefreshWithLast : MinimumFeedRefresh);
                var interval = DateTime.Now - _lastFeedRequest.Value;

                if (interval.TotalSeconds < minRequestInterval)
                {
                    return false;
                }
            }

            return true;
        }

        protected Feed GetFeed(int sportId, int[] leagueIds, OddsFormat format, string currency, long lastTimestamp, int isLive)
        {
            if (!IsFairFeedRequest(lastTimestamp))
                throw new Exception(
                    string.Format(
                        "Too many feed requests. Minimum interval time between request is {0} seconds or {1} seconds when specifying the last parameter",
                        MinimumFeedRefresh,
                        MinimumFeedRefreshWithLast));

            _lastFeedRequest = DateTime.Now;
            var uri = GetFeedRequestUri(sportId, leagueIds, format, currency, lastTimestamp, isLive);

            return GetXmlAsync<FeedResponse>(uri).Feed;
        }

        public Feed GetFeed(int sportId, int[] leagueIds)
        {
            return GetFeed(sportId, leagueIds, OddsFormat, CurrencyCode, -1, -1);
        }

        public Feed GetFeed(int sportId, int[] leagueIds, long lastTimestamp)
        {
            return GetFeed(sportId, leagueIds, OddsFormat, CurrencyCode, lastTimestamp, -1);
        }

        public Feed GetFeed(int sportId, int[] leagueIds, OddsFormat format, string currency)
        {
            return GetFeed(sportId, leagueIds, format, currency, -1, -1);
        }

        public Feed GetFeed(int sportId, int[] leagueIds, OddsFormat format, string currency, bool isLive)
        {
            return GetFeed(sportId, leagueIds, format, currency, -1, isLive ? 1 : 0);
        }

        public Feed GetFeed(int sportId, int[] leagueIds, OddsFormat format, string currency, long lastTimestamp)
        {
            return GetFeed(sportId, leagueIds, format, currency, lastTimestamp, -1);
        }

        public Feed GetFeed(int sportId, int[] leagueIds, OddsFormat format, string currency, long lastTimestamp, bool isLive)
        {
            return GetFeed(sportId, leagueIds, format, currency, lastTimestamp, isLive ? 1 : 0);
        }

        #endregion

        protected T GetJsonAsync<T>(string requestType, params object[] values)
        {
            var response = _httpClient.GetAsync(string.Format(requestType, values)).Result;

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = response.Content.ReadAsStringAsync().Result;

            // deserialise json async
            var apiResponse = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json)).Result;

            return apiResponse;
        }

        // ToDo: replace requestData object type with "IJsonSerialisable"
        protected T PostJsonAsync<T>(string requestType, object requestData)
        {
            var requestPostData = JsonConvert.SerializeObject(requestData);

            var response = _httpClient.PostAsync(requestType,
                new StringContent(requestPostData, Encoding.UTF8, "application/json")).Result;

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = response.Content.ReadAsStringAsync().Result;

            // deserialise async
            return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json)).Result;
        }

        public ClientBalance GetClientBalance()
        {
            const string uri = "client/balance";
            return GetJsonAsync<ClientBalance>(uri);
        }

        public GetBetsResponse GetBets(BetListType type, DateTime startDate, DateTime endDate)
        {
            // get request uri
            var sb = new StringBuilder();
            sb.AppendFormat("bets?betlist={0}", type.ToString().ToLower());
            sb.AppendFormat("&fromDate={0}", startDate.ToString("yyyy-MM-dd"));
            sb.AppendFormat("&toDate={0}", endDate.ToString("yyyy-MM-dd"));

            var uri = sb.ToString();

            return GetJsonAsync<GetBetsResponse>(uri);
        }

        public GetBetsResponse GetBets(List<int> betIds)
        {
            // get request uri
            var sb = new StringBuilder();

            sb.AppendFormat("bets?betids={0}", string.Join(",", betIds));

            var uri = sb.ToString();

            return GetJsonAsync<GetBetsResponse>(uri);
        }

        public PlaceBetResponse PlaceBet(PlaceBetRequest placeBetRequest)
        {
            return PostJsonAsync<PlaceBetResponse>("bets/place", placeBetRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sportId"></param>
        /// <param name="leagueId"></param>
        /// <param name="eventId"></param>
        /// <param name="periodNumber">0 for sports other than soccer, soccer: 0 = Game, 1 = 1st Half, 2 = 2nd Half</param>
        /// <param name="betType"></param>
        /// <param name="oddsFormat"></param>
        /// <param name="team"></param>
        /// <param name="side"></param>
        /// <param name="handicap"></param>
        /// <returns></returns>
        public GetLineResponse GetLine(int sportId, int leagueId, long eventId, int periodNumber, BetType betType, OddsFormat oddsFormat,
            TeamType? team = null, SideType? side = null, decimal? handicap = null)
        {
            if (team == null)
            {
                if (betType == BetType.MoneyLine || betType == BetType.Spread || betType == BetType.TeamTotalPoints)
                    throw new Exception(string.Format("TeamType is required for {0} Bets!", betType));
            }

            if (side == null)
            {
                if (betType == BetType.TotalPoints || betType == BetType.TeamTotalPoints)
                    throw new Exception(string.Format("SideType is required for {0} Bets!", betType));
            }

            if (handicap == null)
            {
                if (betType == BetType.Spread || betType == BetType.TotalPoints || betType == BetType.TeamTotalPoints)
                    throw new Exception(string.Format("Handicap is required for {0} Bets!", betType));
            }

            // get request uri
            var sb = new StringBuilder();
            sb.AppendFormat("line?sportId={0}", sportId);
            sb.AppendFormat("&leagueId={0}", leagueId);
            sb.AppendFormat("&eventId={0}", eventId);
            sb.AppendFormat("&betType={0}", betType.ToString().ToUpper());
            sb.AppendFormat("&oddsFormat={0}", oddsFormat.ToString().ToUpper());
            sb.AppendFormat("&periodNumber={0}", periodNumber);                 // i.e. for soccer: 0 = Game, 1 = 1st Half, 2 = 2nd Half

            if (team != null)
                sb.AppendFormat("&team={0}", team.ToString().ToUpper());

            if (side != null)
                sb.AppendFormat("&side={0}", side.ToString().ToUpper());

            if (handicap != null)
                sb.AppendFormat("&handicap={0}", handicap.ToString().ToUpper());

            var uri = sb.ToString();

            return GetJsonAsync<GetLineResponse>(uri);
        }

        public GetInRunningResponse GetInRunning()
        {
            const string uri = "inrunning";
            return GetJsonAsync<GetInRunningResponse>(uri);
        }
    }
}

