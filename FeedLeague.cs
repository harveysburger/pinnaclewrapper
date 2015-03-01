using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("league")]
    public class FeedLeague
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlArray("events")]
        [XmlArrayItem("event")]
        public List<Event> Events { get; set; }
    }
}
