//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:/Code/MyCode/XFormula/XFormula/Grammar\ExcelFormula.g4 by ANTLR 4.9.1

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
public partial class ExcelFormulaLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, ABS=6, MAX=7, MIN=8, SUMSQ=9, 
		SUM=10, ROUND=11, IF=12, OR=13, AND=14, NOT=15, AVERAGE=16, POWER=17, 
		SQRT=18, RAND=19, MOD=20, INT=21, INTEGER=22, FLOAT=23, SCIENTIFIC_NUMBER=24, 
		BOOLEAN=25, STRING=26, CELL=27, OPERATOR=28, WHITE_SPACE=29;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "ABS", "MAX", "MIN", "SUMSQ", 
		"SUM", "ROUND", "IF", "OR", "AND", "NOT", "AVERAGE", "POWER", "SQRT", 
		"RAND", "MOD", "INT", "INTEGER", "FLOAT", "SCIENTIFIC_NUMBER", "BOOLEAN", 
		"STRING", "CELL", "OPERATOR", "WHITE_SPACE"
	};


	public ExcelFormulaLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public ExcelFormulaLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "':'", "'-('", "')'", "'('", "','"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, "ABS", "MAX", "MIN", "SUMSQ", "SUM", 
		"ROUND", "IF", "OR", "AND", "NOT", "AVERAGE", "POWER", "SQRT", "RAND", 
		"MOD", "INT", "INTEGER", "FLOAT", "SCIENTIFIC_NUMBER", "BOOLEAN", "STRING", 
		"CELL", "OPERATOR", "WHITE_SPACE"
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

	public override string GrammarFileName { get { return "ExcelFormula.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static ExcelFormulaLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x1F', '\xF5', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', 
		'\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\t', 
		'\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', 
		'\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', 
		'\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', 
		'\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', 
		'\xF', '\x3', '\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', 
		'\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', 
		'\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', 
		'\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', 
		'\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', 
		'\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', 
		'\x17', '\x5', '\x17', '\xA4', '\n', '\x17', '\x3', '\x17', '\x6', '\x17', 
		'\xA7', '\n', '\x17', '\r', '\x17', '\xE', '\x17', '\xA8', '\x3', '\x18', 
		'\x5', '\x18', '\xAC', '\n', '\x18', '\x3', '\x18', '\a', '\x18', '\xAF', 
		'\n', '\x18', '\f', '\x18', '\xE', '\x18', '\xB2', '\v', '\x18', '\x3', 
		'\x18', '\x3', '\x18', '\x6', '\x18', '\xB6', '\n', '\x18', '\r', '\x18', 
		'\xE', '\x18', '\xB7', '\x3', '\x19', '\x5', '\x19', '\xBB', '\n', '\x19', 
		'\x3', '\x19', '\x3', '\x19', '\x5', '\x19', '\xBF', '\n', '\x19', '\x3', 
		'\x19', '\x3', '\x19', '\x3', '\x19', '\x6', '\x19', '\xC4', '\n', '\x19', 
		'\r', '\x19', '\xE', '\x19', '\xC5', '\x3', '\x1A', '\x3', '\x1A', '\x3', 
		'\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', 
		'\x1A', '\x3', '\x1A', '\x5', '\x1A', '\xD1', '\n', '\x1A', '\x3', '\x1B', 
		'\x3', '\x1B', '\a', '\x1B', '\xD5', '\n', '\x1B', '\f', '\x1B', '\xE', 
		'\x1B', '\xD8', '\v', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', 
		'\x6', '\x1C', '\xDD', '\n', '\x1C', '\r', '\x1C', '\xE', '\x1C', '\xDE', 
		'\x3', '\x1C', '\x6', '\x1C', '\xE2', '\n', '\x1C', '\r', '\x1C', '\xE', 
		'\x1C', '\xE3', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x5', '\x1D', '\xED', '\n', 
		'\x1D', '\x3', '\x1E', '\x6', '\x1E', '\xF0', '\n', '\x1E', '\r', '\x1E', 
		'\xE', '\x1E', '\xF1', '\x3', '\x1E', '\x3', '\x1E', '\x2', '\x2', '\x1F', 
		'\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', 
		'\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', '\x17', '\r', 
		'\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', '!', '\x12', 
		'#', '\x13', '%', '\x14', '\'', '\x15', ')', '\x16', '+', '\x17', '-', 
		'\x18', '/', '\x19', '\x31', '\x1A', '\x33', '\x1B', '\x35', '\x1C', '\x37', 
		'\x1D', '\x39', '\x1E', ';', '\x1F', '\x3', '\x2', '\x1C', '\x4', '\x2', 
		'\x43', '\x43', '\x63', '\x63', '\x4', '\x2', '\x44', '\x44', '\x64', 
		'\x64', '\x4', '\x2', 'U', 'U', 'u', 'u', '\x4', '\x2', 'O', 'O', 'o', 
		'o', '\x4', '\x2', 'Z', 'Z', 'z', 'z', '\x4', '\x2', 'K', 'K', 'k', 'k', 
		'\x4', '\x2', 'P', 'P', 'p', 'p', '\x4', '\x2', 'W', 'W', 'w', 'w', '\x4', 
		'\x2', 'S', 'S', 's', 's', '\x4', '\x2', 'T', 'T', 't', 't', '\x4', '\x2', 
		'Q', 'Q', 'q', 'q', '\x4', '\x2', '\x46', '\x46', '\x66', '\x66', '\x4', 
		'\x2', 'H', 'H', 'h', 'h', '\x4', '\x2', 'V', 'V', 'v', 'v', '\x4', '\x2', 
		'X', 'X', 'x', 'x', '\x4', '\x2', 'G', 'G', 'g', 'g', '\x4', '\x2', 'I', 
		'I', 'i', 'i', '\x4', '\x2', 'R', 'R', 'r', 'r', '\x4', '\x2', 'Y', 'Y', 
		'y', 'y', '\x3', '\x2', '\x32', ';', '\x4', '\x2', '-', '-', '/', '/', 
		'\x4', '\x2', 'N', 'N', 'n', 'n', '\b', '\x2', '\f', '\f', '\xF', '\xF', 
		'$', '$', '^', '^', '\x87', '\x87', '\x202A', '\x202B', '\x3', '\x2', 
		'\x43', '\\', '\a', '\x2', ',', '-', '/', '/', '\x31', '\x31', '>', '@', 
		'`', '`', '\x5', '\x2', '\v', '\v', '\xF', '\xF', '\"', '\"', '\x2', '\x104', 
		'\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', '\x2', '\x2', '%', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x2', 
		')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', '/', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x31', '\x3', '\x2', '\x2', '\x2', '\x2', '\x33', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x37', '\x3', '\x2', '\x2', '\x2', '\x2', '\x39', '\x3', '\x2', '\x2', 
		'\x2', '\x2', ';', '\x3', '\x2', '\x2', '\x2', '\x3', '=', '\x3', '\x2', 
		'\x2', '\x2', '\x5', '?', '\x3', '\x2', '\x2', '\x2', '\a', '\x42', '\x3', 
		'\x2', '\x2', '\x2', '\t', '\x44', '\x3', '\x2', '\x2', '\x2', '\v', '\x46', 
		'\x3', '\x2', '\x2', '\x2', '\r', 'H', '\x3', '\x2', '\x2', '\x2', '\xF', 
		'M', '\x3', '\x2', '\x2', '\x2', '\x11', 'R', '\x3', '\x2', '\x2', '\x2', 
		'\x13', 'W', '\x3', '\x2', '\x2', '\x2', '\x15', '^', '\x3', '\x2', '\x2', 
		'\x2', '\x17', '\x63', '\x3', '\x2', '\x2', '\x2', '\x19', 'j', '\x3', 
		'\x2', '\x2', '\x2', '\x1B', 'n', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'r', '\x3', '\x2', '\x2', '\x2', '\x1F', 'w', '\x3', '\x2', '\x2', '\x2', 
		'!', '|', '\x3', '\x2', '\x2', '\x2', '#', '\x85', '\x3', '\x2', '\x2', 
		'\x2', '%', '\x8C', '\x3', '\x2', '\x2', '\x2', '\'', '\x92', '\x3', '\x2', 
		'\x2', '\x2', ')', '\x98', '\x3', '\x2', '\x2', '\x2', '+', '\x9D', '\x3', 
		'\x2', '\x2', '\x2', '-', '\xA3', '\x3', '\x2', '\x2', '\x2', '/', '\xAB', 
		'\x3', '\x2', '\x2', '\x2', '\x31', '\xBA', '\x3', '\x2', '\x2', '\x2', 
		'\x33', '\xD0', '\x3', '\x2', '\x2', '\x2', '\x35', '\xD2', '\x3', '\x2', 
		'\x2', '\x2', '\x37', '\xDC', '\x3', '\x2', '\x2', '\x2', '\x39', '\xEC', 
		'\x3', '\x2', '\x2', '\x2', ';', '\xEF', '\x3', '\x2', '\x2', '\x2', '=', 
		'>', '\a', '<', '\x2', '\x2', '>', '\x4', '\x3', '\x2', '\x2', '\x2', 
		'?', '@', '\a', '/', '\x2', '\x2', '@', '\x41', '\a', '*', '\x2', '\x2', 
		'\x41', '\x6', '\x3', '\x2', '\x2', '\x2', '\x42', '\x43', '\a', '+', 
		'\x2', '\x2', '\x43', '\b', '\x3', '\x2', '\x2', '\x2', '\x44', '\x45', 
		'\a', '*', '\x2', '\x2', '\x45', '\n', '\x3', '\x2', '\x2', '\x2', '\x46', 
		'G', '\a', '.', '\x2', '\x2', 'G', '\f', '\x3', '\x2', '\x2', '\x2', 'H', 
		'I', '\t', '\x2', '\x2', '\x2', 'I', 'J', '\t', '\x3', '\x2', '\x2', 'J', 
		'K', '\t', '\x4', '\x2', '\x2', 'K', 'L', '\a', '*', '\x2', '\x2', 'L', 
		'\xE', '\x3', '\x2', '\x2', '\x2', 'M', 'N', '\t', '\x5', '\x2', '\x2', 
		'N', 'O', '\t', '\x2', '\x2', '\x2', 'O', 'P', '\t', '\x6', '\x2', '\x2', 
		'P', 'Q', '\a', '*', '\x2', '\x2', 'Q', '\x10', '\x3', '\x2', '\x2', '\x2', 
		'R', 'S', '\t', '\x5', '\x2', '\x2', 'S', 'T', '\t', '\a', '\x2', '\x2', 
		'T', 'U', '\t', '\b', '\x2', '\x2', 'U', 'V', '\a', '*', '\x2', '\x2', 
		'V', '\x12', '\x3', '\x2', '\x2', '\x2', 'W', 'X', '\t', '\x4', '\x2', 
		'\x2', 'X', 'Y', '\t', '\t', '\x2', '\x2', 'Y', 'Z', '\t', '\x5', '\x2', 
		'\x2', 'Z', '[', '\t', '\x4', '\x2', '\x2', '[', '\\', '\t', '\n', '\x2', 
		'\x2', '\\', ']', '\a', '*', '\x2', '\x2', ']', '\x14', '\x3', '\x2', 
		'\x2', '\x2', '^', '_', '\t', '\x4', '\x2', '\x2', '_', '`', '\t', '\t', 
		'\x2', '\x2', '`', '\x61', '\t', '\x5', '\x2', '\x2', '\x61', '\x62', 
		'\a', '*', '\x2', '\x2', '\x62', '\x16', '\x3', '\x2', '\x2', '\x2', '\x63', 
		'\x64', '\t', '\v', '\x2', '\x2', '\x64', '\x65', '\t', '\f', '\x2', '\x2', 
		'\x65', '\x66', '\t', '\t', '\x2', '\x2', '\x66', 'g', '\t', '\b', '\x2', 
		'\x2', 'g', 'h', '\t', '\r', '\x2', '\x2', 'h', 'i', '\a', '*', '\x2', 
		'\x2', 'i', '\x18', '\x3', '\x2', '\x2', '\x2', 'j', 'k', '\t', '\a', 
		'\x2', '\x2', 'k', 'l', '\t', '\xE', '\x2', '\x2', 'l', 'm', '\a', '*', 
		'\x2', '\x2', 'm', '\x1A', '\x3', '\x2', '\x2', '\x2', 'n', 'o', '\t', 
		'\f', '\x2', '\x2', 'o', 'p', '\t', '\v', '\x2', '\x2', 'p', 'q', '\a', 
		'*', '\x2', '\x2', 'q', '\x1C', '\x3', '\x2', '\x2', '\x2', 'r', 's', 
		'\t', '\x2', '\x2', '\x2', 's', 't', '\t', '\b', '\x2', '\x2', 't', 'u', 
		'\t', '\r', '\x2', '\x2', 'u', 'v', '\a', '*', '\x2', '\x2', 'v', '\x1E', 
		'\x3', '\x2', '\x2', '\x2', 'w', 'x', '\t', '\b', '\x2', '\x2', 'x', 'y', 
		'\t', '\f', '\x2', '\x2', 'y', 'z', '\t', '\xF', '\x2', '\x2', 'z', '{', 
		'\a', '*', '\x2', '\x2', '{', ' ', '\x3', '\x2', '\x2', '\x2', '|', '}', 
		'\t', '\x2', '\x2', '\x2', '}', '~', '\t', '\x10', '\x2', '\x2', '~', 
		'\x7F', '\t', '\x11', '\x2', '\x2', '\x7F', '\x80', '\t', '\v', '\x2', 
		'\x2', '\x80', '\x81', '\t', '\x2', '\x2', '\x2', '\x81', '\x82', '\t', 
		'\x12', '\x2', '\x2', '\x82', '\x83', '\t', '\x11', '\x2', '\x2', '\x83', 
		'\x84', '\a', '*', '\x2', '\x2', '\x84', '\"', '\x3', '\x2', '\x2', '\x2', 
		'\x85', '\x86', '\t', '\x13', '\x2', '\x2', '\x86', '\x87', '\t', '\f', 
		'\x2', '\x2', '\x87', '\x88', '\t', '\x14', '\x2', '\x2', '\x88', '\x89', 
		'\t', '\x11', '\x2', '\x2', '\x89', '\x8A', '\t', '\v', '\x2', '\x2', 
		'\x8A', '\x8B', '\a', '*', '\x2', '\x2', '\x8B', '$', '\x3', '\x2', '\x2', 
		'\x2', '\x8C', '\x8D', '\t', '\x4', '\x2', '\x2', '\x8D', '\x8E', '\t', 
		'\n', '\x2', '\x2', '\x8E', '\x8F', '\t', '\v', '\x2', '\x2', '\x8F', 
		'\x90', '\t', '\xF', '\x2', '\x2', '\x90', '\x91', '\a', '*', '\x2', '\x2', 
		'\x91', '&', '\x3', '\x2', '\x2', '\x2', '\x92', '\x93', '\t', '\v', '\x2', 
		'\x2', '\x93', '\x94', '\t', '\x2', '\x2', '\x2', '\x94', '\x95', '\t', 
		'\b', '\x2', '\x2', '\x95', '\x96', '\t', '\r', '\x2', '\x2', '\x96', 
		'\x97', '\a', '*', '\x2', '\x2', '\x97', '(', '\x3', '\x2', '\x2', '\x2', 
		'\x98', '\x99', '\t', '\x5', '\x2', '\x2', '\x99', '\x9A', '\t', '\f', 
		'\x2', '\x2', '\x9A', '\x9B', '\t', '\r', '\x2', '\x2', '\x9B', '\x9C', 
		'\a', '*', '\x2', '\x2', '\x9C', '*', '\x3', '\x2', '\x2', '\x2', '\x9D', 
		'\x9E', '\t', '\a', '\x2', '\x2', '\x9E', '\x9F', '\t', '\b', '\x2', '\x2', 
		'\x9F', '\xA0', '\t', '\xF', '\x2', '\x2', '\xA0', '\xA1', '\a', '*', 
		'\x2', '\x2', '\xA1', ',', '\x3', '\x2', '\x2', '\x2', '\xA2', '\xA4', 
		'\a', '/', '\x2', '\x2', '\xA3', '\xA2', '\x3', '\x2', '\x2', '\x2', '\xA3', 
		'\xA4', '\x3', '\x2', '\x2', '\x2', '\xA4', '\xA6', '\x3', '\x2', '\x2', 
		'\x2', '\xA5', '\xA7', '\t', '\x15', '\x2', '\x2', '\xA6', '\xA5', '\x3', 
		'\x2', '\x2', '\x2', '\xA7', '\xA8', '\x3', '\x2', '\x2', '\x2', '\xA8', 
		'\xA6', '\x3', '\x2', '\x2', '\x2', '\xA8', '\xA9', '\x3', '\x2', '\x2', 
		'\x2', '\xA9', '.', '\x3', '\x2', '\x2', '\x2', '\xAA', '\xAC', '\a', 
		'/', '\x2', '\x2', '\xAB', '\xAA', '\x3', '\x2', '\x2', '\x2', '\xAB', 
		'\xAC', '\x3', '\x2', '\x2', '\x2', '\xAC', '\xB0', '\x3', '\x2', '\x2', 
		'\x2', '\xAD', '\xAF', '\t', '\x15', '\x2', '\x2', '\xAE', '\xAD', '\x3', 
		'\x2', '\x2', '\x2', '\xAF', '\xB2', '\x3', '\x2', '\x2', '\x2', '\xB0', 
		'\xAE', '\x3', '\x2', '\x2', '\x2', '\xB0', '\xB1', '\x3', '\x2', '\x2', 
		'\x2', '\xB1', '\xB3', '\x3', '\x2', '\x2', '\x2', '\xB2', '\xB0', '\x3', 
		'\x2', '\x2', '\x2', '\xB3', '\xB5', '\a', '\x30', '\x2', '\x2', '\xB4', 
		'\xB6', '\t', '\x15', '\x2', '\x2', '\xB5', '\xB4', '\x3', '\x2', '\x2', 
		'\x2', '\xB6', '\xB7', '\x3', '\x2', '\x2', '\x2', '\xB7', '\xB5', '\x3', 
		'\x2', '\x2', '\x2', '\xB7', '\xB8', '\x3', '\x2', '\x2', '\x2', '\xB8', 
		'\x30', '\x3', '\x2', '\x2', '\x2', '\xB9', '\xBB', '\a', '/', '\x2', 
		'\x2', '\xBA', '\xB9', '\x3', '\x2', '\x2', '\x2', '\xBA', '\xBB', '\x3', 
		'\x2', '\x2', '\x2', '\xBB', '\xBE', '\x3', '\x2', '\x2', '\x2', '\xBC', 
		'\xBF', '\x5', '-', '\x17', '\x2', '\xBD', '\xBF', '\x5', '/', '\x18', 
		'\x2', '\xBE', '\xBC', '\x3', '\x2', '\x2', '\x2', '\xBE', '\xBD', '\x3', 
		'\x2', '\x2', '\x2', '\xBF', '\xC0', '\x3', '\x2', '\x2', '\x2', '\xC0', 
		'\xC1', '\t', '\x11', '\x2', '\x2', '\xC1', '\xC3', '\t', '\x16', '\x2', 
		'\x2', '\xC2', '\xC4', '\t', '\x15', '\x2', '\x2', '\xC3', '\xC2', '\x3', 
		'\x2', '\x2', '\x2', '\xC4', '\xC5', '\x3', '\x2', '\x2', '\x2', '\xC5', 
		'\xC3', '\x3', '\x2', '\x2', '\x2', '\xC5', '\xC6', '\x3', '\x2', '\x2', 
		'\x2', '\xC6', '\x32', '\x3', '\x2', '\x2', '\x2', '\xC7', '\xC8', '\t', 
		'\xF', '\x2', '\x2', '\xC8', '\xC9', '\t', '\v', '\x2', '\x2', '\xC9', 
		'\xCA', '\t', '\t', '\x2', '\x2', '\xCA', '\xD1', '\t', '\x11', '\x2', 
		'\x2', '\xCB', '\xCC', '\t', '\xE', '\x2', '\x2', '\xCC', '\xCD', '\t', 
		'\x2', '\x2', '\x2', '\xCD', '\xCE', '\t', '\x17', '\x2', '\x2', '\xCE', 
		'\xCF', '\t', '\x4', '\x2', '\x2', '\xCF', '\xD1', '\t', '\x11', '\x2', 
		'\x2', '\xD0', '\xC7', '\x3', '\x2', '\x2', '\x2', '\xD0', '\xCB', '\x3', 
		'\x2', '\x2', '\x2', '\xD1', '\x34', '\x3', '\x2', '\x2', '\x2', '\xD2', 
		'\xD6', '\a', '$', '\x2', '\x2', '\xD3', '\xD5', '\n', '\x18', '\x2', 
		'\x2', '\xD4', '\xD3', '\x3', '\x2', '\x2', '\x2', '\xD5', '\xD8', '\x3', 
		'\x2', '\x2', '\x2', '\xD6', '\xD4', '\x3', '\x2', '\x2', '\x2', '\xD6', 
		'\xD7', '\x3', '\x2', '\x2', '\x2', '\xD7', '\xD9', '\x3', '\x2', '\x2', 
		'\x2', '\xD8', '\xD6', '\x3', '\x2', '\x2', '\x2', '\xD9', '\xDA', '\a', 
		'$', '\x2', '\x2', '\xDA', '\x36', '\x3', '\x2', '\x2', '\x2', '\xDB', 
		'\xDD', '\t', '\x19', '\x2', '\x2', '\xDC', '\xDB', '\x3', '\x2', '\x2', 
		'\x2', '\xDD', '\xDE', '\x3', '\x2', '\x2', '\x2', '\xDE', '\xDC', '\x3', 
		'\x2', '\x2', '\x2', '\xDE', '\xDF', '\x3', '\x2', '\x2', '\x2', '\xDF', 
		'\xE1', '\x3', '\x2', '\x2', '\x2', '\xE0', '\xE2', '\t', '\x15', '\x2', 
		'\x2', '\xE1', '\xE0', '\x3', '\x2', '\x2', '\x2', '\xE2', '\xE3', '\x3', 
		'\x2', '\x2', '\x2', '\xE3', '\xE1', '\x3', '\x2', '\x2', '\x2', '\xE3', 
		'\xE4', '\x3', '\x2', '\x2', '\x2', '\xE4', '\x38', '\x3', '\x2', '\x2', 
		'\x2', '\xE5', '\xE6', '\a', '>', '\x2', '\x2', '\xE6', '\xED', '\a', 
		'@', '\x2', '\x2', '\xE7', '\xE8', '\a', '@', '\x2', '\x2', '\xE8', '\xED', 
		'\a', '?', '\x2', '\x2', '\xE9', '\xEA', '\a', '>', '\x2', '\x2', '\xEA', 
		'\xED', '\a', '?', '\x2', '\x2', '\xEB', '\xED', '\t', '\x1A', '\x2', 
		'\x2', '\xEC', '\xE5', '\x3', '\x2', '\x2', '\x2', '\xEC', '\xE7', '\x3', 
		'\x2', '\x2', '\x2', '\xEC', '\xE9', '\x3', '\x2', '\x2', '\x2', '\xEC', 
		'\xEB', '\x3', '\x2', '\x2', '\x2', '\xED', ':', '\x3', '\x2', '\x2', 
		'\x2', '\xEE', '\xF0', '\t', '\x1B', '\x2', '\x2', '\xEF', '\xEE', '\x3', 
		'\x2', '\x2', '\x2', '\xF0', '\xF1', '\x3', '\x2', '\x2', '\x2', '\xF1', 
		'\xEF', '\x3', '\x2', '\x2', '\x2', '\xF1', '\xF2', '\x3', '\x2', '\x2', 
		'\x2', '\xF2', '\xF3', '\x3', '\x2', '\x2', '\x2', '\xF3', '\xF4', '\b', 
		'\x1E', '\x2', '\x2', '\xF4', '<', '\x3', '\x2', '\x2', '\x2', '\x11', 
		'\x2', '\xA3', '\xA8', '\xAB', '\xB0', '\xB7', '\xBA', '\xBE', '\xC5', 
		'\xD0', '\xD6', '\xDE', '\xE3', '\xEC', '\xF1', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace XFormula.Antlr4Gen
