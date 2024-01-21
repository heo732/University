object formExample2: TformExample2
  Left = 395
  Top = 154
  Width = 559
  Height = 480
  Caption = #1055#1088#1080#1082#1083#1072#1076' 2'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -13
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 16
  object Label1: TLabel
    Left = 192
    Top = 16
    Width = 8
    Height = 16
    Caption = 'p'
  end
  object Label2: TLabel
    Left = 192
    Top = 48
    Width = 35
    Height = 16
    Caption = 'alpha'
  end
  object Label3: TLabel
    Left = 8
    Top = 128
    Width = 128
    Height = 16
    Caption = #1042#1080#1073#1110#1088#1082#1086#1074#1077' '#1089#1077#1088#1077#1076#1085#1108
  end
  object labelAverage: TLabel
    Left = 8
    Top = 168
    Width = 10
    Height = 18
    Caption = '0'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 376
    Top = 128
    Width = 139
    Height = 16
    Caption = #1042#1080#1073#1110#1088#1082#1086#1074#1072' '#1076#1080#1089#1087#1077#1088#1089#1110#1103
  end
  object labelDispersion: TLabel
    Left = 376
    Top = 160
    Width = 10
    Height = 18
    Caption = '0'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Button4: TButton
    Left = 192
    Top = 376
    Width = 193
    Height = 65
    Caption = #1053#1072#1079#1072#1076
    TabOrder = 0
    OnClick = Button4Click
  end
  object StringGrid1: TStringGrid
    Left = 208
    Top = 128
    Width = 153
    Height = 233
    ColCount = 2
    DefaultColWidth = 30
    RowCount = 10
    FixedRows = 0
    TabOrder = 1
    ColWidths = (
      30
      103)
  end
  object Button1: TButton
    Left = 208
    Top = 88
    Width = 153
    Height = 33
    Caption = #1043#1077#1085#1077#1088#1091#1074#1072#1090#1080
    TabOrder = 2
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 248
    Top = 16
    Width = 121
    Height = 24
    TabOrder = 3
    Text = '0,1'
  end
  object Edit2: TEdit
    Left = 248
    Top = 48
    Width = 121
    Height = 24
    TabOrder = 4
    Text = '2'
  end
end
