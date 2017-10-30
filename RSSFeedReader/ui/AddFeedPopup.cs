using RSSFeedReader.Models;
using System;
using System.Windows.Forms;

namespace RSSFeedReader.ui
{
    public partial class AddFeedPopup : Form
    {
        string _feedName;
        string _feedUrl;
        string _feedCategory;
        string _feedUpdateFrequencyUnit;
        string _feedUpdateFrequencyValue;

        public AddFeedPopup()
        {
            InitializeComponent();
            SetListeners();
            PopulateViews();
        }

        void PopulateViews()
        {
            cbCategory.Items.AddRange(RSSFeed.Categories);
            cbCategory.SelectedIndex = 0;
            cbUpdateFrequency.Items.AddRange(RSSFeed.UpdateFrequencyUnits);
            cbUpdateFrequency.SelectedIndex = 0;
        }

        #region getters and setters
        public string FeedName
        {
            get
            {
                return _feedName;
            }
        }

        public string FeedUrl
        {
            get
            {
                return _feedUrl;
            }
        }

        public string FeedCategory
        {
            get
            {
                return _feedCategory;
            }
        }

        public string FeedUpdateFrequencyUnit
        {
            get
            {
                return _feedUpdateFrequencyUnit;
            }
        }
        public string FeedUpdateFrequencyValue
        {
            get
            {
                return _feedUpdateFrequencyValue;
            }
        }
       
        #endregion

        #region event listeners
        void SetListeners()
        {
            btnConfirmAddFeed.Click += ConfirmAddFeed;
            btnCancelFeedAdd.Click += CancelFeedAdd;
        }

        void ConfirmAddFeed(object sender, EventArgs args)
        {
            _feedName = tbFeedName.Text;
            _feedUrl = tbFeedUrl.Text;
            _feedCategory = (string) cbCategory.Items[cbCategory.SelectedIndex];
            _feedUpdateFrequencyUnit = (string) cbUpdateFrequency.Items[cbCategory.SelectedIndex];
            _feedUpdateFrequencyValue = tbUpdateFrequency.Text;
            DialogResult = DialogResult.OK;
        }

        void CancelFeedAdd(object sender, EventArgs args)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion event listeners
    }
}
