using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Locater;
using ECObjects.Abstract.Schema.ECType;
using ECObjects.Locater;
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
            if (Thread.VolatileRead(ref ECObjects.s_initialized) != 0)
            {
                return;
            }
            object obj = ECObjects.s_initializationMutex;
            lock (obj)
            {
                if (ECObjects.s_initialized == 0)
                {
                    ECObjects.CustomSerializationHandlers.Add(new ECSchemaXmlSerializer());
                    ECObjects.CustomSerializationHandlers.Add(new ECInstanceGraphXmlSerializer());
                    //ECObjects.RegisterHandler(null);
                    ECObjects.s_initialized = 1;
                }
            }
        }

        public static IList<ECXmlSerializer> CustomSerializationHandlers
        {
            get
            {
                return ECObjects.s_serializationCustomHandlers;
            }
        }

        private static int s_initialized;
        private static object s_initializationMutex = new object();
        private static List<ECXmlSerializer> s_serializationCustomHandlers = new List<ECXmlSerializer>();
    }
}
