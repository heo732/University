object FormMultOnValue: TFormMultOnValue
  Left = 746
  Top = 75
  Width = 258
  Height = 216
  Caption = #1052#1085#1086#1078#1077#1085#1085#1103' '#1085#1072' '#1095#1080#1089#1083#1086
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object edtValue: TEdit
    Left = 64
    Top = 88
    Width = 105
    Height = 21
    TabOrder = 0
  end
  object btnOk: TButton
    Left = 34
    Top = 138
    Width = 73
    Height = 25
    Caption = 'OK'
    TabOrder = 1
    OnClick = btnOkClick
  end
  object btnClose: TButton
    Left = 130
    Top = 138
    Width = 73
    Height = 25
    Caption = #1047#1072#1082#1088#1080#1090#1080
    TabOrder = 2
    OnClick = btnCloseClick
  end
  object rgMatrix: TRadioGroup
    Left = 32
    Top = 8
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
end
