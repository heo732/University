object frm: Tfrm
  Left = 283
  Top = 123
  Width = 908
  Height = 627
  Caption = #1047#1072#1074#1076#1072#1085#1085#1103' 5'
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
  object img: TImage
    Left = 24
    Top = 32
    Width = 529
    Height = 529
  end
  object Label1: TLabel
    Left = 680
    Top = 40
    Width = 150
    Height = 18
    Caption = #1050#1086#1086#1088#1076#1080#1085#1072#1090#1080' '#1090#1086#1095#1086#1082
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 704
    Top = 72
    Width = 11
    Height = 18
    Caption = 'X'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 800
    Top = 72
    Width = 11
    Height = 18
    Caption = 'Y'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 624
    Top = 96
    Width = 10
    Height = 18
    Caption = '1'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label5: TLabel
    Left = 624
    Top = 136
    Width = 10
    Height = 18
    Caption = '2'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label6: TLabel
    Left = 616
    Top = 208
    Width = 274
    Height = 18
    Caption = #1042#1077#1082#1090#1086#1088#1080' '#1088#1091#1093#1091' /  '#1058#1086#1095#1082#1080' '#1076#1083#1103' '#1041#1077#1079#1100#1108
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label7: TLabel
    Left = 704
    Top = 240
    Width = 11
    Height = 18
    Caption = 'X'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label8: TLabel
    Left = 800
    Top = 240
    Width = 11
    Height = 18
    Caption = 'Y'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label9: TLabel
    Left = 560
    Top = 264
    Width = 104
    Height = 16
    Caption = #1055#1086#1095#1072#1090#1082#1086#1074#1080#1081' / 3'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label10: TLabel
    Left = 560
    Top = 304
    Width = 84
    Height = 16
    Caption = #1050#1110#1085#1094#1077#1074#1080#1081' / 4'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object edtPy1: TEdit
    Left = 768
    Top = 96
    Width = 73
    Height = 21
    TabOrder = 0
  end
  object edtPx2: TEdit
    Left = 672
    Top = 136
    Width = 73
    Height = 21
    TabOrder = 1
  end
  object edtPx1: TEdit
    Left = 672
    Top = 96
    Width = 73
    Height = 21
    TabOrder = 2
  end
  object edtPy2: TEdit
    Left = 768
    Top = 136
    Width = 73
    Height = 21
    TabOrder = 3
  end
  object edtRx1: TEdit
    Left = 672
    Top = 264
    Width = 73
    Height = 21
    TabOrder = 4
  end
  object edtRy1: TEdit
    Left = 768
    Top = 264
    Width = 73
    Height = 21
    TabOrder = 5
  end
  object edtRx2: TEdit
    Left = 672
    Top = 304
    Width = 73
    Height = 21
    TabOrder = 6
  end
  object edtRy2: TEdit
    Left = 768
    Top = 304
    Width = 73
    Height = 21
    TabOrder = 7
  end
  object btnCurveH: TButton
    Left = 672
    Top = 368
    Width = 169
    Height = 49
    Caption = #1050#1088#1080#1074#1072' '#1045#1088#1084#1110#1090#1072
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 8
    OnClick = btnCurveHClick
  end
  object btnCurveB: TButton
    Left = 672
    Top = 424
    Width = 169
    Height = 49
    Caption = #1050#1088#1080#1074#1072' '#1041#1077#1079#1100#1108
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 9
    OnClick = btnCurveBClick
  end
  object btnClear: TButton
    Left = 672
    Top = 512
    Width = 169
    Height = 49
    Caption = #1054#1095#1080#1089#1090#1080#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 10
    OnClick = btnClearClick
  end
end
