using RSSFeedReader.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedReader.Models
{
    /// <summary>
    /// Class representing a model for the rss feed
    /// </summary>
    class RSSFeed
    {
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
        RSSFeedHistory _rssFeedHistory;
        int _updateFrequencyValue;
        UpdateFrequencyUnit _updateFrequencyUnit;


        /// <summary>
        /// Constructor for the RSS feed model.
        /// </summary>
        /// <param name="name">Name of the RSS feed</param>
        /// <param name="url">URL to the RSS feed</param>
        /// <param name="updateFrequencyValue">Update frequency interval value</param>
        /// <param name="updateFrequencyUnit">Unit indicating how to interpret the frequency value</param>
        public RSSFeed(string name, string url, int updateFrequencyValue, UpdateFrequencyUnit updateFrequencyUnit)
        {
            _name = name;
            _url = url;
            _rssFeedHistory = new RSSFeedHistory();
            _updateFrequencyValue = updateFrequencyValue;
            _updateFrequencyUnit = updateFrequencyUnit;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Url
        {
            get
            {
                return _url;
            }
        }

        public enum UpdateFrequencyUnit
        {
            Century,
            Year,
            Month,
            Week,
            Hour,
            Minute,
            Second
        }

    }
}
