object Form5: TForm5
  Left = 249
  Top = 225
  Width = 411
  Height = 305
  Caption = 'Form5'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 24
    Top = 32
    Width = 97
    Height = 13
    Caption = #1052#1072#1088#1082#1072' '#1072#1074#1090#1086#1073#1086#1084#1080#1083#1103
  end
  object Label3: TLabel
    Left = 24
    Top = 96
    Width = 25
    Height = 13
    Caption = #1062#1074#1077#1090
  end
  object Label2: TLabel
    Left = 24
    Top = 64
    Width = 126
    Height = 13
    Caption = #1056#1077#1075#1080#1089#1090#1088#1072#1094#1080#1086#1085#1085#1099#1081' '#1085#1086#1084#1077#1088
  end
  object Edit1: TEdit
    Left = 152
    Top = 24
    Width = 145
    Height = 21
    MaxLength = 20
    TabOrder = 0
    OnKeyPress = Edit1KeyPress
  end
  object Edit3: TEdit
    Left = 152
    Top = 88
    Width = 145
    Height = 21
    MaxLength = 15
    TabOrder = 1
    OnKeyPress = Edit3KeyPress
  end
  object MaskEdit1: TMaskEdit
    Left = 152
    Top = 56
    Width = 143
    Height = 21
    AutoSelect = False
    CharCase = ecUpperCase
    EditMask = 'L;1;_'
    MaxLength = 1
    TabOrder = 2
    Text = ' '
  end
  object Button1: TButton
    Left = 24
    Top = 120
    Width = 169
    Height = 41
    Caption = #1042#1083#1072#1076#1077#1083#1100#1094#1099
    TabOrder = 3
    OnClick = Button1Click
  end
  object Button3: TButton
    Left = 224
    Top = 120
    Width = 73
    Height = 41
    Caption = #1047#1072#1082#1088#1099#1090#1100
    TabOrder = 4
    OnClick = Button3Click
  end
end
