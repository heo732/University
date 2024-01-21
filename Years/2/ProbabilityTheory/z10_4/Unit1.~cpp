//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"

#include <time.h>
//---------------------------------------------------------------------------
Tfrm *frm;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnClick(TObject *Sender)
{
  double p1, p2, p3;
  unsigned int cnt=0;

  unsigned int A1=0, A2=0, A1_A2=0;

  p1 = StrToFloat(edtP1In->Text);
  if(p1<=0 || p1 >=1)
    ShowMessage("0 < p1 < 1");
  else{
    p2 = StrToFloat(edtP2In->Text);
    if(p2<=0 || p2 >=1)
    	ShowMessage("0 < p2 < 1");
    else{
    	if(p1+p2<=0 || p1+p2>=1)
      	ShowMessage("0 < p1+p2 < 1");
  		else{
  	  	p3 = StrToFloat(edtP3In->Text);
  	  	if(p3<=0 || p3 >=1)
    			ShowMessage("0 < p3 < 1");
    		else{
  	  		if(p3 >= p1 || p3 >= p2)
  	  			ShowMessage("p3 < p1, p3 < p2");
  	  		else{
  	  			srand(time(0));

  	  			cnt = StrToInt(edtCnt->Text);
  	  			for(unsigned int i=0; i<cnt; i++){
  	  				double x = ((double)rand())/RAND_MAX;
  	  				if(x>0 && x<p1-p3)
  	  					A1++;  	  				
  	  				if(x>p1 && x<p1+p2-p3)
  	  					A2++;
  	  				if(x>p1-p3 && x<p1)
  	  					A1_A2++;
  	  			}

  	  			edtP1Out->Text = FloatToStr((double)A1 / cnt);
  	  			edtP2Out->Text = FloatToStr((double)A2 / cnt);
  	  			edtP3Out->Text = FloatToStr((double)A1_A2 / cnt);
  	  		}
  	  	}	
  		}
  	}
  }	
}
//---------------------------------------------------------------------------