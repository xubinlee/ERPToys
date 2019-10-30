using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    /// <summary>
    /// 类型转换帮助类
    /// </summary>
    public static class TypeConvertHelper
    {
        /// <summary>
        /// 把bool转为short类型
        /// </summary>
        /// <param name="value">可为空bool值</param>
        /// <returns>转换后的short对象</returns>
        public static short ToShort(this bool? value)
        {
            if (!value.HasValue)
            {
                return -1;
            }
            else if (value.Value)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 把可为null的Guid转换为Guid
        /// </summary>
        /// <param name="value">可为空Guid</param>
        /// <returns>转换后的Guid对象</returns>
        public static Guid ToGuid(this Guid? value)
        {
            if (!value.HasValue)
            {
                return Guid.Empty;
            }
            else
            {
                return value.Value;
            }
        }

        #region Guid ExtensionMethods
        public static bool IsNullOrEmpty(this Guid? id)
        {
            return id == null || id == Guid.Empty;
        }
        public static bool IsNullOrEmpty(this Guid id)
        {
            return id == Guid.Empty;
        }
        #endregion

        /// <summary>
        /// 尝试转换成Guid
        /// 异常时返回Guid.Empty
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Guid GetGuid(object o)
        {
            try
            {
                return (Guid)o;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// 把时间数组转换为字符串
        /// </summary>
        /// <param name="values">Guid数组</param>
        /// <returns>返回转换后的字符串</returns>
        public static string Join(this DateTime[] values)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (DateTime value in values)
            {
                result.Append(GlobalConstants.DividedSymbol);

                if (value == DateTime.MinValue)
                {
                    result.Append("");
                }
                else
                {
                    result.Append(value.ToString(GlobalConstants.DATETIMEFORMAT) + "." + value.Millisecond.ToString("000"));
                }
            }

            result = result.Remove(0, GlobalConstants.DividedSymbol.Length);

            return result.ToString();
        }


        /// <summary>
        /// 把时间数组转换为字符串
        /// </summary>
        /// <param name="values">Guid数组</param>
        /// <returns>返回转换后的字符串</returns>
        public static string Join(this DateTime?[] values)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (DateTime? value in values)
            {
                result.Append(GlobalConstants.DividedSymbol);

                if (value.HasValue == false || value == DateTime.MinValue)
                {
                    result.Append("");
                }
                else
                {
                    result.Append(value.Value.ToString(GlobalConstants.DATETIMEFORMAT) + "." + value.Value.Millisecond.ToString("000"));
                }
            }

            result = result.Remove(0, GlobalConstants.DividedSymbol.Length);

            return result.ToString();
        }


        /// <summary>
        /// 把decimal数组转换为字符串
        /// </summary>
        /// <param name="values">Int数组</param>
        /// <param name="preserDigits">保留位数</param>
        /// <returns>转换后的字符串</returns>
        public static string Join(
            this decimal[] values,
            int preserDigits)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            string formart = string.Format("F{0}", preserDigits);

            StringBuilder result = new StringBuilder();

            foreach (decimal value in values)
            {
                result.Append(GlobalConstants.DividedSymbol);

                result.Append(value.ToString(formart));
            }

            result = result.Remove(0, GlobalConstants.DividedSymbol.Length);

            return result.ToString();
        }


        /// <summary>
        /// 把Guid数组转换为字符串
        /// </summary>
        /// <param name="values">Guid数组</param>
        /// <returns>返回转换后的字符串</returns>
        public static string Join(this Guid[] values)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (Guid value in values)
            {
                result.Append(GlobalConstants.DividedSymbol);

                if (value == Guid.Empty)
                {
                    result.Append("");
                }
                else
                {
                    result.Append(value.ToString());
                }
            }

            if (result.Length > 0)
            {
                result = result.Remove(0, GlobalConstants.DividedSymbol.Length);
            }

            return result.ToString();
        }

        /// <summary>
        /// 把Guid数组转换为字符串
        /// </summary>
        /// <param name="values">Guid数组</param>
        /// <returns>返回转换后的字符串</returns>
        public static string Join(this Guid?[] values)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (Guid? value in values)
            {
                result.Append(GlobalConstants.DividedSymbol);

                if (value == null || value == Guid.Empty)
                {
                    result.Append("");
                }
                else
                {
                    result.Append(value.ToString());
                }
            }

            if (result.Length > 0)
            {
                result = result.Remove(0, GlobalConstants.DividedSymbol.Length);
            }

            return result.ToString();
        }


        /// <summary>
        /// 把Int数组转换为字符串
        /// </summary>
        /// <param name="values">Int数组</param>
        /// <returns>转换后的字符串</returns>
        public static string Join(this int[] values)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (int value in values)
            {
                result.Append(GlobalConstants.DividedSymbol);

                result.Append(value.ToString());
            }

            if (result.Length > 0)
            {
                result = result.Remove(0, GlobalConstants.DividedSymbol.Length);
            }

            return result.ToString();
        }


        /// <summary>
        /// 把Short数组转换为字符串
        /// </summary>
        /// <param name="values">Int数组</param>
        /// <returns>转换后的字符串</returns>
        public static string Join(this short[] values)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (short value in values)
            {
                result.Append(GlobalConstants.DividedSymbol);

                result.Append(value.ToString());
            }

            if (result.Length > 0)
            {
                result = result.Remove(0, GlobalConstants.DividedSymbol.Length);
            }

            return result.ToString();
        }


        /// <summary>
        /// 把Int数组转换为字符串
        /// </summary>
        /// <param name="values">Int数组</param>
        /// <returns>转换后的字符串</returns>
        public static string Join(this bool[] values)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();

            foreach (bool value in values)
            {
                result.Append(GlobalConstants.DividedSymbol);

                if (value)
                {
                    result.Append("1");
                }
                else
                {
                    result.Append("0");
                }
            }

            if (result.Length > 0)
            {
                result = result.Remove(0, GlobalConstants.DividedSymbol.Length);
            }

            return result.ToString();
        }

        /// <summary>
        /// 把String数组转换为字符串
        /// </summary>
        /// <param name="values">String数组</param>
        /// <returns>返回转换后的字符串</returns>
        public static string Join(this string[] values)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (string value in values)
            {
                result.Append(GlobalConstants.DividedSymbol);

                result.Append(value);
            }

            if (result.Length > 0)
            {
                result = result.Remove(0, GlobalConstants.DividedSymbol.Length);
            }

            return result.ToString();
        }

        /// <summary>
        /// 把String数组转换为字符串
        /// </summary>
        /// <param name="values">String数组</param>
        /// <param name="divideSymbol">分隔符</param>
        /// <returns>返回转换后的字符串</returns>
        public static string Join(this string[] values, string divideSymbol)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (string value in values)
            {
                result.Append(divideSymbol);

                result.Append(value);
            }

            if (result.Length > 0)
            {
                result = result.Remove(0, divideSymbol.Length);
            }

            return result.ToString();
        }


        /// <summary>
        /// 把Short数组转换为字符串
        /// </summary>
        /// <param name="values">Int数组</param>
        /// <returns>转换后的字符串</returns>
        public static string Join<T>(this T[] values)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            foreach (object value in values)
            {
                result.Append(GlobalConstants.DividedSymbol);

                if (value == null)
                {
                    continue;
                }

                if (value.GetType().IsEnum)
                {
                    result.Append(((int)value));
                }
                else
                {
                    result.Append(value.ToString());
                }
            }

            if (result.Length > 0)
            {
                result = result.Remove(0, GlobalConstants.DividedSymbol.Length);
            }

            return result.ToString();
        }

    }
}
