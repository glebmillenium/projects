unit MainLaba1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls, Math, StdCtrls, TeEngine, Series, Grids, ExtCtrls,
  TeeProcs, Chart, Menus;  { Math - ��� �������������� ����������}    {rang g -��������� � ���������� math}

type
  TForm1 = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    Edit1: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    Label4: TLabel;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Label5: TLabel;
    Label6: TLabel;
    TabSheet2: TTabSheet;
    Chart1: TChart;
    StringGrid1: TStringGrid;
    Series1: TFastLineSeries;
    Series2: TFastLineSeries;
    Series3: TFastLineSeries;
    Series4: TFastLineSeries;
    Series5: TFastLineSeries;
    PopupMenu1: TPopupMenu;
    N1: TMenuItem;
    N2: TMenuItem;
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
    procedure Button8Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

  { ������ ������ ���������� ���������� ���� PChar }



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

                  { �����-������� - n ��������� }

  z2:=1;

  if mi<2 then z2:=1 else for i:=1 to mi do z2:=z2*i;



                { ���������������� ����� � ������ }



  if mi<=0 then z3:=k else z3:=Power(k,mi+1)*Power(t,mi);



  z3:=z3*exp(-k*t)/z2;

 

  Erlang:=z3;

procedure
 TForm1.Button6Click(Sender: TObject);
var i,j,k,n,code,Nmod,mm:integer; x,m,s,kk:double;

    Xmin,Xmax,dx,y:Single;

    xp: array [0..201] of integer;

    t:ShortString;

begin

 

{ ���������� ���������� �� �������� ����� �������������� ��������� ����� }

 

 TitleText:='����������� ����� �������������� ��������� �����, ����� � ���������� ����� �������������';

 

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

 form1.StringGrid1.Cells[1,0]:='y ����.  �';

 form1.StringGrid1.Cells[2,0]:='y �����. �';

 form1.StringGrid1.Cells[3,0]:='y �';

 form1.StringGrid1.Cells[4,0]:='y G';

 

 { � ����������� }

 

 for i:=1 to n do xm[i]:=GammaEE(Nmod,m);

 

 Xmin:=xm[1];

 Xmax:=xm[1];

 for i:=1 to n do

  begin

   if Xmin>xm[i] then Xmin:=xm[i];

   if Xmax<xm[i] then Xmax:=xm[i];

  end;

 dx:=(Xmax-Xmin)/k;

 

 for j:=0 to k+1 do xp[j]:=0;

 

 { ����������� }

 

 for j:=1 to k+1 do

 for i:=1 to n do

 if (xm[i]>=Xmin+(j-1)*dx) and (xm[i]<Xmin+j*dx) then xp[j]:=xp[j]+1;

 

 { ����� � ������� }

 

 for j:=0 to k do

  begin

   if form1.StringGrid1.RowCount<j+1 then form1.StringGrid1.RowCount:=j+1;

 

   x:=Xmin+j*dx-0.5*dx;

   STR(x:7:5,t);

   form1.StringGrid1.Cells[0,j+1]:=t;

 

   y:=xp[j]/n/dx;

   STR(y:7:5,t);

   form1.StringGrid1.Cells[1,j+1]:=t;

 

   if x>=0 then y:=Erlang(kk,mm,x) else y:=0;

   STR(y:7:5,t);

   form1.StringGrid1.Cells[3,j+1]:=t;

 

   y:=exp(-SQR(x-m)/(2*SQR(s)))/SQRT(2*Pi)/s;

   STR(y:7:5,t);

   form1.StringGrid1.Cells[4,j+1]:=t;

 

  end;

 

 { � ���������� }

 

 for j:=0 to k+1 do xp[j]:=0;

 

 { ����������� }

 

 for j:=1 to k+1 do

 for i:=1 to n do

 if (Round(xm[i])>=Xmin+(j-1)*dx) and (Round(xm[i])<Xmin+j*dx) then xp[j]:=xp[j]+1;

 

 { ����� � ������� }

 

 for j:=0 to k do

  begin

   x:=Xmin+j*dx-0.5*dx;

   y:=xp[j]/n/dx;

   STR(y:7:5,t);

   form1.StringGrid1.Cells[2,j+1]:=t;

  end;

 

