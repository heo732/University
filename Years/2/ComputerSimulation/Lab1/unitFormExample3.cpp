//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormExample3.h"
#include "unitFormTask1.h"
#include "unitFunctions.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformExample3 *formExample3;
//---------------------------------------------------------------------------
__fastcall TformExample3::TformExample3(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformExample3::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formTask1->Show();
}
//---------------------------------------------------------------------------
void __fastcall TformExample3::Button4Click(TObject *Sender)
{
        formTask1->Show();
        formExample3->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformExample3::Button1Click(TObject *Sender)
{
        float p, temp;
        if(TryStrToFloat(Edit1->Text, temp))
        {
                p = StrToFloat(Edit1->Text);
                StringGrid1->RowCount = 20;
                float* arr = new float[20];
                for(int i = 0; i < 20; i++)
                {
                        StringGrid1->Cells[0][i] = IntToStr(i+1);
                        StringGrid1->Cells[1][i] = IntToStr(rozpodil_3_Geometry(p));
                        arr[i] = StrToFloat(StringGrid1->Cells[1][i]);
                }
                labelAverage->Caption = FloatToStr(selectiveAverage(arr, 20));
                labelDispersion->Caption = FloatToStr(selectiveDispersion(arr, 20));
        }
        else
                ShowMessage("������ ����� ����� 'p'");
}
//---------------------------------------------------------------------------