using System;
using System.Xml.Serialization;

namespace PinnacleWrapper.Data
{
    [Serializable]
    [XmlRoot("teamTotal")]
    public class TotalPoints
    {
        [XmlElement("@altLineId")]
        public int? AltLineId;

        [XmlElement("points")]
        public decimal Points;

        [XmlElement("overPrice")]
        public decimal OverPrice;

        [XmlElement("underPrice")]
        public decimal UnderPrice;
    }
}
