using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GetLineResponseStatus
    {
        Success,        
        NotExists       // Line no longer offered!
    }
}
