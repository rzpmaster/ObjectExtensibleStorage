using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECObjects.Utils
{
    public static class ECNameRelatedUtils
    {
        public static string FormatSchemaVersion(int versionMajor, int versionMinor)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:00}.{1:00}", versionMajor, versionMinor);
        }

        public static string FormatFullSchemaName(string schemaName, int versionMajor, int versionMinor)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}.{1}", schemaName, ECNameRelatedUtils.FormatSchemaVersion(versionMajor, versionMinor));
        }


    }
}
