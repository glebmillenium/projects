#include <iostream>
#include <cstring>
#include <cstdlib>
using namespace std;
#define SIZE 255

class strtype {
	char *p;
	int len;
public:
	strtype(); // конструктор
	~strtype() ; // деструктор
	void set(char *ptr);
	void show();
};

// Инициализация объекта строка
strtype::strtype()
{
	p=(char *) malloc(SIZE);
	if(!p) {
	cout << "Ошибка выделения памяти\n";
	exit(1);
	}
	*p = '\0';
	len = 0;
}

// Освобождение памяти при удалении объекта строка
strtype::~strtype ()
{
cout << "Освобождение памяти по адресу р\n";
free(p);
}

void strtype::set(char *ptr)
{
	if (strlen(p) >= SIZE) {
		cout << "Строка слишком велика\n";
		return;
	}

	strcpy(p, ptr);
	len=strlen(p);
}

void strtype::show ()
{
	cout << p << " — длина: " << len;
	cout << "\n";
}

int main ()
{
	strtype *s1 = new strtype();
	strtype *s2 = new strtype();
	s1->set((char *) "ЭTO проверка");
	s2->set((char *) "Мне нравится C++");
	s1->show();
	s2->show();
	return 0;
}