end;



procedure TForm1.Button5Click(Sender: TObject);
begin
var i,j,k,Nmod:integer; x,m,s:double;

    t:ShortString;

begin



{ ������������ ����� �������������� �������

  ���������� �� ��������� ��������� ����� }



 TitleText:='������ ������ ��������� �����';



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



 Nmod:=Round(2*SQR(s)/SQR(s));

 if Nmod=0 then Nmod:=1;



 form1.StringGrid1.Cells[0,0]:='� �/�';

 form1.StringGrid1.Cells[4,0]:='x ����. �';



 for i:=1 to j do

  begin

   x:=Round(GammaEE(Nmod,s));

   if form1.StringGrid1.RowCount<i+1 then form1.StringGrid1.RowCount:=i+1;

   form1.StringGrid1.Cells[0,i]:=IntToStr(i);

   STR(x:4:2,t);

   form1.StringGrid1.Cells[4,i]:=t;

  end;
end;

 



procedure TForm1.N1Click(Sender: TObject);
begin
{ ����������� ������� ������� � ����� ��� }



 form1.Chart1.CopyToClipboardMetafile(true); {������� ������� ������� � ����� ���}

{��� ���������� ������� - ����� ���� �� ������}
end;

procedure TForm1.FormResize(Sender: TObject);
begin
   form1.StringGrid1.Left:=form1.Width-365;

 form1.StringGrid1.Height:=form1.Height-65;

 if form1.Width<720 then form1.Width:=720;


end;

procedure TForm1.FormCreate(Sender: TObject);
var i:integer;

begin

 

 form1.PageControl1.ActivePageIndex:=0; {�������� page control �� ������ ��������}

 

 form1.Edit1.Text:='1000';           {������ �������� ��������}

 form1.Edit2.Text:='10';

 form1.Edit3.Text:='20';

 form1.Edit4.Text:='150';

 TitleText:='';      {��������� �������}

 

 for i:=0 to 4 do form1.Chart1.Series[i].ShowInLegend:=false;    {��������� �������� �������� �� ���� �������� ����:
 ���� �������� ������ 16 �� � ��� ����� ��������� ��� � �������}


end;

procedure TForm1.Button1Click(Sender: TObject);
var i,j,k:integer; x,m,s:double;

    t:ShortString;

begin

 

{ ������������ ��������� �������������� ������� ��������� ����� }

 

 TitleText:='������ ������ ��������� �����';



 val(form1.Edit1.Text,j,k);     {������� �������� ��� ����� ����� � ������}

 if k<>0     then j:=1000;    {���� ������ � ����� �� ����������������� �� j=1000}

 if j<10     then j:=10;      {���� j ������ 10, �� ����������� �������� j=10 j-����������� ����� ����}

 if j>100000 then j:=100000;     {���� j ������ 100000, �� j=100000 - ������� ������� ����}

 form1.Edit1.Text:=IntToStr(j);   {� edit1 -������ ������������ �������� j}
              {�������� ����� ����� � ���}   {j - ����� ������}


 val(form1.Edit2.Text,s,k);      {s - �� �� ����������}

 if k<>0    then s:=10;

 if s<0.001 then s:=0.001;

 STR(s:5:3,t); {����������� ����� � ������, ����� ����� 5 ������, �� ��� 3 ����� �������}

 form1.Edit2.Text:=t;         {���� ��� ����� ����� ������ �� ������, �� ��� ����� ����� ���������, �� ��� ����� ����� ������� ������ ������}
          {��� t ������� � edit2}


 val(form1.Edit3.Text,m,k);

 if k<>0 then m:=20; {m ��� ��������}

 STR(m:5:3,t);

 form1.Edit3.Text:=t;



 form1.StringGrid1.Cells[0,0]:='� �/�';   {stringGrid - ����� �������, Cells - ������}

 form1.StringGrid1.Cells[1,0]:='x ����. G';  { 1,0 - ������ ������� ������� ������}


              {��� �����������}
 for i:=1 to j do

  begin

   x:=RandG(m,s);     {��� �� �����, ������� �� ���� ���, � ��� ���� - m � �� �� ���� s}

   if form1.StringGrid1.RowCount<i+1 then form1.StringGrid1.RowCount:=i+1;  {����� ����� � ������� stringgrid}
        {���� ����� ����� � ��� < ����� ������, �� �� ���������� ���� ��� ���� ������}      {��������� ����� ������ � ����, �������� �� 1 ������, ��� rowCount}
   form1.StringGrid1.Cells[0,i]:=IntToStr(i); {� ������� ������� i-�� ������ - ������� ����� �����}

   STR(x:7:5,t);

   form1.StringGrid1.Cells[1,i]:=t;

  end;

