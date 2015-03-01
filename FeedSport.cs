using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("sport")]
    public class FeedSport
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlArray("leagues")]
        [XmlArrayItem("league")]
        public List<FeedLeague> Leagues { get; set; }
    }
}
