using System.Xml;
using System.Xml.Linq;
using ECObjects.Abstract.Schema;
using ECObjects.Serialization.Extendable;

namespace ECObjects.Serialization
{
    internal class ExtendableXmlSerializer : ObjectXmlSerializer
    {
        private const string XmlElementExtendableObject = "ExtendedObject";
        private const string XmlElementExtendedData = "ExtendedData";
        private const string SerializationStackName = "SerializationStack";

        public override bool CanDeserialize(Type type, XmlReader xmlReader, ExtendedParameters? parameters)
        {
            throw new NotImplementedException();
        }

        public override bool CanSerialize(object obj, ExtendedParameters? parameters)
        {
            List<object> serializationStack = ExtendableXmlSerializer.GetSerializationStack(parameters);
            return obj is IExtendable &&
                obj.GetType().IsDefined(typeof(SerializeExtendedDataAttribute), true) &&
                (serializationStack == null || !serializationStack.Contains(obj));
        }

        public override object? Deserialize(Type type, XmlReader xmlReader, ExtendedParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override void Serialize(XmlWriter xmlWriter, ExtendedParameters parameters, object obj)
        {
            List<object> serializationStack = ExtendableXmlSerializer.GetSerializationStack(parameters);
            if (serializationStack != null)
            {
                serializationStack.Add(obj);
            }
            try
            {
                Dictionary<string, object> extendedData = ((IExtendable)obj).ExtendedData;
                int count = extendedData.Count;
                if (count > 0)
                {
                    xmlWriter.WriteStartElement(XmlElementExtendableObject, XmlSerializationConsts.Namespace);
                }
                DynamicXmlSerializer.Serialize(xmlWriter, parameters, obj);
                if (count > 0)
                {
                    xmlWriter.WriteStartElement(XmlElementExtendedData, XmlSerializationConsts.Namespace);
                    DynamicXmlSerializer.Serialize(xmlWriter, parameters, extendedData);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
            }
            finally
            {
                if (serializationStack != null)
                {
                    serializationStack.Remove(obj);
                }
            };
        }

        private static List<object> GetSerializationStack(ExtendedParameters? parameters)
        {
            List<object> list = new List<object>();
            if (parameters == null)
            {
                return list;
            }

            if (parameters.TryGetValue(SerializationStackName, out object? value) && value is List<object> listObj)
            {
                list = listObj;
            }
            else
            {
                ExtendableXmlSerializer.saveit(parameters, SerializationStackName, list);
            }
            return list;
        }

        private static void saveit(ExtendedParameters parameters, string name, object stack)
        {
            parameters[name] = stack;
        }
    }
}