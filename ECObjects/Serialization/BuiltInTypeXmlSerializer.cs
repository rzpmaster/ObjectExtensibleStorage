using System.Globalization;
using System.Xml;
using ECObjects.Serialization.Extendable;

namespace ECObjects.Serialization
{
    internal class BuiltInTypeXmlSerializer : ObjectXmlSerializer
    {
        private const string XmlElementSimpleType = "BuiltInType";
        private const string XmlAttributeTypeCode = "typeCode";

        public override bool CanDeserialize(Type type, XmlReader xmlReader, ExtendedParameters? parameters)
        {
            return xmlReader.GetAttribute(XmlAttributeTypeCode) != null;
        }

        public override bool CanSerialize(object obj, ExtendedParameters? parameters)
        {
            if (obj == null)
            {
                return false;
            }
            Type type = obj.GetType();
            if (type.IsEnum)
            {
                return false;
            }
            TypeCode typeCode = Type.GetTypeCode(type);
            return typeCode != TypeCode.DBNull && typeCode != TypeCode.Object && typeCode != TypeCode.Empty;
        }

        public override object? Deserialize(Type type, XmlReader xmlReader, ExtendedParameters parameters)
        {
            string? attribute = xmlReader.GetAttribute(XmlAttributeTypeCode);
            if (attribute == null)
            {
                return null;
            }
            TypeCode typeCode = (TypeCode)Enum.Parse(typeof(TypeCode), attribute, true);
            bool isEmptyElement = xmlReader.IsEmptyElement;
            xmlReader.ReadStartElement();
            string value = string.Empty;
            if (!isEmptyElement)
            {
                xmlReader.MoveToContent();
                value = xmlReader.ReadContentAsString();
                xmlReader.MoveToContent();
                xmlReader.ReadEndElement();
                xmlReader.MoveToContent();
            }
            return Convert.ChangeType(value, typeCode, CultureInfo.InvariantCulture);
        }

        public override void Serialize(XmlWriter xmlWriter, ExtendedParameters parameters, object obj)
        {
            this.Serialize(xmlWriter, parameters, XmlElementSimpleType, XmlSerializationConsts.Namespace, obj);
        }

        private void Serialize(XmlWriter xmlWriter, ExtendedParameters parameters, string elementName, string elementNamespace, object obj)
        {
            xmlWriter.WriteStartElement(elementName, elementNamespace);
            this.SerializeContent(xmlWriter, parameters, obj);
            xmlWriter.WriteEndElement();
        }

        private void SerializeContent(XmlWriter xmlWriter, ExtendedParameters parameters, object obj)
        {
            TypeCode typeCode = Type.GetTypeCode(obj.GetType());
            xmlWriter.WriteAttributeString(XmlAttributeTypeCode, Enum.GetName(typeof(TypeCode), typeCode));
            xmlWriter.WriteValue(obj);
        }
    }
}