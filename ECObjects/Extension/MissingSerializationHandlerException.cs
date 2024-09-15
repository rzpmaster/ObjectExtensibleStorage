using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Extension
{
    [Serializable]
    public class MissingSerializationHandlerException : ECBaseException
    {
        private static string CreateMessage(object obj)
        {
            if (obj == null)
            {
                return "The DynamicXmlSerializer does not have a registered handler that can serialize a null object.";
            }
            return string.Format(CultureInfo.InvariantCulture, "The DynamicXmlSerializer does not support serializing the specified object of type '{0}'.", obj.GetType().FullName);
        }

        public MissingSerializationHandlerException() { }
        public MissingSerializationHandlerException(string message) : base(message) { }
        public MissingSerializationHandlerException(object obj) : base(MissingSerializationHandlerException.CreateMessage(obj)) { }
        public MissingSerializationHandlerException(string message, Exception inner) : base(message, inner) { }
        public MissingSerializationHandlerException(object obj, Exception innerException) : base(MissingSerializationHandlerException.CreateMessage(obj), innerException) { }
        protected MissingSerializationHandlerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
