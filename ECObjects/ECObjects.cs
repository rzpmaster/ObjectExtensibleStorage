using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Schema;
using ECObjects.XML;

namespace ECObjects
{
    public class ECObjects
    {
        private ECObjects() { }

        static ECObjects()
        {
            ECObjects.Initialize();
        }

        public static void Initialize()
        {
            if (!s_initialized)
            {
                s_serializor.Add(new ECSchemaXmlSerializer());
                s_serializor.Add(new ECInstanceGraphXmlSerializer());

                s_initialized = true;
            }
        }



        private static bool s_initialized;
        private static List<ECXmlSerializer> s_serializor = new List<ECXmlSerializer>();
        private static List<IECSchemaLocater> s_schemaLocaters = new List<IECSchemaLocater>();
    }
}
