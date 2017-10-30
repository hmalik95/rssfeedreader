using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedReader
{
    class Constants
    {
        public static string WORKING_DIRECTORY_PATH = ConfigurationManager.AppSettings["WorkingDirectory"];

        public static string RSSFEED_DIRECTORY = ConfigurationManager.AppSettings["RSSFeeds"];
    }
}
