#ifndef CALCULATOR_H
#define CALCULATOR_H

#include <QWidget>

class Calculator : public QWidget
{
    Q_OBJECT

public:
    Calculator(QWidget *parent = 0);
    ~Calculator();
    void createWidgets();
};

#endif // CALCULATOR_H
