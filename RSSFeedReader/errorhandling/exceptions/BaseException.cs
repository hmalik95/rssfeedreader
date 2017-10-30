using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedReader.errorhandling.exceptions
{
    abstract class BaseException : Exception
    {
        protected string _dialogErrorMsg;

        public string DialogErrorMessage
        {
            get
            {
                return _dialogErrorMsg;
            }
        }
    }
}
