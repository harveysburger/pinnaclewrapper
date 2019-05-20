using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class GetFixturesRequest
    {
        public int SportId { get; set; }
        public List<int> LeagueIds { get; set; }
        public long Since { get; set; }
        public bool IsLive { get; set; }
        public string ApiVersion { get; set; }

        public GetFixturesRequest(int sportId, string apiVersion = "v1")
        {
            SportId = sportId;
            ApiVersion = apiVersion;
        }

        public GetFixturesRequest(int sportId, long since, string apiVersion = "v1")
        {
            SportId = sportId;
            Since = since;
            ApiVersion = apiVersion;
        }

        public GetFixturesRequest(int sportId, List<int> leagueIds, string apiVersion = "v1")
        {
            SportId = sportId;
            LeagueIds = leagueIds;
            ApiVersion = apiVersion;
        }

        public GetFixturesRequest(int sportId, List<int> leagueIds, long since, string apiVersion = "v1")
        {
            SportId = sportId;
            LeagueIds = leagueIds;
            Since = since;
            ApiVersion = apiVersion;
        }

        public GetFixturesRequest(int sportId, List<int> leagueIds, long since, bool isLive, string apiVersion = "v1")
        {
            SportId = sportId;
            LeagueIds = leagueIds;
            Since = since;
            IsLive = isLive;
            ApiVersion = apiVersion;
        }
    }
}