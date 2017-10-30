using RSSFeedReader.auxiliary;
using RSSFeedReader.errorhandling;
using RSSFeedReader.errorhandling.exceptions;
using RSSFeedReader.logic.RSSFeedLogic;
using RSSFeedReader.ui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSFeedReader
{
    public partial class MainView : Form
    {
        RSSFeedHandler _rssFeedHandler;

        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            _rssFeedHandler = new RSSFeedHandler();
            PopulateViews();
            SetListeners();
        }

        #region instantiation
        void PopulateViews()
        {
            SetFeeds();
        }

        void SetListeners()
        {
            exitToolStripMenuItem.Click += Close;
            addNewFeedToolStripMenuItem.Click += AddNewFeed;
            btnEdit.Click += EditSelectedFeed;
            btnDelete.Click += DeleteSelectedFeed;
        }

        void SetFeeds()
        {

        }
        #endregion

        #region event listeners
        void Close(object sender, EventArgs e)
        {
            Close();
        }

        AddFeedPopup addFeedPopup = null;
        void AddNewFeed(object sender, EventArgs e)
        {
            try {
                if (addFeedPopup == null)
                {
                    addFeedPopup = new AddFeedPopup();
                }
                using (addFeedPopup)
                {
                    addFeedPopup.Reuse = true;
                    addFeedPopup.ShowDialog();
                    // If the cancel button was used we stop
                    if (addFeedPopup.DialogResult == DialogResult.Cancel)
                    {
                        addFeedPopup.Close();
                        return;
                    }

                    // Else continue and handle adding of new rss feed
                    string feedName = addFeedPopup.FeedName;
                    string feedUrl = addFeedPopup.FeedUrl;
                    string feedCategory = addFeedPopup.FeedCategory;

                    // Try and parse the entered frequency value
                    int feedUpdateFrequencyValue;
                    string feedUpdateFrequencyValueStr = addFeedPopup.FeedUpdateFrequencyValue;
                    if (!int.TryParse(feedUpdateFrequencyValueStr, 
                        out feedUpdateFrequencyValue))
                    {
                        throw new UpdateFrequencyNotANumberException(feedUpdateFrequencyValueStr);
                    }

                    // Check validity of entered url
                    string feedUpdateFrequencyUnit = addFeedPopup.FeedUpdateFrequencyUnit;
                    if (!InputValidation.IsUrlValid(feedUrl))
                    {
                        
                        throw new UrlInvalidException();
                    }
                    _rssFeedHandler.AddNewRSSFeed(feedName, feedUrl, feedCategory, feedUpdateFrequencyValue, feedUpdateFrequencyValueStr);
                    addFeedPopup.Reuse = false;
                    addFeedPopup = null;
                }
            }
            catch (BaseException ex)
            {
                addFeedPopup.Reuse = true;
                MessageBox.Show(ex.DialogErrorMessage);
                AddNewFeed(sender, e);
            }
        }

        void EditSelectedFeed(object sender, EventArgs e)
        {

        }

        void DeleteSelectedFeed(object sender, EventArgs e)
        {

        }
        #endregion

        #region data manipulation

        #endregion
    }
}
