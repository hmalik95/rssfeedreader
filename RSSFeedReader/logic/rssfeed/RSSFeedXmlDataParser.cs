using RSSFeedReader.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RSSFeedReader.logic.rssfeed
{
    class RSSFeedXmlDataParser
    {

        public static List<RSSFeedItem> GetRSSFeedItems(string rssFeedXml)
        {
            List<RSSFeedItem> rssFeedItems = new List<RSSFeedItem>();

            TextReader tr = new StringReader(rssFeedXml);
            XmlReader xmlReader = XmlReader.Create(tr);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            foreach(SyndicationItem item in feed.Items)
            {
                string title = item.Title.Text;
                string summary = item.Summary.Text;
                List<SyndicationLink> links = item.Links.ToList();
                RSSFeedItem rssFeedItem = new RSSFeedItem(title, summary, links);
                rssFeedItems.Add(rssFeedItem);
            }

            return rssFeedItems;
        }
    }
}
