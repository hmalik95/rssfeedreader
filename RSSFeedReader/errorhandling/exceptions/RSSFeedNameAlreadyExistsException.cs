using RSSFeedReader.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedReader.errorhandling.exceptions
{
    class RSSFeedNameAlreadyExistsException : BaseException
    {
        public RSSFeedNameAlreadyExistsException(string wrongInput) : base()
        {
            _dialogErrorMsg = ConfigurationManager.AppSettings["RSSFeedAlreadyExistsDialogError"];
            _dialogErrorMsg = string.Format(_dialogErrorMsg, wrongInput);
        }
    }
}
