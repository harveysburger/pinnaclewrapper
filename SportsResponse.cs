using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("rsp")]
    public class SportsResponse : XmlResponse
    {
        [XmlArray("sports")]
        [XmlArrayItem("sport")]
        public List<Sport> Sports { get; set; }
    }
}
