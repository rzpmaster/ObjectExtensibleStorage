using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Serialization.Extendable
{
    internal class SerializationExtendedParametersContext : IDisposable
    {
        public static ExtendedParameters? ExtendedParameters
        {
            get
            {
                if (SerializationExtendedParametersContext.m_extendedParametersStack == null ||
                    SerializationExtendedParametersContext.m_extendedParametersStack.Count == 0)
                {
                    return null;
                }
                return SerializationExtendedParametersContext.m_extendedParametersStack.Peek();
            }
        }

        public SerializationExtendedParametersContext(ExtendedParameters extendedParameters)
        {
            if (SerializationExtendedParametersContext.m_extendedParametersStack == null)
            {
                SerializationExtendedParametersContext.m_extendedParametersStack = new Stack<ExtendedParameters>();
            }
            SerializationExtendedParametersContext.m_extendedParametersStack.Push(extendedParameters);
        }

        [ThreadStatic]
        private static Stack<ExtendedParameters>? m_extendedParametersStack;

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (SerializationExtendedParametersContext.m_extendedParametersStack != null)
                    {
                        SerializationExtendedParametersContext.m_extendedParametersStack.Pop();
                    }
                }

                disposedValue = true;
            }
        }

        // override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~SerializationExtendedParametersContext()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
