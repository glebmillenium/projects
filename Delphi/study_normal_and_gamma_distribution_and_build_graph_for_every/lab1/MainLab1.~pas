unit MainLab1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Math, StdCtrls, ComCtrls, TeEngine, Series, ExtCtrls, TeeProcs,
  Chart, Menus, Grids;

 { Math - математическая библиотека}

type
  TForm1 = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    Edit1: TEdit;
    TabSheet2: TTabSheet;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Label2: TLabel;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Label3: TLabel;
    Label4: TLabel;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    Label5: TLabel;
    Label1: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    StringGrid1: TStringGrid;
    PopupMenu1: TPopupMenu;
    Chart1: TChart;
    Series1: TFastLineSeries;
    Series2: TFastLineSeries;
    Series3: TFastLineSeries;
    Series4: TFastLineSeries;
    Series5: TFastLineSeries;
    N1: TMenuItem;
    N2: TMenuItem;
    Edit5: TEdit;
    Edit6: TEdit;
    Edit7: TEdit;
    Edit8: TEdit;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    procedure N1Click(Sender: TObject);
    procedure FormResize(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  { Массив вместо объявления переменной типа PChar }
  ADF: array [0..255] of Char;
  xm: array [1..100000] of double;
  TitleText: ShortString;

implementation

{$R *.dfm}
{$R+}

function Erlang(k:single; mi:integer; t:single):single;

var z2,z3 : Extended;

    i     : integer;

begin

                  { Гамма-функция - n факториал }

  z2:=1;

  if mi<2 then z2:=1 else for i:=1 to mi do z2:=z2*i;

 

                { Экспоненциальный закон и Эрланг }

 

  if mi<=0 then z3:=k else z3:=Power(k,mi+1)*Power(t,mi);

 

  z3:=z3*exp(-k*t)/z2;

 

  Erlang:=z3;

end;

 

function GammaEE(Nmod:integer; m:single):single;

var x: single;
    i: integer;

begin
 { Генератор случайных чисел с плотностью Гамма распределения }
 x:=0;

 for i:=1 to Nmod do x:=x+SQR(RandG(0,1));       // дает распределение Пирсона c Nmod - степенями свободы.
 // Для распределения Пирсона Nmod - мат. ожидание, Nmod - коэф формы
 x:=x*m/Nmod;

 GammaEE:=x;

end;



procedure TForm1.N1Click(Sender: TObject);
begin
 { Копирование рисунка графика в буфер ММО }
 {Обработчик меню на экране. Вызов меню на экране.}
 form1.Chart1.CopyToClipboardMetafile(true);{Заносим рисунок графика в буфер ММО}
end;

procedure TForm1.FormResize(Sender: TObject);
begin
 {Ширина формы -365 пикселей}
 form1.StringGrid1.Left:=form1.Width-365;

 {Высота формы -65 пикселей}
 form1.StringGrid1.Height:=form1.Height-65;

 {Ограничение минимум 720 пикселей}
 if form1.Width<720 then form1.Width:=720;

end;

procedure TForm1.FormCreate(Sender: TObject);      {Вызывается при создании формы : только один раз, а так же исп-ся для ввода исходных данных}
var i:integer;
begin
 form1.PageControl1.ActivePageIndex:=0;   {Активная страница нулевая}

 

 form1.Edit1.Text:='1000';

 form1.Edit2.Text:='10';

 form1.Edit3.Text:='20';

 form1.Edit4.Text:='150';

 TitleText:='';   {Заголовок графика}
 
   {Обращение к графикам возможно по 2 системам имен: через массив либо через форму}
 for i:=0 to 4 do form1.Chart1.Series[i].ShowInLegend:=false;  {Название графиков = false , не показывать}


end;

procedure TForm1.Button1Click(Sender: TObject);
var i,j,k:integer; x,m,s:double;

    t:ShortString;

begin

 

{ Формирование нормально распределенной выборки случайных чисел }

 

 TitleText:='График выборок случайных чисел';



 val(form1.Edit1.Text,j,k);

 if k<>0     then j:=1000;  {если строка в число не преобразовалась то число опытов j = 1000}

 if j<10     then j:=10;    {если выборка меньше 10 , т.е. слишком маленькая то j = 10}

 if j>100000 then j:=100000;{если выборка меньше 100 000 , т.е. слишком большая то j = 100 000, массив имеет верхнюю границу 100 000}

 form1.Edit1.Text:=IntToStr(j);       {В Edit1 вводим исправленное значение j, IntToStr - число в строку }
                              {эти 5 строк, типовой алгоритм для ввода числа с экрана}

 

 val(form1.Edit2.Text,s,k);      {s - среднекв. отклонение}

 if k<>0    then s:=10;

 if s<0.001 then s:=0.001;

 STR(s:5:3,t);                { Преобразует число в строку. Формат числа - 5 знаков, из них 3 после запятой.
                                Если для целой части знаков не хватит, то они будут добавлены автоматически
                                число s в строку t }

 form1.Edit2.Text:=t;

 

 val(form1.Edit3.Text,m,k);    { m - математ. ожидание }

 if k<>0 then m:=20;

 STR(m:5:3,t);

 form1.Edit3.Text:=t;

 

 form1.StringGrid1.Cells[0,0]:='№ п/п';         {StringGrid - таблица, Cells - ячейка таблицы}

 form1.StringGrid1.Cells[1,0]:='x непр. G';

 

 for i:=1 to j do         {Эксперимент}

  begin

   x:=RandG(m,s);         {Генератор случайных чисел, распределенных по норм. з.
                          (з. Гаусса), с мат. ожиданием m и С.К.О. - s}

   if form1.StringGrid1.RowCount<i+1 then form1.StringGrid1.RowCount:=i+1;
   {RowCount - число строк в таблице StringGrid,
    если число строк меньше чем число строк,
    то мы прибавляем к ней еще одну строку}

   form1.StringGrid1.Cells[0,i]:=IntToStr(i);{Выводим номер опыта}

   STR(x:7:5,t);

   form1.StringGrid1.Cells[1,i]:=t;          {Результат опыта}

  end;

end;



procedure TForm1.Button3Click(Sender: TObject);
var i,j,k,n,code:integer;
    x,m,s, matem_ojid,dispers,sigma,assim,akces:double;

    Xmin,Xmax,dx,y:Single;

    xp: array [0..201] of integer;

    t:ShortString;

begin
  matem_ojid:=0;
  dispers   :=0;
  assim     :=0;
  akces     :=0;
 { Построение гистограмм по выборкам нормально распределенных случайных чисел }



 TitleText:='Гистограммы нормально распределенных случайных чисел и нормальный закон распределения';



 val(form1.Edit1.Text,n,code);  { Ввод n - число опытов }

 if code<>0  then n:=1000;

 if n<10     then n:=10;

 if n>100000 then n:=100000;

 form1.Edit1.Text:=IntToStr(n);



 val(form1.Edit2.Text,s,code);  { Ввод s - С.К.О. }

 if code<>0 then s:=10;

 if s<0.001 then s:=0.001;

 STR(s:5:3,t);

 form1.Edit2.Text:=t;



 val(form1.Edit3.Text,m,code);   { Ввод m -мат. ожидание }

 if code<>0 then m:=20;

 STR(m:5:3,t);

 form1.Edit3.Text:=t;



 val(form1.Edit4.Text,k,code);   { k - число интервалов в гистограмме }

 if code<>0 then k:=100;

 if k<10    then k:=10;

 if k>200   then k:=200;

 form1.Edit4.Text:=IntToStr(k);

 

 for i:=0 to form1.StringGrid1.RowCount-1 do

 for j:=0 to form1.StringGrid1.ColCount-1 do form1.StringGrid1.Cells[j,i]:='';

 

 form1.StringGrid1.RowCount:=2;

 

 form1.StringGrid1.Cells[0,0]:='x';

 form1.StringGrid1.Cells[1,0]:='y непр.  G';

 form1.StringGrid1.Cells[2,0]:='y дискр. G';

 form1.StringGrid1.Cells[3,0]:='y G';

 

 { х непрерывный }

 

 for i:=1 to n do
  begin
  xm[i]:=RandG(m,s);
  matem_ojid:=matem_ojid+xm[i];
  end;
matem_ojid:=matem_ojid/n;
STR(matem_ojid:5:3,t);
form1.Edit5.Text:=t;


 Xmin:=xm[1];

 Xmax:=xm[1];

 for i:=1 to n do

  begin

   if Xmin>xm[i] then Xmin:=xm[i];

   if Xmax<xm[i] then Xmax:=xm[i];
   assim  :=assim+sqr(xm[i]-matem_ojid)*(xm[i]-matem_ojid);
   dispers:=dispers+sqr(xm[i]-matem_ojid);
   akces  :=akces+sqr(xm[i]-matem_ojid)*sqr(xm[i]-matem_ojid);
  end;

 akces:=akces/(n-1);
 assim:=assim/(n-1);

 dispers:=dispers/(n-1);
 sigma:=sqrt(dispers);
 assim:=assim/(sigma*sigma*sigma);
 STR(sigma:5:3,t);
 form1.Edit6.Text:=t;
 STR(assim:5:3,t);
 form1.Edit7.Text:=t;
 akces:=akces/(sqr(sigma)*sqr(sigma)) - 3;
 STR(akces:5:3,t);
 form1.Edit8.Text:=t;
 
 dx:=(Xmax-Xmin)/k;

 

 for j:=0 to k+1 do xp[j]:=0;

 

 { Гистограмма }

 

 for j:=1 to k+1 do

 for i:=1 to n do

 if (xm[i]>=Xmin+(j-1)*dx) and (xm[i]<Xmin+j*dx) then xp[j]:=xp[j]+1;

 

 for j:=0 to k do

  begin

   if form1.StringGrid1.RowCount<j+1 then form1.StringGrid1.RowCount:=j+1;

 

   x:=Xmin+j*dx-0.5*dx;

   STR(x:7:5,t);

   form1.StringGrid1.Cells[0,j+1]:=t;

 

   y:=xp[j]/n/dx;

   STR(y:7:5,t);

   form1.StringGrid1.Cells[1,j+1]:=t;

 

   y:=exp(-SQR(x-m)/(2*SQR(s)))/SQRT(2*Pi)/s;

   STR(y:7:5,t);

   form1.StringGrid1.Cells[3,j+1]:=t;

  end;

 

 { х дискретный }

 

 for j:=0 to k+1 do xp[j]:=0;

 

 { Гистограмма }

 

 for j:=1 to k+1 do

 for i:=1 to n do

 if (Round(xm[i])>=Xmin+(j-1)*dx) and (Round(xm[i])<Xmin+j*dx) then xp[j]:=xp[j]+1;

 

 for j:=0 to k do

  begin

   x:=Xmin+j*dx-0.5*dx;

   y:=xp[j]/n/dx;

   STR(y:5:3,t);

   form1.StringGrid1.Cells[2,j+1]:=t;

  end;

end;

procedure TForm1.Button2Click(Sender: TObject);
var i,j,k:integer; x,m,s:double;

    t:ShortString;

begin
{ Формирование нормально распределенной выборки

  дискретных по амплитуде случайных чисел }

 

 TitleText:='График выброк случайных чисел';

 

 val(form1.Edit1.Text,j,k);

 if k<>0     then j:=1000;

 if j<10     then j:=10;

 if j>100000 then j:=100000;

 form1.Edit1.Text:=IntToStr(j);

 

 val(form1.Edit2.Text,s,k);

 if k<>0    then s:=10;

 if s<0.001 then s:=0.001;

 STR(s:5:3,t);

 form1.Edit2.Text:=t;

 

 val(form1.Edit3.Text,m,k);

 if k<>0 then m:=20;

 STR(m:5:3,t);

 form1.Edit3.Text:=t;

 

 form1.StringGrid1.Cells[0,0]:='№ п/п';

 form1.StringGrid1.Cells[2,0]:='x дискр. G';

 

 for i:=1 to j do

  begin

   x:=Round(RandG(m,s)); {Round - округление до ближайшего целого}

   if form1.StringGrid1.RowCount<i+1 then form1.StringGrid1.RowCount:=i+1;

   form1.StringGrid1.Cells[0,i]:=IntToStr(i);

   STR(x:4:2,t);

   form1.StringGrid1.Cells[2,i]:=t;

  end;

end;

procedure TForm1.Button7Click(Sender: TObject);
var i,j,k:integer; x,y:double;

    t:ShortString;

begin
  { Построение графиков }

 if form1.StringGrid1.RowCount<10 then exit;

{ Очистка графиков, отключение легенд }

 for i:=0 to 4 do

  begin

   form1.Chart1.Series[i].Clear;

   form1.Chart1.Series[i].ShowInLegend:=false;   //Скрыть название графика

  end;



 { Вывод заголовка графика }



 form1.Chart1.Title.Visible:=True;         //Сделать видимой надпись на графике

 form1.Chart1.Title.Text.Clear;            //Очищаем старую запись

 form1.Chart1.Title.Text.Add(TitleText);   //Добавить новую строчку, с надписью в TitleText



 { Вывод легенд из таблицы }



 for j:=1 to form1.StringGrid1.ColCount-1 do if form1.StringGrid1.Cells[j,0]<>'' then

  begin

   form1.Chart1.Series[j].Title:=form1.StringGrid1.Cells[j,0]+'   '; //Подписываем график,  '   ' - чтобы подписи не наползали друг на друга

   form1.Chart1.Series[j].ShowInLegend:=True;                        //Сделать видимым подпись

  end;



 { Рисование графиков из таблицы }



 for i:=1 to form1.StringGrid1.RowCount-1 do

  begin

   t:=form1.StringGrid1.Cells[0,i];

   Val(t,x,k);               // преобразуем t  в переменную x, рез-т k, k не равно 0 строку в число преобразовать невозможно!

   if k<>0 then

    begin

     StrPCopy(ADF,'В строке '+IntToStr(i)+' ошибка по х!!!'); //преобразует строку short string в строку ANSIString
                                              //StrPCopy имеет правило языка C, поэтому она не проверяет совместимость типов данных,
                                              // массив ADF исп-ся как буфер
     Application.MessageBox(ADF,'Ошибка чтения таблицы',0);//функция Win32API, которая выводит стандартное окно сообщения
     //Ошибка чтения таблицы - заголовок формы, ADF - содержимое формы, 0 -число кнопок в таблице,
     // 00 - да, 01 - Да Нет, 11 - Да Нет Отменить

     exit;

    end;



   for j:=1 to form1.StringGrid1.ColCount-1 do

    begin

     if form1.StringGrid1.Cells[j,0]<>'' then

      begin

       t:=form1.StringGrid1.Cells[j,i];

       Val(t,y,k);

       if k<>0 then

        begin

         StrPCopy(ADF,'В строке '+IntToStr(i)+' ошибка по y'+IntToStr(j)+'!!!');

         Application.MessageBox(ADF,'Ошибка чтения таблицы',0);

         exit;

        end;

       form1.Chart1.Series[j-1].AddXY(x,y);//Присоединить еще одну точку к графику

      end;

    end;

  end;

end;

procedure TForm1.Button4Click(Sender: TObject);
var i,j,k,Nmod:integer; x,m,s:double;

    t:ShortString;

begin
{ Формирование Гамма распределенной выборки случайных чисел }

 

 TitleText:='График выброк случайных чисел';

 

 val(form1.Edit1.Text,j,k);

 if k<>0     then j:=1000;

 if j<10     then j:=10;

 if j>100000 then j:=100000;

 form1.Edit1.Text:=IntToStr(j);

 

 val(form1.Edit2.Text,s,k);

 if k<>0    then s:=10;

 if s<0.001 then s:=0.001;

 STR(s:5:3,t);

 form1.Edit2.Text:=t;

 

 val(form1.Edit3.Text,m,k);

 if k<>0 then m:=20;

 STR(m:5:3,t);

 form1.Edit3.Text:=t;

 

 Nmod:=Round(2*SQR(m)/SQR(s)); //mu - для случая когда  mu - int

 if Nmod=0 then Nmod:=1;



 form1.StringGrid1.Cells[0,0]:='№ п/п';

 form1.StringGrid1.Cells[3,0]:='x непр. Г';



 for i:=1 to j do

  begin

   x:=GammaEE(Nmod,s);  // Генератор случ. чисел для случаев когда mu - int ( 1, 2, 3 .. )

   if form1.StringGrid1.RowCount<i+1 then form1.StringGrid1.RowCount:=i+1;

   form1.StringGrid1.Cells[0,i]:=IntToStr(i);

   STR(x:7:5,t);

   form1.StringGrid1.Cells[3,i]:=t;

  end;                                                                   


end;

procedure TForm1.Button5Click(Sender: TObject);
var i,j,k,Nmod:integer; x,m,s:double;

    t:ShortString;

begin

 

{ Формирование Гамма распределенной выборки

  дискретных по амплитуде случайных чисел }

 

 TitleText:='График выброк случайных чисел';

 

 val(form1.Edit1.Text,j,k);

 if k<>0     then j:=1000;

 if j<10     then j:=10;

 if j>100000 then j:=100000;

 form1.Edit1.Text:=IntToStr(j);

 

 val(form1.Edit2.Text,s,k);

 if k<>0    then s:=10;

 if s<0.001 then s:=0.001;

 STR(s:5:3,t);

 form1.Edit2.Text:=t;

 

 val(form1.Edit3.Text,m,k);

 if k<>0 then m:=20;

 STR(m:5:3,t);

 form1.Edit3.Text:=t;

 

 Nmod:=Round(2*SQR(m)/SQR(s));

 if Nmod=0 then Nmod:=1;

 

 form1.StringGrid1.Cells[0,0]:='№ п/п';

 form1.StringGrid1.Cells[4,0]:='x диск. Г';

 

 for i:=1 to j do

  begin

   x:=Round(GammaEE(Nmod,s));

   if form1.StringGrid1.RowCount<i+1 then form1.StringGrid1.RowCount:=i+1;

   form1.StringGrid1.Cells[0,i]:=IntToStr(i);

   STR(x:4:2,t);

   form1.StringGrid1.Cells[4,i]:=t;

  end;

end;



procedure TForm1.Button6Click(Sender: TObject);
var i,j,k,n,code,Nmod,mm:integer;
    x,m,s,kk,matem_ojid,dispers,assim,akces,sigma:double;

    Xmin,Xmax,dx,y:Single;

    xp: array [0..201] of integer;

    t:ShortString;

begin
  matem_ojid:=0;
  dispers   :=0;
  assim     :=0;
  akces     :=0;
{ Построение гистограмм по выборкам Гамма распределенных случайных чисел }

 TitleText:='Гистограммы гамма распределенных случайных чисел, гамма и нормальный закон распределения';

 

 val(form1.Edit1.Text,n,code);

 if code<>0  then n:=1000;

 if n<10     then n:=10;

 if n>100000 then n:=100000;

 form1.Edit1.Text:=IntToStr(n);

 

 val(form1.Edit2.Text,s,code);

 if code<>0 then s:=10;

 if s<0.001 then s:=0.001;

 STR(s:5:3,t);

 form1.Edit2.Text:=t;

 

 val(form1.Edit3.Text,m,code);

 if code<>0 then m:=20;

 STR(m:5:3,t);

 form1.Edit3.Text:=t;

 

 val(form1.Edit4.Text,k,code);

 if code<>0 then k:=100;

 if k<10    then k:=10;

 if k>200   then k:=200;

 form1.Edit4.Text:=IntToStr(k);

 kk:=m/SQR(s);

 mm:=Round(m*kk-1);

 Nmod:=Round(2*SQR(m)/SQR(s));

 

 if Nmod=0 then Nmod:=1;

 

 for i:=0 to form1.StringGrid1.RowCount-1 do

 for j:=0 to form1.StringGrid1.ColCount-1 do form1.StringGrid1.Cells[j,i]:='';

 

 form1.StringGrid1.RowCount:=2;

 

 form1.StringGrid1.Cells[0,0]:='x';

 form1.StringGrid1.Cells[1,0]:='y непр.  Г';

 form1.StringGrid1.Cells[2,0]:='y дискр. Г';

 form1.StringGrid1.Cells[3,0]:='y Г';

 form1.StringGrid1.Cells[4,0]:='y G';

 

 { х непрерывный }

 

 for i:=1 to n do
 begin
  xm[i]:=GammaEE(Nmod,m);
  matem_ojid:=matem_ojid+xm[i];
 end;
matem_ojid:=matem_ojid/n;
STR(matem_ojid:5:3,t);
form1.Edit5.Text:=t;

 

 Xmin:=xm[1];

 Xmax:=xm[1];

 for i:=1 to n do

  begin

   if Xmin>xm[i] then Xmin:=xm[i];

   if Xmax<xm[i] then Xmax:=xm[i];

   assim  :=assim+sqr(xm[i]-matem_ojid)*(xm[i]-matem_ojid);
   dispers:=dispers+sqr(xm[i]-matem_ojid);
   akces  :=akces+sqr(xm[i]-matem_ojid)*sqr(xm[i]-matem_ojid);
  end;

 akces:=akces/(n-1);
 assim:=assim/(n-1);

 dispers:=dispers/(n-1);
 sigma:=sqrt(dispers);
 assim:=assim/(sigma*sigma*sigma);
 STR(sigma:5:3,t);
 form1.Edit6.Text:=t;
 STR(assim:5:3,t);
 form1.Edit7.Text:=t;
 akces:=akces/(sqr(sigma)*sqr(sigma)) - 3;
 STR(akces:5:3,t);
 form1.Edit8.Text:=t;

 dx:=(Xmax-Xmin)/k;

 

 for j:=0 to k+1 do xp[j]:=0;

 

 { Гистограмма }

 

 for j:=1 to k+1 do

 for i:=1 to n do

 if (xm[i]>=Xmin+(j-1)*dx) and (xm[i]<Xmin+j*dx) then xp[j]:=xp[j]+1;

 

 { Вывод в таблицу }

 

 for j:=0 to k do

  begin

   if form1.StringGrid1.RowCount<j+1 then form1.StringGrid1.RowCount:=j+1;

 

   x:=Xmin+j*dx-0.5*dx;

   STR(x:7:5,t);

   form1.StringGrid1.Cells[0,j+1]:=t;

 

   y:=xp[j]/n/dx;

   STR(y:7:5,t);

   form1.StringGrid1.Cells[1,j+1]:=t;

 

   if x>=0 then y:=Erlang(kk,mm,x) else y:=0;     //Erlang - теоретич. гамма распр. для целых mu

   STR(y:7:5,t);

   form1.StringGrid1.Cells[3,j+1]:=t;

 

   y:=exp(-SQR(x-m)/(2*SQR(s)))/SQRT(2*Pi)/s;

   STR(y:7:5,t);

   form1.StringGrid1.Cells[4,j+1]:=t;

 

  end;

 

 { х дискретный }

 

 for j:=0 to k+1 do xp[j]:=0;

 

 { Гистограмма }

 

 for j:=1 to k+1 do

 for i:=1 to n do

 if (Round(xm[i])>=Xmin+(j-1)*dx) and (Round(xm[i])<Xmin+j*dx) then xp[j]:=xp[j]+1;

 

 { Вывод в таблицу }

 

 for j:=0 to k do

  begin

   x:=Xmin+j*dx-0.5*dx;

   y:=xp[j]/n/dx;

   STR(y:7:5,t);

   form1.StringGrid1.Cells[2,j+1]:=t;

  end;

 

end;




end.
