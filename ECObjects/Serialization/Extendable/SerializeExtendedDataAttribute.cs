﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Serialization.Extendable
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SerializeExtendedDataAttribute : Attribute
    {
    }
}
