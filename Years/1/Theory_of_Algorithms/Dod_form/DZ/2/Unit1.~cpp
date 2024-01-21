//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <string>
using namespace std;
//---------------------------------------------------------------------------
bool isPunct(char a)
{
	char punct[]=".,!?:; -/[]{}()<>";
	int i;

	for(i=0;i<strlen(punct);i++)
	{
		if(a==punct[i])
		{
			return true;
		}
	}
	return false;
}
//---------------------------------------------------------------------------
void WithoutRepeatWords(string strIn,string &strOut)
{  
  int len_str,i,start=-1,end=-1,slovo=0,j,q,z;
  bool pos=0; // poch abo kinec slova shukaets9
  bool vyluch=0; //peremyka4 na vydalenn9 povtornoho slova

  len_str=strIn.size();


  for(i=0;i<len_str;i++)
  {
    switch(pos)
    {
      case 0:
      {
        if(!(isPunct(strIn[i])))
        {
          start=i;
          end=i;
          pos=1;
          break;
        }
        else
          break;
      }
      case 1:
      {
        if(!(isPunct(strIn[i])))
        {
          end=i;
          break;
        }
        else
        {
          slovo=end-start;
          for(j=i;j<len_str;j++)
          {
            if(strIn[j]==strIn[start] && strIn[j+slovo]==strIn[end] && ((j+slovo==len_str-1)||(isPunct(strIn[j+slovo+1]))) && isPunct(strIn[j-1]))
            {
              q=0;
              for(z=j;z<=j+slovo;z++)
                if(strIn[z]==strIn[start+q])
                {
                  vyluch=1;
                  q++;
                }
                else
                {
                  vyluch=0;
                  break;
                } 															
            }
            else
              continue;
            if(vyluch==1)
            {
              for(z=j;z<=j+slovo;z++)
								strIn[z]='\0';
							vyluch=0;
						}	
          }
          pos=0;
          break;
        }
      }
    }
  }
  //New Row
  strOut="";
  for(i=0;i<len_str;i++)
    if(strIn[i]=='\0')
      continue;
    else
      strOut[strOut.size()]=strIn[i];
}
//---------------------------------------------------------------------------
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::edtInChange(TObject *Sender)
{
  string strIn,strOut;
  strIn=edtIn->Text.c_str();
  strOut="";
  if(strIn!="")
  {
    WithoutRepeatWords(strIn,strOut);
    edtOut->Text=strOut.c_str();
  }  
}
//--------------------------------------------------------------------------- 