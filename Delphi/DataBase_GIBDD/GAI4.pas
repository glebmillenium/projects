unit GAI4;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, StdCtrls;

type
  TForm4 = class(TForm)
    Button1: TButton;
    StringGrid1: TStringGrid;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form4: TForm4;

implementation

uses GAI3;

{$R *.dfm}
{ Реакция на нажатие кнопки "ОК" }
procedure TForm4.Button1Click(Sender: TObject);
begin
{ Присваиваем количесвто строк 2. Убираем все значения в таблице }
Form4.StringGrid1.RowCount:=2;
Form4.StringGrid1.Cells[0,1]:='';
Form4.StringGrid1.Cells[1,1]:='';
Form4.StringGrid1.Cells[2,1]:='';
Form4.StringGrid1.Cells[3,1]:='';
Form4.StringGrid1.Cells[4,1]:='';
close;
end;


end.
