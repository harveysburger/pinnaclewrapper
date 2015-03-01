using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("fd")]
    public class Feed
    {
        [XmlElement("fdTime")]
        public long Timestamp { get; set; }

        [XmlArray("sports")]
        [XmlArrayItem("sport")]
        public List<FeedSport> Sports { get; set; }
    }
}
