using RSSFeedReader.logic.rssfeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSFeedReader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            Test();
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }

        static void Test()
        {
            Constants.Log("Debug build enabled", "Running a couple of tests");
            RSSFeedHandler rssFeedHandler = new RSSFeedHandler();
            rssFeedHandler.GetRSSFeedAsync("https://atwar.blogs.nytimes.com/feed/");
            rssFeedHandler.GetRSSFeedAsync("https://rss.acast.com/sparpodcast");
        }
    }
}
