using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.ClearScript.V8;
using XFormula.Parser;
using Xunit;
using Xunit.Abstractions;

namespace XFormula.Test;

public class FormulaJavaScriptTest
{
    private readonly ITestOutputHelper _console;
    private readonly V8ScriptEngine _engine = new();

    public FormulaJavaScriptTest(ITestOutputHelper console)
    {
        _console = console;
        _engine.ExecuteCommand("var v = { 'AA101': 15, 'CF711': 20, 'DD365': 61 }");
    }

    [Fact]
    public void Test()
    {
        Validate("1 + 5 + 3 / 0 + 1");

        Validate("(3.5 + 3.5 * 2 + 3.5) / 12 + 1");

        Validate("ROUND((3.5 + 3.5 * 2 + 3.5) / 12 + 1, 2)");

        Validate("ROUND(ABS(-12.365),2)");

        Validate("AA101 + CF711 * 2 + DD365");

        Validate("(AA101 + CF711 * 2 + DD365) / 12 + 1");

        Validate("(((2+1)))");
    }

    private void Validate(string formula)
    {
        _console.WriteLine("公式：" + formula);
        var formulaScript = FormulaJavaScriptVisitor.Parse(formula);
        _console.WriteLine("包含指标：" + string.Join(",", formulaScript.SubCodes));
        _console.WriteLine("解析为：" + formulaScript.Script);
        _console.WriteLine("执行结果：" + _engine.ExecuteCommand($"eval(\"{formulaScript.Script}\")"));
        _console.WriteLine("");
    }
}