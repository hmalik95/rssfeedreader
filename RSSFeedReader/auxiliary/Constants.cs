using System.Configuration;
using System.IO;

namespace RSSFeedReader
{
    class Constants
    {
        public static string RSSFEED_DIRECTORY = ConfigurationManager.AppSettings["RSSFeedDirectory"];
        public static string CATEGORY_FILE_NAME = ConfigurationManager.AppSettings["CategoryFileName"];
        public static string WORKING_DIRECTORY = Directory.GetCurrentDirectory();
    }
}
