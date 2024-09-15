using System.Xml;
using ECObjects.Serialization.Extendable;

namespace ECObjects.Serialization
{
    internal class UnknownTypeSerializer : ObjectXmlSerializer
    {
        public override bool CanDeserialize(Type type, XmlReader xmlReader, ExtendedParameters? parameters)
        {
            throw new NotImplementedException();
        }

        public override bool CanSerialize(object obj, ExtendedParameters? parameters)
        {
            throw new NotImplementedException();
        }

        public override object? Deserialize(Type type, XmlReader xmlReader, ExtendedParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override void Serialize(XmlWriter xmlWriter, ExtendedParameters parameters, object obj)
        {
            throw new NotImplementedException();
        }
    }
}