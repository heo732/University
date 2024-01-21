//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
#include <math.h>
#define points 72
#define centers 10
//---------------------------------------------------------------------------
TForm1 *Form1;

double x0[points],y0[points],center_x0[centers],center_y0[centers];
double r1,r2;
int i;

void DrawMyCar(double a[points],double b[points],double c_x[centers],double c_y[centers])
{
////////////////Drawing////////////////
//korpus
Form1->Image1->Canvas->Pen->Color = clBlack;
Form1->Image1->Canvas->Pen->Width = 3;
Form1->Image1->Canvas->MoveTo(a[0],b[0]);
Form1->Image1->Canvas->LineTo(a[1],b[1]);
Form1->Image1->Canvas->LineTo(a[2],b[2]);
Form1->Image1->Canvas->LineTo(a[3],b[3]);
Form1->Image1->Canvas->LineTo(a[4],b[4]);
Form1->Image1->Canvas->LineTo(a[5],b[5]);
Form1->Image1->Canvas->LineTo(a[6],b[6]);
Form1->Image1->Canvas->LineTo(a[68],b[68]);
Form1->Image1->Canvas->LineTo(a[69],b[69]);
Form1->Image1->Canvas->LineTo(a[7],b[7]);
Form1->Image1->Canvas->LineTo(a[8],b[8]);
Form1->Image1->Canvas->LineTo(a[9],b[9]);
Form1->Image1->Canvas->LineTo(a[10],b[10]);
Form1->Image1->Canvas->LineTo(a[11],b[11]);
Form1->Image1->Canvas->LineTo(a[12],b[12]);
Form1->Image1->Canvas->LineTo(a[13],b[13]);
Form1->Image1->Canvas->LineTo(a[14],b[14]);
Form1->Image1->Canvas->LineTo(a[15],b[15]);
Form1->Image1->Canvas->LineTo(a[70],b[70]);
Form1->Image1->Canvas->LineTo(a[71],b[71]);
Form1->Image1->Canvas->LineTo(a[16],b[16]);
//korpus

//dno
Form1->Image1->Canvas->MoveTo(a[17],b[17]);
Form1->Image1->Canvas->LineTo(a[18],b[18]);
Form1->Image1->Canvas->Brush->Color = clMaroon;
Form1->Image1->Canvas->FloodFill(c_x[1],c_y[1],clBlack,fsBorder);

Form1->Image1->Canvas->MoveTo(a[19],b[19]);
Form1->Image1->Canvas->LineTo(a[20],b[20]);
Form1->Image1->Canvas->FloodFill(c_x[2],c_y[2],clBlack,fsBorder);
//dno

//kolesa
Form1->Image1->Canvas->Brush->Color=clGray;
Form1->Image1->Canvas->Ellipse(a[21],b[21],a[22],b[22]);
Form1->Image1->Canvas->Brush->Color=clMoneyGreen;
Form1->Image1->Canvas->Ellipse(a[23],b[23],a[24],b[24]);

Form1->Image1->Canvas->Brush->Color=clGray;
Form1->Image1->Canvas->Ellipse(a[25],b[25],a[26],b[26]);
Form1->Image1->Canvas->Brush->Color=clMoneyGreen;
Form1->Image1->Canvas->Ellipse(a[27],b[27],a[28],b[28]);
//kolesa

//windows
Form1->Image1->Canvas->MoveTo(a[29],b[29]);
Form1->Image1->Canvas->LineTo(a[30],b[30]);
Form1->Image1->Canvas->LineTo(a[31],b[31]);
Form1->Image1->Canvas->LineTo(a[32],b[32]);
Form1->Image1->Canvas->LineTo(a[33],b[33]);

Form1->Image1->Canvas->MoveTo(a[34],b[34]);
Form1->Image1->Canvas->LineTo(a[35],b[35]);
Form1->Image1->Canvas->LineTo(a[36],b[36]);
Form1->Image1->Canvas->LineTo(a[37],b[37]);
Form1->Image1->Canvas->LineTo(a[38],b[38]);


Form1->Image1->Canvas->Brush->Color = clRed;           //pokraska korpusa
Form1->Image1->Canvas->FloodFill(c_x[0],c_y[0],clBlack,fsBorder);
//windows

//kermo
Form1->Image1->Canvas->MoveTo(a[39],b[39]);
Form1->Image1->Canvas->LineTo(a[40],b[40]);
Form1->Image1->Canvas->LineTo(a[41],b[41]);
Form1->Image1->Canvas->LineTo(a[42],b[42]);
Form1->Image1->Canvas->LineTo(a[43],b[43]);

Form1->Image1->Canvas->Brush->Color=clSilver;
Form1->Image1->Canvas->FloodFill(c_x[3],c_y[3],clBlack,fsBorder);
//kermo

//bamper right
Form1->Image1->Canvas->MoveTo(a[44],b[44]);
Form1->Image1->Canvas->LineTo(a[45],b[45]);
Form1->Image1->Canvas->LineTo(a[46],b[46]);
Form1->Image1->Canvas->LineTo(a[47],b[47]);
Form1->Image1->Canvas->LineTo(a[48],b[48]);
Form1->Image1->Canvas->Brush->Color = clSilver;
Form1->Image1->Canvas->FloodFill(c_x[4],c_y[4],clBlack,fsBorder);

Form1->Image1->Canvas->MoveTo(a[49],b[49]);
Form1->Image1->Canvas->LineTo(a[50],b[50]);
Form1->Image1->Canvas->LineTo(a[51],b[51]);
Form1->Image1->Canvas->LineTo(a[52],b[52]);
Form1->Image1->Canvas->LineTo(a[53],b[53]);
Form1->Image1->Canvas->Brush->Color = clMedGray;
Form1->Image1->Canvas->FloodFill(c_x[5],c_y[5],clBlack,fsBorder);
//bamper left

//fary
Form1->Image1->Canvas->MoveTo(a[54],b[54]);
Form1->Image1->Canvas->LineTo(a[55],b[55]);
Form1->Image1->Canvas->LineTo(a[56],b[56]);
Form1->Image1->Canvas->LineTo(a[57],b[57]);
Form1->Image1->Canvas->LineTo(a[58],b[58]);
Form1->Image1->Canvas->Brush->Color = clYellow;
Form1->Image1->Canvas->FloodFill(c_x[6],c_y[6],clBlack,fsBorder);

Form1->Image1->Canvas->MoveTo(a[59],b[59]);
Form1->Image1->Canvas->LineTo(a[60],b[60]);
Form1->Image1->Canvas->LineTo(a[61],b[61]);
Form1->Image1->Canvas->LineTo(a[62],b[62]);
Form1->Image1->Canvas->LineTo(a[63],b[63]);
Form1->Image1->Canvas->FloodFill(c_x[7],c_y[7],clBlack,fsBorder);
//fary

//polosky
Form1->Image1->Canvas->Pen->Color=clMaroon;
Form1->Image1->Canvas->MoveTo(a[64],b[64]);
Form1->Image1->Canvas->LineTo(a[65],b[65]);

Form1->Image1->Canvas->MoveTo(a[66],b[66]);
Form1->Image1->Canvas->LineTo(a[67],b[67]);
//polosky
////////////////Drawing////////////////
}

