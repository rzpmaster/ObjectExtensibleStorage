using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Extension
{

	[Serializable]
	public class ECBaseException : Exception
	{
		public ECBaseException() { }
		public ECBaseException(string message) : base(message) { }
		public ECBaseException(string message, Exception inner) : base(message, inner) { }
		protected ECBaseException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
