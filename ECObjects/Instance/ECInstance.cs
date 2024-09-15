using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Common;
using ECObjects.Abstract.Instance;
using ECObjects.Abstract.Schema;

namespace ECObjects.Instance
{
    public class ECInstance : IECInstance
    {
        public IECPropertyValue this[string accessor] => throw new NotImplementedException();

        public IECClass ClassDefinition => throw new NotImplementedException();

        public string InstanceId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsReadOnly { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool ContainsValues => throw new NotImplementedException();

        public INamed Enabler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dump(TextWriter output, string linePrefix)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IECPropertyValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IECPropertyValue GetPropertyValue(string accessor)
        {
            throw new NotImplementedException();
        }

        public void RemoveValue(IECPropertyValue propertyValue)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
