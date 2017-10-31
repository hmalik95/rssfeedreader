using RSSFeedReader.auxiliary;
using RSSFeedReader.errorhandling.exceptions;
using RSSFeedReader.Models;
using RSSFeedReader.network;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RSSFeedReader.logic.RSSFeedLogic
{
    class RSSFeedHandler
    {
        Dictionary<string, RSSFeed> _rssFeeds;
        string _rssFeedPath; 

        public Dictionary<string, RSSFeed> RSSFeeds
        {
            get
            {
                return _rssFeeds;
            }
        }

        public RSSFeedHandler()
        {
            _rssFeedPath = Path.Combine(Constants.WORKING_DIRECTORY, Constants.RSSFEED_DIRECTORY);
            LoadAllRSSFeeds();
        }

        public void AddNewRSSFeedAsync(string name, string url, string category, int updateFrequencyValue, string updateFrequencyUnit, Action onComplete = null)
        {

            if (FeedExists(name))
            {
                throw new RSSFeedNameAlreadyExistsException(name);
            }

            Task.Run(async () =>
            {
                RSSFeed rssFeed = new RSSFeed(name, url, category, updateFrequencyValue, updateFrequencyUnit);
                SyndicationFeed feed = await GetRSSFeedAsync(url);
                rssFeed.LastFetchedFeed = Util.Atom10ToXmlString(feed.GetAtom10Formatter());
                SaveRSSFeedToFile(rssFeed);
                onComplete?.Invoke();
            });
        }

        public string GetRSSFeedAsXmlSync(string url)
        {
            SyndicationFeed feed = GetRSSFeedSync(url);
            return Util.Atom10ToXmlString(feed.GetAtom10Formatter());
        }

        public SyndicationFeed GetRSSFeedSync(string url)
        {
            return RSSFeedRetrieval.GetRSSFeedByUrl(url).Result;
        }

        public async Task<SyndicationFeed> GetRSSFeedAsync(string url)
        {
            return await RSSFeedRetrieval.GetRSSFeedByUrl(url);
        }

        public void SaveRSSFeedToFile(RSSFeed rssFeed)
        {
            // Write each directory name to a file.
            using (StreamWriter sw = new StreamWriter(Path.Combine(_rssFeedPath, rssFeed.Name + ".xml")))
            {
                sw.WriteLine(rssFeed.GetXmlRepresentation());
            }
            _rssFeeds.Add(rssFeed.Name, rssFeed);
        }

        void LoadAllRSSFeeds()
        {
            _rssFeeds = new Dictionary<string, RSSFeed>();

            string[] allRSSFeedPaths = Directory.GetFiles(_rssFeedPath);
            foreach (string path in allRSSFeedPaths)
            {
                string fileName = Path.GetFileName(path);
                if (!fileName.ToLower().Contains(".xml"))
                {
                    continue;
                }

                RSSFeed feed;
                XmlSerializer mySerializer = new XmlSerializer(typeof(RSSFeed));
                using (FileStream myFileStream = new FileStream(path, FileMode.Open))
                {
                    feed = (RSSFeed)mySerializer.Deserialize(myFileStream);
                    _rssFeeds.Add(feed.Name, feed);

                }
            }
        }
        
        public void DeleteFeed(RSSFeed feed, Action onCompleted = null)
        {
            string path = Path.Combine(_rssFeedPath, feed.Name + ".xml");
            File.Delete(path);
            _rssFeeds.Remove(feed.Name);
            onCompleted?.Invoke();
        }

        bool FeedExists(string name)
        {
            if (!Directory.Exists(_rssFeedPath))
            {
                Directory.CreateDirectory(_rssFeedPath);
            }

            string[] allRSSFeedPaths = Directory.GetFiles(_rssFeedPath);

            foreach (string path in allRSSFeedPaths)
            {
                if (string.Equals(Path.GetFileName(path).Split('.')[0].ToLower(), name.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
