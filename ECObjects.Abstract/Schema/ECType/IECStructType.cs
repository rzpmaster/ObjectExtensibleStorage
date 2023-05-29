using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Abstract.Schema.ECType
{
    public interface IECStructType : IECType, IECObjectBase
    {
        bool RequiresCustomStructSerializer { get; }
        string CustomStructSerializerName { get; }
    }
}
