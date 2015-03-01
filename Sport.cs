using System;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("sport")]
    public class Sport
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("feedContents")]
        public int FeedContents { get; set; }

        [XmlText]
        public string Title { get; set; }
    }
}
