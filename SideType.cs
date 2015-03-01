using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SideType
    {
        Over,
        Under
    }
}