end;





procedure TForm1.Button2Click(Sender: TObject);

var i,j,k:integer; x,m,s:double;

    t:ShortString;

begin

 

{ ������������ ��������� �������������� �������

  ���������� �� ��������� ��������� ����� }

 

 TitleText:='������ ������ ��������� �����';

 

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

 

 form1.StringGrid1.Cells[0,0]:='� �/�';

 form1.StringGrid1.Cells[2,0]:='x �����. G';

 

 for i:=1 to j do

  begin

   x:=Round(RandG(m,s)); {�������� ���������� �� ���������� ������}

   if form1.StringGrid1.RowCount<i+1 then form1.StringGrid1.RowCount:=i+1;

   form1.StringGrid1.Cells[0,i]:=IntToStr(i);

   STR(x:4:2,t);

   form1.StringGrid1.Cells[2,i]:=t;

  end;

end;

 

procedure TForm1.Button3Click(Sender: TObject);

var i,j,k,n,code:integer; x,m,s:double;

    Xmin,Xmax,dx,y:Single;

    xp: array [0..201] of integer;

    t:ShortString;

begin

 

{ ���������� ���������� �� �������� ��������� �������������� ��������� ����� }

 

 TitleText:='����������� ��������� �������������� ��������� ����� � ���������� ����� �������������';

 

 val(form1.Edit1.Text,n,code);    {n - ����� ������}
 if code<>0  then n:=1000;

 if n<10     then n:=10;

 if n>100000 then n:=100000;

 form1.Edit1.Text:=IntToStr(n);

 

 val(form1.Edit2.Text,s,code);    {s - ���� �� �� ����}

 if code<>0 then s:=10;

 if s<0.001 then s:=0.001;

 STR(s:5:3,t);

 form1.Edit2.Text:=t;

 

 val(form1.Edit3.Text,m,code);   { m- ������ ��� �������� }

 if code<>0 then m:=20;

 STR(m:5:3,t);

 form1.Edit3.Text:=t;

 

 val(form1.Edit4.Text,k,code);  { �- ����� ���������� �����������}

 if code<>0 then k:=100;

 if k<10    then k:=10;

 if k>200   then k:=200;

 form1.Edit4.Text:=IntToStr(k);

 

 for i:=0 to form1.StringGrid1.RowCount-1 do

 for j:=0 to form1.StringGrid1.ColCount-1 do form1.StringGrid1.Cells[j,i]:='';

 

 form1.StringGrid1.RowCount:=2;

 

 form1.StringGrid1.Cells[0,0]:='x';

 form1.StringGrid1.Cells[1,0]:='y ����.  G';

 form1.StringGrid1.Cells[2,0]:='y �����. G';

 form1.StringGrid1.Cells[3,0]:='y G';

 

 { � ����������� }

 

 for i:=1 to n do xm[i]:=RandG(m,s);

 

 Xmin:=xm[1];

 Xmax:=xm[1];

 for i:=1 to n do

  begin

   if Xmin>xm[i] then Xmin:=xm[i];

   if Xmax<xm[i] then Xmax:=xm[i];

  end;

 dx:=(Xmax-Xmin)/k;

 

 for j:=0 to k+1 do xp[j]:=0;

 

 { ����������� }

 

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

 

 { � ���������� }

 

 for j:=0 to k+1 do xp[j]:=0;

 

 { ����������� }

 

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



