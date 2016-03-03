unit GAI;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Menus, Grids, StdCtrls;

type
  EError = class(Exception)
     end;

  Zap = Record //описание записи
      Marka: String[20];
      Number: String[20];
      Color: String[15];
      Year: 1950..2020;
      Fam: String[20];
  End;//конец описания записи

  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    N2: TMenuItem;
    N3: TMenuItem;
    N4: TMenuItem;
    N5: TMenuItem;
    N6: TMenuItem;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    OpenDialog1: TOpenDialog;
    SaveDialog1: TSaveDialog;
    N7: TMenuItem;
    N8: TMenuItem;
    N9: TMenuItem;
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure StringGrid1SelectCell(Sender: TObject; ACol, ARow: Integer;
      var CanSelect: Boolean);
    procedure Button3Click(Sender: TObject);
    procedure N2Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
    procedure N5Click(Sender: TObject);
    procedure N7Click(Sender: TObject);
    procedure N8Click(Sender: TObject);
    procedure N9Click(Sender: TObject);
    procedure N3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  F: File of Zap; //описание типизированного файла
  Rec: Zap;
  Nomer: Integer; //номер редактируемой строки
  I: Integer;   //i-используется для поисков
  sohr: String; //, sohr используется для отслеживания сохранения
  Kol: Integer;// количество записей
  add: boolean;// Признак нажатия кнопки добавить

implementation

uses GAI2, GAI3, GAI5;

{$R *.dfm}

procedure TForm1.FormShow(Sender: TObject);
begin
//Задаем заголовки столбцов
StringGrid1.Cells[0,0]:='Марка автомобиля';
StringGrid1.Cells[1,0]:='Гос. номер';
StringGrid1.Cells[2,0]:='Цвет';
StringGrid1.Cells[3,0]:='Год регистрации в ГАИ';
StringGrid1.Cells[4,0]:='Фамилия владельца';
Kol:=0;
Nomer:=1;
end;

{ Реакция на нажатие кнопки "Добавить" }
procedure TForm1.Button1Click(Sender: TObject);
begin
Form2.Caption:='Добавление записи'; //Меняем заголовок в форме редактирования
add:=true;
Form2.ShowModal;//Вызываем форму Form2 для редактирования записи
end;

{ реакция на нажатие кнопки "Изменить" }
procedure TForm1.Button2Click(Sender: TObject);
begin
Form2.Caption:='Изменение записи';//Меняем заголовок в форме редактирования
add:=false;
Form2.ShowModal;//Вызываем форму Form2 для редактирования
end;

{ реакция на выбор строки в таблице }
procedure TForm1.StringGrid1SelectCell(Sender: TObject; ACol,
  ARow: Integer; var CanSelect: Boolean);
begin
Nomer:=Arow; //сохраняем номер выделенной строки
end;

{ реакция на нажатие кнопки "Удалить" }
procedure TForm1.Button3Click(Sender: TObject);
var k:integer;
begin
if Kol<>0 then //проверка не пуста ли таблица
  begin
   for k:= Nomer to StringGrid1.RowCount-1 do
      with StringGrid1 do begin
        //сдвигаем строки
        cells[0,k]:=cells[0, k+1];
        cells[1,k]:=cells[1, k+1];
        cells[2,k]:=cells[2, k+1];
        cells[3,k]:=cells[3, k+1];
        cells[4,k]:=cells[4, k+1];
       end;
    StringGrid1.rows[k-1].Clear; //очистка удаленной строки
    Kol:=Kol-1;  //уменьшаем количество строк
    if Kol<>0 then StringGrid1.RowCount:=Kol+1 else //если удалили последнюю строку, увеличиваем количество а один, чтобы остались заголовки
     begin
      //Делаем недоступными кнопки "Изменить" и "Удалить" если не отслось строк
      Button2.Enabled:=False;
      Button3.Enabled:=False;
     end;
  end;
end;

{ реакция на выбор пункта меню "Открыть"}
procedure TForm1.N2Click(Sender: TObject);
begin
  if Opendialog1.Execute //если диалог выполнился
    and FileExists(OpenDialog1.FileName) then //выбранный файл существует
  begin
    sohr:=OpenDialog1.FileName;
    //связываем имя файла с файловой переменной
    AssignFile(F, Opendialog1.FileName);
    Reset(f); //открываем файл
    i:=0; //номер строки
    while not eof(f) do begin //пока не конец файла
      read(F, Rec); //читаем очередную запись
      inc(i);
      StringGrid1.Cells[0,i]:=Rec.Marka;
      StringGrid1.Cells[1,i]:=Rec.Number;
      StringGrid1.Cells[2,i]:=Rec.Color;
      StringGrid1.Cells[3,i]:=IntToStr(Rec.Year);
      StringGrid1.Cells[4,i]:=Rec.Fam;
      StringGrid1.RowCount:=i+1; //увеличиваем количество строк
    end;
    Kol:=i; //сохраняем прочитанное количество строк
    if Kol<>0 then
     begin
      //Делаем доступными кнопки "Изменить" и "Удалить"
      Button2.Enabled:=True;
      Button3.Enabled:=True;
     end;
    closefile(f);//закрываем файл
  end else ShowMessage('Файл не существует!')
