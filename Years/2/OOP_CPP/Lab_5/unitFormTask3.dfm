object formTask3: TformTask3
  Left = 288
  Top = 114
  Width = 436
  Height = 480
  Caption = #1047#1072#1076#1072#1095#1072' 3.4'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -13
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 16
  object buttonGoMain: TButton
    Left = 152
    Top = 389
    Width = 113
    Height = 49
    Caption = #1053#1072' '#1075#1086#1083#1086#1074#1085#1091
    TabOrder = 0
    OnClick = buttonGoMainClick
  end
  object memoIn: TMemo
    Left = 112
    Top = 16
    Width = 201
    Height = 129
    ScrollBars = ssBoth
    TabOrder = 1
    OnChange = memoInChange
  end
  object memoStrings: TMemo
    Left = 8
    Top = 208
    Width = 201
    Height = 129
    ReadOnly = True
    ScrollBars = ssBoth
    TabOrder = 2
  end
  object memoDigitStrings: TMemo
    Left = 216
    Top = 208
    Width = 201
    Height = 129
    ReadOnly = True
    ScrollBars = ssBoth
    TabOrder = 3
  end
end
