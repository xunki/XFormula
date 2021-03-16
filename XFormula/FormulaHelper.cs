using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Antlr4.Runtime;
using FastExpressionCompiler.LightExpression;
using XFormula.Antlr4Gen;
using XFormula.Parser;

namespace XFormula
{
    public class FormulaHelper
    {
        /// <summary>
        /// 缓存 (暂不自动清理)
        /// </summary>
        private static readonly ConcurrentDictionary<string, Formula> Cache = new();

        /// <summary>
        /// 解析公式
        /// </summary>
        private static Formula GetFormula(string formulaText)
        {
            // 检查公式是否存在缓存
            if (Cache.TryGetValue(formulaText, out var formula1))
                return formula1;
            lock ($"{nameof(FormulaHelper)}_{formulaText}")
            {
                if (Cache.TryGetValue(formulaText, out var formula2))
                    return formula2;

                // 无缓存则进行公式解析
                var errorOutput = new StringWriter();
                var lexer = new FormulaLexer(CharStreams.fromString(formulaText), new StringWriter(), errorOutput);
                var tokens = new CommonTokenStream(lexer);
                var parser = new FormulaParser(tokens, new StringWriter(), errorOutput);
                var tree = parser.prog();
                var errMsg = errorOutput.ToString();
                if (errMsg.IsNotEmpty())
                    throw new SyntaxErrorException($"公式：{formulaText} 错误：{errMsg}");

                var visitor = new FormulaExpressionVisitor();
                var expr = visitor.Visit(tree);
                var formula = new Formula
                {
                    Variables = visitor.Variables.ToArray(),
                    CalcFunc = Expression.Lambda<Func<Dictionary<string, decimal>, decimal>>(
                        expr, FormulaFunction.ValuesExpr).CompileFast()
                };
                Cache[formulaText] = formula;
                return formula;
            }
        }

        /// <summary>
        /// 计算公式值
        /// </summary>
        public static decimal CalcFormulaValue(string formulaText, Dictionary<string, decimal> values)
        {
            var formula = GetFormula(formulaText);
            return formula.CalcFunc(values);
        }
    }
}