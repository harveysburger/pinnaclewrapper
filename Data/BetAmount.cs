using System;
using System.Xml.Serialization;

namespace PinnacleWrapper.Data
{
    [Serializable]
    public class BetAmount
    {
        [XmlElement("spread")]
        public double Spread { get; set; }

        [XmlElement("moneyLine")]
        public double MoneyLine { get; set; }
    }
}
