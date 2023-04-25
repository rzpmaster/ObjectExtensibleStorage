using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Abstract.Common
{
    public interface IDump
    {
        void Dump(TextWriter output, string linePrefix);
    }
}
