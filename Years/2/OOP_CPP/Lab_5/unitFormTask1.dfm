object formTask1: TformTask1
  Left = 339
  Top = 55
  Width = 800
  Height = 700
  Caption = #1047#1072#1076#1072#1095#1072' 1.4'
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
  object imageConsistentDeck1: TImage
    Left = 8
    Top = 8
    Width = 200
    Height = 300
    OnMouseUp = imageConsistentDeck1MouseUp
  end
  object imageFreeDeck1: TImage
    Left = 8
    Top = 328
    Width = 200
    Height = 300
    OnMouseUp = imageFreeDeck1MouseUp
  end
  object imageFreeDeck2: TImage
    Left = 576
    Top = 328
    Width = 200
    Height = 300
    OnMouseUp = imageFreeDeck2MouseUp
  end
  object imageConsistentDeck2: TImage
    Left = 576
    Top = 8
    Width = 200
    Height = 300
    OnMouseUp = imageConsistentDeck2MouseUp
  end
  object imageCurrentCard1: TImage
    Left = 280
    Top = 248
    Width = 100
    Height = 150
  end
  object imageCurrentCard2: TImage
    Left = 416
    Top = 248
    Width = 100
    Height = 150
  end
  object Label1: TLabel
    Left = 280
    Top = 136
    Width = 88
    Height = 18
    Caption = #1043#1088#1072#1074#1077#1094#1100'_1'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clLime
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 416
    Top = 136
    Width = 88
    Height = 18
    Caption = #1043#1088#1072#1074#1077#1094#1100'_2'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clRed
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object labelCountPoints1: TLabel
    Left = 320
    Top = 168
    Width = 10
    Height = 18
    Caption = '0'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clLime
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object labelCountPoints2: TLabel
    Left = 456
    Top = 168
    Width = 10
    Height = 18
    Caption = '0'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clRed
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object labelStatus: TLabel
    Left = 288
    Top = 32
    Width = 211
    Height = 18
    Caption = #1047#1072#1088#1072#1079' '#1093#1086#1076#1080#1090#1100': '#1043#1088#1072#1074#1077#1094#1100'_1'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clTeal
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 328
    Top = 448
    Width = 98
    Height = 16
    Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1093#1086#1076#1110#1074
  end
  object buttonGoMain: TButton
    Left = 344
    Top = 608
    Width = 113
    Height = 49
    Caption = #1053#1072' '#1075#1086#1083#1086#1074#1085#1091
    TabOrder = 0
    OnClick = buttonGoMainClick
  end
  object comboBoxCountSteps: TComboBox
    Left = 433
    Top = 448
    Width = 48
    Height = 24
    ItemHeight = 16
    TabOrder = 1
    Text = '10'
    Items.Strings = (
      '1'
      '2'
      '3'
      '4'
      '5'
      '6'
      '7'
      '8'
      '9'
      '10'
      '11'
      '12'
      '13'
      '14'
      '15'
      '16'
      '17'
      '18'
      '19'
      '20'
      '21'
      '22'
      '23'
      '24'
      '25'
      '26'
      '27'
      '28'
      '29'
      '30'
      '31'
      '32'
      '33'
      '34'
      '35'
      '36')
  end
  object buttonNewGame: TButton
    Left = 344
    Top = 480
    Width = 113
    Height = 33
    Caption = #1053#1086#1074#1072' '#1075#1088#1072
    TabOrder = 2
    OnClick = buttonNewGameClick
  end
end
