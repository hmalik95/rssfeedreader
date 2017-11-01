using RSSFeedReader.auxiliary;
using RSSFeedReader.errorhandling;
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
        string _id;
        List<SyndicationLink> _links;


        public RSSFeedItem(string title, string summary, string id, List<SyndicationLink> links)
        {
            _title = title;
            _summary = summary;
            _links = links;
            _id = id;
        }

        private string _htmlTemplate = "<H1>{0}</H1>\n\n{1}\n\n";
        public string GetHtmlRepresentation()
        {
            string links = "";
            
            foreach(SyndicationLink link in Links)
            {
                long buffer;


                string htmlLink = $"<a href=\"{link.Uri}\"";
                if (!InputValidation.IsStringEmpty(link.MediaType))
                {
                    htmlLink += string.Format(" mediatype=\"{0}\"", link.MediaType);
                }
                if (long.TryParse(link.Length + "", out buffer))
                {
                    htmlLink += string.Format(" length=\"{0}\"", link.Length);
                }
                if (!InputValidation.IsStringEmpty(link.RelationshipType))
                {
                    htmlLink += string.Format(" rel=\"{0}\"", link.RelationshipType);
                }
                htmlLink = htmlLink + ">" + (link.Title == null ? link.Uri.ToString() : link.Title) +"</a>";
                links += htmlLink + "\n";
            }

            return string.Format(_htmlTemplate, Title, Summary) + (_links.Count() > 0 ? "<br><b>Links</b><br>" + links : "");
        }

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public string Id
        {
            get
            {
                return _id;
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
