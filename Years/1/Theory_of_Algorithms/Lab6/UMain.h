//---------------------------------------------------------------------------
#ifndef UMainH
#define UMainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "UAvto.h"
//---------------------------------------------------------------------------
class TfrmMain : public TForm
{
__published:	// IDE-managed Components
        TEdit *edtNumber;
        TEdit *edtMark;
        TEdit *edtNameLast;
        TEdit *edtNameFirst;
        TEdit *edtAddressStreet;
        TEdit *edtAddressHouse;
        TEdit *edtAddressFlat;
        TEdit *edtReceipt;
        TButton *btnSearch;
        TButton *btnFirst;
        TButton *btnPrev;
        TButton *btnNext;
        TButton *btnLast;
        TButton *btnNew;
        TButton *btnSave;
        TButton *btnUpdate;
        TButton *btnDelete;
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TLabel *Label7;
        TLabel *Label8;
        TLabel *Label9;
        TButton *btnRandomContent;
        void __fastcall btnSearchClick(TObject *Sender);
        void __fastcall btnFirstClick(TObject *Sender);
        void __fastcall btnPrevClick(TObject *Sender);
        void __fastcall btnNextClick(TObject *Sender);
        void __fastcall btnLastClick(TObject *Sender);
        void __fastcall btnNewClick(TObject *Sender);
        void __fastcall btnSaveClick(TObject *Sender);
        void __fastcall btnUpdateClick(TObject *Sender);
        void __fastcall btnDeleteClick(TObject *Sender);
        void __fastcall btnRandomContentClick(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TfrmMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmMain *frmMain;
//---------------------------------------------------------------------------
void FShow(TAvto);

#endif