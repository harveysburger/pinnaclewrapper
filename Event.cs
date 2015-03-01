using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PinnacleWrapper
{
    [Serializable]
    [XmlRoot("event")]
    public class Event
    {
        [XmlElement("startDateTime")]
        public DateTime StartDateTime { get; set; }

        [XmlElement("id")]
        public long Id { get; set; }

        [XmlElement("IsLive")]
        public string IsLiveString { get; set; }

        [XmlIgnore]
        public bool IsLive
        {
            get
            {
                return IsLiveString.Equals("Yes", StringComparison.OrdinalIgnoreCase);
            }

            set
            {
                IsLiveString = (value ? "Yes" : "No");
            }
        }

        [XmlElement("status")]
        public string StatusString { get; set; }

        [XmlIgnore]
        public Status Status
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(StatusString))
                {
                    switch (StatusString.ToLower())
                    {
                        case "o":
                            return Status.Open;
                        case "i":
                            return Status.LowerMaximum;
                        case "h":
                            return Status.Unavailable;
                        case "x":
                            return Status.Cancelled;
                        default:
                            throw new Exception("Unrecognized status: " + StatusString);
                    }
                }

                throw new Exception("No status string");
            }
        }

        [XmlElement("homeTeam")]
        public Team HomeTeam { get; set; }

        [XmlElement("awayTeam")]
        public Team AwayTeam { get; set; }

        [XmlArray("periods")]
        [XmlArrayItem("period")]
        public List<Period> Periods { get; set; }
    }
}
