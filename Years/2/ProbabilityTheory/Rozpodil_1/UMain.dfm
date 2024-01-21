object Form_Main: TForm_Main
  Left = 251
  Top = 122
  Width = 638
  Height = 200
  Caption = 'Rozpodil'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -13
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 16
  object Label1: TLabel
    Left = 8
    Top = 40
    Width = 9
    Height = 16
    Caption = 'X'
  end
  object Label2: TLabel
    Left = 8
    Top = 72
    Width = 8
    Height = 16
    Caption = 'p'
  end
  object Label3: TLabel
    Left = 336
    Top = 8
    Width = 141
    Height = 16
    Caption = 'Count of experiments'
  end
  object Button_Do: TButton
    Left = 8
    Top = 120
    Width = 609
    Height = 33
    Caption = 'Do'
    TabOrder = 0
    OnClick = Button_DoClick
  end
  object StringGrid: TStringGrid
    Left = 32
    Top = 40
    Width = 585
    Height = 73
    DefaultColWidth = 70
    FixedCols = 0
    RowCount = 2
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 1
  end
  object Button_Minus: TButton
    Left = 56
    Top = 8
    Width = 49
    Height = 25
    Caption = '-'
    TabOrder = 2
    OnClick = Button_MinusClick
  end
  object Button_Plus: TButton
    Left = 128
    Top = 8
    Width = 49
    Height = 25
    Caption = '+'
    TabOrder = 3
    OnClick = Button_PlusClick
  end
  object Button_Generate: TButton
    Left = 224
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Generate'
    TabOrder = 4
    OnClick = Button_GenerateClick
  end
  object Edit_Count_exp: TEdit
    Left = 488
    Top = 8
    Width = 65
    Height = 24
    TabOrder = 5
    Text = '100000'
  end
end
