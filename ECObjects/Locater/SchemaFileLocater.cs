using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Locater;
using ECObjects.Abstract.Schema;
using ECObjects.Abstract.Schema.ECType;

namespace ECObjects.Locater
{
    public class SchemaFileLocater : IECSchemaLocater, IECSchemaFactory
    {
        private IECSchemaFactory m_schemaFactory;
        private bool m_buildSupplementedSchemas = true;

        public SchemaFileLocater()
        {
            this.m_schemaFactory = new ECSchemaDefaultFactory();
        }

        public SchemaFileLocater(bool buildSupplementedSchemas)
        {
            this.m_schemaFactory = new ECSchemaDefaultFactory();
            this.m_buildSupplementedSchemas = buildSupplementedSchemas;
        }

        #region IECSchemaFactory

        public IECClass CreateClass(IECSchema schema, string className, IECClass baseClass, bool isStruct)
        {
            return m_schemaFactory.CreateClass(schema, className, baseClass, isStruct);
        }

        public IECProperty CreateProperty(IECClass ecClass, string propertyName, IECType propertyType)
        {
            return m_schemaFactory.CreateProperty(ecClass, propertyName, propertyType);
        }

        public IECRelationshipClass CreateRelationshipClass(IECSchema schema, string className, IECClass baseClass)
        {
            return m_schemaFactory.CreateRelationshipClass(schema, className, baseClass);
        }

        public IECSchema CreateSchema(string schemaName, int versionMajor, int versionMinor, string nameSpacePrefix)
        {
            return m_schemaFactory.CreateSchema(schemaName, versionMajor, versionMinor, nameSpacePrefix);
        }

        #endregion

        #region IECSchemaLocater

        public int GetPriority(object context)
        {
            throw new NotImplementedException();
        }

        public IECSchema LocateSchema(string schemaName, int versionMajor, int versionMinor, SchemaMatchType matchType, IECSchema parentSchema, object context)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
