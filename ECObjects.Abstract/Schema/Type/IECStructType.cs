using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Abstract.Schema.Type
{
    public interface IECStructType : IECType
    {
        bool RequiresCustomStructSerializer { get; }
        string CustomStructSerializerName { get; }
    }
}
