using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Antlr4.Runtime;
using FastExpressionCompiler.LightExpression;
using XFormula.Antlr4Gen;
using static FastExpressionCompiler.LightExpression.Expression;

namespace XFormula.Parser
{
    public class NestFormulaExpressionVisitor : FormulaExpressionVisitor
    {
        private NestFormulaExpressionVisitor(Dictionary<string, Formula> formulas)
        {
            _formulas = formulas;
        }

        private readonly Dictionary<string, Formula> _formulas;

        /// <summary>
        /// 不允许缺少的公式配置
        /// </summary>
        private readonly bool _notAllowAbsentFormula = true;

        public override Expression VisitAtom(FormulaParser.AtomContext context)
        {
            if (context.Start.Type != FormulaParser.VARIABLE)
                return base.VisitAtom(context);

            var code = context.VARIABLE().GetText();
            if (!_formulas.TryGetValue(code, out var formula) && _notAllowAbsentFormula)
                throw new ArgumentException($"无法找到编码 {code} 对应的依赖关系");

            // 如果计算函数未生成，则进行解析
            if (formula.CalcFunc == null)
                Parse(formula, _formulas);

            return Call(FormulaFunction.ValueByFuncMethodInfo, Constant(context.VARIABLE().GetText()),
                FormulaFunction.FormulasExpr, FormulaFunction.ValuesExpr);
        }

        public static void Parse(Formula formula, Dictionary<string, Formula> formulas)
        {
            if (formula.IsLowest)
                return;

            var errorOutput = new StringWriter();
            var lexer = new FormulaLexer(CharStreams.fromString(formula.FormulaText), new StringWriter(), errorOutput);
            var tokens = new CommonTokenStream(lexer);
            var parser = new FormulaParser(tokens, new StringWriter(), errorOutput);
            var tree = parser.prog();
            var errMsg = errorOutput.ToString();
            if (errMsg.IsNotEmpty())
                throw new SyntaxErrorException($"公式：{formula.FormulaText} 错误：{errMsg}");

            var visitor = new NestFormulaExpressionVisitor(formulas);
            var expr = visitor.Visit(tree);
            formula.CalcFunc = Lambda<Func<Dictionary<string, Formula>, Dictionary<string, decimal>, decimal>>(
                expr, FormulaFunction.FormulasExpr, FormulaFunction.ValuesExpr).CompileFast();
        }
    }
}