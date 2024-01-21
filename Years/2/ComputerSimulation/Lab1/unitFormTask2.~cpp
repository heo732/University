//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormTask2.h"
#include "unitFormMain.h"
#include "unitFunctions.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformTask2 *formTask2;
//---------------------------------------------------------------------------
__fastcall TformTask2::TformTask2(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformTask2::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formMain->Show();
}
//---------------------------------------------------------------------------
void __fastcall TformTask2::Button4Click(TObject *Sender)
{
        formMain->Show();
        formTask2->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask2::Button1Click(TObject *Sender)
{
        float capital = StrToFloat(Edit1->Text);
        float stepSize = StrToFloat(Edit2->Text);
        int countContracts = StrToInt(Edit3->Text);
        int countModels = StrToInt(Edit4->Text);

        int fails = 0;
        for(int i = 0; i < countModels; i++)
        {
                float sum = 0;
                for(int j = 0; j < countContracts; j++)
                {
                        float x = (float)rand() / (float)RAND_MAX;
                        if(x <= 0.01)
                                sum += 2*stepSize;
                        else if(x > 0.01 && x <= 0.03)
                                sum += stepSize;
                }
                if(sum > capital)
                        fails++;        
        }

        labelProbability->Caption = FloatToStr((float)fails / (float)countModels);
}
//---------------------------------------------------------------------------
