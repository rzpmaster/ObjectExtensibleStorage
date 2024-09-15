using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Schema;
using ECObjects.Abstract.Schema.ECType;

namespace ECObjects.Abstract.Locater
{
    public interface IECSchemaFactory
    {
        IECSchema CreateSchema(string schemaName, int versionMajor, int versionMinor, string nameSpacePrefix);
        IECClass CreateClass(IECSchema schema, string className, IECClass baseClass, bool isStruct);
        IECRelationshipClass CreateRelationshipClass(IECSchema schema, string className, IECClass baseClass);
        IECProperty CreateProperty(IECClass ecClass, string propertyName, IECType propertyType);
    }
}
