unit GAI5;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Mask;

type
  TForm5 = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    Label3: TLabel;
    Edit3: TEdit;
    Label2: TLabel;
    MaskEdit1: TMaskEdit;
    Button1: TButton;
    Button3: TButton;
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure Edit3KeyPress(Sender: TObject; var Key: Char);
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form5: TForm5;
  Count, I: Integer; //счетчик
  col: Integer; //количество строк в таблице ответа

implementation

uses GAI4, GAI;

{$R *.dfm}

{ действие на ввод в поле марка а/м }
procedure TForm5.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
if not (Key in ['0'..'9', 'А'..'Я','A'..'Z','a'..'z', 'а'..'я','-',#8, #32]) then Key:=#0; //ввод только букв, пробела и тире
end;

{ действие на ввод в поле Цвет }
procedure TForm5.Edit3KeyPress(Sender: TObject; var Key: Char);
begin
if not (Key in ['А'..'Я', 'а'..'я','-',#8, #32]) then Key:=#0; //ввод только букв, пробела и тире
end;

{ действие перед открытием окна }
procedure TForm5.FormShow(Sender: TObject);
begin
Form5.Edit1.Text:='';
Form5.MaskEdit1.Text:='';
Form5.Edit3.Text:='';
end;

procedure TForm5.Button1Click(Sender: TObject);
var j:integer; marka, color, number: String;
begin
Form4.Caption:='Поиск владельцев по марке '+Edit1.Text+' цвету '+Edit3.Text+' и первой букве номера '+MaskEdit1.Text;
marka:=Edit1.Text; color:=Edit3.Text; number:=MaskEdit1.Text; //присваиваем введенное значение строке
j:=1; i:=0; col:=1; count:=0;   //сбрасываем показатели
  if (Kol<>0) and (Edit1.Text<>'') and (MaskEdit1.Text<>MaskEdit1.EditMask) and (Edit3.Text<>'') then begin //проверка, чтобы были записи и поле не пустое
    Form4.StringGrid1.ColCount:=1; //создаем таблицу из 1-го столбца
    Form4.StringGrid1.Cells[0,0]:='Фамилия владельца';
    Form4.Show; //выводим форму с таблицей
    while (i<>Form1.StringGrid1.RowCount-1) do
      begin //пока I<>количеству строк
        inc(i);//увеличиваем счетчик прочитанных строк
        if (marka=Form1.StringGrid1.Cells[0,i]) and (color=Form1.StringGrid1.Cells[2,i]) and (Pos(MaskEdit1.Text,Form1.StringGrid1.Cells[1,i])=1) then begin
          inc(col); //увеличиваем количество строк
          Form4.StringGrid1.RowCount:=Col;
          Form4.StringGrid1.Cells[0,j]:=Form1.StringGrid1.Cells[4,i];
          inc(j);      //перевод на следующую строку ответа
          inc(count);  //увеличиваем счетчик
        end;
      end;
  if count=0 then begin MessageDlg('Не найдено ни одной записи!', mtError,[mbok],0); Form4.Close; end; //если нет записей выводим сообщение и закрываем форму
  end else if Kol=0 then MessageDlg('Таблица пуста!', mtError,[mbok],0) //вывод ошибки
              else MessageDlg('Не введен критерий поиска!', mtError,[mbok],0); //выводи ошибки
end;

procedure TForm5.Button3Click(Sender: TObject);
begin
begin
Form4.StringGrid1.RowCount:=2;
Form4.StringGrid1.Cells[0,1]:='';
Form4.StringGrid1.Cells[1,1]:='';
Form4.StringGrid1.Cells[2,1]:='';
Form4.StringGrid1.Cells[3,1]:='';
Form4.StringGrid1.Cells[4,1]:='';
close;
end;
end;

end.
