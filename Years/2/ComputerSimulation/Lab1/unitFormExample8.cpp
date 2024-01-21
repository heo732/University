//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormExample8.h"
#include "unitFormTask1.h"
#include "unitFunctions.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformExample8 *formExample8;
//---------------------------------------------------------------------------
__fastcall TformExample8::TformExample8(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformExample8::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formTask1->Show();
}
//---------------------------------------------------------------------------
void __fastcall TformExample8::Button4Click(TObject *Sender)
{
        formTask1->Show();
        formExample8->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformExample8::Button1Click(TObject *Sender)
{
        float temp, a, sigma_2;
        if(TryStrToFloat(Edit1->Text, temp) && TryStrToFloat(Edit2->Text, temp))
        {
                a = StrToFloat(Edit1->Text);
                sigma_2 = StrToFloat(Edit2->Text);
                StringGrid1->RowCount = 20;
                float* arr = new float[20];
                for(int i = 0; i < 20; i++)
                {
                        StringGrid1->Cells[0][i] = IntToStr(i+1);
                        StringGrid1->Cells[1][i] = FloatToStr(rozpodil_8_Normal(a, sigma_2));
                        arr[i] = StrToFloat(StringGrid1->Cells[1][i]);
                }
                labelAverage->Caption = FloatToStr(selectiveAverage(arr, 20));
                labelDispersion->Caption = FloatToStr(selectiveDispersion(arr, 20));
        }
        else
                ShowMessage("¬вед≥ть д≥йсн≥ числа 'a' ≥ 'sigma^2'");
}
//---------------------------------------------------------------------------
