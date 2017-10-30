using RSSFeedReader.auxiliary;
using RSSFeedReader.errorhandling;
using RSSFeedReader.errorhandling.exceptions;
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
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
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

        void AddNewFeed(object sender, EventArgs e)
        {
            try {
                using (AddFeedPopup addFeedPopup = new AddFeedPopup())
                {
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
                    string feedUpdateFrequencyValue = addFeedPopup.FeedUpdateFrequencyValue;
                    string feedUpdateFrequencyUnit = addFeedPopup.FeedUpdateFrequencyUnit;
                    if (!InputValidation.IsUrlValid(feedUrl))
                    {
                        throw new UrlInvalidException();
                    }
                    // TODO implement feed adding in handler
                }
            }
            catch (UrlInvalidException ex)
            {
                MessageBox.Show(ex.DialogErrorMsg);
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
