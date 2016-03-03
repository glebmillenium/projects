unit GAI2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Spin, StdCtrls, Mask;

type
  TForm2 = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Edit1: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    SpinEdit1: TSpinEdit;
    Button1: TButton;
    Button2: TButton;
    MaskEdit1: TMaskEdit;
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure Edit3KeyPress(Sender: TObject; var Key: Char);
    procedure Edit4KeyPress(Sender: TObject; var Key: Char);
    procedure MaskEdit1KeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation

uses GAI;

{$R *.dfm}

procedure TForm2.FormShow(Sender: TObject);
begin
  if add=true then //была нажата кнопка "Добавить"
   begin
    //Очищаем поля ввода
    Form2.Edit1.Text:='';
    Form2.MaskEdit1.Text:='';
    Form2.Edit3.Text:='';
    Form2.Edit4.Text:='';
    //задаём значения по умолчанию
    Form2.SpinEdit1.Value:=1950;
  end else //Нажали кнопку изменить
    begin
    //вносим выделенные поля в элементы ввода
    Edit1.Text:=Form1.StringGrid1.Cells[0, Nomer];
    MaskEdit1.Text:=Form1.StringGrid1.Cells[1, Nomer];
    Edit3.Text:=Form1.StringGrid1.Cells[2, Nomer];
    Edit4.Text:=Form1.StringGrid1.Cells[4, Nomer];
    SpinEdit1.Value:=StrToInt(Form1.StringGrid1.Cells[3, Nomer]);
    //StrToInt - преобразует строковый аргумент в целое число
    end;

end;

procedure TForm2.Button1Click(Sender: TObject);
var d:integer; //переменная для столбца, в который записываются значения
begin
 if (Edit1.Text<>'') and (MaskEdit1.Text<>MaskEdit1.EditMask) and (Edit3.Text<>'') and (Edit4.Text<>'') then
  begin
    //добавляем в таблицу строку, если была нажата кнопка "Добавить"
    if add=true then
      begin
        Kol:=Kol+1;
       Form1.StringGrid1.RowCount:=Kol+1;
        d:=Kol;
        If kol>0 then begin
          //Делаем доступными кнопки "Изменить" и "Удалить"
          Form1.Button2.Enabled:=True;
          Form1.Button3.Enabled:=True;
       end;
    end else d:=Nomer;
//Заносим введенные значения в таблицу
Form1.StringGrid1.Cells[0, d]:=Edit1.Text;
Form1.StringGrid1.Cells[1, d]:=MaskEdit1.Text;
Form1.StringGrid1.Cells[2, d]:=Edit3.Text;
Form1.StringGrid1.Cells[3, d]:=IntToStr(SpinEdit1.Value);
//IntToStr - преобразует целое значение в строковое
Form1.StringGrid1.Cells[4, d]:=Edit4.Text;
Close; //Закрываем форму редактирования
end else begin
if Edit1.Text='' then MessageDlg('Марка а/м не введена!', mtError,[mbok],0);
if MaskEdit1.Text = MaskEdit1.EditMask then MessageDlg('Гос. номер не введен!', mtError,[mbok],0);
if Edit3.Text='' then MessageDlg('Цвет а/м не введен!', mtError,[mbok],0);
if Edit4.Text='' then MessageDlg('Фамилия владельца не введена!', mtError,[mbok],0);
end;
end;

procedure TForm2.Button2Click(Sender: TObject);
begin
Close;//закрываем форму редактирования
end;

{ реакция на ввод символов в поле марка а/м }
procedure TForm2.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
if not (Key in ['0'..'9', 'А'..'Я','A'..'Z','a'..'z', 'а'..'я','-',#8, #32]) then Key:=#0; //ввод только букв, пробела и тире
end;

{ реакция на ввод символов в поле цвет }
procedure TForm2.Edit3KeyPress(Sender: TObject; var Key: Char);
begin
if not (Key in ['А'..'Я','а'..'я','-',#8, #32]) then Key:=#0; //ввод только букв, пробела и тире
end;

{ реакция на ввод символов в поле фамилия }
procedure TForm2.Edit4KeyPress(Sender: TObject; var Key: Char);
begin
if not (Key in ['А'..'Я','A'..'Z','a'..'z', 'а'..'я','-',#8, #32]) then Key:=#0; //ввод только букв, пробела и тире
end;

{ реакция на ввод символов в поле номер }
procedure TForm2.MaskEdit1KeyPress(Sender: TObject; var Key: Char);
begin
if not (Key in ['А'..'Я','а'..'я','0'..'9',#8]) then Key:=#0; //ввод только букв и цифр
end;

end.
