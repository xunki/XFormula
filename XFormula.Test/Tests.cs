using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using FastExpressionCompiler.LightExpression;
using XFormula.Antlr4Gen;
using XFormula.Parser;
using Xunit;
using Xunit.Abstractions;

namespace XFormula.Test
{
    public class Tests
    {
        private readonly ITestOutputHelper _console;

        public Tests(ITestOutputHelper testOutputHelper)
        {
            _console = testOutputHelper;
        }

        [Fact]
        public void CalcViaNoCache()
        {
            var values = new Dictionary<string, decimal>
            {
                {"AA101", 15},
                {"CF711", 20},
                {"DD365", 61}
            };

            Assert.True(FormulaHelper.CalcFormulaValue("1 + 5 + 3", values, false) ==
                        1 + 5 + 3
            );
            Assert.True(FormulaHelper.CalcFormulaValue("(3.5 + 3.5 * 2 + 3.5) / 12 + 1", values, false) ==
                        (3.5M + 3.5M * 2 + 3.5M) / 12 + 1
            );
            Assert.True(FormulaHelper.CalcFormulaValue("ROUND((3.5 + 3.5 * 2 + 3.5) / 12 + 1, 2)", values, false) ==
                        Math.Round((3.5M + 3.5M * 2 + 3.5M) / 12M + 1, 2)
            );
            Assert.True(FormulaHelper.CalcFormulaValue("AA101 + CF711 * 2 + DD365", values, false) ==
                        values["AA101"] + values["CF711"] * 2 + values["DD365"]
            );
            Assert.True(FormulaHelper.CalcFormulaValue("(AA101 + CF711 * 2 + DD365) / 12 + 1", values, false) ==
                        (values["AA101"] + values["CF711"] * 2 + values["DD365"]) / 12 + 1
            );
            Assert.True(FormulaHelper.CalcFormulaValue("ROUND(ABS(-12.365),2)", values, false) ==
                        Math.Round(Math.Abs(-12.365M), 2, MidpointRounding.AwayFromZero)
            );
        }

        [Fact]
        public void CalcViaCache()
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
            Assert.True(FormulaHelper.CalcFormulaValue("(3.5 + 3.5 * 2 + 3.5) / 12 + 1", values) ==
                        (3.5M + 3.5M * 2 + 3.5M) / 12 + 1
            );
            Assert.True(FormulaHelper.CalcFormulaValue("ROUND((3.5 + 3.5 * 2 + 3.5) / 12 + 1, 2)", values) ==
                        Math.Round((3.5M + 3.5M * 2 + 3.5M) / 12M + 1, 2)
            );
            Assert.True(FormulaHelper.CalcFormulaValue("AA101 + CF711 * 2 + DD365", values) ==
                        values["AA101"] + values["CF711"] * 2 + values["DD365"]
            );
            Assert.True(FormulaHelper.CalcFormulaValue("(AA101 + CF711 * 2 + DD365) / 12 + 1", values) ==
                        (values["AA101"] + values["CF711"] * 2 + values["DD365"]) / 12 + 1
            );
            Assert.True(FormulaHelper.CalcFormulaValue("ROUND(ABS(-12.365),2)", values) ==
                        Math.Round(Math.Abs(-12.365M), 2, MidpointRounding.AwayFromZero)
            );
        }

        [Fact]
        public void CalcNestValues()
        {
            var values = new Dictionary<string, decimal>
            {
                {"AA101", 15},
                {"CF711", 20},
                {"DD365", 61}
            };
            var formulas = new List<Formula>
            {
                new() {Code = "AA101", IsLowest = true},
                new() {Code = "CF711", IsLowest = true},
                new() {Code = "DD365", IsLowest = true},
                new() {Code = "AA105", FormulaText = "(DD365+AA101*2+CF711)/12-AA104"},
                new() {Code = "AA102", FormulaText = "AA101+1"},
                new() {Code = "AA103", FormulaText = "AA102*2"},
                new() {Code = "AA104", FormulaText = "AA101*2+CF711-5"},
            }.ToDictionary(f => f.Code, f => f);
            values = FormulaHelper.CalcNestFormulaValue(formulas, values);

            Assert.True(values["AA101"] == 15);
            Assert.True(values["CF711"] == 20);
            Assert.True(values["DD365"] == 61);
            Assert.True(values["AA105"] == (values["DD365"] + values["AA101"] * 2 + values["CF711"]) / 12 -
                (values["AA101"] * 2 + values["CF711"] - 5));
            Assert.True(values["AA102"] == values["AA101"] + 1);
            Assert.True(values["AA103"] == (values["AA101"] + 1) * 2);
            Assert.True(values["AA104"] == values["AA101"] * 2 + values["CF711"] - 5);
        }
    }
}