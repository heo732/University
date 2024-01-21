//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormTask3.h"
#include "unitFormMain.h"
#include "unitFunctions.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformTask3 *formTask3;
//---------------------------------------------------------------------------
__fastcall TformTask3::TformTask3(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformTask3::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formMain->Show();
}
//---------------------------------------------------------------------------
void __fastcall TformTask3::Button4Click(TObject *Sender)
{
        formMain->Show();
        formTask3->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask3::Button1Click(TObject *Sender)
{
        double capital = StrToFloat(Edit1->Text);
        float rozpodilPoisson = StrToFloat(Edit2->Text);
        float rozpodilExp = StrToFloat(Edit3->Text);
        int countModels = StrToInt(Edit4->Text);

        int fails = 0;
        for(int i = 0; i < countModels; i++)
        {
                double sum = 0;
                int countFires = rozpodil_1_Poisson(rozpodilPoisson);
                for(int j = 0; j < countFires; j++)
                        sum += rozpodil_5_Exp(rozpodilExp);
                if(sum > capital)
                        fails++;        
        }

        labelProbability->Caption = FloatToStr((float)fails / (float)countModels);
}
//---------------------------------------------------------------------------
