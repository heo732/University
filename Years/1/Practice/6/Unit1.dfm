object frm: Tfrm
  Left = 307
  Top = 112
  Width = 610
  Height = 676
  Caption = #1047#1072#1074#1076#1072#1085#1085#1103' 6. '#1042#1072#1088#1110#1072#1085#1090' '#8470'4'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object img: TImage
    Left = 0
    Top = 48
    Width = 600
    Height = 600
    Align = alCustom
    Constraints.MaxHeight = 1000
    Constraints.MaxWidth = 1800
    Proportional = True
    Transparent = True
  end
  object Label1: TLabel
    Left = 16
    Top = 8
    Width = 102
    Height = 13
    Caption = #1044#1086#1074#1078#1080#1085#1072' '#1089#1090#1086#1088#1086#1085#1080
  end
  object Label2: TLabel
    Left = 224
    Top = 8
    Width = 95
    Height = 13
    Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1082#1088#1086#1082#1110#1074
  end
  object btnPaint: TButton
    Left = 432
    Top = 0
    Width = 115
    Height = 41
    Caption = #1047#1073#1110#1083#1100#1096#1080#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Verdana'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    OnClick = btnPaintClick
  end
  object edtLen: TEdit
    Left = 136
    Top = 8
    Width = 57
    Height = 21
    TabOrder = 1
    Text = '50'
  end
  object edtStep: TEdit
    Left = 336
    Top = 8
    Width = 57
    Height = 21
    TabOrder = 2
  end
end
