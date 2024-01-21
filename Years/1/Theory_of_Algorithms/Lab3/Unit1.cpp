//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#pragma package(smart_init)
#pragma resource "*.dfm"
#include "Unit1.h"

#include <time.h>
#include <vector.h>
#define SIZE 1000000
#define RANDOM_SIZE 1000
//---------------------------------------------------------------------------
TForm1 *Form1;

int n;
double a[SIZE],b[SIZE];
int i,j,compare1,move1;
double tmp,time1,time2,time_n;

void Q_sort(int b,int e)
{
	int l=b,r=e;
	int piv=a[(l+r)/2];

	while(l<=r)
	{
		compare1++;
		compare1++;
		while(a[l]>piv)  //while(a[l]<piv)
		{
			l++; move1++;
		}
		compare1++;	
		while(a[r]<piv)  //while(a[r]>piv)
		{
			r--; move1++;
		}
		compare1++;	
		if(l<=r)
		{
			swap(a[l++],a[r--]); move1+=5; 
		}	
	}
	compare1++;	
	if(b<r)
	{
		Q_sort(b,r); compare1++;
	}
	compare1++;	
	if(e>l)
	{
		Q_sort(l,e); compare1++;
	}
	compare1++;	
}
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button2Click(TObject *Sender)
{
Form1->Close();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{ 
time1=clock();
for(i=0;i<n;i++)
{
	a[i]=StrToFloat(StringGrid1->Cells[1][i]);
}	

switch(RadioGroup1->ItemIndex)
{
case 0:
{
	///clear other grids///
	for(i=0;i<=StringGrid3->RowCount;i++)
		{
			StringGrid3->Cells[0][i]="";
			StringGrid3->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid4->RowCount;i++)
		{
			StringGrid4->Cells[0][i]="";
			StringGrid4->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid5->RowCount;i++)
		{
			StringGrid5->Cells[0][i]="";
			StringGrid5->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid6->RowCount;i++)
		{
			StringGrid6->Cells[0][i]="";
			StringGrid6->Cells[1][i]="";
		}					
	///clear other grids///	
	Edit2->Text="";
    Edit3->Text="";
    Edit4->Text="";
	compare1=0;
	move1=0;
		
    //////sort_selection/////
    int Imin;
    for(i=0;i<n-1;i++)
    	{
    		move1++;
    		compare1++;
    		Imin=i; move1++;
    		compare1++;
    		for(j=i+1;j<n;j++)
    			{
    				compare1++;
    				move1++;
    				if(a[Imin]>a[j])    //if(a[Imin]<a[j])
    				{
    					Imin=j;	move1++;
    				}
    			}
    		tmp=a[Imin]; move1++;
    		a[Imin]=a[i]; move1++;
    		a[i]=tmp; move1++;	
    	}	
    compare1++;	
    move1+=2;
	//////sort_selection/////
	
	for (i = 0; i < n; i++)
        {
			StringGrid2->Cells[0][i]=IntToStr(i+1);
			StringGrid2->Cells[1][i]=FloatToStr(a[i]);
        }
    Edit2->Text=IntToStr(compare1);    
    Edit3->Text=IntToStr(move1);
    time2=clock();
    Edit4->Text=FloatToStr((time2-time1)/1000.0);
	break;
}
case 1:
{
	///clear other grids///
	for(i=0;i<=StringGrid2->RowCount;i++)
		{
			StringGrid2->Cells[0][i]="";
			StringGrid2->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid4->RowCount;i++)
		{
			StringGrid4->Cells[0][i]="";
			StringGrid4->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid5->RowCount;i++)
		{
			StringGrid5->Cells[0][i]="";
			StringGrid5->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid6->RowCount;i++)
		{
			StringGrid6->Cells[0][i]="";
			StringGrid6->Cells[1][i]="";
		}					
	///clear other grids///	
	Edit2->Text="";
    Edit3->Text="";
    Edit4->Text="";
	compare1=0;
	move1=0;
		
    //////sort_bubbles/////
    bool f=true;

    while(f)
    	{
    		compare1++;
    		f=false; move1++;
    		compare1++;    		
    		for(i=0;i<n-1;i++)
    			{
    				compare1++;
    				move1++;
    				if(a[i]>a[i+1])  //if(a[i]<a[i+1])
    				{
    					tmp=a[i]; move1++;
    					a[i]=a[i+1]; move1++;
    					a[i+1]=tmp; move1++;
    					f=true; move1++;
    				}
    			}	
    	}
    compare1++;
    move1++;		
	//////sort_bubbles/////
	
	for (i = 0; i < n; i++)
        {
			StringGrid3->Cells[0][i]=IntToStr(i+1);
			StringGrid3->Cells[1][i]=FloatToStr(a[i]);
        }
    Edit2->Text=IntToStr(compare1);    
    Edit3->Text=IntToStr(move1);
    time2=clock();
    Edit4->Text=FloatToStr((time2-time1)/1000.0);
	break;
}
case 2:
{
	///clear other grids///
	for(i=0;i<=StringGrid2->RowCount;i++)
		{
			StringGrid2->Cells[0][i]="";
			StringGrid2->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid3->RowCount;i++)
		{
			StringGrid3->Cells[0][i]="";
			StringGrid3->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid5->RowCount;i++)
		{
			StringGrid5->Cells[0][i]="";
			StringGrid5->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid6->RowCount;i++)
		{
			StringGrid6->Cells[0][i]="";
			StringGrid6->Cells[1][i]="";
		}					
	///clear other grids///	
	Edit2->Text="";
    Edit3->Text="";
    Edit4->Text="";
	compare1=0;
	move1=0;
		
    //////sort_insertion/////
    for(i=1;i<n;i++)
    	{
    		compare1++;
    		move1++;
    		tmp=a[i]; move1++;
    		j=i; move1++;
    		compare1+=2;
    		while(j>0 && tmp<a[j-1])    //while(j>0 && tmp>a[j-1])
    		{
    			a[j]=a[j-1]; move1++;
    			j--; move1++;
    		}
    		a[j]=tmp; move1++;
    	}
    compare1++;	
	//////sort_insertion/////
	
	for (i = 0; i < n; i++)
        {
			StringGrid4->Cells[0][i]=IntToStr(i+1);
			StringGrid4->Cells[1][i]=FloatToStr(a[i]);
        }
    Edit2->Text=IntToStr(compare1);    
    Edit3->Text=IntToStr(move1);
    time2=clock();
    Edit4->Text=FloatToStr((time2-time1)/1000.0);
	break;
}
case 3:
{
	///clear other grids///
	for(i=0;i<=StringGrid2->RowCount;i++)
		{
			StringGrid2->Cells[0][i]="";
			StringGrid2->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid3->RowCount;i++)
		{
			StringGrid3->Cells[0][i]="";
			StringGrid3->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid4->RowCount;i++)
		{
			StringGrid4->Cells[0][i]="";
			StringGrid4->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid6->RowCount;i++)
		{
			StringGrid6->Cells[0][i]="";
			StringGrid6->Cells[1][i]="";
		}					
	///clear other grids///	
	Edit2->Text="";
    Edit3->Text="";
    Edit4->Text="";
	compare1=0;
	move1=0;
		
    //////sort_Shall/////
    int d=n/2;

    while(d>0)
    {
    	compare1++;
    	compare1++;
    	for(i=d;i<n;i++)
    		{
    			move1++;
    			j=i; move1++;
    			tmp=a[i]; move1++;
    			compare1+=2;
    			while(j>=d && tmp<a[j-d])   //while(j>=d && tmp>a[j-d])
    			{
    				a[j]=a[j-d]; move1++;
    				j-=d; move1++;
    			}
    			a[j]=tmp; move1++;
    		}
    	d/=2; move1++;	
    }
    compare1++;
	//////sort_Shall/////
	
	for (i = 0; i < n; i++)
        {
			StringGrid5->Cells[0][i]=IntToStr(i+1);
			StringGrid5->Cells[1][i]=FloatToStr(a[i]);
        }
    Edit2->Text=IntToStr(compare1);    
    Edit3->Text=IntToStr(move1);
    time2=clock();
    Edit4->Text=FloatToStr((time2-time1)/1000.0);
	break;
}
case 4:
{	
	///clear other grids///
	for(i=0;i<=StringGrid2->RowCount;i++)
		{
			StringGrid2->Cells[0][i]="";
			StringGrid2->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid3->RowCount;i++)
		{
			StringGrid3->Cells[0][i]="";
			StringGrid3->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid4->RowCount;i++)
		{
			StringGrid4->Cells[0][i]="";
			StringGrid4->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid5->RowCount;i++)
		{
			StringGrid5->Cells[0][i]="";
			StringGrid5->Cells[1][i]="";
		}					
	///clear other grids///	
	Edit2->Text="";
    Edit3->Text="";
    Edit4->Text="";
	compare1=0;
	move1=0;
	
    //////Q_sort/////
    Q_sort(0,n-1);
	//////Q_sort/////
	
	for (i = 0; i < n; i++)
        {
			StringGrid6->Cells[0][i]=IntToStr(i+1);
			StringGrid6->Cells[1][i]=FloatToStr(a[i]);
        }
    Edit2->Text=IntToStr(compare1);    
    Edit3->Text=IntToStr(move1);
    time2=clock();
    Edit4->Text=FloatToStr((time2-time1)/1000.0);
	break;
}  
}

}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button3Click(TObject *Sender)
{

///clear all grids///
	for(i=0;i<=StringGrid2->RowCount;i++)
		{
			StringGrid2->Cells[0][i]="";
			StringGrid2->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid3->RowCount;i++)
		{
			StringGrid3->Cells[0][i]="";
			StringGrid3->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid4->RowCount;i++)
		{
			StringGrid4->Cells[0][i]="";
			StringGrid4->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid5->RowCount;i++)
		{
			StringGrid5->Cells[0][i]="";
			StringGrid5->Cells[1][i]="";
		}
	for(i=0;i<=StringGrid6->RowCount;i++)
		{
			StringGrid6->Cells[0][i]="";
			StringGrid6->Cells[1][i]="";
		}
	Edit2->Text="";    
    Edit3->Text="";
    Edit4->Text="";				
	///clear all grids///	
n=StrToInt(Edit1->Text);
StringGrid1->RowCount = n;
StringGrid2->RowCount = n;
StringGrid3->RowCount = n;
StringGrid4->RowCount = n;
StringGrid5->RowCount = n;
StringGrid6->RowCount = n; 

for(i=0;i<n;i++)
	b[i]=random(RANDOM_SIZE);
for(i=0;i<n;i++)
{
	StringGrid1->Cells[0][i]=IntToStr(i+1);
	StringGrid1->Cells[1][i]=FloatToStr(b[i]);
}

}
//---------------------------------------------------------------------------

