using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ECObjects.Serialization.Extendable;

namespace ECObjects.Serialization
{
    internal class NullObjectXmlSerializer : ObjectXmlSerializer
    {
        private const string XmlElementNullReference = "NullReference";

        public override bool CanDeserialize(Type type, XmlReader xmlReader, ExtendedParameters? parameters)
        {
            return type == null && xmlReader.IsStartElement(XmlElementNullReference, XmlSerializationConsts.Namespace);
        }

        public override bool CanSerialize(object obj, ExtendedParameters? parameters)
        {
            return obj == null;
        }

        public override object? Deserialize(Type type, XmlReader xmlReader, ExtendedParameters parameters)
        {
            xmlReader.Skip();
            return null;
        }

        public override void Serialize(XmlWriter xmlWriter, ExtendedParameters parameters, object obj)
        {
            xmlWriter.WriteStartElement(XmlElementNullReference, XmlSerializationConsts.Namespace);
            xmlWriter.WriteEndElement();
        }
    }
}
