using System;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("moneyLine")]
    public class MoneyLine
    {
        [XmlElement("awayPrice")]
        public double AwayPrice { get; set; }

        [XmlElement("homePrice")]
        public double HomePrice { get; set; }
    }
}
