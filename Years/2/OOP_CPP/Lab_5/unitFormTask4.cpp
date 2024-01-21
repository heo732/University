//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormTask4.h"
#include "unitMain.h"
#include "unitTask4.h"
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
void __fastcall TformTask4::buttonGoMainClick(TObject *Sender)
{
        formMain->Show();
        formTask4->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask4::memoInChange(TObject *Sender)
{
        Data* data = NULL;

        switch(RadioGroup1->ItemIndex)
        {
        case 0:
                data = new SignalData();
                break;
        case 1:
                data = new ResultProcessingData();
                break;
        case 2:
                data = new AuxiliaryData();
                break;
        }

        Strings strings;
        for(int i = 0; i < memoIn->Lines->Count; i++)
                strings.addLine(memoIn->Lines->operator [](i), 1);

        data->setData(strings);
        data->printInMemo(memoOut);        
}
//---------------------------------------------------------------------------

