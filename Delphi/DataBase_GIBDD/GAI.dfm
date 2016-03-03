object Form1: TForm1
  Left = 205
  Top = 213
  Width = 696
  Height = 375
  Caption = #1041#1072#1079#1072' '#1076#1072#1085#1085#1099#1093' '#1043#1040#1048
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object StringGrid1: TStringGrid
    Left = 8
    Top = 40
    Width = 585
    Height = 209
    FixedCols = 0
    RowCount = 2
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goRowSelect]
    TabOrder = 0
    OnSelectCell = StringGrid1SelectCell
    ColWidths = (
      113
      114
      91
      122
      132)
  end
  object Button1: TButton
    Left = 8
    Top = 264
    Width = 129
    Height = 41
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 144
    Top = 264
    Width = 129
    Height = 41
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100
    Enabled = False
    TabOrder = 2
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 280
    Top = 264
    Width = 129
    Height = 41
    Caption = #1059#1076#1072#1083#1080#1090#1100
    Enabled = False
    TabOrder = 3
    OnClick = Button3Click
  end
  object MainMenu1: TMainMenu
    Left = 8
    Top = 8
    object N1: TMenuItem
      Caption = #1060#1072#1081#1083
      object N2: TMenuItem
        Caption = #1054#1090#1082#1088#1099#1090#1100
        OnClick = N2Click
      end
      object N3: TMenuItem
        Caption = #1057#1086#1093#1088#1072#1085#1080#1090#1100
        OnClick = N3Click
      end
      object N4: TMenuItem
        Caption = #1057#1086#1093#1088#1072#1085#1080#1090#1100' '#1082#1072#1082
        OnClick = N4Click
      end
      object N5: TMenuItem
        Caption = #1042#1099#1093#1086#1076
        OnClick = N5Click
      end
    end
    object N6: TMenuItem
      Caption = #1055#1086#1080#1089#1082
      object N7: TMenuItem
        Caption = #1055#1086' '#1084#1072#1088#1082#1077
        OnClick = N7Click
      end
      object N8: TMenuItem
        Caption = #1055#1086' '#1084#1072#1088#1082#1077' '#1080' '#1075#1086#1076#1091
        OnClick = N8Click
      end
      object N9: TMenuItem
        Caption = #1055#1086#1080#1089#1082' '#1074#1083#1072#1076#1077#1083#1100#1094#1072
        OnClick = N9Click
      end
    end
  end
  object OpenDialog1: TOpenDialog
    Filter = #1060#1072#1081#1083' '#1076#1072#1085#1085#1099#1093'|*.dat'
    InitialDir = 'C:\Users\??????\Desktop\???????!!!\kursovaya\fail'
    Left = 40
    Top = 8
  end
  object SaveDialog1: TSaveDialog
    Filter = '*.dat|*.dat'
    InitialDir = 'C:\Users\??????\Desktop\???????!!!\kursovaya\fail'
    Left = 72
    Top = 8
  end
end
