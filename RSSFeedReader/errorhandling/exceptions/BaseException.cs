using System;

namespace RSSFeedReader.errorhandling.exceptions
{
    abstract class BaseException : Exception
    {
        internal string _dialogErrorMsg;

        public string DialogErrorMessage
        {
            get
            {
                return _dialogErrorMsg;
            }
        }

        public virtual void PostExceptionAction(object o)
        {
            Console.WriteLine(_dialogErrorMsg);
        }
    }
}
