object Form1: TForm1
  Left = 233
  Top = 150
  Width = 856
  Height = 622
  Caption = #1060#1086#1088#1084#1072'_1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnResize = FormResize
  PixelsPerInch = 96
  TextHeight = 13
  object PageControl1: TPageControl
    Left = 0
    Top = 0
    Width = 848
    Height = 588
    ActivePage = TabSheet1
    Align = alClient
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = #1042#1099#1095#1080#1089#1083#1077#1085#1080#1103
      object Label1: TLabel
        Left = 208
        Top = 56
        Width = 7
        Height = 16
        Caption = 's'
        Font.Charset = SYMBOL_CHARSET
        Font.Color = clWindowText
        Font.Height = -13
        Font.Name = 'Symbol'
        Font.Style = []
        ParentFont = False
      end
      object Label2: TLabel
        Left = 208
        Top = 88
        Width = 8
        Height = 13
        Caption = 'm'
      end
      object Label3: TLabel
        Left = 208
        Top = 24
        Width = 6
        Height = 13
        Caption = 'n'
      end
      object Label4: TLabel
        Left = 206
        Top = 120
        Width = 6
        Height = 13
        Caption = 'k'
      end
      object Label5: TLabel
        Left = 8
        Top = 8
        Width = 180
        Height = 13
        Caption = #1053#1086#1088#1084#1072#1083#1100#1085#1099#1081' '#1079#1072#1082#1086#1085' '#1088#1072#1089#1087#1088#1077#1076#1077#1083#1077#1085#1080#1103
      end
      object Label6: TLabel
        Left = 24
        Top = 160
        Width = 115
        Height = 13
        Caption = #1043#1072#1084#1084#1072' '#1088#1072#1089#1087#1088#1077#1076#1077#1083#1077#1085#1080#1077
      end
      object Edit1: TEdit
        Left = 224
        Top = 24
        Width = 121
        Height = 21
        TabOrder = 0
        Text = 'Edit1'
      end
      object Button1: TButton
        Left = 0
        Top = 24
        Width = 161
        Height = 25
        Caption = #1057#1086#1079#1076#1072#1090#1100' '#1074#1099#1073#1086#1088#1082#1091' '#1085#1077#1086#1087#1088'. x'
        TabOrder = 1
        OnClick = Button1Click
      end
      object Button2: TButton
        Left = 0
        Top = 56
        Width = 161
        Height = 25
        Caption = #1057#1086#1079#1076#1072#1090#1100' '#1074#1099#1073#1086#1088#1082#1091' '#1076#1080#1089#1082#1088'. x'
        TabOrder = 2
        OnClick = Button2Click
      end
      object Button3: TButton
        Left = 0
        Top = 88
        Width = 161
        Height = 25
        Caption = #1055#1086#1089#1090#1088#1086#1080#1090#1100' '#1075#1080#1089#1090#1086#1075#1088#1072#1084#1084#1091
        TabOrder = 3
        OnClick = Button3Click
      end
      object Button4: TButton
        Left = 0
        Top = 176
        Width = 145
        Height = 25
        Caption = #1057#1086#1079#1076#1072#1090#1100' '#1074#1099#1073#1086#1088#1082#1091' '#1085#1077#1087#1088'. x'
        TabOrder = 4
        OnClick = Button4Click
      end
      object Button5: TButton
        Left = 0
        Top = 208
        Width = 145
        Height = 25
        Caption = #1057#1086#1079#1076#1072#1090#1100' '#1074#1099#1073#1086#1088#1082#1091' '#1076#1080#1089#1082#1088'. x'
        TabOrder = 5
        OnClick = Button5Click
      end
      object Button6: TButton
        Left = 0
        Top = 240
        Width = 145
        Height = 25
        Caption = #1055#1086#1089#1090#1088#1086#1080#1090#1100' '#1075#1080#1089#1090#1086#1075#1088#1072#1084#1084#1091
        TabOrder = 6
        OnClick = Button6Click
      end
      object Button7: TButton
        Left = 0
        Top = 336
        Width = 185
        Height = 25
        Caption = #1055#1086#1089#1090#1088#1086#1080#1090#1100' '#1075#1088#1072#1092#1080#1082#1080
        TabOrder = 7
        OnClick = Button7Click
      end
      object Button8: TButton
        Left = 0
        Top = 392
        Width = 185
        Height = 25
        Caption = #1052#1077#1090#1086#1076#1080#1095#1077#1089#1082#1080#1077' '#1091#1082#1072#1079#1072#1085#1080#1103
        TabOrder = 8
      end
      object Edit2: TEdit
        Left = 224
        Top = 56
        Width = 121
        Height = 21
        TabOrder = 9
        Text = 'Edit2'
      end
      object Edit3: TEdit
        Left = 224
        Top = 88
        Width = 121
        Height = 21
        TabOrder = 10
        Text = 'Edit3'
      end
      object Edit4: TEdit
        Left = 224
        Top = 120
        Width = 121
        Height = 21
        TabOrder = 11
        Text = 'Edit4'
      end
      object StringGrid1: TStringGrid
        Left = 368
        Top = 16
        Width = 353
        Height = 529
        TabOrder = 12
        ColWidths = (
          64
          64
          64
          64
          62)
      end
    end
    object TabSheet2: TTabSheet
      Caption = #1043#1088#1072#1092#1080#1082#1080
      ImageIndex = 1
      object Chart1: TChart
        Left = 0
        Top = 0
        Width = 840
        Height = 560
        BackWall.Brush.Color = clWhite
        BackWall.Brush.Style = bsClear
        Title.Frame.Color = 65408
        Title.Text.Strings = (
          'TChart')
        Title.Visible = False
        View3D = False
        Align = alClient
        PopupMenu = PopupMenu1
        TabOrder = 0
        object Series1: TFastLineSeries
          Marks.ArrowLength = 8
          Marks.Visible = False
          SeriesColor = clRed
          LinePen.Color = clRed
          LinePen.Width = 2
          XValues.DateTime = False
          XValues.Name = 'X'
          XValues.Multiplier = 1.000000000000000000
          XValues.Order = loAscending
          YValues.DateTime = False
          YValues.Name = 'Y'
          YValues.Multiplier = 1.000000000000000000
          YValues.Order = loNone
        end
        object Series2: TFastLineSeries
          Marks.ArrowLength = 8
          Marks.Visible = False
          SeriesColor = -1
          LinePen.Color = -1
          LinePen.Width = 2
          XValues.DateTime = False
          XValues.Name = 'X'
          XValues.Multiplier = 1.000000000000000000
          XValues.Order = loAscending
          YValues.DateTime = False
          YValues.Name = 'Y'
          YValues.Multiplier = 1.000000000000000000
          YValues.Order = loNone
        end
        object Series3: TFastLineSeries
          Marks.ArrowLength = 8
          Marks.Visible = False
          SeriesColor = 16744703
          LinePen.Color = 16744703
          LinePen.Width = 2
          XValues.DateTime = False
          XValues.Name = 'X'
          XValues.Multiplier = 1.000000000000000000
          XValues.Order = loAscending
          YValues.DateTime = False
          YValues.Name = 'Y'
          YValues.Multiplier = 1.000000000000000000
          YValues.Order = loNone
        end
        object Series4: TFastLineSeries
          Marks.ArrowLength = 8
          Marks.Visible = False
          SeriesColor = clBlue
          LinePen.Color = clBlue
          LinePen.Width = 2
          XValues.DateTime = False
          XValues.Name = 'X'
          XValues.Multiplier = 1.000000000000000000
          XValues.Order = loAscending
          YValues.DateTime = False
          YValues.Name = 'Y'
          YValues.Multiplier = 1.000000000000000000
          YValues.Order = loNone
        end
        object Series5: TFastLineSeries
          Marks.ArrowLength = 8
          Marks.Visible = False
          SeriesColor = clLime
          LinePen.Color = clLime
          LinePen.Width = 2
          XValues.DateTime = False
          XValues.Name = 'X'
          XValues.Multiplier = 1.000000000000000000
          XValues.Order = loAscending
          YValues.DateTime = False
          YValues.Name = 'Y'
          YValues.Multiplier = 1.000000000000000000
          YValues.Order = loNone
        end
      end
    end
  end
  object PopupMenu1: TPopupMenu
    Left = 188
    Top = 184
    object N1: TMenuItem
      Caption = #1057#1082#1086#1087#1080#1088#1086#1074#1072#1090#1100' '#1074' '#1073#1091#1092#1077#1088'  '#1052#1052#1054
      OnClick = N1Click
    end
    object N2: TMenuItem
      Caption = #1054#1090#1084#1077#1085#1080#1090#1100
    end
  end
end
