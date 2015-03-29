using System;
using System.Xml.Serialization;

namespace PinnacleWrapper.Data
{
    [Serializable]
    [XmlRoot("league")]
    public class League
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("feedContents")]
        public int FeedContents { get; set; }

        [XmlText]
        public string Title { get; set; }
    }
}
