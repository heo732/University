object formMain: TformMain
  Left = 290
  Top = 121
  Width = 827
  Height = 554
  Caption = #1052#1086#1076#1077#1083#1102#1074#1072#1085#1085#1103' '#1089#1080#1089#1090#1077#1084' | '#1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1072' '#1088#1086#1073#1086#1090#1072' '#8470'3'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Verdana'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 801
    Height = 481
    BevelOuter = bvNone
    TabOrder = 0
    object Label1: TLabel
      Left = 16
      Top = 32
      Width = 7
      Height = 13
      Caption = 'T'
    end
    object Label2: TLabel
      Left = 16
      Top = 72
      Width = 9
      Height = 13
      Caption = 'M'
    end
    object Label3: TLabel
      Left = 16
      Top = 112
      Width = 119
      Height = 13
      Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1090#1088#1072#1108#1082#1090#1086#1088#1110#1081
    end
    object Image1: TImage
      Left = 228
      Top = 15
      Width = 550
      Height = 450
    end
    object Edit1: TEdit
      Left = 152
      Top = 32
      Width = 57
      Height = 21
      TabOrder = 0
      Text = '3000'
    end
    object Edit2: TEdit
      Left = 152
      Top = 72
      Width = 57
      Height = 21
      TabOrder = 1
      Text = '300'
    end
    object Edit3: TEdit
      Left = 152
      Top = 112
      Width = 57
      Height = 21
      TabOrder = 2
      Text = '10'
    end
    object Button1: TButton
      Left = 16
      Top = 160
      Width = 193
      Height = 49
      Caption = #1055#1086#1073#1091#1076#1091#1074#1072#1090#1080
      Default = True
      TabOrder = 3
      OnClick = Button1Click
    end
  end
  object Panel2: TPanel
    Left = 0
    Top = 0
    Width = 801
    Height = 481
    BevelOuter = bvNone
    TabOrder = 1
    object Label4: TLabel
      Left = 16
      Top = 32
      Width = 7
      Height = 13
      Caption = 'T'
    end
    object Label5: TLabel
      Left = 16
      Top = 72
      Width = 7
      Height = 13
      Caption = 'h'
    end
    object Label6: TLabel
      Left = 16
      Top = 112
      Width = 15
      Height = 13
      Caption = 'So'
    end
    object Image2: TImage
      Left = 228
      Top = 15
      Width = 550
      Height = 450
    end
    object Label7: TLabel
      Left = 16
      Top = 152
      Width = 5
      Height = 13
      Caption = 'r'
    end
    object Label8: TLabel
      Left = 16
      Top = 192
      Width = 34
      Height = 13
      Caption = 'sigma'
    end
    object Label9: TLabel
      Left = 16
      Top = 232
      Width = 119
      Height = 13
      Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1090#1088#1072#1108#1082#1090#1086#1088#1110#1081
    end
    object Edit4: TEdit
      Left = 152
      Top = 32
      Width = 57
      Height = 21
      TabOrder = 0
      Text = '4'
    end
    object Edit5: TEdit
      Left = 152
      Top = 72
      Width = 57
      Height = 21
      TabOrder = 1
      Text = '0,01'
    end
    object Edit6: TEdit
      Left = 152
      Top = 112
      Width = 57
      Height = 21
      TabOrder = 2
      Text = '10'
    end
    object Button2: TButton
      Left = 16
      Top = 272
      Width = 193
      Height = 49
      Caption = #1055#1086#1073#1091#1076#1091#1074#1072#1090#1080
      Default = True
      TabOrder = 3
      OnClick = Button2Click
    end
    object Edit7: TEdit
      Left = 152
      Top = 152
      Width = 57
      Height = 21
      TabOrder = 4
      Text = '0,06'
    end
    object Edit8: TEdit
      Left = 152
      Top = 192
      Width = 57
      Height = 21
      TabOrder = 5
      Text = '0,1'
    end
    object Edit9: TEdit
      Left = 152
      Top = 232
      Width = 57
      Height = 21
      TabOrder = 6
      Text = '5'
    end
    object RadioGroup1: TRadioGroup
      Left = 16
      Top = 360
      Width = 193
      Height = 105
      Columns = 2
      ItemIndex = 0
      Items.Strings = (
        #1090#1088#1072#1108#1082#1090#1086#1088#1110#1111
        #1088#1086#1079#1087#1086#1076#1110#1083)
      TabOrder = 7
    end
  end
  object Panel3: TPanel
    Left = 0
    Top = 0
    Width = 801
    Height = 481
    BevelOuter = bvNone
    TabOrder = 2
    object Image3: TImage
      Left = 228
      Top = 15
      Width = 550
      Height = 450
    end
    object Label10: TLabel
      Left = 16
      Top = 48
      Width = 45
      Height = 13
      Caption = 'Lambda'
    end
    object Label11: TLabel
      Left = 16
      Top = 120
      Width = 119
      Height = 13
      Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1090#1088#1072#1108#1082#1090#1086#1088#1110#1081
    end
    object Button3: TButton
      Left = 16
      Top = 272
      Width = 193
      Height = 49
      Caption = #1055#1086#1073#1091#1076#1091#1074#1072#1090#1080
      Default = True
      TabOrder = 0
      OnClick = Button3Click
    end
    object Edit10: TEdit
      Left = 16
      Top = 64
      Width = 121
      Height = 21
      TabOrder = 1
      Text = '4'
    end
    object Edit11: TEdit
      Left = 16
      Top = 136
      Width = 121
      Height = 21
      TabOrder = 2
      Text = '10'
    end
  end
  object MainMenu1: TMainMenu
    object N1: TMenuItem
      Caption = #1047#1072#1074#1076#1072#1085#1085#1103
      object N11: TMenuItem
        Caption = '1'
        OnClick = N11Click
      end
      object N21: TMenuItem
        Caption = '2'
        OnClick = N21Click
      end
      object N31: TMenuItem
        Caption = '3'
        OnClick = N31Click
      end
    end
  end
end
