using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Abstract.Schema
{
    public interface IECSchemaLocater
    {
        IECSchema LocateSchema(string schemaName, int versionMajor, int versionMinor, SchemaMatchType matchType, IECSchema parentSchema, object context);
        int GetPriority(object context);
    }

    /// <summary>
    /// Schema 版本匹配类型
    /// </summary>
    public enum SchemaMatchType
    {
        /// <summary>
        /// 精确匹配 VersionMajor 和 VersionMinor
        /// </summary>
        Exact,
        /// <summary>
        /// 精确匹配 VersionMajor，然后找 VersionMinor 的最后一个版本
        /// </summary>
        LatestCompatible,
        /// <summary>
        /// 找最后一个版本
        /// </summary>
        Latest
    }
}
