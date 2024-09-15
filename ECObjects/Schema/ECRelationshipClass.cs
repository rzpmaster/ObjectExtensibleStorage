using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Instance;
using ECObjects.Abstract.Schema;

namespace ECObjects.Schema
{
    public class ECRelationshipClass : ECClass, IECClass, IECRelationshipClass
    {
        private IECRelationshipConstraint m_source;
        private IECRelationshipConstraint m_target;

        public ECRelationshipClass(string className, IECClass? baseClass = null) : base(className, baseClass)
        {
            if (baseClass != null && !(baseClass is IECRelationshipClass))
            {
                throw Exceptions.DerivationErrorException.Throw(className, baseClass.Name);
            }

            this.m_source = new ECRelationshipConstraint(this, false);
            this.m_target = new ECRelationshipConstraint(this, true);
        }

        public IECRelationshipConstraint Source => this.m_source;

        public IECRelationshipConstraint Target => this.m_target;

        public StrengthType Strength => throw new NotImplementedException();

        public RelatedInstanceDirection StrengthDirection => throw new NotImplementedException();
    }

    public class ECRelationshipConstraint : IECRelationshipConstraint
    {
        protected IECRelationshipClass m_relClass;
        protected bool m_isTarget;

        public ECRelationshipConstraint(IECRelationshipClass relClass) : this(relClass, false)
        {
        }

        public ECRelationshipConstraint(IECRelationshipClass relClass, bool isTarget)
        {
            if (relClass == null)
            {
                throw new ArgumentNullException(nameof(relClass));
            }
            this.m_relClass = relClass;
            this.m_isTarget = isTarget;
        }

        public bool IsMultiple => throw new NotImplementedException();

        public IECRelationshipCardinality Cardinality { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsPolymorphic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IECRelationshipConstraintClass AddClass(IECClass classConstraint)
        {
            throw new NotImplementedException();
        }

        public void ClearClasses()
        {
            throw new NotImplementedException();
        }

        public bool ContainsClass(IECClass ecClass)
        {
            throw new NotImplementedException();
        }

        public void Dump(TextWriter output, string linePrefix)
        {
            throw new NotImplementedException();
        }

        public IECRelationshipConstraintClass[] GetClasses()
        {
            throw new NotImplementedException();
        }

        public IECInstance[] GetCustomAttributes()
        {
            throw new NotImplementedException();
        }

        public void RemoveClass(IECClass classConstraint)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomAttribute(IECClass classDefinition)
        {
            throw new NotImplementedException();
        }

        public void SetCustomAttribute(IECInstance customAttributeInstance)
        {
            throw new NotImplementedException();
        }

        public bool SupportsClass(IECClass ecClass)
        {
            throw new NotImplementedException();
        }
    }
}