end;

{ реакция на нажатие конопки меню "Сохранить как" }
procedure TForm1.N4Click(Sender: TObject);
begin
if kol<>0 then begin
if SaveDialog1.Execute then //если диалог выполнился
  begin
    assignfile(f, SaveDialog1.FileName);     //связать файл с переменной
    if FileExists(SaveDialog1.FileName) then  //выбранный файл существует
      begin
        if MessageDlg('Файл с таким именем уже существует.Перезаписать?', mtConfirmation,[mbYes,mbNo],0)=mrNo then exit; //выход
        end;
    rewrite(f, savedialog1.FileName+'.dat'); //создание файла
    i:=0;
    while i<>StringGrid1.RowCount-1 do begin
           inc(i); //увеличиваем счетчик прочитанных строк
           Rec.Marka:=StringGrid1.Cells[0,i];
           Rec.Number:=StringGrid1.Cells[1,i];
           Rec.Color:=StringGrid1.Cells[2,i];
           Rec.Year:=StrToInt(StringGrid1.Cells[3,i]);
           Rec.Fam:=StringGrid1.Cells[4,i];
           Write(f,Rec); //сохраняем строку в файл
    end;
    sohr:=SaveDialog1.FileName;
    closefile(f); //закрываем файл
  end;
end else MessageDlg('Нет записей в таблице!', mtError,[mbOK],0);
end;

{ Выход, при нажатие пунтка меню "Выход" }
procedure TForm1.N5Click(Sender: TObject);
begin
Close;
end;

{ открытие поиска при нажатии пункта меню "Поиск по марке" }
procedure TForm1.N7Click(Sender: TObject);
begin
Form3.Button1.Visible:=True;  //Делаем видимыми кнопку
Form3.Button2.Visible:=True;  //Делаем видимыми кнопку
Form3.Button4.Visible:=False;  //Скрываем лишнюю кнопку
Form3.SpinEdit1.Visible:=False;  //Скрываем окно
Form3.Edit1.Text:='';
Form3.Caption:='Поиск по марке'; //открываем форму поиска
Form3.Show; //открываем форму поиска
end;


{ открытие поиска при нажатии пункта меню "Поиск по марке и году" }
procedure TForm1.N8Click(Sender: TObject);
begin
Form3.Button1.Visible:=False;  //Убираем лишние кнопки
Form3.Button2.Visible:=False;  //Убираем лишние кнопки
Form3.Button4.Visible:=True;  //Делаем видимыми кнопку
Form3.SpinEdit1.Visible:=True;  //Делаем видимым окно
Form3.Edit1.Text:='';
Form3.Caption:='Поиск по марке и году'; //открываем форму поиска
Form3.Show; //открываем форму поиска
end;


{ реакция при нажатии пункта меню "Поиск автовладельца" }
procedure TForm1.N9Click(Sender: TObject);
begin
Form5.Caption:='Поиск автовладельца'; //открываем форму поиска
Form5.Show; //открываем форму поиска
end;

{ реакция на кнопку сохранить}
procedure TForm1.N3Click(Sender: TObject);
begin
if kol<>0 then begin //если таблица не пуста
  if sohr<>'' then   //если файл уже существует
    begin
    assignfile(f, sohr);  //связать файл с переменной
    rewrite(f, sohr); //перезапись файла
    i:=0;
    while i<>StringGrid1.RowCount-1 do begin
           inc(i); //увеличиваем счетчик прочитанных строк
           Rec.Marka:=StringGrid1.Cells[0,i];
           Rec.Number:=StringGrid1.Cells[1,i];
           Rec.Color:=StringGrid1.Cells[2,i];
           Rec.Year:=StrToInt(StringGrid1.Cells[3,i]);
           Rec.Fam:=StringGrid1.Cells[4,i];
           Write(f,Rec); //сохраняем строку в файл
    end;
    closefile(f); //закрываем файл
    end else N4Click(N4);
end else MessageDlg('Нет записей в таблице!', mtError,[mbOK],0);
end;

end.
