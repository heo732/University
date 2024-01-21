//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "USearch.h"
#include "UMain.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TfrmSearch *frmSearch;

TAvto arrRez[1000];
int nRez=0;
//---------------------------------------------------------------------------
__fastcall TfrmSearch::TfrmSearch(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfrmSearch::FormCreate(TObject *Sender)
{
stgSearch->Cells[0][0]="Номер автомобіля";
stgSearch->Cells[1][0]="Марка";
stgSearch->Cells[2][0]="Прізвище власника";
stgSearch->Cells[3][0]="Ім'я власника";
stgSearch->Cells[4][0]="Вулиця";
stgSearch->Cells[5][0]="Будинок";
stgSearch->Cells[6][0]="Квартира";
stgSearch->Cells[7][0]="Штрафи";
}
//---------------------------------------------------------------------------

void __fastcall TfrmSearch::edtSearchChange(TObject *Sender)
{
FSearch(edtSearch->Text,arrRez,nRez);
stgSearch->RowCount=nRez+1;
for(int i=0;i<nRez;i++)
        {
                stgSearch->Cells[0][i+1]=arrRez[i].number;
                stgSearch->Cells[1][i+1]=arrRez[i].mark;
                stgSearch->Cells[2][i+1]=arrRez[i].name.last;
                stgSearch->Cells[3][i+1]=arrRez[i].name.first;
                stgSearch->Cells[4][i+1]=arrRez[i].address.street;
                stgSearch->Cells[5][i+1]=arrRez[i].address.house;
                stgSearch->Cells[6][i+1]=arrRez[i].address.flat;
                stgSearch->Cells[7][i+1]=arrRez[i].receipt;
        }
if(stgSearch->RowCount>1)
        stgSearch->FixedRows=1;        
}
//---------------------------------------------------------------------------

void __fastcall TfrmSearch::stgSearchSelectCell(TObject *Sender, int ACol,
      int ARow, bool &CanSelect)
{
FSetId(arrRez[ARow-1].id);
FShow(FGet());
}
//---------------------------------------------------------------------------

