object formTask2: TformTask2
  Left = 342
  Top = 149
  Width = 796
  Height = 522
  Caption = #1047#1072#1076#1072#1095#1072' 2.4'
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
  object buttonGoMain: TButton
    Left = 344
    Top = 421
    Width = 113
    Height = 49
    Caption = #1053#1072' '#1075#1086#1083#1086#1074#1085#1091
    TabOrder = 0
    OnClick = buttonGoMainClick
  end
  object buttonRandom: TButton
    Left = 504
    Top = 392
    Width = 139
    Height = 89
    Caption = #1056#1072#1085#1076#1086#1084
    TabOrder = 1
    OnClick = buttonRandomClick
  end
  object stringGrid: TStringGrid
    Left = 8
    Top = 8
    Width = 769
    Height = 377
    ColCount = 24
    DefaultColWidth = 30
    DefaultRowHeight = 30
    FixedCols = 0
    RowCount = 12
    FixedRows = 0
    TabOrder = 2
  end
  object edit: TEdit
    Left = 16
    Top = 424
    Width = 121
    Height = 24
    TabOrder = 3
  end
  object buttonAdd: TButton
    Left = 144
    Top = 392
    Width = 137
    Height = 89
    Caption = #1044#1086#1076#1072#1090#1080' '#1077#1083#1077#1084#1077#1085#1090
    TabOrder = 4
    OnClick = buttonAddClick
  end
  object buttonErase: TButton
    Left = 648
    Top = 392
    Width = 137
    Height = 89
    Caption = #1054#1095#1080#1089#1090#1080#1090#1080
    TabOrder = 5
    OnClick = buttonEraseClick
  end
end
