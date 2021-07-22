grammar ExcelFormula;

expr
	: expr op=OPERATOR? expr												    # Calc
    | FLOAT																		# Float
    | INTEGER				 													# Integer
    | SCIENTIFIC_NUMBER                                                         # ScientificNumber
    | STRING                                                                    # String 
    | CELL                                                                      # Cell
    | CELL':'CELL                                                               # CellRange
    | '-('expr')'             													# Negative
    | '('expr')'             													# Parens
    | IF expr ',' expr ',' expr ')'									            # If
    | POWER expr ',' expr')'													# Power
    | ABS expr')'                     									    	# Abs
    | MAX expr (','expr)*')'													# Max
    | MIN expr (','expr)*')'													# Min
    | SUMSQ expr (','expr)*')'												    # SumSq
    | SUM expr (','expr)*')'													# Sum
    | ROUND expr ',' INTEGER')'										    		# Round
    | AVERAGE expr (','expr)*')'												# Average
	| SQRT expr')'														    	# Sqrt
    | MOD expr','INTEGER')'												    	# Mod
    | INT expr')'																# Int
 	| RAND')'																	# Rand
 	| BOOLEAN																    # Boolean
    | OR expr (',' expr)* ')'							                        # Or
    | AND expr (',' expr)* ')'								                    # And
    | NOT expr ')'													            # Not
;											

// Excel 函数名
ABS									:[aA][bB][sS]'(';								// 绝对值
MAX									:[mM][aA][xX]'(';								// 返回一组值中的最大值。MAX(number1, [number2], ...)
MIN									:[mM][iI][nN]'(';								// 返回一组值中的最小值。MIN(number1, [number2], ...)
SUMSQ								:[sS][uU][mM][sS][qQ]'(';						// 返回参数的平方和	
SUM									:[sS][uU][mM]'(';								// 返回一组值的和。SUM(number1, [number2], ...)
ROUND								:[rR][oO][uU][nN][dD]'(';						// 函数将数字四舍五入到指定的位数=ROUND(A1, 2),A1 包含 23.7825,此函数的结果为 23.78。
IF									:[iI][fF]'(';									// IF判断函数
OR									:[oO][rR]'(';									// OR函数
AND									:[aA][nN][dD]'(';								// AND函数
NOT									:[nN][oO][tT]'(';								// NOT函数
AVERAGE								:[aA][vV][eE][rR][aA][gG][eE]'(';				// average平均数函数
POWER								:[pP][oO][wW][eE][rR]'(';						// power函数
SQRT								:[sS][qQ][rR][tT]'(';							// SQRT函數
RAND								:[rR][aA][nN][dD]'(';							// RAND函数
MOD									:[mM][oO][dD]'(';								// MOD函数
INT									:[iI][nN][tT]'(';								// INT函数

// 数值
INTEGER								:'-'?[0-9]+;									// 整数，包含正整数、负整数、零
FLOAT								:'-'?[0-9]* '.' [0-9]+;						    // 浮点数，包含正浮点数，负浮点数、零(0.0)
SCIENTIFIC_NUMBER                   :'-'?(INTEGER|FLOAT) [eE] [+-] [0-9]+;          // 科学计数法
BOOLEAN								:([tT][rR][uU][eE])|([fF][aA][lL][sS][eE]);		// Boolean类型，TRUE或者FALSE
STRING                              :'"'  (~["\\\r\n\u0085\u2028\u2029])* '"';
CELL                                : [A-Z]+[0-9]+;

// 运算符
OPERATOR                            : '<>'|'>='|'<='|'>'|'<'|'='|'^'|'/'|'*'|'-'|'+'; 

WHITE_SPACE 						: [ \t\r]+ -> skip ;						    // 空白定义，可以是空格、制表符，换行符