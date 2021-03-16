//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:/Code/MyCode/XFormula/XFormula\Formula.g4 by ANTLR 4.9.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace XFormula.Antlr4Gen {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.1")]
[System.CLSCompliant(false)]
public partial class FormulaLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		ABS=1, ROUND=2, PLUS=3, MINUS=4, TIMES=5, DIV=6, LPAREN=7, RPAREN=8, COMMA=9, 
		NUMBER=10, VARIABLE=11, WS=12;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"ABS", "ROUND", "PLUS", "MINUS", "TIMES", "DIV", "LPAREN", "RPAREN", "COMMA", 
		"NUMBER", "VARIABLE", "WS"
	};


	public FormulaLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public FormulaLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'ABS'", "'ROUND'", "'+'", "'-'", "'*'", "'/'", "'('", "')'", "','"
	};
	private static readonly string[] _SymbolicNames = {
		null, "ABS", "ROUND", "PLUS", "MINUS", "TIMES", "DIV", "LPAREN", "RPAREN", 
		"COMMA", "NUMBER", "VARIABLE", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Formula.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static FormulaLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\xE', 'Q', '\b', '\x1', '\x4', '\x2', '\t', '\x2', '\x4', 
		'\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', 
		'\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', 
		'\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', 
		'\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', 
		'\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x6', '\v', '\x35', '\n', 
		'\v', '\r', '\v', '\xE', '\v', '\x36', '\x3', '\v', '\x3', '\v', '\x6', 
		'\v', ';', '\n', '\v', '\r', '\v', '\xE', '\v', '<', '\x5', '\v', '?', 
		'\n', '\v', '\x3', '\f', '\x6', '\f', '\x42', '\n', '\f', '\r', '\f', 
		'\xE', '\f', '\x43', '\x3', '\f', '\x6', '\f', 'G', '\n', '\f', '\r', 
		'\f', '\xE', '\f', 'H', '\x3', '\r', '\x6', '\r', 'L', '\n', '\r', '\r', 
		'\r', '\xE', '\r', 'M', '\x3', '\r', '\x3', '\r', '\x2', '\x2', '\xE', 
		'\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', 
		'\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', '\x17', '\r', 
		'\x19', '\xE', '\x3', '\x2', '\x3', '\x5', '\x2', '\v', '\f', '\xF', '\xF', 
		'\"', '\"', '\x2', 'V', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', 
		'\x2', '\x2', '\x3', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x5', '\x1F', 
		'\x3', '\x2', '\x2', '\x2', '\a', '%', '\x3', '\x2', '\x2', '\x2', '\t', 
		'\'', '\x3', '\x2', '\x2', '\x2', '\v', ')', '\x3', '\x2', '\x2', '\x2', 
		'\r', '+', '\x3', '\x2', '\x2', '\x2', '\xF', '-', '\x3', '\x2', '\x2', 
		'\x2', '\x11', '/', '\x3', '\x2', '\x2', '\x2', '\x13', '\x31', '\x3', 
		'\x2', '\x2', '\x2', '\x15', '\x34', '\x3', '\x2', '\x2', '\x2', '\x17', 
		'\x41', '\x3', '\x2', '\x2', '\x2', '\x19', 'K', '\x3', '\x2', '\x2', 
		'\x2', '\x1B', '\x1C', '\a', '\x43', '\x2', '\x2', '\x1C', '\x1D', '\a', 
		'\x44', '\x2', '\x2', '\x1D', '\x1E', '\a', 'U', '\x2', '\x2', '\x1E', 
		'\x4', '\x3', '\x2', '\x2', '\x2', '\x1F', ' ', '\a', 'T', '\x2', '\x2', 
		' ', '!', '\a', 'Q', '\x2', '\x2', '!', '\"', '\a', 'W', '\x2', '\x2', 
		'\"', '#', '\a', 'P', '\x2', '\x2', '#', '$', '\a', '\x46', '\x2', '\x2', 
		'$', '\x6', '\x3', '\x2', '\x2', '\x2', '%', '&', '\a', '-', '\x2', '\x2', 
		'&', '\b', '\x3', '\x2', '\x2', '\x2', '\'', '(', '\a', '/', '\x2', '\x2', 
		'(', '\n', '\x3', '\x2', '\x2', '\x2', ')', '*', '\a', ',', '\x2', '\x2', 
		'*', '\f', '\x3', '\x2', '\x2', '\x2', '+', ',', '\a', '\x31', '\x2', 
		'\x2', ',', '\xE', '\x3', '\x2', '\x2', '\x2', '-', '.', '\a', '*', '\x2', 
		'\x2', '.', '\x10', '\x3', '\x2', '\x2', '\x2', '/', '\x30', '\a', '+', 
		'\x2', '\x2', '\x30', '\x12', '\x3', '\x2', '\x2', '\x2', '\x31', '\x32', 
		'\a', '.', '\x2', '\x2', '\x32', '\x14', '\x3', '\x2', '\x2', '\x2', '\x33', 
		'\x35', '\x4', '\x32', ';', '\x2', '\x34', '\x33', '\x3', '\x2', '\x2', 
		'\x2', '\x35', '\x36', '\x3', '\x2', '\x2', '\x2', '\x36', '\x34', '\x3', 
		'\x2', '\x2', '\x2', '\x36', '\x37', '\x3', '\x2', '\x2', '\x2', '\x37', 
		'>', '\x3', '\x2', '\x2', '\x2', '\x38', ':', '\a', '\x30', '\x2', '\x2', 
		'\x39', ';', '\x4', '\x32', ';', '\x2', ':', '\x39', '\x3', '\x2', '\x2', 
		'\x2', ';', '<', '\x3', '\x2', '\x2', '\x2', '<', ':', '\x3', '\x2', '\x2', 
		'\x2', '<', '=', '\x3', '\x2', '\x2', '\x2', '=', '?', '\x3', '\x2', '\x2', 
		'\x2', '>', '\x38', '\x3', '\x2', '\x2', '\x2', '>', '?', '\x3', '\x2', 
		'\x2', '\x2', '?', '\x16', '\x3', '\x2', '\x2', '\x2', '@', '\x42', '\x4', 
		'\x43', '\\', '\x2', '\x41', '@', '\x3', '\x2', '\x2', '\x2', '\x42', 
		'\x43', '\x3', '\x2', '\x2', '\x2', '\x43', '\x41', '\x3', '\x2', '\x2', 
		'\x2', '\x43', '\x44', '\x3', '\x2', '\x2', '\x2', '\x44', '\x46', '\x3', 
		'\x2', '\x2', '\x2', '\x45', 'G', '\x4', '\x32', ';', '\x2', '\x46', '\x45', 
		'\x3', '\x2', '\x2', '\x2', 'G', 'H', '\x3', '\x2', '\x2', '\x2', 'H', 
		'\x46', '\x3', '\x2', '\x2', '\x2', 'H', 'I', '\x3', '\x2', '\x2', '\x2', 
		'I', '\x18', '\x3', '\x2', '\x2', '\x2', 'J', 'L', '\t', '\x2', '\x2', 
		'\x2', 'K', 'J', '\x3', '\x2', '\x2', '\x2', 'L', 'M', '\x3', '\x2', '\x2', 
		'\x2', 'M', 'K', '\x3', '\x2', '\x2', '\x2', 'M', 'N', '\x3', '\x2', '\x2', 
		'\x2', 'N', 'O', '\x3', '\x2', '\x2', '\x2', 'O', 'P', '\b', '\r', '\x2', 
		'\x2', 'P', '\x1A', '\x3', '\x2', '\x2', '\x2', '\t', '\x2', '\x36', '<', 
		'>', '\x43', 'H', 'M', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace XFormula.Antlr4Gen
