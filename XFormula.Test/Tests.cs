using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Antlr4.Runtime;
using FastExpressionCompiler.LightExpression;
using XFormula.Antlr4Gen;
using XFormula.Parser;
using Xunit;

namespace XFormula.Test
{
    public class Tests
    {
        private FormulaParser.ProgContext GetParseTree(string input)
        {
            var output = new StringWriter();
            var errorOutput = new StringWriter();

            var lexer = new FormulaLexer(CharStreams.fromString(input), output, errorOutput);
            var tokens = new CommonTokenStream(lexer);
            var parser = new FormulaParser(tokens, output, errorOutput);

            var tree = parser.prog();
            var errMsg = errorOutput.ToString();
            if (!string.IsNullOrEmpty(errMsg))
                throw new SyntaxErrorException(errMsg);
            return tree;
        }

        public decimal CalcByVisitorImpl(string input, Dictionary<string, decimal> values)
        {
            var tree = GetParseTree(input);
            var visitor = new FormulaCalcVisitor(values);
            var value = visitor.Visit(tree);
            return value;
        }

        public decimal ExpressionByVisitorImpl(string input, Dictionary<string, decimal> values)
        {
            var tree = GetParseTree(input);
            var visitor = new FormulaExpressionVisitor();
            var expr = visitor.Visit(tree);
            var func = Expression.Lambda<Func<Dictionary<string, decimal>, decimal>>
                (expr, FormulaFunction.ValuesExpr).CompileFast();
            return func(values);
        }

        [Fact]
        public void CalcByVisitor()
        {
            var values = new Dictionary<string, decimal>
            {
                {"AA101", 15},
                {"CF711", 20},
                {"DD365", 61}
            };

            Assert.True(CalcByVisitorImpl("1 + 5 + 3", values) ==
                        1 + 5 + 3
            );
            Assert.True(CalcByVisitorImpl("(3.5 + 3.5 * 2 + 3.5) / 12 + 1", values) ==
                        (3.5M + 3.5M * 2 + 3.5M) / 12 + 1
            );
            Assert.True(CalcByVisitorImpl("ROUND((3.5 + 3.5 * 2 + 3.5) / 12 + 1, 2)", values) ==
                        Math.Round((3.5M + 3.5M * 2 + 3.5M) / 12M + 1, 2)
            );
            Assert.True(CalcByVisitorImpl("AA101 + CF711 * 2 + DD365", values) ==
                        values["AA101"] + values["CF711"] * 2 + values["DD365"]
            );
            Assert.True(CalcByVisitorImpl("(AA101 + CF711 * 2 + DD365) / 12 + 1", values) ==
                        (values["AA101"] + values["CF711"] * 2 + values["DD365"]) / 12 + 1
            );
            Assert.True(CalcByVisitorImpl("ROUND(ABS(-12.365),2)", values) ==
                        Math.Round(Math.Abs(-12.365M), 2, MidpointRounding.AwayFromZero)
            );
        }

        [Fact]
        public void CalcByExpressionVisitor()
        {
            var values = new Dictionary<string, decimal>
            {
                {"AA101", 15},
                {"CF711", 20},
                {"DD365", 61}
            };

            Assert.True(ExpressionByVisitorImpl("1 + 5 + 3", values) ==
                        1 + 5 + 3
            );
            Assert.True(ExpressionByVisitorImpl("(3.5 + 3.5 * 2 + 3.5) / 12 + 1", values) ==
                        (3.5M + 3.5M * 2 + 3.5M) / 12 + 1
            );
            Assert.True(ExpressionByVisitorImpl("ROUND((3.5 + 3.5 * 2 + 3.5) / 12 + 1, 2)", values) ==
                        Math.Round((3.5M + 3.5M * 2 + 3.5M) / 12M + 1, 2)
            );
            Assert.True(ExpressionByVisitorImpl("AA101 + CF711 * 2 + DD365", values) ==
                        values["AA101"] + values["CF711"] * 2 + values["DD365"]
            );
            Assert.True(ExpressionByVisitorImpl("(AA101 + CF711 * 2 + DD365) / 12 + 1", values) ==
                        (values["AA101"] + values["CF711"] * 2 + values["DD365"]) / 12 + 1
            );
            Assert.True(ExpressionByVisitorImpl("ROUND(ABS(-12.365),2)", values) ==
                        Math.Round(Math.Abs(-12.365M), 2, MidpointRounding.AwayFromZero)
            );
        }

        [Fact]
        public void CalcByHelper()
        {
            var values = new Dictionary<string, decimal>
            {
                {"AA101", 15},
                {"CF711", 20},
                {"DD365", 61}
            };

            Assert.True(FormulaHelper.CalcFormulaValue("1 + 5 + 3", values) ==
                        1 + 5 + 3
            );
            Assert.True(FormulaHelper.CalcFormulaValue("1 + 5 + 3", values) ==
                        1 + 5 + 3
            );
            Assert.True(FormulaHelper.CalcFormulaValue("(AA101 + CF711 * 2 + DD365) / 12 + 1", values) ==
                        (values["AA101"] + values["CF711"] * 2 + values["DD365"]) / 12 + 1
            );
            Assert.True(FormulaHelper.CalcFormulaValue("(AA101 + CF711 * 2 + DD365) / 12 + 1", values) ==
                        (values["AA101"] + values["CF711"] * 2 + values["DD365"]) / 12 + 1
            );
        }
    }
}