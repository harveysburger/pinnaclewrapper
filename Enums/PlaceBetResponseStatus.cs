using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlaceBetResponseStatus
    {
        ACCEPTED,
        PENDING_ACCEPTANCE,      // live bets in the danger zone
        PROCESSED_WITH_ERROR
    }
}
