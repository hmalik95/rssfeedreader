using RSSFeedReader.logic.rssfeed;
using RSSFeedReader.logic.RSSFeedLogic;
using RSSFeedReader.Models;
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
    public partial class EditCategoriesPopup : Form
    {

        public EditCategoriesPopup()
        {
            InitializeComponent();
            PopulateView();
            SetListeners();
        }

        public void PopulateView()
        {

            List<string> categories = CategoryHandler.GetInstance.Categories;

            btnRemoveCategory.Enabled = true;
            btnEditCategory.Enabled = true;
            if (categories.Count() == 0)
            {
                btnRemoveCategory.Enabled = false;
                btnEditCategory.Enabled = false;
            }

            listBoxCategories.Items.Clear();
            foreach(string category in CategoryHandler.GetInstance.Categories)
            {
                listBoxCategories.Items.Add(category);
            }
        }

        void SetListeners()
        {
            btnAddCategory.Click += AddCategory;
            btnRemoveCategory.Click += RemoveCategory;
            btnEditCategory.Click += EditCategory;
        }

        void AddCategory(object sender, EventArgs e)
        {
            EnterCategoryPopup addCategoryPopup = new EnterCategoryPopup(EnterCategoryPopup.Mode.Add, this);
            addCategoryPopup.ShowDialog();
        }

        void RemoveCategory(object sender, EventArgs e)
        {
            bool success = CategoryHandler.GetInstance.RemoveCategory(listBoxCategories.SelectedIndex);
            if (!success)
            {
                MessageBox.Show("The category you want to delete is in use, remove the feeds that use this category first.");
            }
            PopulateView();
        }

        void EditCategory(object sender, EventArgs e)
        {
            EnterCategoryPopup editCategoryPopup = new EnterCategoryPopup(EnterCategoryPopup.Mode.Edit, this);
            editCategoryPopup.ShowDialog();
        }
    }
}
