using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OddsFormat
    {
        AMERICAN,
        DECIMAL,
        HONGKONG,
        INDONESIAN,
        MALAY,
        Fraction
    }
}
