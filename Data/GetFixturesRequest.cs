using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class GetFixturesRequest
    {
        public int SportId { get; set; } 
        public List<int> LeagueIds { get; set; } 
        public long Since { get; set; } 
        public bool IsLive { get; set; }

        public GetFixturesRequest(int sportId)
        {
            SportId = sportId;
        }

        public GetFixturesRequest(int sportId, long since)
        {
            SportId = sportId;
            Since = since;
        }

        public GetFixturesRequest(int sportId, List<int> leagueIds)
        {
            SportId = sportId;
            LeagueIds = leagueIds;
        }

        public GetFixturesRequest(int sportId, List<int> leagueIds, long since)
        {
            SportId = sportId;
            LeagueIds = leagueIds;
            Since = since;
        }

        public GetFixturesRequest(int sportId, List<int> leagueIds, long since, bool isLive)
        {
            SportId = sportId;
            LeagueIds = leagueIds;
            Since = since;
            IsLive = isLive;
        }
    }
}
