%union { int a; char* str; }

%token term

%%
S : E
;

E : term E 						
	| term 'Laboratory' B		{ printf( "type document: Laboratory work \n" ); }
	| term 'Practical' B		{ printf( "type document: Practical work \n" ); }
;

B :	term B 			
	| 'student'	F				{ printf( "author: student \n" ); }
	| 'teacher'	F				{ printf( "author: teacher \n" ); }		
	| term 	F					{ printf( "no author\n" ); }
;

F : term F
	| term '2016'				{ printf( "year: 2016\n" ); }
	| term						{ printf( "no data\n" ); }

%%

#include <stdio.h> 
#include <ctype.h> 
#include <string.h>
#define MAX 100
#define LEN 255
char text[MAX][LEN];
// {"Laboratory", "Practical", "teacher", "student", "2016"};


int checkWordOnTerm(char* v)
{
	int check = 0;
	if (strncmp(v, "Laboratory", strlen("Laboratory")) == 0  || strncmp(v, "Practical", 9) == 0 
			|| strncmp(v, "teacher", 7) == 0 || strncmp(v, "student", 7) == 0 ||  strncmp(v, "2016", 4) == 0)
	{
		check = 1;
	}
	return check;
}

int yylex()
{ 
	char c;
	char v[LEN];
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
		ungetc(c, stdin );
		yylval.str = v;
		if (checkWordOnTerm(&v))
		{
			return (*v);
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
