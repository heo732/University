object frmSearch: TfrmSearch
  Left = 191
  Top = 204
  Width = 1068
  Height = 500
  Caption = #1055#1086#1096#1091#1082
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label2: TLabel
    Left = 288
    Top = 396
    Width = 251
    Height = 13
    Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1074#1093#1086#1076#1078#1077#1085#1100' '#1096#1091#1082#1072#1085#1086#1075#1086' '#1077#1083#1077#1084#1077#1085#1090#1072' '#1091' '#1089#1087#1080#1089#1086#1082':'
  end
  object stg: TStringGrid
    Left = 12
    Top = 60
    Width = 1033
    Height = 313
    ColCount = 9
    DefaultColWidth = 115
    RowCount = 12
    TabOrder = 0
    OnSelectCell = stgSelectCell
    ColWidths = (
      80
      115
      115
      115
      115
      115
      115
      115
      115)
  end
  object edtSearch: TEdit
    Left = 408
    Top = 16
    Width = 465
    Height = 21
    TabOrder = 1
  end
  object edtCount: TEdit
    Left = 560
    Top = 396
    Width = 121
    Height = 21
    ReadOnly = True
    TabOrder = 2
  end
  object btnShawAll: TButton
    Left = 12
    Top = 12
    Width = 145
    Height = 25
    Caption = #1042#1110#1076#1086#1073#1088#1072#1079#1080#1090#1080' '#1074#1089#1110' '#1079#1072#1087#1080#1089#1080
    TabOrder = 3
    OnClick = btnShawAllClick
  end
  object btnSearch: TButton
    Left = 892
    Top = 16
    Width = 75
    Height = 25
    Caption = #1047#1085#1072#1081#1090#1080
    TabOrder = 4
    OnClick = btnSearchClick
  end
end
