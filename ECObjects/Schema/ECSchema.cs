using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Schema;

namespace ECObjects.Schema
{
    public class ECSchema
    {
        private Dictionary<string, IECClass> m_classes;

        public ECSchema(string schemaName, int versionMajor, int versionMinor, string namespacePrefix)
        {
            this.m_classes = new Dictionary<string, IECClass>();
            this.DisplayLabel = string.Empty;
            this.Description = string.Empty;
            this.Name = schemaName;
            this.VersionMajor = versionMajor;
            this.VersionMinor = versionMinor;
            this.NamespacePrefix = namespacePrefix;
        }

        // Files

        public bool IsSupplemented { get; set; }
        public string FullName => $"{NamespacePrefix}-{Name}.{VersionMajor}.{VersionMinor}";
        public string NamespacePrefix { get; private set; }
        public int VersionMajor { get; private set; }
        public int VersionMinor { get; private set; }

        // INamed,IDescriped

        public string Name { get; private set; }
        public string DisplayLabel { get; private set; }
        public bool IsDisplayLabelDefined { get; private set; }
        public string Description { get; private set; }

        // Classes
        public int ClassCount => m_classes.Count;
    }
}
