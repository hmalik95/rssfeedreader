using RSSFeedReader.logic.RSSFeedLogic;
using RSSFeedReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedReader.logic.rssfeed
{
    class CategoryHandler
    {

        private static CategoryHandler _instance;
        private static object _lockObject = new object();

        private List<string> _categories;
        private string _filePath;

        private CategoryHandler()
        {
            _filePath = Path.Combine(Constants.WORKING_DIRECTORY, Constants.CATEGORY_FILE_NAME);
            _categories = LoadCategories();
        }

        public static CategoryHandler GetInstance
        {
            get
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new CategoryHandler();
                    }
                    return _instance;
                }
            }
        }

        public List<string> Categories
        {
            get
            {
                return _categories;
            }
        }

        public bool AddCategory(string categoryToAdd)
        {
            foreach(string category in _categories)
            {
                if (string.Equals(category.ToLower(), categoryToAdd.ToLower())){
                    return false;
                }
            }
            _categories.Add(categoryToAdd);
            SaveCategories();
            return true;
        }

        public bool RemoveCategory(int index)
        {
            string category = _categories[index];
            foreach (RSSFeed feed in RSSFeedHandler.GetInstance.RSSFeeds.Values)
            {
                if (string.Equals(feed.Category, category))
                {
                    return false;
                }
            }
            _categories.Remove(_categories[index]);
            SaveCategories();
            return true;
        }

        public bool EditCategory(string category, string edittedValue)
        {

            int index = 0;
            for (int i = 0; i < _categories.Count(); i++)
            {
                string c = _categories[i];
                if (string.Equals(c.ToLower(), edittedValue.ToLower()))
                {
                    return false;
                }
                if (string.Equals(c, category))
                {
                    index = i;
                }
            }
            _categories[index] = edittedValue;
            SaveCategories();
            return true;
        }

        private void SaveCategories()
        {
            string categoriesCSV = string.Join(",", _categories);
            File.WriteAllText(_filePath, categoriesCSV);
        }

        private List<string> LoadCategories()
        {
            if (!File.Exists(_filePath))
            {
                using (var myFile = File.Create(_filePath))
                {
                    // let it dispose
                }

                return new List<string>();
            }
            string[] categoriesArray;
            List<string> categories;
            using (StreamReader sr = new StreamReader(_filePath))
            {
                string categoryString = sr.ReadToEnd();
                if (string.IsNullOrEmpty(categoryString) || string.IsNullOrWhiteSpace(categoryString))
                {
                    categories = new List<string>();
                } 
                else
                {
                    categoriesArray = categoryString.Split(',');
                    categories = categoriesArray.ToList();
                }
                
            }

            return categories;
        }
    }
}
