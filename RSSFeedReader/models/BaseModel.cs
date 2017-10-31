using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RSSFeedReader.models
{

    public abstract class BaseModel
    {
        DateTime _creationDate;

        public BaseModel()
        {
            _creationDate = DateTime.Now;
        }

        public DateTime CreationDate
        {
            get
            {
                return _creationDate;
            }
        }

        abstract public string GetXmlRepresentation();
        
        abstract public void Save();
    }
}
