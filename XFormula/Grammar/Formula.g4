grammar Formula;

prog
    : expr
    ;

expr
    : expr op=(TIMES|DIV) expr  # OpFirst
    | expr op=(PLUS|MINUS) expr # OpSecond
    | atom                      # Value
    | '(' expr ')'              # Parens
    | func                      # Function
    ;
    
atom 
    : NUMBER
    | VARIABLE
    | LPAREN atom RPAREN   
    | MINUS atom
    ;
    
func
   : funcName LPAREN expr (COMMA expr)* RPAREN
   ;
   
funcName
   : ABS
   | ROUND
   ;

ABS : 'ABS' ;
ROUND : 'ROUND' ;

PLUS : '+' ;
MINUS : '-' ;
TIMES : '*' ;
DIV : '/' ;

LPAREN : '(' ;
RPAREN : ')' ;
COMMA : ',' ;


NUMBER : ('0' .. '9') + ('.' ('0' .. '9') +)? ;
VARIABLE : ('A' .. 'Z') + ('0' .. '9') + ;

WS : [ \t\r\n]+ -> skip ;