using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventStatus
    {
        O,  // This is the starting status of a game. It means that the lines are open for betting.
        I,  // This status indicates that one or more lines have a red circle (a lower maximum bet amount).
        H   // This status indicates that the lines are temporarily unavailable for betting.
    }
}
