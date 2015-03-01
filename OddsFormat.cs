using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OddsFormat
    {
        American,
        Decimal,
        HongKong,
        Indonesian,
        Malay,
        Fraction
    }
}
