unit GAI3;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, Spin;

type
  TForm3 = class(TForm)
    Label1: TLabel;
    Edit1: TEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    SpinEdit1: TSpinEdit;
    Button4: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure Button4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form3: TForm3; //Создаём форму
  Count, I: Integer; //счетчик
  col: Integer; //количество строк в таблице ответа
  str: String;

implementation

uses GAI, GAI4;

{$R *.dfm}

{ реакция на нажатие кнопки "Владельцы и номера по марке" }
procedure TForm3.Button1Click(Sender: TObject);
var j:integer;
begin
Form4.Caption:='Поиск автомобилей заданной марки '+Edit1.Text;
str:=Edit1.Text; //присваиваем введенное значение строке
j:=1; i:=0; col:=1; count:=0;   //сбрасываем показатели
  if (Kol<>0) and (Edit1.Text<>'') then begin //проверка, чтобы были записи и поле не пустое
    Form4.StringGrid1.ColCount:=2;      //создаем таблицу из 2-х столбцов
    Form4.StringGrid1.Cells[0,0]:='Фамилия';
    Form4.StringGrid1.Cells[1,0]:='Гос. номер';
    Form4.Show;   //выводим форму с таблицей
    while (i<>Form1.StringGrid1.RowCount-1) do  //начало алгоритма поиска
      begin //пока I<>количеству строк
        inc(i);//увеличиваем счетчик прочитанных строк
        if str=Form1.StringGrid1.Cells[0,i] then begin   //если найдено совпадение
          inc(col); //увеличиваем количество строк
          Form4.StringGrid1.RowCount:=Col; //присваиваем новое количество строк
          Form4.StringGrid1.Cells[0,j]:=Form1.StringGrid1.Cells[4,i]; //переписываем фамилию в ответ
          Form4.StringGrid1.Cells[1,j]:=Form1.StringGrid1.Cells[1,i]; //переписываем гос номер в ответ
          inc(j); //переводим на следующую строку ответа
          inc(count);  //уведичиваем счетчик
        end;
      end;
    if count=0 then begin MessageDlg('Не найдено ни одной записи!', mtError,[mbok],0); Form4.Close; end; //если нет записей выводим сообщение и закрываем форму
  end else if Kol=0 then MessageDlg('Таблица пуста!', mtError,[mbok],0) //вывод ошибки
              else MessageDlg('Не введен критерий поиска!', mtError,[mbok],0); //выводи ошибки
end;

{ реакция на нажатие кнопки "Закрыть" }
procedure TForm3.Button3Click(Sender: TObject);
begin
Close;  //закрываем форму
end;

{ реакция на нажатие кнопки "Поиск количества" }
procedure TForm3.Button2Click(Sender: TObject);
begin
str:=Edit1.Text; //присваиваем введенное значение строке
i:=0; count:=0; //сбрасываем показатели
  if (Kol<>0) and (Edit1.Text<>'') then begin //проверка, чтобы были записи в таблице и поле не пустое
    while (i<>Form1.StringGrid1.RowCount-1) do //пока I<>количеству строк
      begin
        inc(i);//увеличиваем счетчик прочитанных строк
        if str=Form1.StringGrid1.Cells[0,i] then inc(count);  //если нашлось совпадение, то увеличиваем счетчик на 1
      end;
    str:=IntToStr(count); //переводим число в строку
    MessageDlg('Количество автомобилей заданной марки = '+str, mtInformation,[mbok],0); //выводим ответ
  end else if Kol=0 then MessageDlg('Таблица пуста!', mtError,[mbok],0) //выводим ошибку
              else MessageDlg('Не введен критерий поиска!', mtError,[mbok],0); //выводим ошибку
end;

{ действие на ввод в поле марка а/м }
procedure TForm3.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
if not (Key in ['0'..'9', 'А'..'Я','A'..'Z','a'..'z', 'а'..'я','-',#8, #32]) then Key:=#0; //ввод только букв, пробела и тире
end;

{ реакция на нажатие кнопки "По году и марке" }
procedure TForm3.Button4Click(Sender: TObject);
var j:integer;
begin
Form4.Caption:='Поиск автомобилей заданной марки '+Edit1.Text+' и году регистрации '+SpinEdit1.Text;
str:=Edit1.Text; //присваиваем введенное значение строке
j:=1; i:=0; col:=1; count:=0;   //сбрасываем показатели
  if (Kol<>0) and (Edit1.Text<>'') then begin //проверка, чтобы были записи и поле не пустое
    Form4.StringGrid1.ColCount:=5; //создаем таблицу из 5-и столбцов
    Form4.StringGrid1.Cells[0,0]:='Марка';
    Form4.StringGrid1.Cells[1,0]:='Гос. номер';
    Form4.StringGrid1.Cells[2,0]:='Цвет';
    Form4.StringGrid1.Cells[3,0]:='Год регистрации';
    Form4.StringGrid1.Cells[4,0]:='Фамилия владельца';
    Form4.Show; //выводим форму с таблицей
    while (i<>Form1.StringGrid1.RowCount-1) do
      begin //пока I<>количеству строк
        inc(i);//увеличиваем счетчик прочитанных строк
        if (str=Form1.StringGrid1.Cells[0,i]) and (StrToInt(SpinEdit1.Text)<=StrToInt(Form1.StringGrid1.Cells[3,i])) then begin
          inc(col); //увеличиваем количество строк
          Form4.StringGrid1.RowCount:=Col;
          Form4.StringGrid1.Cells[0,j]:=Form1.StringGrid1.Cells[0,i];
          Form4.StringGrid1.Cells[1,j]:=Form1.StringGrid1.Cells[1,i];
          Form4.StringGrid1.Cells[2,j]:=Form1.StringGrid1.Cells[2,i];
          Form4.StringGrid1.Cells[3,j]:=Form1.StringGrid1.Cells[3,i];
          Form4.StringGrid1.Cells[4,j]:=Form1.StringGrid1.Cells[4,i];
          inc(j);      //перевод на следующую строку ответа
          inc(count);  //увеличиваем счетчик
        end;
      end;
  if count=0 then begin MessageDlg('Не найдено ни одной записи!', mtError,[mbok],0); Form4.Close; end; //если нет записей выводим сообщение и закрываем форму
  end else if Kol=0 then MessageDlg('Таблица пуста!', mtError,[mbok],0) //вывод ошибки
              else MessageDlg('Не введен критерий поиска!', mtError,[mbok],0); //выводи ошибки
end;

end.
