using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeedReader.errorhandling.exceptions
{
    class UpdateFrequencyNotANumberException : BaseException
    {
        public UpdateFrequencyNotANumberException(string wrongInput) : base()
        {
            _dialogErrorMsg = ConfigurationManager.AppSettings["UpdateFrequenceDialogError"];
            _dialogErrorMsg = string.Format(_dialogErrorMsg, wrongInput);
        }
    }
}
