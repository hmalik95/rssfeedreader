using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedReader.models
{

    class RSSFeedItem
    {
        string _title;
        string _summary;
        List<SyndicationLink> _links;

        public RSSFeedItem(string title, string summary, List<SyndicationLink> links)
        {
            _title = title;
            _summary = summary;
            _links = links;
        }

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public string Summary
        {
            get
            {
                return _summary;
            }
        }

        public List<SyndicationLink> Links
        {
            get
            {
                return _links;
            }
        }
    }
}
