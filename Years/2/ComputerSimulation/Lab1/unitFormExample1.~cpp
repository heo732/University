//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormExample1.h"
#include "unitFormTask1.h"
#include "unitFunctions.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformExample1 *formExample1;
//---------------------------------------------------------------------------
__fastcall TformExample1::TformExample1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformExample1::Button4Click(TObject *Sender)
{
        formTask1->Show();
        formExample1->Hide();
}
//---------------------------------------------------------------------------
void __fastcall TformExample1::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formTask1->Show();        
}
//---------------------------------------------------------------------------
void __fastcall TformExample1::Button1Click(TObject *Sender)
{
        float lambda, temp;
        if(TryStrToFloat(Edit1->Text, temp))
        {
                lambda = StrToFloat(Edit1->Text);
                StringGrid1->RowCount = 20;
                float* arr = new float[20];
                for(int i = 0; i < 20; i++)
                {
                        StringGrid1->Cells[0][i] = IntToStr(i+1);
                        StringGrid1->Cells[1][i] = IntToStr(rozpodil_1_Poisson(lambda));
                        arr[i] = StrToFloat(StringGrid1->Cells[1][i]);
                }
                labelAverage->Caption = FloatToStr(selectiveAverage(arr, 20));
                labelDispersion->Caption = FloatToStr(selectiveDispersion(arr, 20));
        }
        else
                ShowMessage("¬вед≥ть д≥йсне число 'lambda'");
}
//---------------------------------------------------------------------------
