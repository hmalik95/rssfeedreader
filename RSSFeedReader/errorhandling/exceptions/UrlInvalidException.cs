using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedReader.errorhandling.exceptions
{
    class UrlInvalidException : BaseException
    {
        public UrlInvalidException() : base()
        {
            _dialogErrorMsg = ConfigurationManager.AppSettings["UrlInvalidDialogError"];
        }
    }
}
