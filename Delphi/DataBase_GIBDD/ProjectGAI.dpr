program ProjectGAI;

uses
  Forms,
  GAI in 'GAI.pas' {Form1},
  GAI2 in 'GAI2.pas' {Form2},
  GAI3 in 'GAI3.pas' {Form3},
  GAI4 in 'GAI4.pas' {Form4},
  GAI5 in 'GAI5.pas' {Form5};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TForm3, Form3);
  Application.CreateForm(TForm4, Form4);
  Application.CreateForm(TForm5, Form5);
  Application.Run;
end.
