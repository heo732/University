object FormMain: TFormMain
  Left = 600
  Top = 346
  Width = 773
  Height = 393
  Caption = #1050#1072#1083#1100#1082#1091#1083#1103#1090#1086#1088' '#1084#1072#1090#1088#1080#1094#1100
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object stg1: TStringGrid
    Left = 40
    Top = 48
    Width = 281
    Height = 281
    ColCount = 8
    DefaultColWidth = 30
    DefaultRowHeight = 30
    RowCount = 8
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object stg2: TStringGrid
    Left = 456
    Top = 48
    Width = 281
    Height = 281
    ColCount = 8
    DefaultColWidth = 30
    DefaultRowHeight = 30
    RowCount = 8
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 1
  end
  object btnColCountPlus: TButton
    Left = 224
    Top = 16
    Width = 65
    Height = 25
    Caption = '+'
    TabOrder = 2
    OnClick = btnColCountPlusClick
  end
  object btnColCountMinus: TButton
    Left = 72
    Top = 16
    Width = 65
    Height = 25
    Caption = #8212
    TabOrder = 3
    OnClick = btnColCountMinusClick
  end
  object btnRowCountMinus: TButton
    Left = 8
    Top = 80
    Width = 25
    Height = 65
    Caption = #8212
    TabOrder = 4
    OnClick = btnRowCountMinusClick
  end
  object btnRowCountPlus: TButton
    Left = 8
    Top = 232
    Width = 25
    Height = 65
    Caption = '+'
    TabOrder = 5
    OnClick = btnRowCountPlusClick
  end
  object btnSize: TButton
    Left = 328
    Top = 96
    Width = 41
    Height = 41
    Caption = 'S'
    TabOrder = 6
    OnClick = btnSizeClick
  end
  object btnRead: TButton
    Left = 368
    Top = 96
    Width = 41
    Height = 41
    Caption = 'R'
    TabOrder = 7
    OnClick = btnReadClick
  end
  object btnClear: TButton
    Left = 408
    Top = 96
    Width = 41
    Height = 41
    Caption = 'C'
    TabOrder = 8
    OnClick = btnClearClick
  end
  object btnAdd: TButton
    Left = 328
    Top = 176
    Width = 41
    Height = 41
    Caption = '+'
    TabOrder = 9
    OnClick = btnAddClick
  end
  object btnSub: TButton
    Left = 368
    Top = 176
    Width = 41
    Height = 41
    Caption = #8212
    TabOrder = 10
    OnClick = btnSubClick
  end
  object btnMultiply: TButton
    Left = 408
    Top = 176
    Width = 41
    Height = 41
    Caption = '*'
    TabOrder = 11
    OnClick = btnMultiplyClick
  end
  object btnLessOrNotEqual: TButton
    Left = 368
    Top = 216
    Width = 81
    Height = 41
    Caption = '< OR !='
    TabOrder = 12
    OnClick = btnLessOrNotEqualClick
  end
  object btnMore: TButton
    Left = 328
    Top = 216
    Width = 41
    Height = 41
    Caption = '>'
    TabOrder = 13
    OnClick = btnMoreClick
  end
  object btnReverse: TButton
    Left = 328
    Top = 136
    Width = 121
    Height = 41
    Caption = '<'#8212'>'
    TabOrder = 14
    OnClick = btnReverseClick
  end
end