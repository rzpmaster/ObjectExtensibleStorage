using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Common;

namespace ECObjects.Abstract.Schema.ECType
{
    public interface IECPrimitiveType : IECType, IDump, INamed
    {
        Type NativeCLRType { get; }
    }
}
