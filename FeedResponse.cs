using System;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("rsp")]
    public class FeedResponse : XmlResponse
    {
        [XmlElement("fd")]
        public Feed Feed { get; set; }
    }
}
