using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Instance;
using ECObjects.Abstract.Schema;
using ECObjects.Utils;

namespace ECObjects.Schema
{
    public class ECClass : IECClass
    {
        private string m_name;
        private string? m_displayLabel;
        private Dictionary<string, IECProperty> m_localProperties;
        private Dictionary<string, IECProperty> m_inheritedProperties;

        public ECClass(string className) : this(className, null, false)
        {
        }

        public ECClass(string className, IECClass? baseClass) : this(className, baseClass, false)
        {
        }

        public ECClass(string className, bool isStruct) : this(className, null, isStruct)
        {
        }

        public ECClass(string className, IECClass? baseClass, bool isStruct)
        {
            ECNameValidation.Validate(className);
            this.m_name = className;
            this.m_localProperties = new Dictionary<string, IECProperty>();
            this.m_inheritedProperties = new Dictionary<string, IECProperty>();
            if (baseClass != null) this.AddBaseClass(baseClass);
            this.IsStruct = isStruct;
        }


        public string Name
        {
            get { return m_name; }
            set { SetName(value, this.IsDisplayLabelDefined ? this.DisplayLabel : null); }
        }

        public string? DisplayLabel
        {
            get { return m_displayLabel; }
            set { SetName(this.Name, value); }
        }

        public bool IsDisplayLabelDefined => !string.IsNullOrEmpty(DisplayLabel);

        private void SetName(string newName, string? newDisplayLabel = null)
        {
            ECNameValidation.Validate(newName);
            this.m_name = newName;
            this.m_displayLabel = newDisplayLabel;

            // todo: schema changed event
            // todo: class changed event
        }

        public bool IsStruct { get; private set; }


        public IECProperty this[string propertyName] => throw new NotImplementedException();

        public IECSchema Schema => throw new NotImplementedException();

        public bool IsCustomAttribute { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDomainClass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsFinal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IECClass[] BaseClasses => throw new NotImplementedException();

        public bool HasBaseClasses => throw new NotImplementedException();

        public IEnumerable<IECClass> DerivedClasses => throw new NotImplementedException();

        public bool HasDerivedClasses => throw new NotImplementedException();

        public bool RequiresCustomStructSerializer => throw new NotImplementedException();

        public string CustomStructSerializerName => throw new NotImplementedException();


        public string? Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(IECProperty property)
        {
            throw new NotImplementedException();
        }

        public void AddBaseClass(IECClass baseClass)
        {
            throw new NotImplementedException();
        }

        public bool AddDerivedClass(IECClass derivedClass)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IECPropertyValue CreateArrayMember(IECArrayValue owningArray, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IECInstance CreateInstance()
        {
            throw new NotImplementedException();
        }

        public IECPropertyValue CreateValue(IECProperty property, IECValueContainer container)
        {
            throw new NotImplementedException();
        }

        public void Dump(TextWriter output, string linePrefix)
        {
            throw new NotImplementedException();
        }

        public IECInstance[] GetCustomAttributes()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IECProperty> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IECProperty> Properties(bool includeBaseClassProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void RemoveBaseClass(IECClass baseClass)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomAttribute(IECClass classDefinition)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDerivedClass(IECClass derivedClass)
        {
            throw new NotImplementedException();
        }

        public void SetCustomAttribute(IECInstance customAttributeInstance)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
