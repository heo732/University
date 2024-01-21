object Form1: TForm1
  Left = 255
  Top = 125
  Width = 561
  Height = 500
  Caption = #1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1072' '#1088#1086#1073#1086#1090#1072' '#8470'2'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 16
    Top = 24
    Width = 74
    Height = 13
    Caption = #1042#1074#1077#1076#1110#1090#1100' '#1088#1103#1076#1086#1082':'
  end
  object Label2: TLabel
    Left = 16
    Top = 72
    Width = 74
    Height = 13
    Caption = #1042#1074#1077#1076#1110#1090#1100' '#1089#1083#1086#1074#1086':'
  end
  object Label3: TLabel
    Left = 80
    Top = 176
    Width = 176
    Height = 13
    Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1074#1093#1086#1076#1078#1077#1085#1100' '#1089#1083#1086#1074#1072' '#1074' '#1088#1103#1076#1086#1082':'
  end
  object lblCount: TLabel
    Left = 264
    Top = 168
    Width = 13
    Height = 25
    Caption = '0'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -21
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object edtStr: TEdit
    Left = 112
    Top = 24
    Width = 409
    Height = 21
    TabOrder = 0
    OnChange = edtStrChange
  end
  object edtWord: TEdit
    Left = 112
    Top = 72
    Width = 121
    Height = 21
    TabOrder = 1
    OnChange = edtWordChange
  end
end
