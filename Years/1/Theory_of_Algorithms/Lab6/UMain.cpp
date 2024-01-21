//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "UMain.h"
#include "UAvto.h"
#include "URandomContent.h"
#include "USearch.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
TfrmMain *frmMain;
//---------------------------------------------------------------------------
__fastcall TfrmMain::TfrmMain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void FEnabled1(bool f)
{
  frmMain->edtNumber->Enabled=f;
  frmMain->edtMark->Enabled=f;
  frmMain->edtNameLast->Enabled=f;
  frmMain->edtNameFirst->Enabled=f;
  frmMain->edtAddressStreet->Enabled=f;
  frmMain->edtAddressHouse->Enabled=f;
  frmMain->edtAddressFlat->Enabled=f;
  frmMain->edtReceipt->Enabled=f;
  
  frmMain->btnFirst->Enabled=!f;
  frmMain->btnPrev->Enabled=!f;
  frmMain->btnNext->Enabled=!f;
  frmMain->btnLast->Enabled=!f;
  frmMain->btnNew->Enabled=!f;
  frmMain->btnUpdate->Enabled=!f;
  frmMain->btnDelete->Enabled=!f;
  frmMain->btnSave->Enabled=f;
  frmMain->btnRandomContent->Enabled=f;
}
//---------------------------------------------------------------------------
void FShow(TAvto a)
{
  frmMain->edtNumber->Text=a.number;
  frmMain->edtMark->Text=a.mark;
  frmMain->edtNameLast->Text=a.name.last;
  frmMain->edtNameFirst->Text=a.name.first;
  frmMain->edtAddressStreet->Text=a.address.street;
  frmMain->edtAddressHouse->Text=a.address.house;
  frmMain->edtAddressFlat->Text=a.address.flat;
  frmMain->edtReceipt->Text=a.receipt;
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnSearchClick(TObject *Sender)
{
  frmSearch->Show();
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnFirstClick(TObject *Sender)
{
  FFirst();
  FShow(FGet());
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnPrevClick(TObject *Sender)
{
  FPrev();
  FShow(FGet());
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnNextClick(TObject *Sender)
{
  FNext();
  FShow(FGet());
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnLastClick(TObject *Sender)
{
  FLast();
  FShow(FGet());
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnNewClick(TObject *Sender)
{
  FNew();
  FShow(FGet());
  FEnabled1(true);
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnSaveClick(TObject *Sender)
{
  TAvto b;
  b.number=frmMain->edtNumber->Text;
  b.mark=frmMain->edtMark->Text;
  b.name.last=frmMain->edtNameLast->Text;
  b.name.first=frmMain->edtNameFirst->Text;
  b.address.street=frmMain->edtAddressStreet->Text;
  b.address.house=frmMain->edtAddressHouse->Text;
  b.address.flat=frmMain->edtAddressFlat->Text;
  b.receipt=frmMain->edtReceipt->Text;
  FSave(b);
  FEnabled1(false);
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnUpdateClick(TObject *Sender)
{
  FEnabled1(true);
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnDeleteClick(TObject *Sender)
{
  if(Application->MessageBox("Ви дійсно бажаєте видалити цей запис?","Виделання поточного запису",MB_YESNO)==mrYes)
  {
    FDelete();
    FShow(FGet());
  }
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::btnRandomContentClick(TObject *Sender)
{
  char s[1000];
  FRandom1(s);
  frmMain->edtNumber->Text=s;
  FRandom2(s);
  frmMain->edtMark->Text=s;
  FRandom3(s);
  frmMain->edtNameLast->Text=s;
  FRandom4(s);
  frmMain->edtNameFirst->Text=s;
  FRandom5(s);
  frmMain->edtAddressStreet->Text=s;
  FRandom6(s);
  frmMain->edtAddressHouse->Text=s;
  FRandom7(s);
  frmMain->edtAddressFlat->Text=s;
  FRandom8(s);
  frmMain->edtReceipt->Text=s;
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::FormCreate(TObject *Sender)
{
  FNew();
  FEnabled1(true);
}
//---------------------------------------------------------------------------