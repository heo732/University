object formMain: TformMain
  Left = 341
  Top = 118
  Width = 688
  Height = 480
  Caption = #1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1072' '#1088#1086#1073#1086#1090#1072' '#8470'2'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -13
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 16
  object Label1: TLabel
    Left = 122
    Top = 20
    Width = 99
    Height = 16
    Caption = #1084#1086#1078#1083#1080#1074#1110' '#1089#1090#1072#1085#1080
  end
  object Label2: TLabel
    Left = 112
    Top = 120
    Width = 115
    Height = 16
    Caption = #1087#1086#1095#1072#1090#1082#1086#1074#1080#1081' '#1089#1090#1072#1085
  end
  object Label3: TLabel
    Left = 400
    Top = 20
    Width = 216
    Height = 16
    Caption = #1084#1072#1090#1088#1080#1094#1103' '#1110#1084#1086#1074#1110#1088#1085#1086#1089#1090#1077#1081' '#1087#1077#1088#1077#1093#1086#1076#1091
  end
  object Label4: TLabel
    Left = 8
    Top = 208
    Width = 85
    Height = 16
    Caption = #1047#1075#1077#1085#1077#1088#1091#1074#1072#1090#1080
  end
  object Label5: TLabel
    Left = 152
    Top = 208
    Width = 148
    Height = 16
    Caption = #1089#1090#1072#1085#1110#1074' '#1076#1083#1103' '#1076#1072#1085#1086#1075#1086' '#1051#1052
  end
  object Label6: TLabel
    Left = 296
    Top = 368
    Width = 229
    Height = 16
    Caption = #1049#1084#1086#1074#1110#1088#1085#1110#1089#1090#1100' '#1073#1072#1085#1082#1088#1091#1090#1089#1090#1074#1072' '#1082#1086#1084#1087#1072#1085#1110#1111
  end
  object Label7: TLabel
    Left = 370
    Top = 390
    Width = 213
    Height = 23
    Caption = #1089#1090#1072#1085#1110#1074' '#1076#1083#1103' '#1076#1072#1085#1086#1075#1086' '#1051#1052
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Button1: TButton
    Left = 88
    Top = 16
    Width = 27
    Height = 25
    Caption = '-'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 224
    Top = 16
    Width = 27
    Height = 25
    Caption = '+'
    TabOrder = 1
    OnClick = Button2Click
  end
  object StringGrid1: TStringGrid
    Left = 16
    Top = 48
    Width = 320
    Height = 51
    ColCount = 11
    DefaultColWidth = 30
    DefaultRowHeight = 30
    FixedCols = 0
    RowCount = 1
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 2
  end
  object Edit1: TEdit
    Left = 144
    Top = 144
    Width = 49
    Height = 24
    TabOrder = 3
    Text = '3'
  end
  object StringGrid2: TStringGrid
    Left = 360
    Top = 48
    Width = 297
    Height = 297
    ColCount = 12
    DefaultColWidth = 30
    DefaultRowHeight = 30
    RowCount = 12
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 4
  end
  object Edit2: TEdit
    Left = 100
    Top = 206
    Width = 49
    Height = 24
    TabOrder = 5
    Text = '10'
  end
  object Button3: TButton
    Left = 56
    Top = 272
    Width = 241
    Height = 65
    Caption = #1043#1077#1085#1077#1088#1091#1074#1072#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    OnClick = Button3Click
  end
  object StringGrid3: TStringGrid
    Left = 16
    Top = 353
    Width = 641
    Height = 83
    ColCount = 22
    DefaultColWidth = 30
    DefaultRowHeight = 30
    FixedCols = 0
    RowCount = 2
    TabOrder = 7
  end
  object RadioGroup1: TRadioGroup
    Left = 88
    Top = 232
    Width = 185
    Height = 33
    Columns = 4
    ItemIndex = 0
    Items.Strings = (
      '1'
      '2'
      '3'
      '4')
    TabOrder = 8
    OnClick = RadioGroup1Click
  end
  object Edit3: TEdit
    Left = 132
    Top = 358
    Width = 85
    Height = 24
    TabOrder = 9
    Text = '100000'
  end
end
