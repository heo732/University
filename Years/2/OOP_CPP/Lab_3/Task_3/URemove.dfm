object Form_Remove: TForm_Remove
  Left = 380
  Top = 177
  Width = 619
  Height = 554
  Caption = #1042#1080#1076#1072#1083#1077#1085#1085#1103' '#1079#1072#1087#1080#1089#1110#1074
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -13
  Font.Name = 'Verdana'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 16
  object Label1: TLabel
    Left = 14
    Top = 456
    Width = 44
    Height = 16
    Caption = #1055#1086#1096#1091#1082
  end
  object Grid: TStringGrid
    Left = 16
    Top = 16
    Width = 569
    Height = 345
    ColCount = 3
    DefaultColWidth = 40
    TabOrder = 0
    OnSelectCell = GridSelectCell
    ColWidths = (
      40
      243
      256)
  end
  object Edit_Search: TEdit
    Left = 72
    Top = 448
    Width = 225
    Height = 24
    TabOrder = 1
    OnChange = Edit_SearchChange
  end
  object Button_Close: TButton
    Left = 472
    Top = 472
    Width = 123
    Height = 33
    Caption = #1053#1072' '#1075#1086#1083#1086#1074#1085#1091
    TabOrder = 2
    OnClick = Button_CloseClick
  end
end
