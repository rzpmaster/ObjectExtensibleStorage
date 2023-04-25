using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Common;
using ECObjects.Abstract.Instance;

namespace ECObjects.Abstract.Schema
{
    public interface IECCustomAttributeContainer : IDump
    {
        IECInstance[] GetCustomAttributes();
        void SetCustomAttribute(IECInstance customAttributeInstance);
        bool RemoveCustomAttribute(IECClass classDefinition);
    }
}
