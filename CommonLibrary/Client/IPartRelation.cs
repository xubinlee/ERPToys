using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Client
{
    /// <summary>
    /// 处理部件之间关系
    /// </summary>
    public interface IPartRelation : IBuilderStrategy
    {
        /// <summary>
        /// 关系名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 当前场景中，需要建立关系的部件的名称
        /// </summary>
        List<string> PartNames { get; set; }

        /// <summary>
        /// 交互控制逻辑处理类类型,必须实现IRelationController
        /// </summary>
        Type Controller { get; set; }

    }
}
