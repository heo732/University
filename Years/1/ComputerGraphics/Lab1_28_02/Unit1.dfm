object Form1: TForm1
  Left = 191
  Top = 125
  Width = 870
  Height = 640
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  DesignSize = (
    854
    602)
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 120
    Top = 64
    Width = 49
    Height = 41
    Anchors = [akLeft, akTop, akRight, akBottom]
    AutoSize = False
    BiDiMode = bdLeftToRight
    Caption = 'N='
    Color = clCream
    ParentBiDiMode = False
    ParentColor = False
  end
  object Image1: TImage
    Left = 120
    Top = 272
    Width = 369
    Height = 193
  end
  object Edit1: TEdit
    Left = 176
    Top = 64
    Width = 97
    Height = 41
    AutoSize = False
    TabOrder = 0
    Text = '7'
  end
  object Button1: TButton
    Left = 280
    Top = 64
    Width = 79
    Height = 41
    Caption = #1056#1086#1079#1084#1110#1088
    TabOrder = 1
    OnClick = Button1Click
  end
  object StringGrid1: TStringGrid
    Left = 120
    Top = 120
    Width = 236
    Height = 129
    ColCount = 3
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 2
    RowHeights = (
      24
      24
      24
      24
      24)
  end
  object Button2: TButton
    Left = 368
    Top = 64
    Width = 121
    Height = 41
    Caption = #1057#1077#1088#1077#1076#1085#1110'_'#1082#1086#1086#1088#1076#1080#1085#1072#1090#1080
    TabOrder = 3
    OnClick = Button2Click
  end
  object Edit2: TEdit
    Left = 368
    Top = 120
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'Edit2'
  end
  object Edit3: TEdit
    Left = 368
    Top = 152
    Width = 121
    Height = 21
    TabOrder = 5
    Text = 'Edit3'
  end
  object Button3: TButton
    Left = 536
    Top = 296
    Width = 75
    Height = 25
    Caption = #1053#1072#1088#1080#1089#1091#1074#1072#1090#1080
    TabOrder = 6
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 536
    Top = 344
    Width = 75
    Height = 25
    Caption = #1047#1072#1092#1072#1088#1073#1091#1074#1072#1090#1080
    TabOrder = 7
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 536
    Top = 392
    Width = 75
    Height = 25
    Caption = #1054#1095#1080#1089#1090#1080#1090#1080
    TabOrder = 8
    OnClick = Button5Click
  end
end
