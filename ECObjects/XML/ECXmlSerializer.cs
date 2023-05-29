using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Instance;
using System.Xml;

namespace ECObjects.XML
{
    public abstract class ECXmlSerializer
    {
        public abstract bool CanDeserialize(Type type, XmlReader xmlReader);

        public abstract bool CanSerialize(object obj);

        public abstract void Deserialize(Type type, XmlReader xmlReader);

        public abstract void Serialize(object obj, XmlReader writer);
    }
}
