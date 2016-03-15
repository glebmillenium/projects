#include <iostream>
#include <fstream>
using namespace std;

int main()
{
ofstream fout("test"); // создание файла для вывода
if (!fout) {
cout << "Файл открыть невозможно\n";
return 1;
}

fout << "Привет !\n";
fout << 100 << ' ' << hex << 100 << endl;
fout.close() ;

ifstream fin ("test"); // открытие файла для ввода

if (!fin) {
cout << "Файл открыть невозможно\n";
return 1;
}

char str[80] ;
int i;
fin >> str >> i;
cout << str << ' ' << i << endl;
fin.close();
return 0;
}
