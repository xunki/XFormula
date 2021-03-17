using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
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

        private readonly Dictionary<string, decimal> _values = new()
        {
            {"AA101", 15},
            {"CF711", 20},
            {"DD365", 61}
        };

        private readonly Dictionary<string, Formula> _formulas = new List<Formula>
        {
            new() {Code = "AA102", FormulaText = "AA101+1"},
            new() {Code = "AA101", IsLowest = true},
            new() {Code = "CF711", IsLowest = true},
            new() {Code = "DD365", IsLowest = true},
            new() {Code = "AA105", FormulaText = "(DD365+AA101*2+CF711)/12-AA104"},
            new() {Code = "AA103", FormulaText = "AA102*2"},
            new() {Code = "AA104", FormulaText = "AA101*2+CF711-5"},
        }.ToDictionary(f => f.Code, f => f);

        [Fact]
        public void CalcViaNoCache()
        {
            Assert.True(FormulaHelper.CalcFormulaValue("1 + 5 + 3", _values, false) ==
                        1 + 5 + 3
            );
            Assert.True(FormulaHelper.CalcFormulaValue("(3.5 + 3.5 * 2 + 3.5) / 12 + 1", _values, false) ==
                        (3.5M + 3.5M * 2 + 3.5M) / 12 + 1
            );
            Assert.True(FormulaHelper.CalcFormulaValue("ROUND((3.5 + 3.5 * 2 + 3.5) / 12 + 1, 2)", _values, false) ==
                        Math.Round((3.5M + 3.5M * 2 + 3.5M) / 12M + 1, 2)
            );
            Assert.True(FormulaHelper.CalcFormulaValue("AA101 + CF711 * 2 + DD365", _values, false) ==
                        _values["AA101"] + _values["CF711"] * 2 + _values["DD365"]
            );
            Assert.True(FormulaHelper.CalcFormulaValue("(AA101 + CF711 * 2 + DD365) / 12 + 1", _values, false) ==
                        (_values["AA101"] + _values["CF711"] * 2 + _values["DD365"]) / 12 + 1
            );
            Assert.True(FormulaHelper.CalcFormulaValue("ROUND(ABS(-12.365),2)", _values, false) ==
                        Math.Round(Math.Abs(-12.365M), 2, MidpointRounding.AwayFromZero)
            );
        }

        [Fact]
        public void CalcViaCache()
        {
            Assert.True(FormulaHelper.CalcFormulaValue("1 + 5 + 3", _values) ==
                        1 + 5 + 3
            );
            Assert.True(FormulaHelper.CalcFormulaValue("(3.5 + 3.5 * 2 + 3.5) / 12 + 1", _values) ==
                        (3.5M + 3.5M * 2 + 3.5M) / 12 + 1
            );
            Assert.True(FormulaHelper.CalcFormulaValue("ROUND((3.5 + 3.5 * 2 + 3.5) / 12 + 1, 2)", _values) ==
                        Math.Round((3.5M + 3.5M * 2 + 3.5M) / 12M + 1, 2)
            );
            Assert.True(FormulaHelper.CalcFormulaValue("AA101 + CF711 * 2 + DD365", _values) ==
                        _values["AA101"] + _values["CF711"] * 2 + _values["DD365"]
            );
            Assert.True(FormulaHelper.CalcFormulaValue("(AA101 + CF711 * 2 + DD365) / 12 + 1", _values) ==
                        (_values["AA101"] + _values["CF711"] * 2 + _values["DD365"]) / 12 + 1
            );
            Assert.True(FormulaHelper.CalcFormulaValue("ROUND(ABS(-12.365),2)", _values) ==
                        Math.Round(Math.Abs(-12.365M), 2, MidpointRounding.AwayFromZero)
            );
        }

        [Fact]
        public void CalcNestValues()
        {
            var values = FormulaHelper.CalcNestFormulaValue(_formulas, _values);

            Assert.True(values["AA101"] == 15);
            Assert.True(values["CF711"] == 20);
            Assert.True(values["DD365"] == 61);
            Assert.True(values["AA105"] == (values["DD365"] + values["AA101"] * 2 + values["CF711"]) / 12 -
                (values["AA101"] * 2 + values["CF711"] - 5));
            Assert.True(values["AA102"] == values["AA101"] + 1);
            Assert.True(values["AA103"] == (values["AA101"] + 1) * 2);
            Assert.True(values["AA104"] == values["AA101"] * 2 + values["CF711"] - 5);
        }

        [Fact]
        private void CalcNestValuesBenchmark()
        {
            for (var i = 0; i < 10; i++)
            {
                var sw = Stopwatch.StartNew();
                for (var j = 0; j < 1000; j++)
                {
                    FormulaHelper.CalcNestFormulaValue(_formulas.Adapt<Dictionary<string, Formula>>(), _values);
                }
                Assert.True(_formulas.Values.All(f => f.CalcFunc == null));
                _console.WriteLine("耗时：" + sw.ElapsedMilliseconds);
            }
        }

        [Fact]
        private void CalcNestValuesCache()
        {
            var f1 = _formulas.Adapt<Dictionary<string, Formula>>();
            var values = FormulaHelper.CalcNestFormulaValue(f1, _values);
            Assert.True(values["AA105"] == (values["DD365"] + values["AA101"] * 2 + values["CF711"]) / 12 -
                (values["AA101"] * 2 + values["CF711"] - 5));
            _console.WriteLine(values["AA105"].ToString("F4"));

            var f2 = _formulas.Adapt<Dictionary<string, Formula>>();
            f2["AA104"].FormulaText += "+10";
            values = FormulaHelper.CalcNestFormulaValue(f2, _values);
            Assert.True(values["AA105"] == (values["DD365"] + values["AA101"] * 2 + values["CF711"]) / 12 -
                (values["AA101"] * 2 + values["CF711"] - 5 + 10));
            _console.WriteLine(values["AA105"].ToString("F4"));

            var f3 = _formulas.Adapt<Dictionary<string, Formula>>();
            f3["AA104"].FormulaText += "+20";
            values = FormulaHelper.CalcNestFormulaValue(f3, _values);
            Assert.True(values["AA105"] == (values["DD365"] + values["AA101"] * 2 + values["CF711"]) / 12 -
                (values["AA101"] * 2 + values["CF711"] - 5 + 20));
            _console.WriteLine(values["AA105"].ToString("F4"));
        }
    }
}