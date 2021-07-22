using System.Collections.Generic;
using XFormula.Antlr4Gen;

namespace XFormula.Parser
{
    public class ExcelFormulaParseVisitor : ExcelFormulaBaseVisitor<IEnumerable<string>>
    {
        #region 数值
        public override IEnumerable<string> VisitInteger(ExcelFormulaParser.IntegerContext context)
        {
            yield return context.GetText();
        }

        public override IEnumerable<string> VisitFloat(ExcelFormulaParser.FloatContext context)
        {
            yield return context.GetText();
        }

        public override IEnumerable<string> VisitScientificNumber(ExcelFormulaParser.ScientificNumberContext context)
        {
            yield return context.GetText();
        }

        public override IEnumerable<string> VisitBoolean(ExcelFormulaParser.BooleanContext context)
        {
            yield return context.GetText().AsBool() ? "true" : "false";
        }

        public override IEnumerable<string> VisitString(ExcelFormulaParser.StringContext context)
        {
            yield return context.GetText();
        }
        #endregion

        #region 操作符
        private string VisitConvertOperator(string operatorText)
        {
            return operatorText switch
            {
                "<>" => "!=",
                "=" => "==",
                _ => operatorText
            };
        }

        public override IEnumerable<string> VisitCalc(ExcelFormulaParser.CalcContext context)
        {
            var exprContexts = context.expr();

            foreach (var value in Visit(exprContexts[0]))
                yield return value;

            if (context.op != null) // 有可能判定为负数
                yield return VisitConvertOperator(context.op.Text);

            foreach (var value in Visit(exprContexts[1]))
                yield return value;
        }

        public override IEnumerable<string> VisitIf(ExcelFormulaParser.IfContext context)
        {
            var exprContexts = context.expr();

            yield return "(";

            foreach (var value in Visit(exprContexts[0]))
                yield return value;

            yield return "?";

            foreach (var value in Visit(exprContexts[1]))
                yield return value;

            yield return ":";

            foreach (var value in Visit(exprContexts[2]))
                yield return value;

            yield return ")";
        }

        public override IEnumerable<string> VisitParens(ExcelFormulaParser.ParensContext context)
        {
            yield return "(";

            foreach (var value in Visit(context.expr()))
                yield return value;

            yield return ")";
        }

        public override IEnumerable<string> VisitNegative(ExcelFormulaParser.NegativeContext context)
        {
            yield return "-(";

            foreach (var value in Visit(context.expr()))
                yield return value;

            yield return ")";
        }

        public override IEnumerable<string> VisitOr(ExcelFormulaParser.OrContext context)
        {
            yield return "(";

            var exprContexts = context.expr();
            for (var i = 0; i < exprContexts.Length; i++)
            {
                if (i > 0)
                    yield return "||";

                foreach (var value in Visit(exprContexts[i]))
                    yield return value;
            }

            yield return ")";
        }

        public override IEnumerable<string> VisitAnd(ExcelFormulaParser.AndContext context)
        {
            yield return "(";

            var exprContexts = context.expr();
            for (var i = 0; i < exprContexts.Length; i++)
            {
                if (i > 0)
                    yield return "&&";

                foreach (var value in Visit(exprContexts[i]))
                    yield return value;
            }

            yield return ")";
        }

        public override IEnumerable<string> VisitNot(ExcelFormulaParser.NotContext context)
        {
            yield return "!(";

            foreach (var value in Visit(context.expr()))
                yield return value;

            yield return ")";
        }
        #endregion

        #region 函数
        #region ABS
        public override IEnumerable<string> VisitAbs(ExcelFormulaParser.AbsContext context)
        {
            yield return "Math.abs(";

            foreach (var value in Visit(context.expr()))
                yield return value;

            yield return ")";
        }
        #endregion

        #region POWER
        public override IEnumerable<string> VisitPower(ExcelFormulaParser.PowerContext context)
        {
            var exprContexts = context.expr();

            yield return "Math.pow(";

            foreach (var value in Visit(exprContexts[0]))
                yield return value;

            yield return ",";

            foreach (var value in Visit(exprContexts[1]))
                yield return value;

            yield return ")";
        }
        #endregion

