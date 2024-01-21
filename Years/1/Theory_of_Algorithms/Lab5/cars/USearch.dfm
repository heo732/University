object frmSearch: TfrmSearch
  Left = 277
  Top = 283
  Width = 870
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
  object edtSearch: TEdit
    Left = 32
    Top = 16
    Width = 793
    Height = 21
    TabOrder = 0
    OnChange = edtSearchChange
  end
  object stgSearch: TStringGrid
    Left = 8
    Top = 56
    Width = 833
    Height = 393
    ColCount = 8
    FixedCols = 0
    TabOrder = 1
    OnSelectCell = stgSearchSelectCell
    ColWidths = (
      108
      76
      106
      105
      107
      101
      100
      100)
  end
end
