//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormExample2.h"
#include "unitFormTask1.h"
#include "unitFunctions.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformExample2 *formExample2;
//---------------------------------------------------------------------------
__fastcall TformExample2::TformExample2(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformExample2::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formTask1->Show();
}
//---------------------------------------------------------------------------
void __fastcall TformExample2::Button4Click(TObject *Sender)
{
        formTask1->Show();
        formExample2->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformExample2::Button1Click(TObject *Sender)
{
        float temp, p, alpha;
        if(TryStrToFloat(Edit1->Text, temp) && TryStrToFloat(Edit2->Text, temp))
        {
                p = StrToFloat(Edit1->Text);
                alpha = StrToFloat(Edit2->Text);
                StringGrid1->RowCount = 20;
                float* arr = new float[20];
                for(int i = 0; i < 20; i++)
                {
                        StringGrid1->Cells[0][i] = IntToStr(i+1);
                        StringGrid1->Cells[1][i] = IntToStr(rozpodil_2_Binom(p, alpha));
                        arr[i] = StrToFloat(StringGrid1->Cells[1][i]);
                }
                labelAverage->Caption = FloatToStr(selectiveAverage(arr, 20));
                labelDispersion->Caption = FloatToStr(selectiveDispersion(arr, 20));
        }
        else
                ShowMessage("������ ����� ����� 'p' � 'alpha'");        
}
//---------------------------------------------------------------------------
