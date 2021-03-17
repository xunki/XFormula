﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using FastExpressionCompiler.LightExpression;
using XFormula.Antlr4Gen;
using XFormula.Parser;

namespace XFormula
{
    public class FormulaHelper
    {
        #region 计算公式值 (不支持嵌套)
        /// <summary>
        /// 方法缓存 (暂不自动清理)
        /// </summary>
        private static readonly ConcurrentDictionary<string, Func<Dictionary<string, decimal>, decimal>> NoNestCache = new();

        /// <summary>
        /// 解析公式
        /// </summary>
        private static Func<Dictionary<string, decimal>, decimal> GetNoNestCalcFunc(string formulaText)
        {
            // 检查公式是否存在缓存
            if (NoNestCache.TryGetValue(formulaText, out var func1))
                return func1;
            lock ($"{nameof(FormulaHelper)}_{formulaText}")
            {
                if (NoNestCache.TryGetValue(formulaText, out var func2))
                    return func2;

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
                var func = Expression.Lambda<Func<Dictionary<string, decimal>, decimal>>(
                    expr, FormulaFunction.ValuesExpr).CompileFast();
                NoNestCache[formulaText] = func;
                return func;
            }
        }

        /// <summary>
        /// 计算公式值 (不支持嵌套)
        /// </summary>
        public static decimal CalcFormulaValue(string formulaText, Dictionary<string, decimal> values, bool useCache = true)
        {
            if (useCache)
            {
                var func = GetNoNestCalcFunc(formulaText);
                return func(values);
            }

            // 不使用缓存则直接进行计算
            var errorOutput = new StringWriter();
            var lexer = new FormulaLexer(CharStreams.fromString(formulaText), new StringWriter(), errorOutput);
            var tokens = new CommonTokenStream(lexer);
            var parser = new FormulaParser(tokens, new StringWriter(), errorOutput);
            var tree = parser.prog();
            var errMsg = errorOutput.ToString();
            if (errMsg.IsNotEmpty())
                throw new SyntaxErrorException($"公式：{formulaText} 错误：{errMsg}");

            var visitor = new FormulaCalcVisitor(values);
            return visitor.Visit(tree);
        }
        #endregion

        #region 计算公式值/解析公式 (支持嵌套)
        /// <summary>
        /// 已解析公式缓存 (暂不自动清理)
        /// </summary>
        private static readonly ConcurrentDictionary<string, Formula> NestFormulaCache = new();

        /// <summary>
        /// 计算公式值 (支持嵌套)
        /// </summary>
        public static Dictionary<string, decimal> CalcNestFormulaValue(Dictionary<string, Formula> formulas,
            Dictionary<string, decimal> values)
        {
            ParseNestFormula(formulas);
            return formulas.Values.ToDictionary(f => f.Code,
                f => f.GetValue(formulas, values));
        }

        /// <summary>
        /// 解析嵌套公式
        /// </summary>
        public static void ParseNestFormula(Dictionary<string, Formula> formulas)
        {
            foreach (var formula in formulas.Values)
            {
                // TODO 使用缓存
                NestFormulaExpressionVisitor.Parse(formula, formulas);
            }
        }
        #endregion
    }
}