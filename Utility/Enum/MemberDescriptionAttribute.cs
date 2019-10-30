namespace Utility
{
    using System;

    /// <summary>
    /// 枚举成员描述特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class MemberDescriptionAttribute : Attribute
    {
        /// <summary>
        /// 中文描述
        /// </summary>
        public string CDescription { get; set; }

        /// <summary>
        /// 英文描述
        /// </summary>
        public string EDescription { get; set; }
        /// <summary>
        /// 另外的含义
        /// </summary>
        public string SimpleMeaning { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="description"></param>
        public MemberDescriptionAttribute(string description)
        {
            this.CDescription = description;
            this.EDescription = description;
            this.SimpleMeaning = description;
        }
        public MemberDescriptionAttribute(string simpleMeaning,string cDescriprion,string eDescription)
        {
            this.SimpleMeaning = simpleMeaning;
            this.CDescription = cDescriprion;
            this.EDescription = EDescription;
        }
        

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cDescription">中文描述</param>
        /// <param name="eDescription">英文描述</param>
        public MemberDescriptionAttribute(
            string cDescription,
            string eDescription)
        {
            this.CDescription = cDescription;
            this.EDescription = eDescription;
        }
    }
}
