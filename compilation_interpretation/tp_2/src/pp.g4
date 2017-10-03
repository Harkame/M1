grammar pp;

BINARY_OPERATOR :
	| '+'
	| '-'
	| 'x'
	| '/'
	| 'and'|'or'
	| '<'
	| '<='
	| '='
	| '>='
	| '>'
	;

UNARY_OPERATOR :
	| '-'
	|'not'
	;

TYPE:
	'integer'
	|'boolean'
	|'array of ' TYPE
	;

EXPRESSION:
	UNARY_OPERATOR EXPRESSION
	| EXPRESSION BINARY_OPERATOR EXPRESSION
	;

CALL_TARGET:
	'Read'
	| 'Write'
	[a-zA-Z]+
	;

VARIABLE:
	[a-zA-Z]+
	;

ACCES_INDEX:
	VARIABLE '[' EXPRESSION ']'
	;

ARRAY_CREATION:
	'new array of' TYPE '[' EXPRESSION ']'
	;

PROGRAM :
	| (VARIABLE '(' EXPRESSION ':' TYPE ')')*
	| d*
	| INSTRUCTION;

d :
	| function'('( EXPRESSION ':' TYPE)*')'
	| VARIABLE '(' EXPRESSION ':' TYPE ')'*
	| i
	;

INSTRUCTION:
	| EXPRESSION '=' EXPRESSION
	| EXPRESSION '['EXPRESSION'] =' EXPRESSION
	| ' if ' EXPRESSION ' then ' EXPRESSION ' else ' EXPRESSION
	| 'while' EXPRESSION 'do' INSTRUCTION
	| phi'('EXPRESSION*')'
	| skip
	| INSTRUCTION';'INSTRUCTION
	;

k returns [int value]:
	n = number {$value = Integer.parseInt($n.text);}
	|'true'
	|'false';

NUMBER:
	('0'..'9')+;

WS : [ \t\r\n]+ -> skip;
