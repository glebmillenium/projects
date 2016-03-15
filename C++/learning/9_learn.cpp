#include <iostream>
#include <ctime>

using namespace std;
class timer
{
clock_t start;
public:
timer(); // конструктор
~timer(); // деструктор
};

timer::timer()
{
start=clock();
}

timer::~timer()
{
clock_t end;
end=clock();
cout << "Затраченное время:" << (end-start) << "\n";
}

int main()
{
timer ob;
char c;
// Пауза . . .
cout << "Нажмите любую клавишу, затем ENTER: ";
cin >> c;
return 0;
}
