using System;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("currency")]
    public class Currency
    {
        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlText]
        public string Name { get; set; }
    }
}
