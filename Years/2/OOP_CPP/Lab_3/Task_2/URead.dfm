object FormRead: TFormRead
  Left = 1037
  Top = 3
  Width = 333
  Height = 336
  Caption = #1047#1072#1087#1086#1074#1085#1077#1085#1085#1103
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object btnInitialize: TButton
    Left = 18
    Top = 112
    Width = 279
    Height = 25
    Caption = #1030#1085#1110#1094#1110#1072#1083#1110#1079#1091#1074#1072#1090#1080' '#1079#1085#1072#1095#1077#1085#1085#1103#1084
    TabOrder = 0
    OnClick = btnInitializeClick
  end
  object btnRandomFill: TButton
    Left = 18
    Top = 152
    Width = 279
    Height = 25
    Caption = #1047#1072#1087#1086#1074#1085#1080#1090#1080' '#1088#1072#1085#1076#1086#1084#1085#1080#1084#1080' '#1079#1085#1072#1095#1077#1085#1085#1103#1084#1080
    TabOrder = 1
    OnClick = btnRandomFillClick
  end
  object btnReadFromFile: TButton
    Left = 18
    Top = 192
    Width = 279
    Height = 25
    Caption = #1055#1088#1086#1095#1080#1090#1072#1090#1080' '#1079' '#1092#1072#1081#1083#1091
    TabOrder = 2
    OnClick = btnReadFromFileClick
  end
  object RadioGroup: TRadioGroup
    Left = 64
    Top = 24
    Width = 177
    Height = 65
    Caption = '            '#1052#1072#1090#1088#1080#1094#1103'            '
    Columns = 2
    ItemIndex = 0
    Items.Strings = (
      '1'
      '2')
    TabOrder = 3
  end
  object btnClose: TButton
    Left = 122
    Top = 256
    Width = 73
    Height = 25
    Caption = #1047#1072#1082#1088#1080#1090#1080
    TabOrder = 4
    OnClick = btnCloseClick
  end
  object OpenDialog: TOpenDialog
    Left = 24
    Top = 56
  end
end
