using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Common;
using ECObjects.Abstract.Instance;
using ECObjects.Abstract.Schema;

namespace ECObjects.Schema
{
    [Serializable]
    public class ECCustomAttributeContainer : IECCustomAttributeContainer, IDump
    {
        public ECCustomAttributeContainer()
        {

        }

        public virtual void Dump(TextWriter output, string linePrefix)
        {
            throw new NotImplementedException();
        }

        public IECInstance[] GetCustomAttributes()
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

        protected List<IECInstance> m_primaryCustomAttributes = new List<IECInstance>();
        protected List<IECInstance> m_supplementedCustomAttributes = new List<IECInstance>();
    }
}
