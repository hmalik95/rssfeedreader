using RSSFeedReader.logic.rssfeed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSFeedReader.ui
{
    public partial class EnterCategoryPopup : Form
    {
        public enum Mode
        {
            Add,
            Edit
        }

        private Mode _mode;
        private EditCategoriesPopup _mainView;

        public EnterCategoryPopup(Mode mode, EditCategoriesPopup mainView)
        {
            InitializeComponent();
            _mode = mode;
            _mainView = mainView;
            SetListeners();
        }

        void SetListeners()
        {
            btnCancel.Click += delegate
            {
                Close();
            };

            if (_mode == Mode.Add)
            {
                btnConfirm.Click += AddCategory;
            }
            else
            {
                btnConfirm.Click += EditCategory;
            }
        }

        void AddCategory(object sender, EventArgs args)
        {
            string category = tbEnteredCategory.Text;
            bool success = CategoryHandler.GetInstance.AddCategory(category);
            if (!success)
            {
                MessageBox.Show("Category already exists.");
            }
            _mainView.PopulateView();
            Close();
        }

        void EditCategory(object sender, EventArgs args)
        {
            string edittedValue = tbEnteredCategory.Text;
            string category = CategoryHandler.GetInstance.Categories[_mainView.listBoxCategories.SelectedIndex];
            bool success = CategoryHandler.GetInstance.EditCategory(category, edittedValue);
            if (!success)
            {
                MessageBox.Show("Category already exists.");
            }
            _mainView.PopulateView();
            Close();
        }
    }
}
