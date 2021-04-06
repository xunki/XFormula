using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Antlr4.Runtime;
using XFormula.Antlr4Gen;

namespace XFormula.Parser
{
    public class NestFormulaParsingVisitor : FormulaBaseVisitor<NestFormulaParsedNode>
    {
        #region 初始化
        private NestFormulaParsingVisitor(Dictionary<string, Formula> formulas, Dictionary<string, decimal> values,
            bool notAllowAbsentFormula = true)
        {
            _formulas = formulas;
            _values = values;
            _notAllowAbsentFormula = notAllowAbsentFormula;
        }

        private readonly Dictionary<string, Formula> _formulas;
        private readonly Dictionary<string, decimal> _values;

        /// <summary>
        /// 不允许缺少的公式配置
        /// </summary>
        private readonly bool _notAllowAbsentFormula;

        private static readonly NestFormulaParsedNode DefaultValue = new() {Name = "未知"};

        public static NestFormulaParsedNode Parse(Formula formula, Dictionary<string, Formula> formulas,
            Dictionary<string, decimal> values)
        {
            var input = formula.IsLowest ? formula.Code : formula.FormulaText;
            var errorOutput = new StringWriter();
            var lexer = new FormulaLexer(CharStreams.fromString(input),
                new StringWriter(), errorOutput);
            var tokens = new CommonTokenStream(lexer);
            var parser = new FormulaParser(tokens, new StringWriter(), errorOutput);
            var tree = parser.prog();
            var errMsg = errorOutput.ToString();
            if (errMsg.IsNotEmpty())
                throw new SyntaxErrorException($"公式：{formula.FormulaText} 错误：{errMsg}");

            var visitor = new NestFormulaParsingVisitor(formulas, values);
            var node = visitor.Visit(tree);
            node.Name = $"{formula.Name}({formula.Code})";
            return node;
        }
        #endregion

        public override NestFormulaParsedNode VisitAtom(FormulaParser.AtomContext context)
        {
            switch (context.Start.Type)
            {
                case FormulaParser.NUMBER:
                {
                    var text = context.NUMBER().GetText();
                    return new NestFormulaParsedNode {Name = text, Value = text.AsDecimal().Round()};
                }
                case FormulaParser.VARIABLE:
                {
                    var text = context.VARIABLE().GetText();
                    if (!_formulas.TryGetValue(text, out var formula) && _notAllowAbsentFormula)
                        throw new ArgumentException($"无法找到编码 {text} 对应的依赖关系");

                    // 最底层指标，使用字典中的数据
                    if (formula.IsLowest)
                        return new NestFormulaParsedNode
                        {
                            Name = $"{formula.Name}({formula.Code})",
                            Value = _values.GetValueOrDefault(formula.Code)
                        };

                    // 如果计算函数未生成，则进行解析
                    return Parse(formula, _formulas, _values);
                }
                case FormulaParser.MINUS:
                {
                    var node = Visit(context.atom());
                    node.Name = $"-({node.Name})";
                    node.Value = -node.Value;
                    return node;
                }
                case FormulaParser.LPAREN:
                {
                    var node = Visit(context.atom());
                    node.Name = $"({node.Name})";
                    return node;
                }
                default:
                    return DefaultValue;
            }
        }

        #region 运算符
        public override NestFormulaParsedNode VisitOpFirst(FormulaParser.OpFirstContext context)
        {
            return VisitOperate(context.op.Type, context);
        }

        public override NestFormulaParsedNode VisitOpSecond(FormulaParser.OpSecondContext context)
        {
            return VisitOperate(context.op.Type, context);
        }

        private NestFormulaParsedNode VisitOperate(int type, FormulaParser.ExprContext context)
        {
            var left = Visit(context.GetRuleContext<FormulaParser.ExprContext>(0));
            var right = Visit(context.GetRuleContext<FormulaParser.ExprContext>(1));
            string operatorSymbol;
            decimal value;
            switch (type)
            {
                case FormulaParser.PLUS:
                    operatorSymbol = "+";
                    value = left.Value + right.Value;
                    break;
                case FormulaParser.MINUS:
                    operatorSymbol = "-";
                    value = left.Value - right.Value;
                    break;
                case FormulaParser.TIMES:
                    operatorSymbol = "*";
                    value = left.Value * right.Value;
                    break;
                case FormulaParser.DIV:
                    operatorSymbol = "/";
                    value = left.Value / right.Value;
                    break;
                default:
                    return DefaultValue;
            }
            return new NestFormulaParsedNode
            {
                Name = $"{left.Name}{operatorSymbol}{right.Name}",
                Value = value,
                Children = new List<NestFormulaParsedNode> {left, right}
            };
        }
        #endregion

        #region 函数
        public override NestFormulaParsedNode VisitFunction(FormulaParser.FunctionContext context)
        {
            var func = context.func();
            return func.funcName().Start.Type switch
            {
                FormulaParser.ABS => VisitAbs(func),
                FormulaParser.ROUND => VisitRound(func),
                _ => DefaultValue
            };
        }

        private NestFormulaParsedNode VisitAbs(FormulaParser.FuncContext context)
        {
            var node = Visit(context.expr(0));
            node.Name = $"ABS({node.Name})";
            node.Value = Math.Abs(node.Value);
            return node;
        }

        private NestFormulaParsedNode VisitRound(FormulaParser.FuncContext context)
        {
            var exprContexts = context.expr();
            var node = Visit(exprContexts[0]);
            var decimals = 0;
            if (exprContexts.Length > 1)
                decimals = (int) Visit(exprContexts[1]).Value;
            node.Value = node.Value.Round(decimals);
            node.Name = $"ROUND({node.Name}{(decimals == 0 ? "" : "," + decimals)})";
            return node;
        }
        #endregion
    }
}