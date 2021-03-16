using System;
using System.Collections.Generic;
using System.Reflection;
using FastExpressionCompiler.LightExpression;
using XFormula.Antlr4Gen;
using static FastExpressionCompiler.LightExpression.Expression;

namespace XFormula.Parser
{
    public class FormulaFunction
    {
        public static IReadOnlyDictionary<int, MethodInfo> MethodInfos { get; } =
            new Dictionary<int, MethodInfo>
            {
                {FormulaParser.ABS, typeof(FormulaFunction).GetMethod(nameof(Abs))},
                {FormulaParser.ROUND, typeof(FormulaFunction).GetMethod(nameof(Round))}
            };

        public static MethodInfo ValueMethodInfo { get; } = typeof(FormulaFunction).GetMethod(nameof(GetValue));
        public static ParameterExpression ValuesExpr { get; } = Parameter(typeof(Dictionary<string, decimal>), "values");

        public static decimal GetValue(string code, Dictionary<string, decimal> values)
        {
            return values.GetValueOrDefault(code);
        }

        public static decimal Abs(decimal value)
        {
            return Math.Abs(value);
        }

        public static decimal Round(decimal value, int decimals)
        {
            return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
        }
    }
}