object frmMain: TfrmMain
  Left = 261
  Top = 212
  Width = 891
  Height = 528
  Caption = 
    #1051#1072#1073#1086#1088#1072#1090#1086#1088#1085#1072' '#1088#1086#1073#1086#1090#1072' '#8470'7. '#1044#1077#1088#1077#1074#1072'     |    '#1042#1072#1088#1110#1072#1085#1090' 4. '#1044#1086#1073#1091#1090#1086#1082' '#1077#1083#1077#1084#1077#1085 +
    #1090#1110#1074' '#1076#1077#1088#1077#1074#1072
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
  object Label1: TLabel
    Left = 36
    Top = 12
    Width = 103
    Height = 13
    Caption = #1050#1110#1083#1100#1082#1110#1089#1090#1100' '#1077#1083#1077#1084#1077#1085#1090#1110#1074':'
  end
  object Label2: TLabel
    Left = 316
    Top = 468
    Width = 100
    Height = 13
    Caption = #1044#1086#1073#1091#1090#1086#1082' '#1077#1083#1077#1084#1077#1085#1090#1110#1074':'
  end
  object edtSize: TEdit
    Left = 148
    Top = 8
    Width = 121
    Height = 21
    TabOrder = 0
    Text = '10'
  end
  object btnSize: TButton
    Left = 280
    Top = 8
    Width = 75
    Height = 25
    Caption = #1055#1110#1076#1075#1086#1090#1091#1074#1072#1090#1080
    TabOrder = 1
    OnClick = btnSizeClick
  end
  object stgElements: TStringGrid
    Left = 36
    Top = 68
    Width = 165
    Height = 381
    ColCount = 1
    FixedCols = 0
    RowCount = 15
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 2
    OnDrawCell = stgElementsDrawCell
    ColWidths = (
      140)
  end
  object btnDo: TButton
    Left = 444
    Top = 8
    Width = 75
    Height = 25
    Caption = #1042#1080#1082#1086#1085#1072#1090#1080
    TabOrder = 3
    OnClick = btnDoClick
  end
  object stgTree: TStringGrid
    Left = 236
    Top = 68
    Width = 613
    Height = 381
    ColCount = 11
    DefaultColWidth = 25
    DefaultRowHeight = 25
    RowCount = 7
    FixedRows = 0
    TabOrder = 4
    OnDrawCell = stgTreeDrawCell
  end
  object btnRandom: TButton
    Left = 36
    Top = 40
    Width = 165
    Height = 25
    Caption = #1056#1072#1085#1076#1086#1084#1085#1110' '#1079#1085#1072#1095#1077#1085#1085#1103
    TabOrder = 5
    OnClick = btnRandomClick
  end
  object edtDobutok: TEdit
    Left = 424
    Top = 464
    Width = 121
    Height = 21
    ReadOnly = True
    TabOrder = 6
  end
  object edtRandomLeft: TEdit
    Left = 4
    Top = 40
    Width = 25
    Height = 21
    TabOrder = 7
    Text = '-50'
  end
  object edtRandomRight: TEdit
    Left = 208
    Top = 40
    Width = 25
    Height = 21
    TabOrder = 8
    Text = '50'
  end
  object btnBalance: TButton
    Left = 552
    Top = 8
    Width = 75
    Height = 25
    Caption = #1041#1072#1083#1072#1085#1089#1091#1074#1072#1090#1080
    TabOrder = 9
    OnClick = btnBalanceClick
  end
end
