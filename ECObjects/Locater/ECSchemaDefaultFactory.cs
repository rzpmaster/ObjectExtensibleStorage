using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Locater;
using ECObjects.Abstract.Schema;
using ECObjects.Abstract.Schema.ECType;
using ECObjects.Schema;

namespace ECObjects.Locater
{
    public class ECSchemaDefaultFactory : IECSchemaFactory
    {
        public virtual IECSchema CreateSchema(string schemaName, int versionMajor, int versionMinor, string nameSpacePrefix)
        {
            return new ECSchema(schemaName, versionMajor, versionMinor, nameSpacePrefix);
        }

        public virtual IECClass CreateClass(IECSchema schema, string className, IECClass baseClass, bool isStruct)
        {
            return new ECClass(className, baseClass, isStruct);
        }

        public virtual IECRelationshipClass CreateRelationshipClass(IECSchema schema, string className, IECClass baseClass)
        {
            return new ECRelationshipClass(className, baseClass);
        }

        public virtual IECProperty CreateProperty(IECClass ecClass, string propertyName, IECType propertyType)
        {
            return new ECProperty(propertyName, propertyType);
        }
    }
}
