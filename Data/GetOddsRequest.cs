using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class GetOddsRequest
    {
        public int SportId { get; set; } 
        public List<int> LeagueIds { get; set; } 
        public long Since { get; set; } 
        public bool IsLive { get; set; }

        public GetOddsRequest(int sportId)
        {
            SportId = sportId;
        }

        public GetOddsRequest(int sportId, long since)
        {
            SportId = sportId;
            Since = since;
        }

        public GetOddsRequest(int sportId, List<int> leagueIds)
        {
            SportId = sportId;
            LeagueIds = leagueIds;
        }

        public GetOddsRequest(int sportId, List<int> leagueIds, long since)
        {
            SportId = sportId;
            LeagueIds = leagueIds;
            Since = since;
        }

        public GetOddsRequest(int sportId, List<int> leagueIds, long since, bool isLive)
        {
            SportId = sportId;
            LeagueIds = leagueIds;
            Since = since;
            IsLive = isLive;
        }
    }
}
