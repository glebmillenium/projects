unit GAI;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Menus, Grids, StdCtrls;

type
  EError = class(Exception)
     end;

  Zap = Record //�������� ������
      Marka: String[20];
      Number: String[20];
      Color: String[15];
      Year: 1950..2020;
      Fam: String[20];
  End;//����� �������� ������

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
  F: File of Zap; //�������� ��������������� �����
  Rec: Zap;
  Nomer: Integer; //����� ������������� ������
  I: Integer;   //i-������������ ��� �������
  sohr: String; //, sohr ������������ ��� ������������ ����������
  Kol: Integer;// ���������� �������
  add: boolean;// ������� ������� ������ ��������

implementation

uses GAI2, GAI3, GAI5;

{$R *.dfm}

procedure TForm1.FormShow(Sender: TObject);
begin
//������ ��������� ��������
StringGrid1.Cells[0,0]:='����� ����������';
StringGrid1.Cells[1,0]:='���. �����';
StringGrid1.Cells[2,0]:='����';
StringGrid1.Cells[3,0]:='��� ����������� � ���';
StringGrid1.Cells[4,0]:='������� ���������';
Kol:=0;
Nomer:=1;
end;

{ ������� �� ������� ������ "��������" }
procedure TForm1.Button1Click(Sender: TObject);
begin
Form2.Caption:='���������� ������'; //������ ��������� � ����� ��������������
add:=true;
Form2.ShowModal;//�������� ����� Form2 ��� �������������� ������
end;

{ ������� �� ������� ������ "��������" }
procedure TForm1.Button2Click(Sender: TObject);
begin
Form2.Caption:='��������� ������';//������ ��������� � ����� ��������������
add:=false;
Form2.ShowModal;//�������� ����� Form2 ��� ��������������
end;

{ ������� �� ����� ������ � ������� }
procedure TForm1.StringGrid1SelectCell(Sender: TObject; ACol,
  ARow: Integer; var CanSelect: Boolean);
begin
Nomer:=Arow; //��������� ����� ���������� ������
end;

{ ������� �� ������� ������ "�������" }
procedure TForm1.Button3Click(Sender: TObject);
var k:integer;
begin
if Kol<>0 then //�������� �� ����� �� �������
  begin
   for k:= Nomer to StringGrid1.RowCount-1 do
      with StringGrid1 do begin
        //�������� ������
        cells[0,k]:=cells[0, k+1];
        cells[1,k]:=cells[1, k+1];
        cells[2,k]:=cells[2, k+1];
        cells[3,k]:=cells[3, k+1];
        cells[4,k]:=cells[4, k+1];
       end;
    StringGrid1.rows[k-1].Clear; //������� ��������� ������
    Kol:=Kol-1;  //��������� ���������� �����
    if Kol<>0 then StringGrid1.RowCount:=Kol+1 else //���� ������� ��������� ������, ����������� ���������� � ����, ����� �������� ���������
     begin
      //������ ������������ ������ "��������" � "�������" ���� �� ������� �����
      Button2.Enabled:=False;
      Button3.Enabled:=False;
     end;
  end;
end;

{ ������� �� ����� ������ ���� "�������"}
procedure TForm1.N2Click(Sender: TObject);
begin
  if Opendialog1.Execute //���� ������ ����������
    and FileExists(OpenDialog1.FileName) then //��������� ���� ����������
  begin
    sohr:=OpenDialog1.FileName;
    //��������� ��� ����� � �������� ����������
    AssignFile(F, Opendialog1.FileName);
    Reset(f); //��������� ����
    i:=0; //����� ������
    while not eof(f) do begin //���� �� ����� �����
      read(F, Rec); //������ ��������� ������
      inc(i);
      StringGrid1.Cells[0,i]:=Rec.Marka;
      StringGrid1.Cells[1,i]:=Rec.Number;
      StringGrid1.Cells[2,i]:=Rec.Color;
      StringGrid1.Cells[3,i]:=IntToStr(Rec.Year);
      StringGrid1.Cells[4,i]:=Rec.Fam;
      StringGrid1.RowCount:=i+1; //����������� ���������� �����
    end;
    Kol:=i; //��������� ����������� ���������� �����
    if Kol<>0 then
     begin
      //������ ���������� ������ "��������" � "�������"
      Button2.Enabled:=True;
      Button3.Enabled:=True;
     end;
    closefile(f);//��������� ����
  end else ShowMessage('���� �� ����������!')
