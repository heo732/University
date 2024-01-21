object Form1: TForm1
  Left = 286
  Top = 153
  Width = 948
  Height = 500
  Caption = 
    #1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1072' '#1088#1086#1073#1086#1090#1072' '#8470'4. '#1042#1087#1086#1088#1103#1076#1082#1091#1074#1072#1085#1085#1103' '#1084#1072#1089#1080#1074#1091'. '#1044'/'#1079'. '#1042#1072#1088#1110#1072#1085#1090' '#8470'4. '#1044#1074 +
    #1086#1074#1080#1084#1110#1088#1085#1080#1081' '#1084#1072#1089#1080#1074
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 168
    Top = 16
    Width = 27
    Height = 24
    Caption = 'n ='
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 64
    Top = 96
    Width = 181
    Height = 24
    Caption = #1055#1086#1095#1072#1090#1082#1086#1074#1072' '#1084#1072#1090#1088#1080#1094#1103':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 728
    Top = 96
    Width = 98
    Height = 24
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 376
    Top = 96
    Width = 173
    Height = 24
    Caption = #1055#1088#1086#1084#1110#1078#1085#1072' '#1084#1072#1090#1088#1080#1094#1103':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
  end
  object edtSize: TEdit
    Left = 208
    Top = 16
    Width = 73
    Height = 32
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    Text = '5'
  end
  object btnSize: TButton
    Left = 328
    Top = 16
    Width = 129
    Height = 33
    Caption = 'SIZE'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    OnClick = btnSizeClick
  end
  object btnDo: TButton
    Left = 464
    Top = 16
    Width = 129
    Height = 33
    Caption = 'DO'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    OnClick = btnDoClick
  end
  object stgIn: TStringGrid
    Left = 16
    Top = 128
    Width = 265
    Height = 233
    ColCount = 6
    DefaultColWidth = 25
    DefaultRowHeight = 25
    RowCount = 6
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    ParentFont = False
    TabOrder = 3
  end
  object stgOut: TStringGrid
    Left = 640
    Top = 128
    Width = 265
    Height = 233
    ColCount = 6
    DefaultColWidth = 25
    DefaultRowHeight = 25
    RowCount = 6
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
  end
  object btnRandom: TButton
    Left = 40
    Top = 368
    Width = 217
    Height = 25
    Caption = #1047#1072#1087#1086#1074#1085#1080#1090#1080' '#1088#1072#1085#1076#1086#1084#1085#1080#1084#1080' '#1079#1085#1072#1095#1077#1085#1085#1103#1084#1080
    TabOrder = 5
    OnClick = btnRandomClick
  end
  object edtRandomL: TEdit
    Left = 16
    Top = 368
    Width = 25
    Height = 21
    TabOrder = 6
    Text = '1'
  end
  object edtRandomR: TEdit
    Left = 256
    Top = 368
    Width = 25
    Height = 21
    TabOrder = 7
    Text = '100'
  end
  object stgBetween: TStringGrid
    Left = 328
    Top = 128
    Width = 265
    Height = 233
    ColCount = 6
    DefaultColWidth = 25
    DefaultRowHeight = 25
    RowCount = 6
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'MS Sans Serif'
    Font.Style = []
    ParentFont = False
    TabOrder = 8
  end
end
