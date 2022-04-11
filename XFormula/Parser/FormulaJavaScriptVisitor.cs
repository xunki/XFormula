using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Antlr4.Runtime;
using XFormula.Antlr4Gen;

namespace XFormula.Parser;

public class FormulaJavaScriptVisitor : FormulaBaseVisitor<IEnumerable<string>>
{
    /// <summary>
    /// 子级指标编码
    /// </summary>
    public HashSet<string> SubCodes { get; } = new();

    /// <summary>
    /// 默认值
    /// </summary>
    private const string DEFAULT_VALUE = "0";

    public override IEnumerable<string> VisitAtom(FormulaParser.AtomContext context)
    {
        switch (context.Start.Type)
        {
            case FormulaParser.NUMBER:
                yield return context.NUMBER().GetText();
                break;
            case FormulaParser.VARIABLE:
                yield return "v['";
                var code = context.VARIABLE().GetText();
                SubCodes.Add(code);
                yield return code;
                yield return "']";
                break;
            case FormulaParser.MINUS:
                yield return "-";
                foreach (var value in Visit(context.atom()))
                    yield return value;
                break;
            default:
                yield return DEFAULT_VALUE;
                break;
        }
    }

    public override IEnumerable<string> VisitParens(FormulaParser.ParensContext context)
    {
        return Visit(context.expr());
    }

    #region 运算符
    public override IEnumerable<string> VisitOpFirst(FormulaParser.OpFirstContext context)
    {
        return VisitOperate(context.op, context);
    }

    public override IEnumerable<string> VisitOpSecond(FormulaParser.OpSecondContext context)
    {
        return VisitOperate(context.op, context);
    }

    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    private IEnumerable<string> VisitOperate(IToken op, FormulaParser.ExprContext context)
    {
        var left = Visit(context.GetRuleContext<FormulaParser.ExprContext>(0));
        var right = Visit(context.GetRuleContext<FormulaParser.ExprContext>(1));

        if (op.Type != FormulaParser.DIV)
        {
            foreach (var value in left)
                yield return value;

            yield return op.Text;

            foreach (var value in right)
                yield return value;
        }
        else
        {
            // 除法需要对除零时进行特殊处理，避免报错 
            // ( right == 0 ? 0 : left / right )
            yield return "(";
            foreach (var value in right)
                yield return value;

            yield return "==0?0:";

            foreach (var value in left)
                yield return value;

            yield return "/";

            foreach (var value in right)
                yield return value;

            yield return ")";
        }
    }
    #endregion

    #region 函数
    public override IEnumerable<string> VisitFunction(FormulaParser.FunctionContext context)
    {
        var func = context.func();
        return func.funcName().Start.Type switch
        {
            FormulaParser.ABS => VisitAbs(func),
            FormulaParser.ROUND => VisitRound(func),
            _ => throw new ArgumentOutOfRangeException("暂不支持函数 " + func.funcName().GetText())
        };
    }

    private IEnumerable<string> VisitAbs(FormulaParser.FuncContext context)
    {
        // Math.abs( value )
        var arg = Visit(context.expr(0));

        yield return "Math.abs(";

        foreach (var value in arg)
            yield return value;

        yield return ")";
    }

    private IEnumerable<string> VisitRound(FormulaParser.FuncContext context)
    {
        var exprContexts = context.expr();

        // Number( ( value ).toFixed( decimal ) )

        yield return "Number((";

        var valueExpr = Visit(exprContexts[0]);
        foreach (var value in valueExpr)
            yield return value;
        yield return ").toFixed(";

        if (exprContexts.Length <= 1)
            yield return "0";
        else
        {
            foreach (var value in Visit(exprContexts[1]))
                yield return value;
        }

        yield return "))";
    }
    #endregion

    /// <summary>
    /// 解析公式
    /// </summary>
    public static FormulaScript Parse(string formula)
    {
        var errorOutput = new StringWriter();
        var lexer = new FormulaLexer(CharStreams.fromString(formula),
            new StringWriter(), errorOutput);
        var tokens = new CommonTokenStream(lexer);
        var parser = new FormulaParser(tokens, new StringWriter(), errorOutput);
        var tree = parser.prog();
        var errMsg = errorOutput.ToString();
        if (errMsg.IsNotEmpty())
            throw new SyntaxErrorException($"公式：{formula} 错误：{errMsg}");

        var visitor = new FormulaJavaScriptVisitor();
        var expr = visitor.Visit(tree);

        var result = new FormulaScript { SubCodes = visitor.SubCodes };
        if (expr != null)
        {
            var script = string.Concat(expr);
            if (script.IsNotEmpty())
                result.Script = script;
        }
        result.Script ??= DEFAULT_VALUE;
        return result;
    }

    public class FormulaScript
    {
        public string Script { get; set; }
        public HashSet<string> SubCodes { get; set; }
    }
}