using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Schema
{
    public class ExceptionReason
    {
        public static readonly string DerivationError = "DerivationError";
        public static readonly string StructTypeNotMatch = "StructTypeNotMatch";
    }

    [Serializable]
    public class Exceptions
    {
        [Serializable]
        public class DerivationErrorException : ApplicationException
        {
            public DerivationErrorException() { }
            public DerivationErrorException(string message) : base(message) { }
            public DerivationErrorException(string message, Exception inner) : base(message, inner) { }
            protected DerivationErrorException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

            public static Exception Throw(string className, string baseClassName)
            {
                return new DerivationErrorException($"{ExceptionReason.DerivationError}.Class {className} BaseClass {baseClassName}.");
            }
        }


        [Serializable]
        public class StructTypeNotMatchException : ApplicationException
        {
            public StructTypeNotMatchException() { }
            public StructTypeNotMatchException(string message) : base(message) { }
            public StructTypeNotMatchException(string message, Exception inner) : base(message, inner) { }
            protected StructTypeNotMatchException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

            public static Exception Throw(string typeName)
            {
                return new StructTypeNotMatchException($"{ExceptionReason.StructTypeNotMatch}.TypeName {typeName} is not struct.");
            }
        }


    }
}
