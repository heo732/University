//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormExample6.h"
#include "unitFormTask1.h"
#include "unitFunctions.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformExample6 *formExample6;
//---------------------------------------------------------------------------
__fastcall TformExample6::TformExample6(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformExample6::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formTask1->Show();        
}
//---------------------------------------------------------------------------
void __fastcall TformExample6::Button4Click(TObject *Sender)
{
        formTask1->Show();
        formExample6->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformExample6::Button1Click(TObject *Sender)
{
        float temp, lambda, alpha;
        if(TryStrToFloat(Edit1->Text, temp) && TryStrToFloat(Edit2->Text, temp))
        {
                lambda = StrToFloat(Edit1->Text);
                alpha = StrToFloat(Edit2->Text);
                StringGrid1->RowCount = 20;
                float* arr = new float[20];
                for(int i = 0; i < 20; i++)
                {
                        StringGrid1->Cells[0][i] = IntToStr(i+1);
                        StringGrid1->Cells[1][i] = FloatToStr(rozpodil_6_Pareto(lambda, alpha));
                        arr[i] = StrToFloat(StringGrid1->Cells[1][i]);
                }
                labelAverage->Caption = FloatToStr(selectiveAverage(arr, 20));
                labelDispersion->Caption = FloatToStr(selectiveDispersion(arr, 20));
        }
        else
                ShowMessage("¬вед≥ть д≥йсн≥ числа 'lambda' ≥ 'alpha'");
}
//---------------------------------------------------------------------------
