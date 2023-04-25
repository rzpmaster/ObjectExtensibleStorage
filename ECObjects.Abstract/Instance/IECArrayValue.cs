using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Common;

namespace ECObjects.Abstract.Instance
{
    public interface IECArrayValue : IECPropertyValue, IDump, IECValueContainer
    {
        IECPropertyValue this[int index] { get; }
        void Clear();
        IECPropertyValue Add();
        void RemoveAt(int index);
        IECPropertyValue InsertAt(int index);
    }
}
