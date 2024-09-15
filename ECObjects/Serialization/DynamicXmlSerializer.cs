using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ECObjects.Extension;
using ECObjects.Serialization.Extendable;

namespace ECObjects.Serialization
{
    public class BeforeSerializationEventArgs : EventArgs
    {
        public BeforeSerializationEventArgs(object obj, ExtendedParameters parameters)
        {
            Obj = obj;
            Parameters = parameters;
        }

        public object Obj { get; }
        public ExtendedParameters Parameters { get; }
    }

    public class AfterSerializationEventArgs : EventArgs
    {
        public AfterSerializationEventArgs(object obj, ExtendedParameters parameters)
        {
            Obj = obj;
            Parameters = parameters;
        }

        public object Obj { get; }
        public ExtendedParameters Parameters { get; }
    }

    public class DynamicXmlSerializer
    {
        private static List<ObjectXmlSerializer> InitializeBuiltInFirstChanceHandlers()
        {
            return new List<ObjectXmlSerializer>
            {
                new NullObjectXmlSerializer(),
                new BuiltInTypeXmlSerializer(),
                new ExtendableXmlSerializer()
            };
        }

        private static List<ObjectXmlSerializer> InitializeBuiltInLastChanceHandlers()
        {
            return new List<ObjectXmlSerializer>
            {
                new UnknownTypeSerializer(),
                new XmlWithContextSerializer(),
                new DataContractSerializer(),
                new TransientLookupCollectionSerializer(),
                new DictionarySerializer(),
                new ListSerializer(),
                new GeneralSerializer()
            };
        }

        public static event EventHandler<BeforeSerializationEventArgs>? BeforeSerializationEvent;

        public static event EventHandler<AfterSerializationEventArgs>? AfterSerializationEvent;

        public static IEnumerable<ObjectXmlSerializer> AllSerializationHandlers
        {
            get
            {
                foreach (ObjectXmlSerializer builtInFirstChanceSerializationHandler in DynamicXmlSerializer.s_serializationBuiltInFirstChanceHandlers)
                {
                    yield return builtInFirstChanceSerializationHandler;
                }
                foreach (ObjectXmlSerializer customSerializationHandler in DynamicXmlSerializer.s_serializationCustomHandlers)
                {
                    yield return customSerializationHandler;
                }
                foreach (ObjectXmlSerializer builtInLastChanceSerializationHandler in DynamicXmlSerializer.s_serializationBuiltInLastChanceHandlers)
                {
                    yield return builtInLastChanceSerializationHandler;
                }
                yield break;
            }
        }

        public static bool IsSerializable(object obj)
        {
            using (IEnumerator<ObjectXmlSerializer> enumerator = DynamicXmlSerializer.AllSerializationHandlers.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.CanSerialize(obj, null))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void Serialize(XmlWriter xmlWriter, object obj)
        {
            DynamicXmlSerializer.Serialize(xmlWriter, null, obj);
        }

        public static void Serialize(XmlWriter xmlWriter, ExtendedParameters? parameters, object obj)
        {
            if (xmlWriter == null)
            {
                throw ThrowingPolicy.Apply(new ArgumentNullException("xmlWriter"));
            }
            if (parameters == null)
            {
                parameters = ExtendedParameters.Create();
            }
            if (DynamicXmlSerializer.BeforeSerializationEvent != null)
            {
                DynamicXmlSerializer.BeforeSerializationEvent(null, new BeforeSerializationEventArgs(obj, parameters));
            }
            bool flag = false;
            using (new SerializationExtendedParametersContext(parameters))
            {
                foreach (ObjectXmlSerializer objectSerializationHandler in DynamicXmlSerializer.AllSerializationHandlers)
                {
                    if (objectSerializationHandler.CanSerialize(obj, parameters))
                    {
                        objectSerializationHandler.Serialize(xmlWriter, parameters, obj);
                        flag = true;
                        break;
                    }
                }
            }
            if (!flag)
            {
                throw ThrowingPolicy.Apply(new MissingSerializationHandlerException(obj));
            }
            if (DynamicXmlSerializer.AfterSerializationEvent != null)
            {
                DynamicXmlSerializer.AfterSerializationEvent(null, new AfterSerializationEventArgs(obj, parameters));
            }
        }

        private static List<ObjectXmlSerializer> s_serializationBuiltInFirstChanceHandlers = DynamicXmlSerializer.InitializeBuiltInFirstChanceHandlers();
        private static List<ObjectXmlSerializer> s_serializationCustomHandlers = new List<ObjectXmlSerializer>();
        private static List<ObjectXmlSerializer> s_serializationBuiltInLastChanceHandlers = DynamicXmlSerializer.InitializeBuiltInLastChanceHandlers();
    }
}
