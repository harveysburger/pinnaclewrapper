using System;
using Newtonsoft.Json;
using PinnacleWrapper.Enums;

namespace PinnacleWrapper.Data
{
    public class FixturesEvent
    {
        [JsonProperty(PropertyName = "id")] 
        public long Id;

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

        [JsonProperty(PropertyName = "parentId")]
        public long ParentId;

        [JsonProperty(PropertyName = "resultingUnit")]
        public string ResultingUnit;
    }
}