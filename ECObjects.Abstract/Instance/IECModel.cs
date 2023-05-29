using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Common;
using ECObjects.Abstract.Schema;

namespace ECObjects.Abstract.Instance
{
    public interface IECModel : IEnumerable<IECInstance>, IECObjectBase
    {
        string FullName { get; }
        void AddInstance(IECInstance instanceToAdd);
        void RemoveInstance(IECInstance instanceToRemove);
        ICollection<IECInstance> GetInstances();
        IECInstance GetInstance(IECClass ecClass, string instanceId);

        ICollection<IECInstance> GetRelationshipInstances();
        ICollection<IECInstance> GetRelationshipInstances(IECRelationshipClass relationshipClass);
    }
}
