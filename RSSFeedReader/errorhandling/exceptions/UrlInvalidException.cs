using System.Configuration;

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
