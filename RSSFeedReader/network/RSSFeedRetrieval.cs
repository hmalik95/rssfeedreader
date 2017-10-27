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
            await Task.Factory.StartNew(() => {
                using (XmlReader r = XmlReader.Create(url))
                {
                    Constants.Log("Fetching feed for: " + url);

                    SyndicationFeed feed = SyndicationFeed.Load(r);
                    
                    foreach(SyndicationItem item in feed.Items)
                    {
                        Constants.Log("----------------------------\nItem title: " + item.Title.Text + "\nCategories:");
                        foreach(SyndicationCategory category in item.Categories)
                        {
                            Constants.Log(category.Label);
                            Constants.Log(category.Name);
                            Constants.Log(category.Scheme);
                        }
                    }

                    return feed;
                }
            });

            return null;
        }
    }
}
