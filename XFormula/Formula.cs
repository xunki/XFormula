using System;
using System.Collections.Generic;

namespace XFormula
{
    public class Formula
    {
        /// <summary>
        /// 所需指标变量
        /// </summary>
        public string[] Variables { get; set; }
        
        /// <summary>
        /// 公式计算方法
        /// </summary>
        public Func<Dictionary<string, decimal>, decimal> CalcFunc { get; set; }
    }
}