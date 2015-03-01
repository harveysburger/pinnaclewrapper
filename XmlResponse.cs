using System;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("rsp")]
    public abstract class XmlResponse
    {
        [XmlAttribute("status")]
        public string Status { get; set; }

        [XmlIgnore]
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Status)
                    && Status.Equals("ok", StringComparison.OrdinalIgnoreCase);
            }
        }

        [XmlElement("err")]
        public ResponseError Error { get; set; }
    }
}
