object Form_Main: TForm_Main
  Left = 254
  Top = 125
  Width = 696
  Height = 480
  Caption = 
    #1052#1086#1076#1077#1083#1102#1074#1072#1085#1085#1103' '#1085#1077#1087#1077#1088#1077#1088#1074#1085#1086#1111' '#1074#1080#1087#1072#1076#1082#1086#1074#1086#1111' '#1074#1077#1083#1080#1095#1080#1085#1080' '#1088#1110#1074#1085#1086#1084#1110#1088#1085#1086' '#1088#1086#1079#1087#1086#1076#1110#1083#1077 +
    #1085#1086#1111' '#1085#1072' '#1074#1110#1076#1088#1110#1079#1082#1091
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -13
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 16
  object Label1: TLabel
    Left = 96
    Top = 80
    Width = 91
    Height = 16
    Caption = #1052#1077#1078#1110' '#1074#1110#1076#1088#1110#1079#1082#1072
  end
  object Label2: TLabel
    Left = 80
    Top = 112
    Width = 8
    Height = 16
    Caption = 'a'
  end
  object Label3: TLabel
    Left = 152
    Top = 112
    Width = 8
    Height = 16
    Caption = 'b'
  end
  object Label4: TLabel
    Left = 16
    Top = 152
    Width = 279
    Height = 16
    Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1075#1077#1085#1077#1088#1072#1094#1110#1081' '#1074#1080#1087#1072#1076#1082#1086#1074#1086#1111' '#1074#1077#1083#1080#1095#1080#1085#1080
  end
  object Image1: TImage
    Left = 304
    Top = 8
    Width = 369
    Height = 425
  end
  object Label5: TLabel
    Left = 80
    Top = 392
    Width = 164
    Height = 16
    Caption = 'Y(w) = (b-a) * X(w) + a'
  end
  object Edit_A: TEdit
    Left = 96
    Top = 112
    Width = 33
    Height = 24
    TabOrder = 0
    Text = '2'
  end
  object Edit_B: TEdit
    Left = 168
    Top = 112
    Width = 33
    Height = 24
    TabOrder = 1
    Text = '10'
  end
  object Edit_Count: TEdit
    Left = 96
    Top = 176
    Width = 105
    Height = 24
    TabOrder = 2
    Text = '1000'
  end
  object Button_Execute: TButton
    Left = 80
    Top = 240
    Width = 137
    Height = 41
    Caption = #1042#1080#1082#1086#1085#1072#1090#1080
    TabOrder = 3
    OnClick = Button_ExecuteClick
  end
end
