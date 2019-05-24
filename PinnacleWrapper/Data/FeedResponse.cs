using System;
using System.Xml.Serialization;

namespace PinnacleWrapper.Data
{
    [Serializable]
    [XmlRoot("rsp")]
    [Obsolete("GetFeed is Deprecated, please use GetOdds and GetFixtures")]
    public class FeedResponse : XmlResponse
    {
        [XmlElement("fd")]
        public Feed Feed { get; set; }
    }
}
