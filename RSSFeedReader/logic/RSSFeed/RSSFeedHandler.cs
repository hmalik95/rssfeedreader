using RSSFeedReader.errorhandling.exceptions;
using RSSFeedReader.Models;
using RSSFeedReader.network;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void AddNewRSSFeed(string name, string url, string category, int updateFrequencyValue, string updateFrequencyUnit)
        {
            string rssFeedPath = Path.Combine(Constants.WORKING_DIRECTORY, Constants.RSSFEED_DIRECTORY);
            if (!Directory.Exists(rssFeedPath))
            {
                Directory.CreateDirectory(rssFeedPath);
            }

            string[] allRSSFeedPaths = Directory.GetFiles(rssFeedPath);

            foreach(string path in allRSSFeedPaths)
            {
                if (string.Equals(Path.GetFileName(path).Split('.')[0].ToLower(), name.ToLower()))
                {
                    throw new RSSFeedNameAlreadyExistsException(name);
                }
            }


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