end;

{ ������� �� ������� ������� ���� "��������� ���" }
procedure TForm1.N4Click(Sender: TObject);
begin
if kol<>0 then begin
if SaveDialog1.Execute then //���� ������ ����������
  begin
    assignfile(f, SaveDialog1.FileName);     //������� ���� � ����������
    if FileExists(SaveDialog1.FileName) then  //��������� ���� ����������
      begin
        if MessageDlg('���� � ����� ������ ��� ����������.������������?', mtConfirmation,[mbYes,mbNo],0)=mrNo then exit; //�����
        end;
    rewrite(f, savedialog1.FileName+'.dat'); //�������� �����
    i:=0;
    while i<>StringGrid1.RowCount-1 do begin
           inc(i); //����������� ������� ����������� �����
           Rec.Marka:=StringGrid1.Cells[0,i];
           Rec.Number:=StringGrid1.Cells[1,i];
           Rec.Color:=StringGrid1.Cells[2,i];
           Rec.Year:=StrToInt(StringGrid1.Cells[3,i]);
           Rec.Fam:=StringGrid1.Cells[4,i];
           Write(f,Rec); //��������� ������ � ����
    end;
    sohr:=SaveDialog1.FileName;
    closefile(f); //��������� ����
  end;
end else MessageDlg('��� ������� � �������!', mtError,[mbOK],0);
end;

{ �����, ��� ������� ������ ���� "�����" }
procedure TForm1.N5Click(Sender: TObject);
begin
Close;
end;

{ �������� ������ ��� ������� ������ ���� "����� �� �����" }
procedure TForm1.N7Click(Sender: TObject);
begin
Form3.Button1.Visible:=True;  //������ �������� ������
Form3.Button2.Visible:=True;  //������ �������� ������
Form3.Button4.Visible:=False;  //�������� ������ ������
Form3.SpinEdit1.Visible:=False;  //�������� ����
Form3.Edit1.Text:='';
Form3.Caption:='����� �� �����'; //��������� ����� ������
Form3.Show; //��������� ����� ������
end;


{ �������� ������ ��� ������� ������ ���� "����� �� ����� � ����" }
procedure TForm1.N8Click(Sender: TObject);
begin
Form3.Button1.Visible:=False;  //������� ������ ������
Form3.Button2.Visible:=False;  //������� ������ ������
Form3.Button4.Visible:=True;  //������ �������� ������
Form3.SpinEdit1.Visible:=True;  //������ ������� ����
Form3.Edit1.Text:='';
Form3.Caption:='����� �� ����� � ����'; //��������� ����� ������
Form3.Show; //��������� ����� ������
end;


{ ������� ��� ������� ������ ���� "����� �������������" }
procedure TForm1.N9Click(Sender: TObject);
begin
Form5.Caption:='����� �������������'; //��������� ����� ������
Form5.Show; //��������� ����� ������
end;

{ ������� �� ������ ���������}
procedure TForm1.N3Click(Sender: TObject);
begin
if kol<>0 then begin //���� ������� �� �����
  if sohr<>'' then   //���� ���� ��� ����������
    begin
    assignfile(f, sohr);  //������� ���� � ����������
    rewrite(f, sohr); //���������� �����
    i:=0;
    while i<>StringGrid1.RowCount-1 do begin
           inc(i); //����������� ������� ����������� �����
           Rec.Marka:=StringGrid1.Cells[0,i];
           Rec.Number:=StringGrid1.Cells[1,i];
           Rec.Color:=StringGrid1.Cells[2,i];
           Rec.Year:=StrToInt(StringGrid1.Cells[3,i]);
           Rec.Fam:=StringGrid1.Cells[4,i];
           Write(f,Rec); //��������� ������ � ����
    end;
    closefile(f); //��������� ����
    end else N4Click(N4);
end else MessageDlg('��� ������� � �������!', mtError,[mbOK],0);
end;

end.
