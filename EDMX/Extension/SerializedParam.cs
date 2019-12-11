using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EDMX
{
    [DataContract]
    //[TypeConverter(typeof(SerializedParamTypeConverter))]
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

        [DataMember]
        public string queryable { get; set; }

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
            if (!string.IsNullOrWhiteSpace(serialized.entityType))
                p.entityType = Type.GetType(serialized.entityType);
            p.filter = serialized.filter;
            if (p.entityType != null)
            {
                p.model = DeserializeObject(serialized.model, p.entityType.UnderlyingSystemType);
                p.list = (IList)DeserializeObject(serialized.list, p.entityType.UnderlyingSystemType);
                // 这里IQueryable反序列化回报异常，直接在客户端通过List<T>反序列化
                //p.queryable = (IQueryable)DeserializeObject(serialized.queryable, p.entityType.UnderlyingSystemType);
            }
            return p;
        }

        public Parameter GetParameter()
        {
            return this.GetParameter(this);
        }

        private void SerializeProperties(Parameter p)
        {
            if (p.entityType != null)
                this.entityType = p.entityType.AssemblyQualifiedName;
            this.filter = p.filter;
            this.model = SerializeObject(p.model);
            this.list = SerializeObject(p.list);
            this.queryable = SerializeObject(p.queryable);
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

//public class SerializedParamTypeConverter : TypeConverter
//{
//    //static readonly Regex regex = new Regex(string.Format(@"(?<={0}=)(.*?)(?=\&|$)", p.Name), RegexOptions.IgnoreCase); //new Regex(@"\[(\d+),(\d+)\]");
//    static readonly Regex regexJson= new Regex("(\"([^,^\"]+)\":\"([^:^\"]+)\")|(\"([^,^\"]+)\":([\\d]+))");
//    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
//    {
//        return sourceType == typeof(string) ||
//            base.CanConvertFrom(context, sourceType);
//    }
//    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
//    {
//        string strValue = value as string;
//        if (strValue != null)
//        {
//            var matches = regexJson.Matches(strValue);
//            //if (match.Success)
//            //{
//                Parameter p = new Parameter();
//            //if (matches.Count > 0 && matches[0].Groups.Count > 3)
//            //    p.entityType = Type.GetType(matches[0].Groups[3].Value);
//            //if (matches.Count > 1 && matches[1].Groups.Count > 3)
//            //    p.filter = matches[1].Groups[3].Value;
//            //if (matches.Count > 2 && matches[2].Groups.Count > 3)
//            //    p.model = matches[2].Groups[3].Value;
//            //if (matches.Count > 3 && matches[3].Groups.Count > 3)
//            //    p.list = matches[3].Groups[3].Value;
//            //return new SerializedParam(p);
//            return new SerializedParam(p)
//            {
//                entityType = matches.Count > 0 ? matches[0].Groups[3].Value : null,
//                filter = matches.Count > 1 ? matches[1].Groups[3].Value : null,
//                model = matches.Count > 2 ? matches[2].Groups[3].Value : null,
//                list = matches.Count > 3 ? matches[3].Groups[3].Value : null,
//            };
//            //}
//        }

//        return base.ConvertFrom(context, culture, value);
//    }
//    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
//    {
//        if (destinationType == typeof(string))
//        {
//            SerializedParam param = (SerializedParam)value;
//            return string.Format("[\"entityType\":{0},\"filter\":{1},\"model\":{2},\"list\":{3}]", param.entityType, param.filter, param.model, param.list);
//        }
//        else
//        {
//            return base.ConvertTo(context, culture, value, destinationType);
//        }
//    }
//}
