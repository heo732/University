object frm: Tfrm
  Left = 254
  Top = 107
  Width = 870
  Height = 500
  Caption = #1047#1072#1074#1076#1072#1085#1085#1103' 3. '#1042#1072#1088#1110#1072#1085#1090' '#8470'4'
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
    Left = 64
    Top = 8
    Width = 237
    Height = 16
    Caption = #1042#1084#1110#1089#1090#1080#1084#1077' '#1092#1072#1081#1083#1091' '#1079' '#1087#1077#1088#1096#1080#1084' '#1090#1077#1082#1089#1090#1086#1084
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 448
    Top = 8
    Width = 232
    Height = 16
    Caption = #1042#1084#1110#1089#1090#1080#1084#1077' '#1092#1072#1081#1083#1091' '#1079' '#1076#1088#1091#1075#1080#1084' '#1090#1077#1082#1089#1090#1086#1084
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 64
    Top = 192
    Width = 41
    Height = 16
    Caption = #1060#1072#1081#1083':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 448
    Top = 192
    Width = 41
    Height = 16
    Caption = #1060#1072#1081#1083':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label5: TLabel
    Left = 248
    Top = 416
    Width = 41
    Height = 16
    Caption = #1060#1072#1081#1083':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object Label6: TLabel
    Left = 248
    Top = 232
    Width = 210
    Height = 16
    Caption = #1042#1084#1110#1089#1090#1080#1084#1077' '#1092#1072#1081#1083#1091' '#1079' '#1088#1077#1079#1091#1083#1100#1090#1072#1090#1086#1084
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object lblNameFileIn1: TLabel
    Left = 112
    Top = 192
    Width = 5
    Height = 16
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object lblNameFileIn2: TLabel
    Left = 496
    Top = 192
    Width = 5
    Height = 16
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object lblNameFileOut: TLabel
    Left = 296
    Top = 416
    Width = 5
    Height = 16
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
  end
  object memIn1: TMemo
    Left = 64
    Top = 32
    Width = 353
    Height = 153
    ReadOnly = True
    TabOrder = 0
  end
  object memIn2: TMemo
    Left = 448
    Top = 32
    Width = 353
    Height = 153
    ReadOnly = True
    TabOrder = 1
  end
  object memOut: TMemo
    Left = 248
    Top = 256
    Width = 353
    Height = 153
    ReadOnly = True
    TabOrder = 2
  end
  object btnFileIn1: TButton
    Left = 336
    Top = 192
    Width = 81
    Height = 17
    Caption = #1054#1073#1088#1072#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    OnClick = btnFileIn1Click
  end
  object btnFileIn2: TButton
    Left = 720
    Top = 192
    Width = 81
    Height = 17
    Caption = #1054#1073#1088#1072#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    OnClick = btnFileIn2Click
  end
  object btnFileOut: TButton
    Left = 520
    Top = 416
    Width = 81
    Height = 17
    Caption = #1054#1073#1088#1072#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    OnClick = btnFileOutClick
  end
  object btnDo: TButton
    Left = 648
    Top = 288
    Width = 153
    Height = 73
    Caption = #1042#1080#1082#1086#1085#1072#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -19
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    OnClick = btnDoClick
  end
  object odl: TOpenDialog
    Left = 8
    Top = 64
  end
  object sdl: TSaveDialog
    Left = 8
    Top = 104
  end
end
