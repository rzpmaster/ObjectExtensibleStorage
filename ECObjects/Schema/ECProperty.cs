using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ECObjects.Abstract.Instance;
using ECObjects.Abstract.Schema;
using ECObjects.Abstract.Schema.ECType;

namespace ECObjects.Schema
{
    [Serializable]
    public class ECProperty : ECCustomAttributeContainer, IECProperty
    {
        public ECProperty(string propertyName, IECType propertyType)
        {
            IECClass? ecClass = propertyType as IECClass;
            if (ecClass != null && !ecClass.IsStruct)
            {
                throw Exceptions.StructTypeNotMatchException.Throw(propertyType.Name);
            }
            this.m_propertyName = propertyName;
            this.m_propertyType = propertyType;
        }

        public string Name
        {
            get
            {
                return this.m_propertyName;
            }
            set
            {
                this.SetName(value, this.DisplayLabel);
            }
        }

        public string? DisplayLabel
        {
            get
            {
                return this.m_displayLabel;
            }
            set
            {
                this.SetName(this.Name, value);
            }
        }

        public bool IsDisplayLabelDefined
        {
            get
            {
                return this.m_displayLabel != null;
            }
        }

        public string? Description
        {
            get
            {
                return this.m_description;
            }
            set
            {
                this.m_description = value;
            }
        }

        public virtual IECType Type
        {
            get
            {
                return this.m_propertyType;
            }
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return this.m_isReadOnly;
            }
            set
            {
                this.m_isReadOnly = value;
            }
        }

        public IECClass ClassDefinition
        {
            get
            {
                return this.m_classDefinition ?? throw new Exception("PropertyNotSetClass");
            }
            set
            {
                this.m_classDefinition = value;
            }
        }

        public void SetName(string newName, string? newDisplayLabel)
        {
            this.m_propertyName = newName;
            this.m_displayLabel = newDisplayLabel;

            // TODO: update it's belongs Class
        }

        public void SetType(IECType newType)
        {
            if (newType == null)
            {
                throw new ArgumentNullException("newType");
            }
            this.m_propertyType = newType;
        }

        public virtual IECPropertyValue CreateValue(IECValueContainer container)
        {
            return this.Type.CreateValue(this, container);
        }

        public override void Dump(TextWriter output, string linePrefix)
        {
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }
            if (linePrefix == null)
            {
                linePrefix = "";
            }
            output.WriteLine($"{linePrefix}IECProperty.Name = <{this.Name}>");
            if (!string.IsNullOrEmpty(this.Description))
            {
                output.WriteLine($"{linePrefix}Description: {this.Description}");
            }
            linePrefix += "  ";
            output.WriteLine($"{linePrefix}IECProperty.Type:");
            this.Type.Dump(output, linePrefix);
            // CustomAttribute.Dump
            base.Dump(output, linePrefix);
        }

        public override string ToString()
        {
            return $"{{ECProperty {this.Name} ({this.Type.Name})}}";
        }

        private string m_propertyName;
        private string? m_displayLabel;
        private string? m_description;

        private IECType m_propertyType;
        private bool m_isReadOnly;
        private IECClass? m_classDefinition;
    }
}
