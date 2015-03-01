using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("rsp")]
    public class LeaguesResponse : XmlResponse
    {
        [XmlArray("leagues")]
        [XmlArrayItem("league")]
        public List<League> Leagues { get; set; }
    }
}
