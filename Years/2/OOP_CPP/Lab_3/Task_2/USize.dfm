object FormSize: TFormSize
  Left = 127
  Top = 32
  Width = 242
  Height = 209
  Caption = #1056#1086#1079#1084#1110#1088#1080
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
    Top = 24
    Width = 96
    Height = 13
    Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1088#1103#1076#1082#1110#1074
  end
  object Label2: TLabel
    Left = 16
    Top = 64
    Width = 107
    Height = 13
    Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1089#1090#1086#1074#1087#1094#1110#1074
  end
  object edtRowCount: TEdit
    Left = 144
    Top = 24
    Width = 65
    Height = 21
    TabOrder = 0
  end
  object edtColCount: TEdit
    Left = 144
    Top = 64
    Width = 65
    Height = 21
    TabOrder = 1
  end
  object btnOk: TButton
    Left = 26
    Top = 130
    Width = 73
    Height = 25
    Caption = 'OK'
    TabOrder = 2
    OnClick = btnOkClick
  end
  object btnClose: TButton
    Left = 122
    Top = 130
    Width = 73
    Height = 25
    Caption = #1047#1072#1082#1088#1080#1090#1080
    TabOrder = 3
    OnClick = btnCloseClick
  end
end
