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
        List<RSSFeedItem> _currentRssFeedItems;

        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            PopulateViews();
            SetListeners();
        }

        #region instantiation and refresh
        void PopulateViews()
        {
            SetFeeds();
            SetFilters();
            if (RSSFeedHandler.GetInstance.RSSFeeds.Count() > 0)
            {
                ShowFeed(0);
            }
        }

        void SetFilters()
        {
            cbFeedCategoryFilter.Items.Clear();
            cbFeedCategoryFilter.Items.Add("All");
            cbFeedCategoryFilter.Items.AddRange(RSSFeed.Categories);
            cbFeedCategoryFilter.Items.AddRange(CategoryHandler.GetInstance.Categories.ToArray());
            cbFeedCategoryFilter.SelectedIndex = 0;
        }

        void SetListeners()
        {
            exitToolStripMenuItem.Click += Close;
            addNewFeedToolStripMenuItem.Click += AddNewFeed;
            toolStripMenuItemEditCategories.Click += EditCategories;
            btnDelete.Click += DeleteSelectedFeed;
            lstBoxFeed.Click += SelectFeedToDisplay;
            lstBoxFeedItems.Click += ShowRSSFeedItemDetails;
            cbFeedCategoryFilter.SelectionChangeCommitted += FilterFeeds;
        }

        void SetFeeds()
        {
            lstBoxFeed.Items.Clear();
            foreach(RSSFeed feed in RSSFeedHandler.GetInstance.RSSFeeds.Values)
            {
                lstBoxFeed.Items.Add(string.Format("{0} ({1})", feed.Name, feed.Category));
            }
        }

        void SetFeeds(List<RSSFeed> feeds)
        {
            lstBoxFeed.Items.Clear();
            foreach (RSSFeed feed in feeds)
            {
                lstBoxFeed.Items.Add(string.Format("{0} ({1})", feed.Name, feed.Category));
            }
        }

        void RefreshFeedToLastItem()
        {
            this.Invoke(new Action(() => {
                SetFeeds();
                ShowFeed(RSSFeedHandler.GetInstance.RSSFeeds.Count() - 1);
            }));
        }

        void ShowFeed(int index)
        {
            if (RSSFeedHandler.GetInstance.RSSFeeds.Count() < 1)
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
            lstBoxFeedItems.Items.Clear();
            foreach(RSSFeedItem item in _currentRssFeedItems)
            {
                lstBoxFeedItems.Items.Add(item.Title);
            }
        }
        #endregion

        #region event listeners
        void FilterFeeds(object sender, EventArgs e)
        {
            string category = cbFeedCategoryFilter.SelectedItem.ToString();

            if (string.Equals(category, "All"))
            {
                SetFeeds(RSSFeedHandler.GetInstance.RSSFeeds.Values.ToList());
                return;
            }

            List<RSSFeed> filteredFeedList = RSSFeedHandler.GetInstance.RSSFeeds.Values.Where<RSSFeed>(x => string.Equals(x.Category, category)).ToList();
            SetFeeds(filteredFeedList);
        }

        void EditCategories(object sender, EventArgs e)
        {
            using (EditCategoriesPopup popup = new EditCategoriesPopup())
            {
                popup.ShowDialog();
            }
            SetFilters();
        }

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
                else
                {
                    _addFeedPopup.RefreshCategories();
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

                    RSSFeedHandler.GetInstance.AddNewRSSFeedAsync(feedName, feedUrl, feedCategory, feedUpdateFrequencyValue, feedUpdateFrequencyUnit, RefreshFeedToLastItem);
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

        void DeleteSelectedFeed(object sender, EventArgs e)
        {
            if (RSSFeedHandler.GetInstance.RSSFeeds.Count() < 1)
            {
                return;
            }
            RSSFeed feed = GetSelectedFeed();
            RSSFeedHandler.GetInstance.DeleteFeed(feed, RefreshFeedToLastItem);
        }
        #endregion

        #region helpers functions
        RSSFeed GetSelectedFeed()
        {
            return RSSFeedHandler.GetInstance.RSSFeeds[lstBoxFeed.SelectedItem.ToString().Split('(')[0].Trim()];
        }
        #endregion
    }
}
