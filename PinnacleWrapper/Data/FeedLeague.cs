using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PinnacleWrapper.Data
{
    [Serializable]
    [XmlRoot("league")]
    [Obsolete("GetFeed is Deprecated, please use GetOdds and GetFixtures")]
    public class FeedLeague
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlArray("events")]
        [XmlArrayItem("event")]
        public List<Event> Events { get; set; }
    }
}
