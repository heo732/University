object FormResult: TFormResult
  Left = 257
  Top = 292
  Width = 330
  Height = 479
  Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object stg: TStringGrid
    Left = 16
    Top = 16
    Width = 281
    Height = 281
    ColCount = 8
    DefaultColWidth = 30
    DefaultRowHeight = 30
    RowCount = 8
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object btnClose: TButton
    Left = 122
    Top = 400
    Width = 73
    Height = 25
    Caption = #1047#1072#1082#1088#1080#1090#1080
    TabOrder = 1
    OnClick = btnCloseClick
  end
  object btnWrite1: TButton
    Left = 18
    Top = 304
    Width = 279
    Height = 25
    Caption = #1047#1072#1087#1080#1089#1072#1090#1080' '#1074' '#1087#1077#1088#1096#1091' '#1084#1072#1090#1088#1080#1094#1102
    TabOrder = 2
    OnClick = btnWrite1Click
  end
  object btnWrite2: TButton
    Left = 18
    Top = 336
    Width = 279
    Height = 25
    Caption = #1047#1072#1087#1080#1089#1072#1090#1080' '#1074' '#1076#1088#1091#1075#1091' '#1084#1072#1090#1088#1080#1094#1102
    TabOrder = 3
    OnClick = btnWrite2Click
  end
end
