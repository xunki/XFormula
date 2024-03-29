//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:/Code/MyCode/XFormula/XFormula/Grammar\Formula.g4 by ANTLR 4.9.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace XFormula.Antlr4Gen {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="FormulaParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.1")]
[System.CLSCompliant(false)]
public interface IFormulaVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="FormulaParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProg([NotNull] FormulaParser.ProgContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>Function</c>
	/// labeled alternative in <see cref="FormulaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction([NotNull] FormulaParser.FunctionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>OpSecond</c>
	/// labeled alternative in <see cref="FormulaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOpSecond([NotNull] FormulaParser.OpSecondContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>Parens</c>
	/// labeled alternative in <see cref="FormulaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParens([NotNull] FormulaParser.ParensContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>Value</c>
	/// labeled alternative in <see cref="FormulaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] FormulaParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>OpFirst</c>
	/// labeled alternative in <see cref="FormulaParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOpFirst([NotNull] FormulaParser.OpFirstContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FormulaParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtom([NotNull] FormulaParser.AtomContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FormulaParser.func"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc([NotNull] FormulaParser.FuncContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FormulaParser.funcName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncName([NotNull] FormulaParser.FuncNameContext context);
}
} // namespace XFormula.Antlr4Gen
