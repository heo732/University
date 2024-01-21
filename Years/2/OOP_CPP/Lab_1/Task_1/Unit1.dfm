object Form1: TForm1
  Left = 254
  Top = 107
  Width = 555
  Height = 446
  Caption = #1051#1072#1073'. 1, '#1042#1072#1088#1110#1072#1085#1090' 4, '#1047#1072#1074#1076#1072#1085#1085#1103' 1'
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
    Left = 16
    Top = 48
    Width = 81
    Height = 13
    Caption = #1042#1093#1110#1076#1085#1080#1081' '#1090#1077#1082#1089#1090
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 16
    Top = 232
    Width = 122
    Height = 13
    Caption = #1047#1072#1096#1080#1092#1088#1086#1074#1072#1085#1080#1081' '#1090#1077#1082#1089#1090
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object memIn: TMemo
    Left = 16
    Top = 72
    Width = 513
    Height = 113
    TabOrder = 0
    OnChange = memInChange
  end
  object memOut: TMemo
    Left = 16
    Top = 248
    Width = 513
    Height = 113
    ReadOnly = True
    TabOrder = 1
  end
end
