//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "UMain.h"
#include "USearch.h"
#include "URandomContent.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
TAvto arrAvto[1000];
int N=0;
int idAvto=0;

void FNew()
{
	if(N<1000)
	{
		arrAvto[N].id=N;
		idAvto=N;
	}
	else
		ShowMessage("Переповнення масиву!");
}

TAvto FGet()          
{                          
	return arrAvto[idAvto];
}

void FSave(String num,String mrk,String nl,String nf,String as,String ah,String af,String rcpt)
{  
	arrAvto[idAvto].number=num;
	arrAvto[idAvto].mark=mrk;
	arrAvto[idAvto].name.last=nl;
	arrAvto[idAvto].name.first=nf;
	arrAvto[idAvto].address.street=as;
	arrAvto[idAvto].address.house=ah;
	arrAvto[idAvto].address.flat=af;
	arrAvto[idAvto].receipt=rcpt;
    N++;
}

void FDelete()
{
	N--;
	for(int i=idAvto;i<N;i++)
		arrAvto[i]=arrAvto[i+1];
	if(idAvto==N)
		idAvto--;
}

void FNext()
{
	if(idAvto<N-1)
		idAvto++;
}

void FPrev()
{
	if(idAvto>0)
		idAvto--;
}

void FFirst()
{
	if(idAvto>0)
		idAvto=0;
}

void FLast()
{
	idAvto=N-1;
}

void FSetId(int id)
{
	idAvto=0;
	while(idAvto<N && arrAvto[idAvto].id!=id)
		idAvto++;
}

void FSearch(String s,TAvto arrRez[],int &k)
{
	k=0;
	for(int i=0;i<N;i++)
	{
		if(arrAvto[i].number.Pos(s)>0 ||
			arrAvto[i].mark.Pos(s)>0 ||
			arrAvto[i].name.last.Pos(s)>0 ||
			arrAvto[i].name.first.Pos(s)>0 ||
			arrAvto[i].address.street.Pos(s)>0 ||
			arrAvto[i].address.house.Pos(s)>0 ||
			arrAvto[i].address.flat.Pos(s)>0 ||
			arrAvto[i].receipt.Pos(s)>0
			)
		{
			arrRez[k]=arrAvto[i];
			k++;
		}
	}
}
//---------------------------------------------------------------------------
TfrmMain *frmMain;
//---------------------------------------------------------------------------
__fastcall TfrmMain::TfrmMain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void enabledOnOff(bool f)
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
	frmMain->btnRandom->Enabled=f;
}

void FShow(TAvto avto)
{
	frmMain->edtNumber->Text=avto.number;
	frmMain->edtMark->Text=avto.mark;
	frmMain->edtNameLast->Text=avto.name.last;
	frmMain->edtNameFirst->Text=avto.name.first;
	frmMain->edtAddressStreet->Text=avto.address.street;
	frmMain->edtAddressHouse->Text=avto.address.house;
	frmMain->edtAddressFlat->Text=avto.address.flat;
	frmMain->edtReceipt->Text=avto.receipt;
}

void enabledStep()
{
if(N>1)
	{	
    if(idAvto==0)    	
    		{
    			frmMain->btnFirst->Enabled=false;
    			frmMain->btnPrev->Enabled=false;
    			frmMain->btnNext->Enabled=true;
    			frmMain->btnLast->Enabled=true;
    		}
    if(idAvto==N-1)
    		{
    			frmMain->btnFirst->Enabled=true;
    			frmMain->btnPrev->Enabled=true;
    			frmMain->btnNext->Enabled=false;
    			frmMain->btnLast->Enabled=false;	
    		}
    if(idAvto>0 && idAvto<N-1)
    		{
    			frmMain->btnFirst->Enabled=true;
    			frmMain->btnPrev->Enabled=true;
    			frmMain->btnNext->Enabled=true;
    			frmMain->btnLast->Enabled=true;	
    		}		
    }
else
	{
		frmMain->btnFirst->Enabled=false;
    	frmMain->btnPrev->Enabled=false;
    	frmMain->btnNext->Enabled=false;
    	frmMain->btnLast->Enabled=false;    
	}
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnNewClick(TObject *Sender)
{
enabledOnOff(true);
frmMain->edtNumber->Text="";
frmMain->edtMark->Text="";
frmMain->edtNameLast->Text="";
frmMain->edtNameFirst->Text="";
frmMain->edtAddressStreet->Text="";
frmMain->edtAddressHouse->Text="";
frmMain->edtAddressFlat->Text="";
frmMain->edtReceipt->Text="";
FNew();
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnUpdateClick(TObject *Sender)
{
N--;
enabledOnOff(true);
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnSaveClick(TObject *Sender)
{
FSave(edtNumber->Text,edtMark->Text,edtNameLast->Text,edtNameFirst->Text,edtAddressStreet->Text,edtAddressHouse->Text,edtAddressFlat->Text,edtReceipt->Text);
enabledOnOff(false);
enabledStep();
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnDeleteClick(TObject *Sender)
{
if(Application->MessageBox("Ви дійсно бажаєте видалити запис?","Видалення запису",MB_YESNO)==mrYes)
        {
         if(N>1)
                {
                FDelete();
                FShow(FGet());                
                }
         else
                {
                FDelete();
                enabledOnOff(true);
                frmMain->edtNumber->Text="";
				frmMain->edtMark->Text="";
				frmMain->edtNameLast->Text="";
				frmMain->edtNameFirst->Text="";	
				frmMain->edtAddressStreet->Text="";
				frmMain->edtAddressHouse->Text="";
				frmMain->edtAddressFlat->Text="";
				frmMain->edtReceipt->Text="";
                FNew();
                }
        }
enabledStep();        
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::FormCreate(TObject *Sender)
{
enabledOnOff(true);
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnFirstClick(TObject *Sender)
{
FFirst();
FShow(FGet());
enabledStep();
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnPrevClick(TObject *Sender)
{
FPrev();
FShow(FGet());
enabledStep();
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnNextClick(TObject *Sender)
{
FNext();
FShow(FGet());
enabledStep();
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnLastClick(TObject *Sender)
{
FLast();
FShow(FGet());
enabledStep();
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnSearchClick(TObject *Sender)
{
frmSearch->Show();
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::btnRandomClick(TObject *Sender)
{
char s[100];
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