        #region MAX
        public override IEnumerable<string> VisitMax(ExcelFormulaParser.MaxContext context)
        {
            var exprContexts = context.expr();
            yield return "Math.max(";

            for (var i = 0; i < exprContexts.Length; i++)
            {
                if (i > 0)
                    yield return ",";

                foreach (var value in Visit(exprContexts[i]))
                    yield return value;
            }

            yield return ")";
        }
        #endregion

        #region MIN
        public override IEnumerable<string> VisitMin(ExcelFormulaParser.MinContext context)
        {
            var exprContexts = context.expr();
            yield return "Math.min(";

            for (var i = 0; i < exprContexts.Length; i++)
            {
                if (i > 0)
                    yield return ",";

                foreach (var value in Visit(exprContexts[i]))
                    yield return value;
            }

            yield return ")";
        }
        #endregion

        #region SUMSQ
        public override IEnumerable<string> VisitSumSq(ExcelFormulaParser.SumSqContext context)
        {
            var exprContexts = context.expr();
            yield return "(";

            for (var i = 0; i < exprContexts.Length; i++)
            {
                if (i > 0)
                    yield return "+";

                yield return "Math.pow(";

                foreach (var value in Visit(exprContexts[i]))
                    yield return value;

                yield return ",2)";
            }

            yield return ")";
        }
        #endregion

        #region SUM
        public override IEnumerable<string> VisitSum(ExcelFormulaParser.SumContext context)
        {
            var exprContexts = context.expr();
            yield return "(";

            for (var i = 0; i < exprContexts.Length; i++)
            {
                if (i > 0)
                    yield return "+";

                foreach (var value in Visit(exprContexts[i]))
                    yield return value;
            }

            yield return ")";
        }
        #endregion

        #region ROUND
        public override IEnumerable<string> VisitRound(ExcelFormulaParser.RoundContext context)
        {
            // Math.round(number + 'e' + precision) / Math.pow(10, precision);
            // 不用科学计数法来乘精度，防止表达式存在科学计数法
            var precision = context.INTEGER().GetText();

            yield return "Math.round(";
            foreach (var value in Visit(context.expr()))
                yield return value;
            yield return "*Math.pow(10,";

            yield return precision;
            yield return "))/Math.pow(10,";
            yield return precision;
            yield return ")";
        }
        #endregion

        #region AVERAGE
        public override IEnumerable<string> VisitAverage(ExcelFormulaParser.AverageContext context)
        {
            var exprContexts = context.expr();
            yield return "(";

            for (var i = 0; i < exprContexts.Length; i++)
            {
                if (i > 0)
                    yield return "+";

                foreach (var value in Visit(exprContexts[i]))
                    yield return value;
            }

            yield return ")/";
            yield return exprContexts.Length.ToString();
        }
        #endregion

        #region SQRT
        public override IEnumerable<string> VisitSqrt(ExcelFormulaParser.SqrtContext context)
        {
            yield return "Math.sqrt(";

            foreach (var value in Visit(context.expr()))
                yield return value;

            yield return ")";
        }
        #endregion

        #region MOD
        public override IEnumerable<string> VisitMod(ExcelFormulaParser.ModContext context)
        {
            yield return "(";

            foreach (var value in Visit(context.expr()))
                yield return value;

            yield return "%";

            yield return context.INTEGER().GetText();

            yield return ")";
        }
        #endregion

        #region INT
        public override IEnumerable<string> VisitInt(ExcelFormulaParser.IntContext context)
        {
            yield return "Math.floor(";

            foreach (var value in Visit(context.expr()))
                yield return value;

            yield return ")";
        }
        #endregion

        #region RAND
        public override IEnumerable<string> VisitRand(ExcelFormulaParser.RandContext context)
        {
            yield return "Math.random()";
        }
        #endregion
        #endregion
    }
}