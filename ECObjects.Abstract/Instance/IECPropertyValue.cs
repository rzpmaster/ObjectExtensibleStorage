using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Common;
using ECObjects.Abstract.Schema;
using ECObjects.Abstract.Schema.ECType;

namespace ECObjects.Abstract.Instance
{
    public interface IECPropertyValue : IDump
    {
        IECType Type { get; }
        IECProperty Property { get; }
        IECValueContainer Container { get; }
        IECInstance Instance { get; }

        object Value { get; }
    }
}
