using System;
using System.Collections.Generic;

namespace XFormula
{
    public class Formula
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 公式
        /// </summary>
        public string FormulaText { get; set; }

        /// <summary>
        /// 是否为最底级
        /// </summary>
        public bool IsLowest { get; set; }

        /// <summary>
        /// 计算值的方法
        /// </summary>
        public Func<Dictionary<string, Formula>, Dictionary<string, decimal>, decimal> CalcFunc { get; set; }

        /// <summary>
        /// 计算结果缓存
        /// </summary>
        private decimal? _cachedValue;

        /// <summary>
        /// 获取计算结果
        /// </summary>
        public decimal GetValue(Dictionary<string, Formula> formulas, Dictionary<string, decimal> values)
        {
            if (_cachedValue.HasValue)
                return _cachedValue.Value;

            var value = IsLowest ? values.GetValueOrDefault(Code) : CalcFunc(formulas, values);
            _cachedValue = value;
            return value;
        }

        public void Cleanup()
        {
            _cachedValue = null;
            CalcFunc = null;
        }
    }
}