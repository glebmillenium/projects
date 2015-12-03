library my_library;

{ Important note about DLL memory management: ShareMem must be the
  first unit in your library's USES clause AND your project's (select
  Project-View Source) USES clause if your DLL exports any procedures or
  functions that pass strings as parameters or function results. This
  applies to all strings passed to and from your DLL--even those that
  are nested in records and classes. ShareMem is the interface unit to
  the BORLNDMM.DLL shared memory manager, which must be deployed along
  with your DLL. To avoid using BORLNDMM.DLL, pass string information
  using PChar or ShortString parameters. }

{ ShareMem должна быть первой в списке вызываемых модулей
  а также в вашем проекте
}

uses
  ShareMem, Windows, SysUtils,  Classes, ActiveX;

{$R *.res}

function Triple (C: Char): Longint; stdcall; overload;
begin
//  ShowMessage ('Triple (Char) function called');
  MessageBox (0, 'Вызвана функция Triple',
    'First DLL', mb_OK);
  Result := Ord (C) * 3;
end;

function Triple (N: Longint): Longint; stdcall; overload;
begin
//  ShowMessage ('Triple function called');
  MessageBox (0, 'Вызвана функция Triple',
    'First DLL', mb_OK);
  Result := N * 3;
end;

function Double (N: Longint): Longint; stdcall;
begin
//  ShowMessage ('Double function called');
  MessageBox (0, 'Вызвана функция Double',
    'First DLL', mb_OK);
  Result := N * 2;
end;

function DoubleString (s: PAnsiChar; Separat: PAnsiChar): TBSTR; stdcall;
var Res: WideString;
begin
  Res:= string(s)+string(Separat)+string(s);
  DoubleString := SysAllocStringLen(PWideChar(Res), Length(Res));
end;

function readFileToMemo (way: PAnsiChar): TBSTR; stdcall;
var f:TextFile;
    res:WideString;
    temp:string;
begin
  res:='';
  assignfile(f,string(way));
  reset(f);
  while not eof(f) do
    begin
      read(f,temp);
      res:=res+temp;
    end;
  MessageBox (0, 'Считывание файла окончено!',
    'First DLL', mb_OK);
  readFileToMemo := SysAllocStringLen(PWideChar(res), Length(res));
end;

function writeTextInFile(fileDir: PAnsiChar; text: PAnsiChar):integer;stdcall;
var f:TextFile;
begin

 AssignFile(f,'C:\Users\Глеб\Desktop\need.txt'); //регистрация файла
 Rewrite(f); //создание файла, если он там есть, то перезаписываеться (старый удаляеться, новый пустой появляеться)
 //Reset(f); //просто открываем файл для редактирования
 WriteLn(f,'My first file!!!'); //записываем строку в файл с переводом курсора на новую строку
 Write(f,'My first file!!!'); //записываем строку в файл без перевода курсора на новую строку
 CloseFile(f); //закрываем файл

MessageBox (0, 'Запись файла успешно завершена!',
    'First DLL', mb_OK);
writeTextInFile:=1;
end;

function DoublePChar (BufferIn, BufferOut: PChar;
  BufferOutLen: Cardinal; Separator: Char): LongBool; stdcall;
var
  SepStr: array [0..1] of Char;
begin
  // если буфер недостаточно большой
  if BufferOutLen > StrLen (BufferIn) * 2 + 2 then
  begin
    // копировать входной буфер в выходной
    StrCopy (BufferOut, BufferIn);
    // Построить разделяющую строку (заканчивающуюся нулевым байтом)
    SepStr [0] := Separator; // это второй параметр функции
    SepStr [1] := #0;
    // добавить разделитель
    StrCat (BufferOut, SepStr);
    // добавить входной буфер
    StrCat (BufferOut, BufferIn);
    Result := True;
  end
  else
    // Недостаточно места
    Result := False;
end;
exports
  Triple (N: Longint),
  Triple (C: Char) name 'TripleChar',
  Double, DoubleString, DoublePChar, readFileToMemo,writeTextInFile;
begin
end.

