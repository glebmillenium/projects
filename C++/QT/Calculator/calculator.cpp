#include "calculator.h"
#include "QGridLayout"

Calculator::Calculator(QWidget *parent)
    : QWidget(parent)
{
    resize(300, 300);
    setWindowTitle("Simple Calculator");
    createWidgets();
}

Calculator::~Calculator()
{

}

void Calculator::createWidgets()
{
    QGridLayout *GridLayout = new QGridLayout();
    setLayout(GridLayout);

}
