using System;
using Newtonsoft.Json;
using PinnacleWrapper.Enums;

namespace PinnacleWrapper.Data
{
    public class PlaceBetResponse
    {
        [JsonProperty(PropertyName = "status")]
        public PlaceBetResponseStatus Status;

        [JsonProperty(PropertyName = "errorCode")]              // If Status is PROCESSED_WITH_ERROR, errorCode will be in the response.
        public PlaceBetErrorCode? ErrorCode;

        [JsonProperty(PropertyName = "betId")]                  // The bet ID of the new bet. May be empty on failure.
        public int? BetId;

        [JsonProperty(PropertyName = "uniqueRequestId")]        // Echo of the uniqueRequestId from the request.
        public Guid UniquerequestId;

        [JsonProperty(PropertyName = "betterLineWasAccepted")]  // Whether or not the bet was accepted on the line that changed in favour of client.
        public bool BetterLineWasAccepted;
    }
}
