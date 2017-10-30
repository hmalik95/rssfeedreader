using RSSFeedReader.logic.RSSFeedLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSSFeedReader.network
{
    class RSSFeedRetrieval
    {

        public static async Task<SyndicationFeed> GetRSSFeedByUrl(string url)
        {
            SyndicationFeed feed = null;
            await Task.Factory.StartNew(() => {
                using (XmlReader r = new CustomXmlReader(url))
                {
                    feed = SyndicationFeed.Load(r);
                    return feed;
                }
            });
            return feed;
        }
    }
}
