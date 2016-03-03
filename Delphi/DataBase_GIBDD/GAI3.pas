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
  Form3: TForm3; //������ �����
  Count, I: Integer; //�������
  col: Integer; //���������� ����� � ������� ������
  str: String;

implementation

uses GAI, GAI4;

{$R *.dfm}

{ ������� �� ������� ������ "��������� � ������ �� �����" }
procedure TForm3.Button1Click(Sender: TObject);
var j:integer;
begin
Form4.Caption:='����� ����������� �������� ����� '+Edit1.Text;
str:=Edit1.Text; //����������� ��������� �������� ������
j:=1; i:=0; col:=1; count:=0;   //���������� ����������
  if (Kol<>0) and (Edit1.Text<>'') then begin //��������, ����� ���� ������ � ���� �� ������
    Form4.StringGrid1.ColCount:=2;      //������� ������� �� 2-� ��������
    Form4.StringGrid1.Cells[0,0]:='�������';
    Form4.StringGrid1.Cells[1,0]:='���. �����';
    Form4.Show;   //������� ����� � ��������
    while (i<>Form1.StringGrid1.RowCount-1) do  //������ ��������� ������
      begin //���� I<>���������� �����
        inc(i);//����������� ������� ����������� �����
        if str=Form1.StringGrid1.Cells[0,i] then begin   //���� ������� ����������
          inc(col); //����������� ���������� �����
          Form4.StringGrid1.RowCount:=Col; //����������� ����� ���������� �����
          Form4.StringGrid1.Cells[0,j]:=Form1.StringGrid1.Cells[4,i]; //������������ ������� � �����
          Form4.StringGrid1.Cells[1,j]:=Form1.StringGrid1.Cells[1,i]; //������������ ��� ����� � �����
          inc(j); //��������� �� ��������� ������ ������
          inc(count);  //����������� �������
        end;
      end;
    if count=0 then begin MessageDlg('�� ������� �� ����� ������!', mtError,[mbok],0); Form4.Close; end; //���� ��� ������� ������� ��������� � ��������� �����
  end else if Kol=0 then MessageDlg('������� �����!', mtError,[mbok],0) //����� ������
              else MessageDlg('�� ������ �������� ������!', mtError,[mbok],0); //������ ������
end;

{ ������� �� ������� ������ "�������" }
procedure TForm3.Button3Click(Sender: TObject);
begin
Close;  //��������� �����
end;

{ ������� �� ������� ������ "����� ����������" }
procedure TForm3.Button2Click(Sender: TObject);
begin
str:=Edit1.Text; //����������� ��������� �������� ������
i:=0; count:=0; //���������� ����������
  if (Kol<>0) and (Edit1.Text<>'') then begin //��������, ����� ���� ������ � ������� � ���� �� ������
    while (i<>Form1.StringGrid1.RowCount-1) do //���� I<>���������� �����
      begin
        inc(i);//����������� ������� ����������� �����
        if str=Form1.StringGrid1.Cells[0,i] then inc(count);  //���� ������� ����������, �� ����������� ������� �� 1
      end;
    str:=IntToStr(count); //��������� ����� � ������
    MessageDlg('���������� ����������� �������� ����� = '+str, mtInformation,[mbok],0); //������� �����
  end else if Kol=0 then MessageDlg('������� �����!', mtError,[mbok],0) //������� ������
              else MessageDlg('�� ������ �������� ������!', mtError,[mbok],0); //������� ������
end;

{ �������� �� ���� � ���� ����� �/� }
procedure TForm3.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
if not (Key in ['0'..'9', '�'..'�','A'..'Z','a'..'z', '�'..'�','-',#8, #32]) then Key:=#0; //���� ������ ����, ������� � ����
end;

{ ������� �� ������� ������ "�� ���� � �����" }
procedure TForm3.Button4Click(Sender: TObject);
var j:integer;
begin
Form4.Caption:='����� ����������� �������� ����� '+Edit1.Text+' � ���� ����������� '+SpinEdit1.Text;
str:=Edit1.Text; //����������� ��������� �������� ������
j:=1; i:=0; col:=1; count:=0;   //���������� ����������
  if (Kol<>0) and (Edit1.Text<>'') then begin //��������, ����� ���� ������ � ���� �� ������
    Form4.StringGrid1.ColCount:=5; //������� ������� �� 5-� ��������
    Form4.StringGrid1.Cells[0,0]:='�����';
    Form4.StringGrid1.Cells[1,0]:='���. �����';
    Form4.StringGrid1.Cells[2,0]:='����';
    Form4.StringGrid1.Cells[3,0]:='��� �����������';
    Form4.StringGrid1.Cells[4,0]:='������� ���������';
    Form4.Show; //������� ����� � ��������
    while (i<>Form1.StringGrid1.RowCount-1) do
      begin //���� I<>���������� �����
        inc(i);//����������� ������� ����������� �����
        if (str=Form1.StringGrid1.Cells[0,i]) and (StrToInt(SpinEdit1.Text)<=StrToInt(Form1.StringGrid1.Cells[3,i])) then begin
          inc(col); //����������� ���������� �����
          Form4.StringGrid1.RowCount:=Col;
          Form4.StringGrid1.Cells[0,j]:=Form1.StringGrid1.Cells[0,i];
          Form4.StringGrid1.Cells[1,j]:=Form1.StringGrid1.Cells[1,i];
          Form4.StringGrid1.Cells[2,j]:=Form1.StringGrid1.Cells[2,i];
          Form4.StringGrid1.Cells[3,j]:=Form1.StringGrid1.Cells[3,i];
          Form4.StringGrid1.Cells[4,j]:=Form1.StringGrid1.Cells[4,i];
          inc(j);      //������� �� ��������� ������ ������
          inc(count);  //����������� �������
        end;
      end;
  if count=0 then begin MessageDlg('�� ������� �� ����� ������!', mtError,[mbok],0); Form4.Close; end; //���� ��� ������� ������� ��������� � ��������� �����
  end else if Kol=0 then MessageDlg('������� �����!', mtError,[mbok],0) //����� ������
              else MessageDlg('�� ������ �������� ������!', mtError,[mbok],0); //������ ������
end;

end.
