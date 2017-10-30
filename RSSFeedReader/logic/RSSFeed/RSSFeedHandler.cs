using RSSFeedReader.Models;
using RSSFeedReader.network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using static RSSFeedReader.Models.RSSFeed;

namespace RSSFeedReader.logic.RSSFeedLogic
{
    class RSSFeedHandler
    {

        public RSSFeedHandler()
        {

        }

        public RSSFeed GetRSSFeed(string name, string url = null, int updateFrequencyValue = -1, UpdateFrequencyUnit updateFrequencyUnit = UpdateFrequencyUnit.Second)
        {

            if (FeedExists(name))
            {
                return ReadFeedFromFile(name);
            } 
            else if (url != null && updateFrequencyValue != -1)
            {
                return new RSSFeed(name, url, updateFrequencyValue, updateFrequencyUnit);
            }

            throw new ArgumentException(string.Format("Feed '{0}' does not exist in local storage", name));
        }

        public SyndicationFeed GetRSSFeedSync(string url)
        {
            return RSSFeedRetrieval.GetRSSFeedByUrl(url).Result;
        }

        public async Task<SyndicationFeed> GetRSSFeedAsync(string url)
        {
            return await RSSFeedRetrieval.GetRSSFeedByUrl(url);
        }

        RSSFeed ReadFeedFromFile(string name)
        {

            return null;
        }

        bool FeedExists(string name)
        {


            return false;
        }

    }


}
