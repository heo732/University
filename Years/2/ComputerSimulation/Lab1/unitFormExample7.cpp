//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormExample7.h"
#include "unitFormTask1.h"
#include "unitFunctions.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformExample7 *formExample7;
//---------------------------------------------------------------------------
__fastcall TformExample7::TformExample7(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformExample7::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formTask1->Show();
}
//---------------------------------------------------------------------------
void __fastcall TformExample7::Button4Click(TObject *Sender)
{
        formTask1->Show();
        formExample7->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformExample7::Button1Click(TObject *Sender)
{
        float temp, a, b;
        if(TryStrToFloat(Edit1->Text, temp) && TryStrToFloat(Edit2->Text, temp))
        {
                a = StrToFloat(Edit1->Text);
                b = StrToFloat(Edit2->Text);
                StringGrid1->RowCount = 20;
                float* arr = new float[20];
                for(int i = 0; i < 20; i++)
                {
                        StringGrid1->Cells[0][i] = IntToStr(i+1);
                        StringGrid1->Cells[1][i] = FloatToStr(rozpodil_7_Vidrizok(a, b));
                        arr[i] = StrToFloat(StringGrid1->Cells[1][i]);
                }
                labelAverage->Caption = FloatToStr(selectiveAverage(arr, 20));
                labelDispersion->Caption = FloatToStr(selectiveDispersion(arr, 20));
        }
        else
                ShowMessage("������ ����� ����� 'a' � 'b'");
}
//---------------------------------------------------------------------------
