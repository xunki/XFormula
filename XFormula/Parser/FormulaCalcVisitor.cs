using System;
using System.Collections.Generic;
using XFormula.Antlr4Gen;

namespace XFormula.Parser
{
    public class FormulaCalcVisitor : FormulaBaseVisitor<decimal>
    {
        private const decimal DEFAULT_VALUE = default;

        public FormulaCalcVisitor(Dictionary<string, decimal> values)
        {
            _values = values;
        }

        private readonly IReadOnlyDictionary<string, decimal> _values;

        public override decimal VisitAtom(FormulaParser.AtomContext context)
        {
            return context.Start.Type switch
            {
                FormulaParser.NUMBER => context.NUMBER().GetText().AsDecimal(),
                FormulaParser.VARIABLE => _values.GetValueOrDefault(context.VARIABLE().GetText()),
                FormulaParser.MINUS => -Visit(context.atom()),
                FormulaParser.LPAREN => Visit(context.atom()),
                _ => DEFAULT_VALUE
            };
        }

        public override decimal VisitParens(FormulaParser.ParensContext context)
        {
            return Visit(context.expr());
        }

        #region 运算符
        public override decimal VisitOpFirst(FormulaParser.OpFirstContext context)
        {
            return VisitOperate(context.op.Type, context);
        }

        public override decimal VisitOpSecond(FormulaParser.OpSecondContext context)
        {
            return VisitOperate(context.op.Type, context);
        }

        private decimal VisitOperate(int type, FormulaParser.ExprContext context)
        {
            var left = Visit(context.GetRuleContext<FormulaParser.ExprContext>(0));
            var right = Visit(context.GetRuleContext<FormulaParser.ExprContext>(1));
            return type switch
            {
                FormulaParser.PLUS => left + right,
                FormulaParser.MINUS => left - right,
                FormulaParser.TIMES => left * right,
                FormulaParser.DIV => left / right,
                _ => DEFAULT_VALUE
            };
        }
        #endregion

        #region 函数
        public override decimal VisitFunction(FormulaParser.FunctionContext context)
        {
            var func = context.func();
            return func.funcName().Start.Type switch
            {
                FormulaParser.ABS => VisitAbs(func),
                FormulaParser.ROUND => VisitRound(func),
                _ => DEFAULT_VALUE
            };
        }

        private decimal VisitAbs(FormulaParser.FuncContext context)
        {
            return Math.Abs(Visit(context.expr(0)));
        }

        private decimal VisitRound(FormulaParser.FuncContext context)
        {
            var exprContexts = context.expr();
            var value = Visit(exprContexts[0]);
            var decimals = 0;
            if (exprContexts.Length > 1)
                decimals = (int) Visit(exprContexts[1]);
            return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
        }
        #endregion
    }
}