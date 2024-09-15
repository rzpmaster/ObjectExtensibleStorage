using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Serialization.Extendable
{
    internal interface IExtendable
    {
        Dictionary<string, object> ExtendedData { get; }
    }
}
