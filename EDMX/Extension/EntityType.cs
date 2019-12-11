using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EDMX
{
    /// <summary>
    /// 通过实体名称获得实体类型
    /// </summary>
    [DataContract]
    [TypeConverter(typeof(EntityTypeConverter))]
    public class EntityType
    {
        [DataMember]
        string typeName;
        
        public EntityType(Type type)
        {
            this.typeName = type.AssemblyQualifiedName;
        }

        public new Type GetType()
        {
            return Type.GetType(typeName);
        }
    }

    public class EntityTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) ||
                base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value != null)
            {
                string assemblyString = nameof(EDMX);
                Assembly assembly = Assembly.Load(assemblyString);
                Type type = assembly.GetType(string.Format("{0}.{1}", assemblyString, value));
                EntityType entityType = new EntityType(type);
                return entityType;
            }

            return base.ConvertFrom(context, culture, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                Type type = (Type)value;
                return type.AssemblyQualifiedName;
            }
            else
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }
}
