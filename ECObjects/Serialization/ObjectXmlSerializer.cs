using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ECObjects.Serialization.Extendable;

namespace ECObjects.Serialization
{
    public abstract class ObjectXmlSerializer
    {
        public abstract bool CanSerialize(object obj, ExtendedParameters? parameters);

        public abstract void Serialize(XmlWriter xmlWriter, ExtendedParameters parameters, object obj);

        public abstract bool CanDeserialize(Type type, XmlReader xmlReader, ExtendedParameters? parameters);

        public abstract object? Deserialize(Type type, XmlReader xmlReader, ExtendedParameters parameters);
    }
}
