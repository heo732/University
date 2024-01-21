//---------------------------------------------------------------------------

#ifndef UMainH
#define UMainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <String.h>
//---------------------------------------------------------------------------
struct TName
{
	String last;
	String first;
};

struct TAddress
{
        String street;
        String house;
        String flat;
};

struct TAvto
{
	int id;
        String number;
        String mark;
        TName name;
        TAddress address;
        String receipt;
};

void FShow(TAvto);
void FNew();
TAvto FGet();
void FSave(String num,String mrk,String nl,String nf,String as,String ah,String af,String rcpt);
void FDelete();
void FNext();
void FPrev();
void FFirst();
void FLast();
void FSetId(int);
void FSearch(String s,TAvto arrRez[],int &k);
//---------------------------------------------------------------------------
class TfrmMain : public TForm
{
__published:	// IDE-managed Components
        TEdit *edtNumber;
        TEdit *edtMark;
        TEdit *edtNameLast;
        TEdit *edtNameFirst;
        TEdit *edtAddressStreet;
        TButton *btnNew;
        TButton *btnFirst;
        TButton *btnPrev;
        TButton *btnUpdate;
        TButton *btnDelete;
        TButton *btnSearch;
        TButton *btnNext;
        TButton *btnSave;
        TButton *btnLast;
        TEdit *edtAddressHouse;
        TEdit *edtAddressFlat;
        TEdit *edtReceipt;
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TLabel *Label7;
        TLabel *Label8;
        TLabel *Label9;
        TButton *btnRandom;
        void __fastcall btnNewClick(TObject *Sender);
        void __fastcall btnUpdateClick(TObject *Sender);
        void __fastcall btnSaveClick(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall btnFirstClick(TObject *Sender);
        void __fastcall btnPrevClick(TObject *Sender);
        void __fastcall btnNextClick(TObject *Sender);
        void __fastcall btnLastClick(TObject *Sender);
        void __fastcall btnDeleteClick(TObject *Sender);
        void __fastcall btnSearchClick(TObject *Sender);
        void __fastcall btnRandomClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TfrmMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmMain *frmMain;
//---------------------------------------------------------------------------
#endif
