using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PinnacleWrapper.Data
{
    [Serializable]
    [XmlRoot("period")]
    public class Period
    {
        [XmlAttribute("lineId")]
        public long LineId { get; set; }

        [XmlElement("number")]
        public int Number { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("cutoffDateTime")]
        public DateTime CutoffDateTime { get; set; }

        [XmlArray("spreads")]
        [XmlArrayItem("spread")]
        public List<Spread> Spreads { get; set; }

        [XmlElement("moneyLine")]
        public MoneyLine MoneyLine { get; set; }

        [XmlArray("totals")]
        [XmlArrayItem("total")]
        public List<TotalPoints> Totals { get; set; }

        //[XmlElement("teamTotals")]
        //public TeamTotalPoints TeamTotalPoints { get; set; }      // temporarily unused

        [XmlElement("maxBetAmount")]
        public BetAmount MaxBetAmount { get; set; }
    }
}