void ResetImage(double x[points],double y[points],double center_x[centers],double center_y[centers])
{
Form1->Image1->Picture->LoadFromFile("background.bmp");
 //korpus
x[0]=220; y[0]=400;
x[1]=300; y[1]=400;
x[2]=350; y[2]=320;
x[3]=500; y[3]=320;
x[4]=555; y[4]=400;
x[5]=635; y[5]=400;
x[6]=631; y[6]=496;
x[7]=600; y[7]=520;
x[8]=585; y[8]=470;
x[9]=520; y[9]=470;
x[10]=505; y[10]=520;
x[11]=360; y[11]=520;
x[12]=345; y[12]=470;
x[13]=280; y[13]=470;
x[14]=265; y[14]=520;
x[15]=235; y[15]=520;
x[16]=220; y[16]=400;
center_x[0]=(x[0]+x[5]+x[6]+x[15])/4;
center_y[0]=(y[0]+y[5]+y[6]+y[15])/4;
x[68]=618; y[68]=496;
x[69]=618; y[69]=520;
x[70]=235; y[70]=498;
x[71]=223; y[71]=498;
//korpus

//dno right
x[17]=599; y[17]=517;
x[18]=506; y[18]=517;
center_x[1]=(x[17]+x[18]+x[8]+x[9])/4;
center_y[1]=(y[17]+y[18]+y[8]+y[9])/4;

x[19]=266; y[19]=517;
x[20]=359; y[20]=517;
center_x[2]=(x[19]+x[20]+x[12]+x[13])/4;
center_y[2]=(y[19]+y[20]+y[12]+y[13])/4;
//dno left

//koleso left
center_x[8]=313; center_y[8]=520;
r1=40; r2=23;
x[21]=center_x[8]-r1;       y[21]=center_y[8]-r1;
x[22]=center_x[8]+r1;       y[22]=center_y[8]+r1;
x[23]=center_x[8]-r2;       y[23]=center_y[8]-r2;
x[24]=center_x[8]+r2;       y[24]=center_y[8]+r2;

center_x[9]=553; center_y[9]=520;
x[25]=center_x[9]-r1;       y[25]=center_y[9]-r1;
x[26]=center_x[9]+r1;       y[26]=center_y[9]+r1;
x[27]=center_x[9]-r2;       y[27]=center_y[9]-r2;
x[28]=center_x[9]+r2;       y[28]=center_y[9]+r2;
//koleso right

//window left
x[29]=315; y[29]=400;
x[30]=355; y[30]=335;
x[31]=422.5; y[31]=335;
x[32]=422.5; y[32]=400;
x[33]=315; y[33]=400;

x[34]=437.5; y[34]=400;
x[35]=437.5; y[35]=335;
x[36]=495; y[36]=335;
x[37]=540; y[37]=400;
x[38]=437.5; y[38]=400;
//window right

//kermo
x[39]=510; y[39]=400;
x[40]=515; y[40]=380;
x[41]=525; y[41]=380;
x[42]=520; y[42]=400;
x[43]=510; y[43]=400;
center_x[3]=(x[39]+x[40]+x[41]+x[42])/4;
center_y[3]=(y[39]+y[40]+y[41]+y[42])/4;
//kermo

//bamper right
x[44]=618; y[44]=532;
x[45]=618; y[45]=496;
x[46]=654; y[46]=496;
x[47]=654; y[47]=532;
x[48]=618; y[48]=532;
center_x[4]=(x[44]+x[45]+x[46]+x[47])/4;
center_y[4]=(y[44]+y[45]+y[46]+y[47])/4;

x[49]=235; y[49]=530;
x[50]=235; y[50]=498;
x[51]=205; y[51]=498;
x[52]=205; y[52]=530;
x[53]=235; y[53]=530;
center_x[5]=(x[49]+x[50]+x[51]+x[52])/4;
center_y[5]=(y[49]+y[50]+y[51]+y[52])/4;
//bamper left

//fara right
x[54]=634; y[54]=410;
x[55]=646; y[55]=407;
x[56]=646; y[56]=452;
x[57]=634; y[57]=450;
x[58]=634; y[58]=410;
center_x[6]=(x[54]+x[55]+x[56]+x[57])/4;
center_y[6]=(y[54]+y[55]+y[56]+y[57])/4;

x[59]=221; y[59]=408;
x[60]=221; y[60]=438;
x[61]=213; y[61]=438;
x[62]=213; y[62]=408;
x[63]=221; y[63]=408;
center_x[7]=(x[59]+x[60]+x[61]+x[62])/4;
center_y[7]=(y[59]+y[60]+y[61]+y[62])/4;
//fara left

//polosky
x[64]=422.5; y[64]=430;
x[65]=422.5; y[65]=490;
x[66]=437.5; y[66]=420;
x[67]=437.5; y[67]=500;
//polosky

DrawMyCar(x,y,center_x,center_y);
}

