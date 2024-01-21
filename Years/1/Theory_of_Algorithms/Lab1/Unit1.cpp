//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
#include <cstring>
#include <iostream>
#include <conio.h>
#include <cctype.h>
#include <string.h>
#include <locale>
using namespace std;
//---------------------------------------------------------------------------
TForm1 *Form1;
const int LEN=0x50;
char s[LEN],word[LEN];
int i,j,k;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
Memo1->Clear();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
Memo1->Clear();
strcpy(s,Edit1->Text.c_str());

k=0;
for(i=0;i<strlen(s);)
        if((s[i]==' ')||(ispunct(s[i])))
                i++;
        else
                {
                for(j=0;j<=k;j++)
                        word[j]='\0';
                k=0;
                while(((s[i]!=' ')&&(!(ispunct(s[i]))))&&(i<strlen(s)))
                        {
                        word[k]=s[i];
                        i++;
                        k++;
                        }
                Memo1->Lines->Add(word); 
                }  
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button2Click(TObject *Sender)
{
Form1->Close();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button3Click(TObject *Sender)
{
Memo1->Clear();
Edit1->Clear();
Application->MainForm->Refresh();
}
//---------------------------------------------------------------------------

