
using RSSFeedReader.logic.RSSFeedLogic;
using RSSFeedReader.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RSSFeedReader.Models
{
    /// <summary>
    /// Class representing a model for the rss feed
    /// </summary>
    public class RSSFeed : BaseModel
    {
        public static string ACTION_IDENTIFIER_SEPARATOR = "[####]";

        public static readonly string[] Categories = new string[]
        {
            "Arts",
            "Business",
            "Games and Hobbies",
            "News and Politics",
            "Religion and Spirituality",
            "Science and Medicine",
            "Other"
        };

        public static readonly string[] UpdateFrequencyUnits = new string[]
        {
            "Century",
            "Year",
            "Month",
            "Week",
            "Hour",
            "Minute",
            "Second"
        };

        string _name;
        string _url;
        string _category;
        int _updateFrequencyValue;
        string _updateFrequencyUnit;
        string _lastFetchedFeed;
        DateTime _lastUpdate;
        List<string> _actionIdentifiers;

        public RSSFeed()
        {

        }

        /// <summary>
        /// Constructor for the RSS feed model.
        /// </summary>
        /// <param name="name">Name of the RSS feed</param>
        /// <param name="url">URL to the RSS feed</param>
        /// <param name="updateFrequencyValue">Update frequency interval value</param>
        /// <param name="updateFrequencyUnit">Unit indicating how to interpret the frequency value</param>
        public RSSFeed(string name, string url, string category, int updateFrequencyValue, string updateFrequencyUnit)
        {
            _name = name;
            _url = url;
            _category = category;
            _updateFrequencyValue = updateFrequencyValue;
            _updateFrequencyUnit = updateFrequencyUnit;
            _lastFetchedFeed = "Still fetching..";
            _lastUpdate = DateTime.Now;
            _actionIdentifiers = new List<string>();
        }

        #region overrides        
        public override string GetXmlRepresentation()
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(RSSFeed));
            string xml = "";

            using (var sww = new Utf8StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, this);
                    xml = sww.ToString();
                }
            }
            return xml;
        }

        public override void Save()
        {
            // TODO see if needed to save from instance
        }
        #endregion

        #region getters and setters
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        public int UpdateFrequencyValue
        {
            get
            {
                return _updateFrequencyValue;
            }
            set
            {
                _updateFrequencyValue = value;
            }
        }

        public string UpdateFrequencyUnit
        {
            get
            {
                return _updateFrequencyUnit;
            }
            set
            {
                _updateFrequencyUnit = value;
            }
        }

        public DateTime LastUpdate
        {
            get
            {
                return _lastUpdate;
            }
            set
            {
                _lastUpdate = value;
            }
        }

        public string LastFetchedFeed
        {
            get
            {
                return _lastFetchedFeed;
            }
            set
            {
                _lastFetchedFeed = value;
            }
        }

        public List<string> ActionIdentifiers
        {
            get
            {
                return _actionIdentifiers;
            }
            set
            {
                _actionIdentifiers = value;
            }
        }
        #endregion
    }
}
