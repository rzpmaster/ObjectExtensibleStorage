using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ECObjects.Abstract;
using ECObjects.Abstract.Schema;

namespace ECObjects.XML
{
    public class ECSchemaXmlSerializer : ECXmlSerializer
    {
        public override bool CanDeserialize(Type type, XmlReader xmlReader)
        {
            throw new NotImplementedException();
        }

        public override bool CanSerialize(object obj)
        {
            return obj is IECSchema;
        }

        public override void Deserialize(Type type, XmlReader xmlReader)
        {
            throw new NotImplementedException();
        }

        public override void Serialize(object obj, XmlReader writer)
        {
            throw new NotImplementedException();
        }
    }
}
