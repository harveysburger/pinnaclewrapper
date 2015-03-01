using System;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("spread")]
    public class Spread
    {
        [XmlElement("awaySpread")]
        public double AwaySpread { get; set; }

        [XmlElement("awayPrice")]
        public double AwayPrice { get; set; }

        [XmlElement("homeSpread")]
        public double HomeSpread { get; set; }

        [XmlElement("homePrice")]
        public double HomePrice { get; set; }
    }
}
