program Laba1;

uses
  Forms,
  MainLaba1 in 'MainLaba1.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