procedure TForm1.Button7Click(Sender: TObject);

var i,j,k:integer; x,y:double;

    t:ShortString;

begin

 

{ ���������� �������� }

 

 

 if form1.StringGrid1.RowCount<10 then exit;

 

{ ������� ��������, ���������� ������ }

 

 for i:=0 to 4 do

  begin

   form1.Chart1.Series[i].Clear;

   form1.Chart1.Series[i].ShowInLegend:=false;

  end;

 

 { ����� ��������� ������� } 

 

 form1.Chart1.Title.Visible:=True;

 form1.Chart1.Title.Text.Clear;

 form1.Chart1.Title.Text.Add(TitleText);

 

 { ����� ������ �� ������� }

 

 for j:=1 to form1.StringGrid1.ColCount-1 do if form1.StringGrid1.Cells[j,0]<>'' then

  begin

   form1.Chart1.Series[j].Title:=form1.StringGrid1.Cells[j,0]+'   ';

   form1.Chart1.Series[j].ShowInLegend:=True;

  end;

 

 { ��������� �������� �� ������� }

 

 for i:=1 to form1.StringGrid1.RowCount-1 do

  begin

   t:=form1.StringGrid1.Cells[0,i];{������������ ������ ������}

   Val(t,x,k);

   if k<>0 then {k<>0 ������ � ����� �������� ����������}

    begin

     StrPCopy(ADF,'� ������ '+IntToStr(i)+' ������ �� �!!!'); {�������� � ���� ������, ������� ����� ��,
                                                               ������� ��� �� ��������� ������������� ����� ������. ������ ADF ��� ��� �����}

     Application.MessageBox(ADF,'������ ������ �������',0); {������� Win32 API ��� ������� ����������� ���� �����. ������ ������ ������� - �������� � �����.
                                                               ADF ���������� �����. 0 �� ����� - ����� ������ � ����, �������� � �������� ����.}

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

         StrPCopy(ADF,'� ������ '+IntToStr(i)+' ������ �� y'+IntToStr(j)+'!!!');

         Application.MessageBox(ADF,'������ ������ �������',0);

         exit;

        end;

       form1.Chart1.Series[j-1].AddXY(x,y); {������������ ��� ���� ����� � �������}

      end;

    end;

  end;



end;



procedure TForm1.Button4Click(Sender: TObject);
begin
var i,j,k,Nmod:integer; x,m,s:double;

    t:ShortString;

begin



{ ������������ ����� �������������� ������� ��������� ����� }



 TitleText:='������ ������ ��������� �����';



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



 Nmod:=Round(2*SQR(s)/SQR(s));

 if Nmod=0 then Nmod:=1;



 form1.StringGrid1.Cells[0,0]:='� �/�';

 form1.StringGrid1.Cells[3,0]:='x ����. �';



 for i:=1 to j do

  begin

   x:=GammaEE(Nmod,s);

   if form1.StringGrid1.RowCount<i+1 then form1.StringGrid1.RowCount:=i+1;

   form1.StringGrid1.Cells[0,i]:=IntToStr(i);

   STR(x:7:5,t);

   form1.StringGrid1.Cells[3,i]:=t;

  end;

end;

end.
