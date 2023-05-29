using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Instance;

namespace ECObjects.Abstract.Schema.ECType
{
    public interface IECType : IECObjectBase
    {
        IECPropertyValue CreateValue(IECProperty property, IECValueContainer container);
        IECPropertyValue CreateArrayMember(IECArrayValue owningArray, int arrayIndex);
    }
}
