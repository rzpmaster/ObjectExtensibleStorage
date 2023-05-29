using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Schema;
using System.Xml;
using System.Collections;
using ECObjects.Abstract.Common;

namespace ECObjects.XML
{
    public class ECSchemaXmlWriter
    {
        public bool Indented { get; set; } = true;

        public void Serialize(XmlWriter writer, IECSchema schema)
        {
            this.Serialize(writer, schema, true);
        }

        public void Serialize(XmlWriter writer, IECSchema schema, bool writeDocument)
        {
            var alreadySerializedClasses = new Dictionary<string, IECClass>();
            var classes = schema.GetClasses();
            Array.Sort(classes, new ClassNameComparer());

        }
    }

    internal class ClassNameComparer : IComparer<INamed>
    {
        public int Compare(INamed? x, INamed? y)
        {
            if (x == null || y == null) return 0;
            return string.Compare(x.Name, y.Name, StringComparison.InvariantCulture);
        }
    }
}
