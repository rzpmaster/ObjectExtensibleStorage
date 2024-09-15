using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Serialization.Extendable
{
    public class ExtendedParameters : Dictionary<string, object>
    {
        public static ExtendedParameters Create()
        {
            return new ExtendedParameters();
        }
    }
}
