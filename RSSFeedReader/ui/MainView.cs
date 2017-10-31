using RSSFeedReader.auxiliary;
using RSSFeedReader.errorhandling;
using RSSFeedReader.errorhandling.exceptions;
using RSSFeedReader.logic.rssfeed;
using RSSFeedReader.logic.RSSFeedLogic;
using RSSFeedReader.models;
using RSSFeedReader.Models;
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
        List<RSSFeedItem> _currentRssFeedItems;

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

        #region instantiation and refresh
        void PopulateViews()
        {
            SetFeeds();
            if (_rssFeedHandler.RSSFeeds.Count() > 0)
            {
                ShowFeed(0);
            }
        }

        void SetListeners()
        {
            exitToolStripMenuItem.Click += Close;
            addNewFeedToolStripMenuItem.Click += AddNewFeed;
            btnEdit.Click += EditSelectedFeed;
            btnDelete.Click += DeleteSelectedFeed;
            lstBoxFeed.Click += SelectFeedToDisplay;
            lstBoxFeedItems.Click += ShowRSSFeedItemDetails;
        }

        void SetFeeds()
        {
            lstBoxFeed.Items.Clear();
            foreach(string feedName in _rssFeedHandler.RSSFeeds.Keys)
            {
                lstBoxFeed.Items.Add(feedName);
            }
        }

        void RefreshFeedToLastItem()
        {
            this.Invoke(new Action(() => {
                SetFeeds();
                ShowFeed(_rssFeedHandler.RSSFeeds.Count() - 1);
            }));
        }

        void ShowFeed(int index)
        {
            if (_rssFeedHandler.RSSFeeds.Count() < 1)
            {
                rssFeedTextBox.Text = "No feeds";
                return;
            }
            lstBoxFeed.SelectedIndex = index;
            RSSFeed rssFeed = GetSelectedFeed();
            rssFeedTextBox.Text = rssFeed.LastFetchedFeed;
            _currentRssFeedItems = RSSFeedXmlDataParser.GetRSSFeedItems(rssFeed.LastFetchedFeed);
            SetRSSFeedItems();
        }

        void ShowRSSFeedItemDetails(object sender, EventArgs e)
        {
            int selectedIndex = lstBoxFeedItems.SelectedIndex;
            RSSFeedItem rssFeedItem = _currentRssFeedItems[selectedIndex];
            rssFeedTextBox.Text = rssFeedItem.Summary;
        }

        void SetRSSFeedItems()
        {
            foreach(RSSFeedItem item in _currentRssFeedItems)
            {
                lstBoxFeedItems.Items.Add(item.Title);
            }
        }
        #endregion

        #region event listeners
        void SelectFeedToDisplay(object sender, EventArgs e)
        {
            int selectedIndex = ((ListBox)sender).SelectedIndex;
            ShowFeed(selectedIndex);
        }

        void Close(object sender, EventArgs e)
        {
            Close();
        }

        AddFeedPopup _addFeedPopup = null;
        void AddNewFeed(object sender, EventArgs e)
        {
            try {
                if (_addFeedPopup == null)
                {
                    _addFeedPopup = new AddFeedPopup();
                }
                using (_addFeedPopup)
                {
                    _addFeedPopup.Reuse = true;
                    _addFeedPopup.ShowDialog();
                    // If the cancel button was used we stop
                    if (_addFeedPopup.DialogResult == DialogResult.Cancel)
                    {
                        _addFeedPopup.Close();
                        return;
                    }

                    // Else continue and handle adding of new rss feed
                    string feedName = _addFeedPopup.FeedName;
                    string feedUrl = _addFeedPopup.FeedUrl;
                    string feedCategory = _addFeedPopup.FeedCategory;

                    // Check validity of entered url
                    string feedUpdateFrequencyUnit = _addFeedPopup.FeedUpdateFrequencyUnit;
                    if (!InputValidation.IsUrlValid(feedUrl))
                    {

                        throw new UrlInvalidException();
                    }

                    // Try and parse the entered frequency value
                    int feedUpdateFrequencyValue;
                    string feedUpdateFrequencyValueStr = _addFeedPopup.FeedUpdateFrequencyValue;
                    if (!int.TryParse(feedUpdateFrequencyValueStr, 
                        out feedUpdateFrequencyValue))
                    {
                        throw new UpdateFrequencyNotANumberException(feedUpdateFrequencyValueStr);
                    }

                    _rssFeedHandler.AddNewRSSFeedAsync(feedName, feedUrl, feedCategory, feedUpdateFrequencyValue, feedUpdateFrequencyUnit, RefreshFeedToLastItem);
                    _addFeedPopup.Reuse = false;
                    _addFeedPopup = null;
                }
            }
            catch (BaseException ex)
            {
                _addFeedPopup.Reuse = true;
                MessageBox.Show(ex.DialogErrorMessage);
                AddNewFeed(sender, e);
            }
        }

        void EditSelectedFeed(object sender, EventArgs e)
        {

        }

        void DeleteSelectedFeed(object sender, EventArgs e)
        {
            if (_rssFeedHandler.RSSFeeds.Count() < 1)
            {
                return;
            }
            RSSFeed feed = GetSelectedFeed();
            _rssFeedHandler.DeleteFeed(feed, RefreshFeedToLastItem);
        }
        #endregion

        #region helpers functions
        RSSFeed GetSelectedFeed()
        {
            string feedName = lstBoxFeed.SelectedItem.ToString();
            return _rssFeedHandler.RSSFeeds[feedName];
        }
        #endregion
    }
}
