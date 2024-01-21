object FormMain: TFormMain
  Left = 804
  Top = 361
  Width = 549
  Height = 393
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
    Width = 177
    Height = 281
    ColCount = 2
    DefaultColWidth = 75
    DefaultRowHeight = 30
    RowCount = 8
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object stg2: TStringGrid
    Left = 352
    Top = 48
    Width = 177
    Height = 281
    ColCount = 2
    DefaultColWidth = 75
    DefaultRowHeight = 30
    RowCount = 8
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 1
  end
  object btnRowCountMinus: TButton
    Left = 8
    Top = 48
    Width = 25
    Height = 65
    Caption = #8212
    TabOrder = 2
    OnClick = btnRowCountMinusClick
  end
  object btnRowCountPlus: TButton
    Left = 8
    Top = 112
    Width = 25
    Height = 65
    Caption = '+'
    TabOrder = 3
    OnClick = btnRowCountPlusClick
  end
  object btnSize: TButton
    Left = 224
    Top = 96
    Width = 41
    Height = 41
    Caption = '?'
    TabOrder = 4
    OnClick = btnSizeClick
  end
  object btnRead: TButton
    Left = 264
    Top = 96
    Width = 41
    Height = 41
    Caption = '?'
    TabOrder = 5
    OnClick = btnReadClick
  end
  object btnClear: TButton
    Left = 304
    Top = 96
    Width = 41
    Height = 41
    Caption = '?'
    TabOrder = 6
    OnClick = btnClearClick
  end
  object btnAdd: TButton
    Left = 224
    Top = 176
    Width = 41
    Height = 41
    Caption = '+'
    TabOrder = 7
    OnClick = btnAddClick
  end
  object btnSub: TButton
    Left = 264
    Top = 176
    Width = 41
    Height = 41
    Caption = #8212
    TabOrder = 8
    OnClick = btnSubClick
  end
  object btnMultiply: TButton
    Left = 304
    Top = 176
    Width = 41
    Height = 41
    Caption = '*'
    TabOrder = 9
    OnClick = btnMultiplyClick
  end
  object btnLess: TButton
    Left = 264
    Top = 216
    Width = 41
    Height = 41
    Caption = '<'
    TabOrder = 10
    OnClick = btnLessClick
  end
  object btnMore: TButton
    Left = 224
    Top = 216
    Width = 41
    Height = 41
    Caption = '>'
    TabOrder = 11
    OnClick = btnMoreClick
  end
  object btnReverse: TButton
    Left = 224
    Top = 136
    Width = 121
    Height = 41
    Caption = '<'#8212'>'
    TabOrder = 12
    OnClick = btnReverseClick
  end
  object btnEqual: TButton
    Left = 304
    Top = 216
    Width = 41
    Height = 41
    Caption = '=='
    TabOrder = 13
    OnClick = btnEqualClick
  end
end
