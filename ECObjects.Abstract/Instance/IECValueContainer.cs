using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Abstract.Instance
{
    public interface IECValueContainer : IEnumerable<IECPropertyValue>
    {
        IECPropertyValue this[string accessor] { get; }
        IECPropertyValue GetPropertyValue(string accessor);
        void RemoveValue(IECPropertyValue propertyValue);
    }
}
