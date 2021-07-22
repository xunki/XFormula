using System;
using System.Data;
using System.IO;
using Antlr4.Runtime;
using Microsoft.ClearScript.V8;
using XFormula.Antlr4Gen;
using XFormula.Parser;
using Xunit;
using Xunit.Abstractions;

namespace XFormula.Test
{
    public class ExcelFormulaTest
    {
        private readonly ITestOutputHelper _console;
        private readonly V8ScriptEngine _engine = new();

        public ExcelFormulaTest(ITestOutputHelper console)
        {
            _console = console;
        }

        [Theory]
        [InlineData("5=9")]
        [InlineData("7+1")]
        [InlineData("IF(1<>2,666,777)+5")]
        [InlineData("ABS(9-11)")]
        [InlineData("POWER(3-1,4)")]
        [InlineData("MAX(3-1,4,7,1,99,123,45,12,1,58)")]
        [InlineData("MIN(3-1,4,7,1,99,123,45,12,1,58)")]
        [InlineData("SumSq(1,2,3)")]
        [InlineData("SUM(1,2,3)")]
        [InlineData("ROUND(115.141042,2)")]
        [InlineData("AVERAGE(1,2,3,4)")]
        [InlineData("SQRT(14+1)")]
        [InlineData("MOD(12,10)")]
        [InlineData("INT(15.8875212)")]
        [InlineData("RAND()")]
        [InlineData("-(1+2)*3")]
        [InlineData("TRUE")]
        [InlineData("OR(1=2,FALSE,FALSE)")]
        [InlineData("AND(1<2,TRUE,3=2+1)")]
        [InlineData("NOT(AND(1<2,TRUE,3=2+1))")]
        [InlineData("IF(1>2,\"OK\",\"TE\")")]
        public void Parse(string input)
        {
            _console.WriteLine("解析公式：" + input);

            var errorOutput = new StringWriter();
            var lexer = new ExcelFormulaLexer(CharStreams.fromString(input), new StringWriter(), errorOutput);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ExcelFormulaParser(tokens, new StringWriter(), errorOutput);
            var tree = parser.expr();
            var errMsg = errorOutput.ToString();
            if (!string.IsNullOrEmpty(errMsg))
                throw new SyntaxErrorException("解析错误：" + errMsg);

            var visitor = new ExcelFormulaParseVisitor();
            var visitResult = visitor.Visit(tree);
            var jsScript = visitResult == null ? "" : string.Concat(visitResult);
            _console.WriteLine("解析后公式：" + jsScript);
            try
            {
                _console.WriteLine("执行结果：" + _engine.ExecuteCommand(jsScript));
            }
            catch
            {
                _console.WriteLine("执行结果：异常");
            }
            _console.WriteLine("===============");
        }
    }
}