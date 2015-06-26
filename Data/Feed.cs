using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using PinnacleWrapper.Data;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("fd")]
    [Obsolete("GetFeed is Deprecated, please use GetOdds and GetFixtures")]
    public class Feed
    {
        [XmlElement("fdTime")]
        public long Timestamp { get; set; }

        [XmlArray("sports")]
        [XmlArrayItem("sport")]
        public List<FeedSport> Sports { get; set; }
    }
}
