using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedReader.errorhandling.exceptions
{

    class UrlInvalidException : Exception
    {
        string _dialogErrorMsg;

        public UrlInvalidException() : base()
        {
            _dialogErrorMsg = ConfigurationManager.AppSettings["UrlInvalidDialogError"];
        }

        public string DialogErrorMsg
        {
            get
            {
                return _dialogErrorMsg;
            }
        }
    }
}
