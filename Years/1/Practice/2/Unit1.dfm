object frm: Tfrm
  Left = 261
  Top = 118
  Width = 733
  Height = 647
  Caption = #1047#1072#1074#1076#1072#1085#1085#1103' 2. '#1042#1072#1088#1110#1072#1085#1090' '#8470'4'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 56
    Top = 48
    Width = 152
    Height = 23
    Caption = #1055#1077#1088#1096#1080#1081' '#1089#1087#1080#1089#1086#1082
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 288
    Top = 48
    Width = 144
    Height = 23
    Caption = #1044#1088#1091#1075#1080#1081' '#1089#1087#1080#1089#1086#1082
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 40
    Top = 528
    Width = 641
    Height = 18
    Caption = 
      '('#1042' '#1086#1073#1077#1088#1085#1077#1085#1086#1084#1091' '#1087#1086#1088#1103#1076#1082#1091') '#1057#1083#1086#1074#1072' '#1087#1077#1088#1096#1086#1075#1086' '#1089#1087#1080#1089#1082#1091', '#1097#1086' '#1085#1077' '#1084#1110#1089#1090#1103#1090#1100#1089#1103' '#1091' '#1076 +
      #1088#1091#1075#1086#1084#1091':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 504
    Top = 56
    Width = 90
    Height = 13
    Caption = #1056#1086#1079#1084#1110#1088' '#1087#1077#1088#1096#1086#1075#1086
  end
  object Label5: TLabel
    Left = 504
    Top = 80
    Width = 87
    Height = 13
    Caption = #1056#1086#1079#1084#1110#1088' '#1076#1088#1091#1075#1086#1075#1086
  end
  object stg1: TStringGrid
    Left = 48
    Top = 80
    Width = 169
    Height = 377
    ColCount = 1
    DefaultColWidth = 147
    FixedCols = 0
    RowCount = 15
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object stg2: TStringGrid
    Left = 280
    Top = 80
    Width = 169
    Height = 377
    ColCount = 1
    DefaultColWidth = 147
    FixedCols = 0
    RowCount = 15
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 1
  end
  object btnFill: TButton
    Left = 496
    Top = 168
    Width = 185
    Height = 65
    Caption = #1047#1072#1087#1086#1074#1085#1080#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    OnClick = btnFillClick
  end
  object btnDo: TButton
    Left = 496
    Top = 248
    Width = 185
    Height = 65
    Caption = #1042#1080#1082#1086#1085#1072#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    OnClick = btnDoClick
  end
  object edtOut: TEdit
    Left = 40
    Top = 560
    Width = 641
    Height = 21
    ReadOnly = True
    TabOrder = 4
  end
  object edtSize1: TEdit
    Left = 600
    Top = 56
    Width = 57
    Height = 21
    TabOrder = 5
    Text = '2'
  end
  object edtSize2: TEdit
    Left = 600
    Top = 80
    Width = 57
    Height = 21
    TabOrder = 6
    Text = '5'
  end
  object btnSizeStg: TButton
    Left = 496
    Top = 104
    Width = 185
    Height = 25
    Caption = #1055#1110#1076#1075#1086#1090#1091#1074#1072#1090#1080' '#1090#1072#1073#1083#1080#1094#1110
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 7
    OnClick = btnSizeStgClick
  end
end
