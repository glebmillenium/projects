#include <stdio.h>
#include <stdlib.h>

int foo(int a, int b)
{
        return a+b;
}

int main()
{
        int c, a, b;
        c = 0, a = 1, b = 2;
        c = foo(a, b);
        return c;
}
