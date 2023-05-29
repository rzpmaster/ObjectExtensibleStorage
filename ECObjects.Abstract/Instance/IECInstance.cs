using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Common;
using ECObjects.Abstract.Schema;

namespace ECObjects.Abstract.Instance
{
    public interface IECInstance : IEnumerable<IECPropertyValue>, IECValueContainer, IDump
    {
        IECClass ClassDefinition { get; }
        string InstanceId { get; set; }
        bool IsReadOnly { get; set; }
        bool ContainsValues { get; }

        INamed Enabler { get; set; }
    }
}
