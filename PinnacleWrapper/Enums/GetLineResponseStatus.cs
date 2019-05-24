using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GetLineResponseStatus
    {
        Success,        
        NotExists       // Line no longer offered!
    }
}
