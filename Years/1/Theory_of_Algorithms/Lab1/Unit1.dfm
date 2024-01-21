object Form1: TForm1
  Left = 236
  Top = 145
  Width = 726
  Height = 675
  Caption = #1044#1088#1091#1082' '#1074#1089#1110#1093' '#1089#1083#1110#1074' '#1090#1077#1082#1089#1090#1091
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -18
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 120
  TextHeight = 24
  object Label1: TLabel
    Left = 50
    Top = 30
    Width = 131
    Height = 21
    Caption = #1042#1074#1077#1076#1110#1090#1100' '#1090#1077#1082#1089#1090':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -18
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 48
    Top = 168
    Width = 157
    Height = 21
    Caption = #1042#1089#1110' '#1089#1083#1086#1074#1072' '#1090#1077#1082#1089#1090#1091':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -18
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Edit1: TEdit
    Left = 48
    Top = 64
    Width = 601
    Height = 29
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -18
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 0
  end
  object Memo1: TMemo
    Left = 48
    Top = 200
    Width = 449
    Height = 385
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -18
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    Lines.Strings = (
      'Memo1')
    ParentFont = False
    TabOrder = 1
  end
  object Button1: TButton
    Left = 48
    Top = 112
    Width = 449
    Height = 49
    Caption = #1042#1080#1082#1086#1085#1072#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -18
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 504
    Top = 544
    Width = 145
    Height = 41
    Caption = #1042#1080#1093#1110#1076
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -18
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 3
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 504
    Top = 112
    Width = 145
    Height = 49
    Caption = #1054#1085#1086#1074#1080#1090#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -18
    Font.Name = 'Arial'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 4
    OnClick = Button3Click
  end
end
