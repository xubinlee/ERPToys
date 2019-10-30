namespace Utility
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    //using ICP.Framework.CommonLibrary.Attributes;

    /// <summary>
    /// 枚举处理帮助类
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// 获取枚举成员列表
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="english">是否英文环境</param>
        /// <returns>返回枚举成员列表</returns>
        public static List<ListItem<T>> GetEnumValues<T>(bool english)
        {
            Type type = typeof(T);
            if (type.IsEnum == false)
            {
                return null;
            }

            string[] names = Enum.GetNames(type);
            T[] values = (T[])Enum.GetValues(type);
            List<ListItem<T>> results = new List<ListItem<T>>();
            for (int i = 0; i < names.Length; i++)
            {
                ListItem<T> item = new ListItem<T>();
                item.Name = GetDescription<T>(values[i], english);
                item.Value = values[i];
                results.Add(item);

            }

            return results;
        }

        /// <summary>
        /// 成员类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ListItem<T>
        {
            T value;
            /// <summary>
            /// 值
            /// </summary>
            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            string name;
            /// <summary>
            /// 名称
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        /// <summary>
        /// 获取枚举类型值的描述信息.
        /// 2011-05-18 修改：没有标签的时候返回value本身的字符串形式
        /// </summary>
        /// <param name="value">枚举类型值</param>
        /// <param name="english">是否英文环境</param>
        /// <param name="returnEmptyIfNull">对为空值的枚举(值为0时)返回Empty</param>
        /// <returns>返回枚举成员的描述</returns>
        public static string GetDescription<T>(T value, bool english, bool returnEmptyIfNull)
        {
            return Get<T>(value, english, returnEmptyIfNull, true);
        }

        public static string GetDescription<T>(T value)
        {
            return Get<T>(value, false, false, false);
        }

        public static string Get<T>(T value, bool english, bool returnEmptyIfNull, bool returnDescription)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = string.Empty;
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                object[] attrs = fieldInfo.GetCustomAttributes(typeof(MemberDescriptionAttribute), false);

                if (attrs != null)
                {
                    MemberDescriptionAttribute[] attributes = (MemberDescriptionAttribute[])attrs;
                    if (attributes != null && attributes.Length > 0)
                    {
                        if (returnDescription)
                        {
                            description = english ? attributes[0].EDescription : attributes[0].CDescription;
                        }
                        else {
                            description = attributes[0].SimpleMeaning;
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(description))
            {
                if (returnEmptyIfNull)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.ToString();
                }
            }

            return description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="english"></param>
        /// <returns></returns>
        public static string GetDescription<T>(T value, bool english)
        {
            return GetDescription<T>(value, english, false);
        }

        /// <summary>
        /// 转化为名称
        /// </summary>
        /// <param name="enumvalue">枚举值</param>
        /// <returns>返回转换后的名称</returns>
        public static string ToString(object enumvalue)
        {
            Type type = enumvalue.GetType();

            var values = Enum.GetNames(type);
            string enumString = enumvalue.ToString();
            string result = string.Empty;
            foreach (var v in values)
            {
                if (enumString.Contains(v.ToString()))
                {
                    if (result != string.Empty) result += " | ";
                    result += type.FullName + "." + v.ToString();
                }
            }
            return result;
        }
    }

}
