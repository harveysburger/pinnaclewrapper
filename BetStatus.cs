using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BetStatus
    {
        Accepted, 
        PendingAcceptance, 
        Rejected, 
        Refunded, 
        Cancelled, 
        Lose, 
        Won
    }
}
