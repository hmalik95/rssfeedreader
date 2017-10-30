using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedReader.errorhandling
{
    class InputValidation
    {
        public static bool IsUrlValid(string url)
        {
            if (url == null)
            {
                return false;
            }

            try
            {
                Uri uriResult = new Uri(url);
                return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
            }
            catch
            {
                return false;
            }
        }
    }
}
