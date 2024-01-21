//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormTask1.h"
#include "unitFormMain.h"
#include "unitFormExample1.h"
#include "unitFormExample2.h"
#include "unitFormExample3.h"
#include "unitFormExample4.h"
#include "unitFormExample5.h"
#include "unitFormExample6.h"
#include "unitFormExample7.h"
#include "unitFormExample8.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TformTask1 *formTask1;
//---------------------------------------------------------------------------
__fastcall TformTask1::TformTask1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::FormClose(TObject *Sender,
      TCloseAction &Action)
{
        formMain->Show();
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::Button4Click(TObject *Sender)
{
        formMain->Show();
        formTask1->Hide();       
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::Button1Click(TObject *Sender)
{
        formExample1->Show();
        formTask1->Hide();
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::Button2Click(TObject *Sender)
{
        formExample2->Show();
        formTask1->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::Button3Click(TObject *Sender)
{
        formExample3->Show();
        formTask1->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::Button5Click(TObject *Sender)
{
        formExample4->Show();
        formTask1->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::Button6Click(TObject *Sender)
{
        formExample5->Show();
        formTask1->Hide();        
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::Button7Click(TObject *Sender)
{
        formExample6->Show();
        formTask1->Hide();
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::Button8Click(TObject *Sender)
{
        formExample7->Show();
        formTask1->Hide();
}
//---------------------------------------------------------------------------
void __fastcall TformTask1::Button9Click(TObject *Sender)
{
        formExample8->Show();
        formTask1->Hide();
}
//---------------------------------------------------------------------------
