using System;
using System.Collections.Generic;
using System.Reflection;
using FastExpressionCompiler.LightExpression;
using XFormula.Antlr4Gen;
using static FastExpressionCompiler.LightExpression.Expression;

namespace XFormula.Parser
{
    internal class FormulaFunction
    {
        #region 函数
        public static IReadOnlyDictionary<int, MethodInfo> MethodInfos { get; } =
            new Dictionary<int, MethodInfo>
            {
                {FormulaParser.ABS, typeof(FormulaFunction).GetMethod(nameof(Abs))},
                {FormulaParser.ROUND, typeof(FormulaFunction).GetMethod(nameof(Round))}
            };

        public static decimal Abs(decimal value)
        {
            return Math.Abs(value);
        }

        public static decimal Round(decimal value, int decimals)
        {
            return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
        }
        #endregion

        #region 获取值的方法
        public static MethodInfo ValueMethodInfo { get; } = typeof(FormulaFunction).GetMethod(nameof(GetValue));
        public static MethodInfo ValueByFuncMethodInfo { get; } = typeof(FormulaFunction).GetMethod(nameof(GetValueByFunc));
        public static ParameterExpression ValuesExpr { get; } = Parameter(typeof(Dictionary<string, decimal>), "values");
        public static ParameterExpression FormulasExpr { get; } = Parameter(typeof(Dictionary<string, Formula>), "formulas");
        public static ParameterExpression CodeExpr { get; } = Parameter(typeof(string), "code");

        public static decimal GetValue(string code, Dictionary<string, decimal> values)
        {
            return values.GetValueOrDefault(code);
        }

        public static decimal GetValueByFunc(string code, Dictionary<string, Formula> formulas,
            Dictionary<string, decimal> values)
        {
            if (!formulas.TryGetValue(code, out var formula))
                throw new ArgumentException($"无法计算编码 {code}，可能无法解析其公式中使用的其他编码");

            return formula.GetValue(formulas, values);
        }
        #endregion
    }
}