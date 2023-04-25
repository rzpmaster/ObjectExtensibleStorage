using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Abstract.Schema
{
    public interface IECSchema : IECObjectBase, IEnumerable<IECClass>, IECCustomAttributeContainer
    {
        bool IsSupplemented { get; set; }
        IECSchema[] GetReferencedSchemas(bool includeReferencesFromSupplementalSchemas);

        string FullName { get; }
        string NamespacePrefix { get; }
        int VersionMajor { get; }
        int VersionMinor { get; }

        // classes
        int ClassCount { get; }
        IECClass[] GetClasses();
        IECClass GetClass(string className);
        IECClass this[string className] { get; }
        void AddClass(IECClass classToAdd);
        void RemoveClass(IECClass classToRemove);

        IECClass[] GetDomainClasses();
        IECClass[] GetStructs();
        IECClass[] GetCustomAttributeClasses();
    }
}
