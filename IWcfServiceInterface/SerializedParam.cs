using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace IWcfServiceInterface
{
    [DataContract]
    public class SerializedParam
    {
        [DataMember]
        public string entityType { get; set; }

        [DataMember]
        public string filter { get; set; }

        [DataMember]
        public string model { get; set; }

        [DataMember]
        public string list { get; set; }

        public SerializedParam(Parameter p)
        {
            this.SerializeProperties(p);
        }

        public static explicit operator SerializedParam(Parameter p)
        {
            return new SerializedParam(p);
        }

        public static explicit operator Parameter(SerializedParam p)
        {
            return p.GetParameter(p);
        }

        public Parameter GetParameter(SerializedParam serialized)
        {
            Parameter p = new Parameter();
            p.entityType = serialized.entityType;
            p.filter = serialized.filter;
            p.model = serialized.model;
            p.list = (IList)DeserializeObject(serialized.list, typeof(IList));
            return p;
        }

        public Parameter GetParameter()
        {
            return this.GetParameter(this);
        }

        private void SerializeProperties(Parameter p)
        {
            this.entityType = SerializeObject(p.entityType);
            this.filter = SerializeObject(p.filter);
            this.model = SerializeObject(p.model);
            this.list = SerializeObject(p.list);
        }
        private string SerializeObject(object value)
        {
            if (value == null) return null;

            return JsonConvert.SerializeObject(value);
        }

        private object DeserializeObject(string value, Type type)
        {
            if (string.IsNullOrEmpty(value)) return null;

            return JsonConvert.DeserializeObject(value, type);
        }
    }
}
