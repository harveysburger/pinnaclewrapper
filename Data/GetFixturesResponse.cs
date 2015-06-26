using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PinnacleWrapper.Enums;

namespace PinnacleWrapper.Data
{
    public class GetFixturesResponse
    {
        [JsonProperty(PropertyName = "sportId")]
        public int SportId;

        [JsonProperty(PropertyName = "last")] 
        public long Last;
                
        [JsonProperty(PropertyName = "league")] 
        public List<FixturesLeague> Leagues;
    }

    public class FixturesLeague
    {
        [JsonProperty(PropertyName = "id")]
        public int Id;

        [JsonProperty(PropertyName = "events")]
        public List<FixturesEvent> Events;
    }

    public class FixturesEvent
    {
        [JsonProperty(PropertyName = "id")]
        public int Id;

        [JsonProperty(PropertyName = "starts")]
        public DateTime Start;

        [JsonProperty(PropertyName = "home")]
        public string Home;

        [JsonProperty(PropertyName = "away")]
        public string Away;

        [JsonProperty(PropertyName = "rotNum")]
        public string RotationNumber;

        [JsonProperty(PropertyName = "liveStatus")]
        public LiveStatus LiveStatus;

        [JsonProperty(PropertyName = "status")]
        public EventStatus EventStatus;

        [JsonProperty(PropertyName = "parlayRestriction")]
        public ParlayRestriction ParlayRestriction;
    }
}
