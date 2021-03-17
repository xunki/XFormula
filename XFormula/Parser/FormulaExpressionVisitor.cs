using FastExpressionCompiler.LightExpression;
using XFormula.Antlr4Gen;
using static FastExpressionCompiler.LightExpression.Expression;

namespace XFormula.Parser
{
    public class FormulaExpressionVisitor : FormulaBaseVisitor<Expression>
    {
        protected static readonly Expression DefaultValue = Constant(0M);

        public override Expression VisitAtom(FormulaParser.AtomContext context)
        {
            return context.Start.Type switch
            {
                FormulaParser.NUMBER => Constant(context.NUMBER().GetText().AsDecimal()),
                FormulaParser.VARIABLE => Call(FormulaFunction.ValueMethodInfo, Constant(context.VARIABLE().GetText()),
                    FormulaFunction.ValuesExpr),
                FormulaParser.MINUS => Substract(DefaultValue, Visit(context.atom())),
                FormulaParser.LPAREN => Visit(context.atom()),
                _ => DefaultValue
            };
        }

        public override Expression VisitParens(FormulaParser.ParensContext context)
        {
            return Visit(context.expr());
        }

        #region 运算符
        public override Expression VisitOpFirst(FormulaParser.OpFirstContext context)
        {
            return VisitOperate(context.op.Type, context);
        }

        public override Expression VisitOpSecond(FormulaParser.OpSecondContext context)
        {
            return VisitOperate(context.op.Type, context);
        }

        private Expression VisitOperate(int type, FormulaParser.ExprContext context)
        {
            var left = Visit(context.GetRuleContext<FormulaParser.ExprContext>(0));
            var right = Visit(context.GetRuleContext<FormulaParser.ExprContext>(1));
            return type switch
            {
                FormulaParser.PLUS => Add(left, right),
                FormulaParser.MINUS => Substract(left, right),
                FormulaParser.TIMES => Multiply(left, right),
                FormulaParser.DIV => Divide(left, right),
                _ => DefaultValue
            };
        }
        #endregion

        #region 函数
        public override Expression VisitFunction(FormulaParser.FunctionContext context)
        {
            var func = context.func();
            return func.funcName().Start.Type switch
            {
                FormulaParser.ABS => VisitAbs(func),
                FormulaParser.ROUND => VisitRound(func),
                _ => DefaultValue
            };
        }

        private Expression VisitAbs(FormulaParser.FuncContext context)
        {
            var methodInfo = FormulaFunction.MethodInfos[FormulaParser.ABS];
            var arg = Visit(context.expr(0));
            return Call(methodInfo, arg);
        }

        private Expression VisitRound(FormulaParser.FuncContext context)
        {
            var methodInfo = FormulaFunction.MethodInfos[FormulaParser.ROUND];

            var exprContexts = context.expr();
            var valueExpr = Visit(exprContexts[0]);
            Expression decimalsExpr = exprContexts.Length <= 1
                ? Constant(0)
                : Convert(Visit(exprContexts[1]), typeof(int));
            return Call(methodInfo, valueExpr, decimalsExpr);
        }
        #endregion
    }
}