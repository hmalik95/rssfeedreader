
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;

namespace RSSFeedReader.auxiliary
{
    class Util
    {

        public static string Atom10ToJsonString(Atom10FeedFormatter feed)
        {
            XmlDocument xmlRep = new XmlDocument();
            xmlRep.LoadXml(Atom10ToXmlString(feed));
            return JsonConvert.SerializeXmlNode(xmlRep);
        }

        public static string Atom10ToXmlString(Atom10FeedFormatter feed)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter xw = XmlWriter.Create(sw))
                {
                    feed.WriteTo(xw);
                }
                return sw.ToString(); 
            }
        }

        public static void Log(params string[] msgs)
        {
#if DEBUG
            foreach (string msg in msgs)
            {
                Console.WriteLine(msg); 
            }
#endif
        }
    }
}
