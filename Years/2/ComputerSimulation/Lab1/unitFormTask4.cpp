//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormTask4.h"
#include "unitFormMain.h"
#include "unitFunctions.h"
#include "math.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformTask4 *formTask4;
//---------------------------------------------------------------------------
__fastcall TformTask4::TformTask4(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformTask4::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formMain->Show();
}
//---------------------------------------------------------------------------

void __fastcall TformTask4::Button4Click(TObject *Sender)
{
        formMain->Show();
        formTask4->Hide();        
}
//---------------------------------------------------------------------------

void __fastcall TformTask4::Button1Click(TObject *Sender)
{
        double mu = StrToFloat(Edit2->Text);
        double sigma = StrToFloat(Edit3->Text);
        int T = StrToInt(Edit4->Text);
        double* s = new double[T+1];
        s[0] = StrToFloat(Edit1->Text);


        StringGrid1->RowCount = T+1;
        StringGrid1->Cells[0][0] = "0";
        StringGrid1->Cells[1][0] = FloatToStr(s[0]);

        for(int t = 1; t <= T; t++)
        {
                //double w = (double)rand() / (double)RAND_MAX;
                double w = rozpodil_8_Normal(0,1);
                s[t] = s[t-1] * exp(mu*t) * exp((sigma*w)-(sigma*sigma*(double)t/2.0));
                StringGrid1->Cells[0][t] = IntToStr(t);
                StringGrid1->Cells[1][t] = FloatToStr(s[t]);
        }
}
//---------------------------------------------------------------------------

