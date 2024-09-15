using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ECObjects.Abstract.Instance;
using ECObjects.Abstract.Schema.ECType;

namespace ECObjects.Abstract.Schema
{
    public interface IECClass : IEnumerable<IECProperty>, IECStructType, IECType, IECCustomAttributeContainer, IECObjectBase
    {
        IECInstance CreateInstance();
        IECSchema Schema { get; }
        bool IsStruct { get; }
        bool IsCustomAttribute { get; }
        bool IsDomainClass { get; }
        bool IsFinal { get; }

        // base classes
        IECClass[] BaseClasses { get; }
        bool HasBaseClasses { get; }
        void AddBaseClass(IECClass baseClass);
        void RemoveBaseClass(IECClass baseClass);

        // derived classes
        IEnumerable<IECClass> DerivedClasses { get; }
        bool HasDerivedClasses { get; }
        bool AddDerivedClass(IECClass derivedClass);
        bool RemoveDerivedClass(IECClass derivedClass);

        // properties
        void Clear();
        void Add(IECProperty property);
        void Remove(string propertyName);
        IECProperty this[string propertyName] { get; }
        IEnumerable<IECProperty> Properties(bool includeBaseClassProperties);
    }
}
