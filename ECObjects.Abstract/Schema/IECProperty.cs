using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Common;
using ECObjects.Abstract.Instance;
using ECObjects.Abstract.Schema.ECType;

namespace ECObjects.Abstract.Schema
{
    public interface IECProperty : IECObjectBase, IECCustomAttributeContainer
    {
        IECType Type { get; }
        void SetType(IECType newType);

        IECClass ClassDefinition { get; set; }

        bool IsReadOnly { get; set; }

        IECPropertyValue CreateValue(IECValueContainer container);
    }
}
