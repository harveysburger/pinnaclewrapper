using System;
using System.Xml.Serialization;

namespace PinnacleWrapper.Data
{
    [Serializable]
    public class Team
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("rotNum")]
        public int RotNum { get; set; }
    }
}
