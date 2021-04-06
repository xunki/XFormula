using System.Collections.Generic;

namespace XFormula
{
    public class NestFormulaParsedNode
    {
        /// <summary>
        /// 节点名称，例：单车财务费用(A0205035) = 销售业务财务费用(Z01005035)/新车总销量(Z01005036)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 节点值，例：644.5132
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<NestFormulaParsedNode> Children { get; set; }
    }
}