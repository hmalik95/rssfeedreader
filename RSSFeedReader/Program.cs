using RSSFeedReader.auxiliary;
using RSSFeedReader.logic.RSSFeedLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
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
            //Test();
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }

        static async void Test()
        {
            Util.Log("Debug build enabled", "Running a couple of tests");
            RSSFeedHandler rssFeedHandler = new RSSFeedHandler();
            SyndicationFeed feed1 = await rssFeedHandler.GetRSSFeedAsync("https://rss.acast.com/sparpodcast");
            Util.Log(Util.Atom10ToJsonString(feed1.GetAtom10Formatter()));
        }
    }
}
