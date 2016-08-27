#include "widget.h"
#include "QVBoxLayout"
#include "QHBoxLayout"
#include "QLabel"
#include "QPushButton"
#include "QLineEdit"
#include "QMenuBar"
#include "QMenu"

Widget::Widget(QWidget *parent)
    : QWidget(parent)
{
    //Первая горизонтальная строка. Начальный текст в поле ввода
    QLineEdit *LineEdit = new QLineEdit("Text 1");
    QLabel *Label = new QLabel("Line Edit &1");

    //Задаём текст. & — означает комбинацию клавиш для активации виджета
    //Задаём виджет на который будет переключаться фокус ввода при нажатии Alt+1
    Label->setBuddy(LineEdit);
    //Размещаем поле ввода и метку в одной строке
    QHBoxLayout *HLayout = new QHBoxLayout();
    HLayout->addWidget(Label);
    HLayout->addWidget(LineEdit);

    //Вторая горизонтальная строка
    QLineEdit *LineEdit2 = new QLineEdit("Text 2");
    QLabel *Label2 = new QLabel("Line Edit &2");
    Label2->setBuddy(LineEdit2);
    QHBoxLayout *HLayout2 = new QHBoxLayout();
    HLayout2->addWidget(Label2);
    HLayout2->addWidget(LineEdit2);
    //Третий ряд виджетов с кнопками
    QPushButton *Button1 = new QPushButton("&Ok");
    QPushButton *Button2 = new QPushButton("&Cancel");
    //Добавим элемент-растяжку он займёт всё возможное свободное пространство
    //и "прижмёт"кнопки к краю
    QHBoxLayout *HLayout3 = new QHBoxLayout();
    HLayout3->addStretch();
    HLayout3->addWidget(Button1);
    HLayout3->addWidget(Button2);

    QMenuBar *mnuBar = new QMenuBar();
    QMenu *pmnu   = new QMenu("&Menu");



    pmnu->addSeparator();

    QAction* pCheckableAction = pmnu->addAction("&CheckableItem");
    pCheckableAction->setCheckable(true);
    pCheckableAction->setChecked(true);


    QMenu* pmnuSubMenu = new QMenu("&SubMenu", pmnu);
    pmnu->addMenu(pmnuSubMenu);
    pmnuSubMenu->addAction("&Test");

    QAction* pDisabledAction = pmnu->addAction("&DisabledItem");
    pDisabledAction->setEnabled(false);

    pmnu->addSeparator();
    QMenu *derb   = new QMenu("&Second");


    mnuBar->addMenu(pmnu);
    mnuBar->addMenu(derb);

    //Добавим компоновку вертикально в колонку
    QVBoxLayout *VLayout = new QVBoxLayout();
    VLayout->addWidget(mnuBar);
    VLayout->addLayout(HLayout);
    VLayout->addLayout(HLayout2);
    VLayout->addLayout(HLayout3);
    //Задаём компоновщик для окна
    setLayout(VLayout);
}

Widget::~Widget()
{

}