void Zsuv(double a[points],double c[centers],double k)
{
Form1->Image1->Picture->LoadFromFile("background.bmp");
for(i=0;i<points;i++)
        a[i]+=k;
for(i=0;i<centers;i++)
        c[i]+=k;
DrawMyCar(x0,y0,center_x0,center_y0);
}

void Masshtab(double x[points],double y[points],double center_x[centers],double center_y[centers],double k)
{
Form1->Image1->Picture->LoadFromFile("background.bmp");
for(i=0;i<points;i++)
        {
        y[i]=(y[i]-center_y[0])*k+center_y[0];
        x[i]=(x[i]-center_x[0])*k+center_x[0];
        }
for(i=0;i<centers;i++)
        {
        center_y[i]=(center_y[i]-center_y[0])*k+center_y[0];
        center_x[i]=(center_x[i]-center_x[0])*k+center_x[0];
        }
r1=r1*k*0.996; r2=r2*k*0.996;        
DrawMyCar(x0,y0,center_x0,center_y0);
}

void Povorot(double x[points],double y[points],double center_x[centers],double center_y[centers],double k)
{
double x_b,y_b;
Form1->Image1->Picture->LoadFromFile("background.bmp");
for(i=0;i<points;i++)
        {
        x_b=((x[i]-center_x[0])*cos(k))-((y[i]-center_y[0])*sin(k))+center_x[0];
        y_b=((x[i]-center_x[0])*sin(k))+((y[i]-center_y[0])*cos(k))+center_y[0];
        x[i]=x_b;
        y[i]=y_b;
        }
for(i=0;i<centers;i++)
        {
        x_b=((center_x[i]-center_x[0])*cos(k))-((center_y[i]-center_y[0])*sin(k))+center_x[0];
        y_b=((center_x[i]-center_x[0])*sin(k))+((center_y[i]-center_y[0])*cos(k))+center_y[0];
        center_x[i]=x_b;
        center_y[i]=y_b;
        }
x[21]=center_x[8]-r1;       y[21]=center_y[8]-r1;
x[22]=center_x[8]+r1;       y[22]=center_y[8]+r1;
x[23]=center_x[8]-r2;       y[23]=center_y[8]-r2;
x[24]=center_x[8]+r2;       y[24]=center_y[8]+r2;

x[25]=center_x[9]-r1;       y[25]=center_y[9]-r1;
x[26]=center_x[9]+r1;       y[26]=center_y[9]+r1;
x[27]=center_x[9]-r2;       y[27]=center_y[9]-r2;
x[28]=center_x[9]+r2;       y[28]=center_y[9]+r2;

DrawMyCar(x0,y0,center_x0,center_y0);
}
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{ 
ResetImage(x0,y0,center_x0,center_y0);
}  
//---------------------------------------------------------------------------
void __fastcall TForm1::Button1Click(TObject *Sender)  //Clear
{
ResetImage(x0,y0,center_x0,center_y0);
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button2Click(TObject *Sender) //top
{
Zsuv(y0,center_y0,-(StrToFloat(Form1->Edit1->Text)));
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button3Click(TObject *Sender) //right
{
Zsuv(x0,center_x0,(StrToFloat(Form1->Edit1->Text)));
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button4Click(TObject *Sender)  //bottom
{
Zsuv(y0,center_y0,(StrToFloat(Form1->Edit1->Text)));
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button5Click(TObject *Sender) //left
{
Zsuv(x0,center_x0,-(StrToFloat(Form1->Edit1->Text)));
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button6Click(TObject *Sender) //mashtabuvann9
{
Masshtab(x0,y0,center_x0,center_y0,StrToFloat(Form1->Edit2->Text));
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button7Click(TObject *Sender) //povorot right
{
Povorot(x0,y0,center_x0,center_y0,(StrToFloat(Form1->Edit3->Text))/180*M_PI);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button8Click(TObject *Sender) //povorot left
{
Povorot(x0,y0,center_x0,center_y0,-((StrToFloat(Form1->Edit3->Text))/180*M_PI));
}
//---------------------------------------------------------------------------