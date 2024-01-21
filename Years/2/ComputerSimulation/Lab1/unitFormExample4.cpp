//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormExample4.h"
#include "unitFormTask1.h"
#include "unitFunctions.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformExample4 *formExample4;
//---------------------------------------------------------------------------
__fastcall TformExample4::TformExample4(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformExample4::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formTask1->Show();
}
//---------------------------------------------------------------------------
void __fastcall TformExample4::Button4Click(TObject *Sender)
{
        formTask1->Show();
        formExample4->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformExample4::Button1Click(TObject *Sender)
{
        float temp, p;
        int tmp, n;
        if(TryStrToInt(Edit1->Text, tmp) && TryStrToFloat(Edit2->Text, temp))
        {
                n = StrToInt(Edit1->Text);
                p = StrToFloat(Edit2->Text);
                StringGrid1->RowCount = 20;
                float* arr = new float[20];
                for(int i = 0; i < 20; i++)
                {
                        StringGrid1->Cells[0][i] = IntToStr(i+1);
                        StringGrid1->Cells[1][i] = IntToStr(rozpodil_4_Binom(n, p));
                        arr[i] = StrToFloat(StringGrid1->Cells[1][i]);
                }
                labelAverage->Caption = FloatToStr(selectiveAverage(arr, 20));
                labelDispersion->Caption = FloatToStr(selectiveDispersion(arr, 20));
        }
        else
                ShowMessage("¬вед≥ть ц≥ле число 'n' ≥ д≥йсне число 'p'");
}
//---------------------------------------------------------------------------
