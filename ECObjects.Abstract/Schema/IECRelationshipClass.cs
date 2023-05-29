using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECObjects.Abstract.Common;
using ECObjects.Abstract.Schema.ECType;

namespace ECObjects.Abstract.Schema
{
    public interface IECRelationshipClass : IECClass, IECStructType, IECType, IECCustomAttributeContainer, IECObjectBase
    {
        IECRelationshipConstraint Source { get; }
        IECRelationshipConstraint Target { get; }

        /// <summary>
        /// 关系的强度
        /// </summary>
        StrengthType Strength { get; }

        /// <summary>
        /// 关系的方向
        /// </summary>
        RelatedInstanceDirection StrengthDirection { get; }
    }

    /// <summary>
    /// 描述 Relationship 的 源 和 目标
    /// </summary>
    public interface IECRelationshipConstraint : IECCustomAttributeContainer, IDump
    {
        /// <summary>
        /// 描述该约束是否可以作用于多个类
        /// </summary>
        bool IsMultiple { get; }

        /// <summary>
        /// 关系基数
        /// </summary>
        /// <remarks>
        /// (1,n) 就是 1对多
        /// (1,1) 就是 1对1
        /// </remarks>
        IECRelationshipCardinality Cardinality { get; set; }

        /// <summary>
        /// 是否多态，描述改关系是否可以作用于子类
        /// </summary>
        bool IsPolymorphic { get; set; }


        IECRelationshipConstraintClass AddClass(IECClass classConstraint);
        void RemoveClass(IECClass classConstraint);
        void ClearClasses();
        IECRelationshipConstraintClass[] GetClasses();

        /// <summary>
        /// 此方法不考虑多态
        /// </summary>
        /// <param name="ecClass"></param>
        /// <returns></returns>
        bool ContainsClass(IECClass ecClass);

        /// <summary>
        /// 此方法考虑多态
        /// </summary>
        /// <param name="ecClass"></param>
        /// <returns></returns>
        bool SupportsClass(IECClass ecClass);
    }

    /// <summary>
    /// 描述约束的类
    /// </summary>
    public interface IECRelationshipConstraintClass : IDump
    {
        /// <summary>
        /// 描述约束作用在哪个类上
        /// </summary>
        IECClass Class { get; }
    }

    /// <summary>
    /// 描述关系的基数，有效的技术是 (x,y) 
    /// x y 满足以下条件
    /// <para>x 小于等于 y</para>
    /// <para>x 大于等于 0</para>
    /// <para>y 大于等于 1, n 表示无穷大</para>
    /// For example, (0,1), (1,1), (1,n), (0,n), (1,10), (2,5), ...
    /// </summary>
    public interface IECRelationshipCardinality
    {
        int LowerLimit { get; }
        int UpperLimit { get; }
        bool IsUpperLimitUnbounded();
        string ToString();
    }


    /// <summary>
    /// 描述关系强度
    /// </summary>
    public enum StrengthType
    {
        /// <summary>
        /// 引用关系
        /// 当删除关系两端的关系时，没有级联删除
        /// For Example,文档对象引用了修改它的用户，当删除用户或者文档时，不应该删除另一个
        /// </summary>
        Referencing,
        /// <summary>
        /// 持有关系
        /// 一个对象可以被多个对象持有，除非先删除持有它的所有对象（或者断开关系），否则该对象不会被删除
        /// </summary>
        Holding,
        /// <summary>
        /// 嵌入关系
        /// 独占所有权
        /// For Example,文件夹嵌入了它包含的所有文档，当文件夹删除时，文件夹里的文档全部删除
        /// </summary>
        Embedding
    }

    /// <summary>
    /// 描述关系方向
    /// </summary>
    [Flags]
    public enum RelatedInstanceDirection
    {
        /// <summary>
        /// Related instance is the target in the relationship instance.
        /// </summary>
        Forward = 1,
        /// <summary>
        /// Related instance is the source in the relationship instance
        /// </summary>
        Backward = 2
    }
}
