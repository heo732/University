object frm: Tfrm
  Left = 377
  Top = 155
  Width = 594
  Height = 529
  Caption = #1047#1072#1076#1072#1095#1072' '#1041#1102#1092#1092#1086#1085#1072
  Color = cl3DLight
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -16
  Font.Name = 'Consolas'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 19
  object Label1: TLabel
    Left = 104
    Top = 16
    Width = 162
    Height = 19
    Caption = #1044#1086#1074#1078#1080#1085#1072' '#1075#1086#1083#1082#1080' (2l)'
  end
  object Label2: TLabel
    Left = 104
    Top = 56
    Width = 225
    Height = 19
    Caption = #1042#1110#1076#1089#1090#1072#1085#1100' '#1084#1110#1078' '#1087#1088#1103#1084#1080#1084#1080' (2a)'
  end
  object Label3: TLabel
    Left = 104
    Top = 112
    Width = 243
    Height = 19
    Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1077#1082#1089#1087#1077#1088#1080#1084#1077#1085#1090#1110#1074' (n)'
  end
  object Label4: TLabel
    Left = 216
    Top = 224
    Width = 171
    Height = 19
    Caption = 'p = 2l / a/Pi ~ m/n'
  end
  object Label5: TLabel
    Left = 168
    Top = 432
    Width = 36
    Height = 19
    Caption = 'Pi ='
  end
  object Label6: TLabel
    Left = 24
    Top = 304
    Width = 342
    Height = 19
    Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1087#1077#1088#1077#1090#1080#1085#1110#1074'  '#1075#1086#1083#1082#1086#1102' '#1087#1088#1103#1084#1086#1111' (m)'
  end
  object Label7: TLabel
    Left = 24
    Top = 352
    Width = 153
    Height = 19
    Caption = #1063#1072#1089#1090#1086#1090#1072' '#1087#1086#1076#1110#1111' (p)'
  end
  object Label8: TLabel
    Left = 392
    Top = 40
    Width = 63
    Height = 19
    Caption = '2l < 2a'
  end
  object Label9: TLabel
    Left = 216
    Top = 264
    Width = 135
    Height = 19
    Caption = 'Pi ~ 2l*n / a/m'
  end
  object Label10: TLabel
    Left = 384
    Top = 464
    Width = 98
    Height = 15
    Caption = #1063#1072#1089' '#1074#1080#1082#1086#1085#1072#1085#1085#1103':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Consolas'
    Font.Style = []
    ParentFont = False
  end
  object lblTime: TLabel
    Left = 488
    Top = 465
    Width = 7
    Height = 15
    Caption = '0'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Consolas'
    Font.Style = []
    ParentFont = False
  end
  object edt2L: TEdit
    Left = 472
    Top = 16
    Width = 73
    Height = 27
    TabOrder = 0
    Text = '6'
  end
  object edt2A: TEdit
    Left = 472
    Top = 56
    Width = 73
    Height = 27
    TabOrder = 1
    Text = '7'
  end
  object edtN: TEdit
    Left = 376
    Top = 112
    Width = 169
    Height = 27
    TabOrder = 2
    Text = '1000000'
  end
  object edtPi: TEdit
    Left = 216
    Top = 432
    Width = 329
    Height = 27
    Color = clGradientActiveCaption
    ReadOnly = True
    TabOrder = 3
  end
  object btnDo: TButton
    Left = 168
    Top = 152
    Width = 225
    Height = 57
    Caption = #1055#1088#1086#1074#1077#1089#1090#1080' '#1077#1082#1089#1087#1077#1088#1080#1084#1077#1085#1090#1080
    TabOrder = 4
    OnClick = btnDoClick
  end
  object edtM: TEdit
    Left = 392
    Top = 304
    Width = 153
    Height = 27
    ReadOnly = True
    TabOrder = 5
  end
  object edtP: TEdit
    Left = 391
    Top = 352
    Width = 153
    Height = 27
    ReadOnly = True
    TabOrder = 6
  end
end