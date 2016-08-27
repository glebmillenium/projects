%union { int a; char* str; }

%token term

%left 'Lab'
%left 'Prakt'

%%
S : E
E : 'Lab' B { printf("Its Laborat work"); }
	| 'Prakt' B { printf("Prakt"); }
	| term E
	| term 

B : term
	| term B
;

%%

#include <stdio.h> 
#include <ctype.h> 
#include <string.h>


int yylex()
{ 
	char c;
	char v[256];
	int i; 
	while ((c = getchar()) == ' ') continue;
	if((c != ' ') && (c != '\n'))
	{
		i = 0;
		for(  ; c != ' ' && c != '\n'; )
		{
			v[i] = c;
			c = getchar();
			i++;
		}
		v[i] = '\0';
		ungetc( c, stdin );
		yylval.str = v;
		if (strncmp(v, 'Lab', 3) == 0  || strncmp(v, 'Prakt', 5) == 0)
		{
			return (v);
		}
		else
		{
			return (term);
		}
	}
	
	return (0);
}

int main() 
{ 
for(;;) yyparse(); return 0; 
} 

int yyerror(char *mes) { printf( "%s \n", mes); return 0; }
