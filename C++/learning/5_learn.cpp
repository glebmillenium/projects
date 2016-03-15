#include <iostream>
using namespace std;

int main()
{
int a, b, d, min;
cout << "Введите два числа: ";
cin >> a >> b;
min = a > b ? b : a;
for (d=2; d<min; d++)
	if ( ((a%d)==0) && ((b%d) == 0)) break;

if (d==min) 
	cout << "Нет общего кратного\n";
else
	cout << "Наименьшее общее кратное равно" <<  d << "\n";

return 0;
}
