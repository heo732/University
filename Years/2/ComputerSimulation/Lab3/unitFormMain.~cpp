//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormMain.h"
#include "unitFunctions.h"
#include <vector>
#include <map>
#include <math.h>
#include <iostream>
using namespace std;
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
TColor getRandomColor()
{
        std::vector<TColor> lineColors;

        lineColors.push_back(clMaroon);
        lineColors.push_back(clGreen);
        lineColors.push_back(clOlive);
        lineColors.push_back(clNavy);
        lineColors.push_back(clPurple);
        lineColors.push_back(clTeal);
        lineColors.push_back(clRed);
        lineColors.push_back(clLime);
        lineColors.push_back(clYellow);
        lineColors.push_back(clBlue);
        lineColors.push_back(clFuchsia);
        lineColors.push_back(clAqua);
        lineColors.push_back(clHotLight);

        int z = rand() % lineColors.size();

        return lineColors[z];
}
//---------------------------------------------------------------------------
int currentColorIndex = 0;
//---------------------------------------------------------------------------
TColor getNextColor()
{
        std::vector<TColor> lineColors;

        lineColors.push_back(clMaroon);
        lineColors.push_back(clGreen);
        lineColors.push_back(clOlive);
        lineColors.push_back(clNavy);
        lineColors.push_back(clPurple);
        lineColors.push_back(clTeal);
        lineColors.push_back(clRed);
        lineColors.push_back(clLime);
        lineColors.push_back(clYellow);
        lineColors.push_back(clBlue);
        lineColors.push_back(clFuchsia);
        lineColors.push_back(clAqua);
        lineColors.push_back(clHotLight);

        currentColorIndex++;
        if(currentColorIndex >= lineColors.size())
            currentColorIndex = 0;

        return lineColors[currentColorIndex];
}
//---------------------------------------------------------------------------
void drawGrid(TImage*& image, double left, double top, double width, double height,
double cellWidth, double cellHeight)
{
        image->Canvas->Pen->Width = 1;
        image->Canvas->Pen->Color = clSilver;
        image->Canvas->Brush->Color = clSilver;
        image->Canvas->Rectangle(left, top, left+width, top+height);

        image->Canvas->Pen->Color = clWhite;

        double row = height/2 + cellHeight;
        while(row > cellHeight)
        {
                row -= cellHeight;
                image->Canvas->MoveTo(left, top+row);
                image->Canvas->LineTo(left+width, top+row);
        }
        row = height/2 - cellHeight;
        while(row < height-cellHeight)
        {
                row += cellHeight  ;
                image->Canvas->MoveTo(left, top+row);
                image->Canvas->LineTo(left+width, top+row);
        }

        double col = width/2 + cellWidth;
        while(col > cellWidth)
        {
                col -= cellWidth;
                image->Canvas->MoveTo(left+col, top);
                image->Canvas->LineTo(left+col, top+height);
        }
        col = width/2 - cellWidth;
        while(col < width-cellWidth)
        {
                col += cellWidth  ;
                image->Canvas->MoveTo(left+col, top);
                image->Canvas->LineTo(left+col, top+height);
        }
}
//---------------------------------------------------------------------------
void drawStrokes(TImage*& image, double left, double top, double width, double height,
double cellWidth, double cellHeight)
{
        image->Canvas->Pen->Width = 1;
        image->Canvas->Pen->Color = clBlack;
        image->Canvas->Brush->Color = clBlack;

        double row = height/2 + cellHeight*2;
        while(row > cellHeight*2)
        {
                row -= cellHeight*2;
                image->Canvas->MoveTo(left-1, top+row);
                image->Canvas->LineTo(left-6, top+row);
        }
        row = height/2 - cellHeight*2;
        while(row < height-cellHeight*2)
        {
                row += cellHeight*2;
                image->Canvas->MoveTo(left-1, top+row);
                image->Canvas->LineTo(left-6, top+row);
        }

        double x0 = left + width/2 - cellWidth*((int)(width/2 / cellWidth));
        double col = 0;
        while(col < width)
        {
                image->Canvas->MoveTo(x0+col, top+height+1);
                image->Canvas->LineTo(x0+col, top+height+6);
                col += cellWidth*2;
        }
}
//---------------------------------------------------------------------------
void drawStrokesCaption(TImage*& image, double left, double top, double width, double height,
double cellWidth, double cellHeight, double xMax, double yMax)
{
        image->Canvas->Pen->Width = 1;
        image->Canvas->Pen->Color = clBlack;
        image->Canvas->Brush->Color = clWhite;

        int colCount = (int)(width/2 / cellWidth) * 2;
        int rowCount = (int)(height/2 / cellHeight) * 2;

        double xStep = xMax / colCount * 2;
        double yStep = yMax / (rowCount/2) * 2;

        double row = height/2 + cellHeight*2;
        double y = 0;
        while(row > cellHeight*2)
        {
                row -= cellHeight*2;
                AnsiString caption = FloatToStrF(y, ffFixed, 5, 2);
                y += yStep;
                image->Canvas->TextOutA(left-10-caption.Length()*5, top+row-5, caption);
        }
        row = height/2 - cellHeight*2;
        y = 0;
        while(row < height-cellHeight*2)
        {
                row += cellHeight*2;
                AnsiString caption = FloatToStrF(y, ffFixed, 5, 2);
                y -= yStep;
                image->Canvas->TextOutA(left-10-caption.Length()*5, top+row-5, caption);
        }

        double x0 = left + width/2 - cellWidth*((int)(width/2 / cellWidth));
        double col = 0;
        double x = 0;
        while(col < width)
        {
                AnsiString caption = FloatToStrF(x, ffFixed, 5, 2);
                image->Canvas->TextOutA(x0+col-(caption.Length()/2+1)*8, top+height+10, caption);
                x += xStep;
                col += cellWidth*2;
        }
}
//---------------------------------------------------------------------------
void drawStrokesCaption2(TImage*& image, double left, double top, double width, double height,
double cellWidth, double cellHeight, double xMax, double yMax)
{
        image->Canvas->Pen->Width = 1;
        image->Canvas->Pen->Color = clBlack;
        image->Canvas->Brush->Color = clWhite;

        int colCount = (int)(width/2 / cellWidth) * 2;
        int rowCount = (int)(height/2 / cellHeight) * 2;

        double xStep = xMax / colCount * 2;
        double yStep = yMax / rowCount * 2;

        double y0 = top + height/2 + cellHeight*((int)(height/2 / cellHeight));
        double row = 0;
        double y = 0;
        while(row < height)
        {
                AnsiString caption = FloatToStrF(y, ffFixed, 5, 2);
                image->Canvas->TextOutA(left-10-caption.Length()*5, y0-row, caption);
                y += yStep;
                row += cellHeight*2;
        }

        double x0 = left + width/2 - cellWidth*((int)(width/2 / cellWidth));
        double col = 0;
        double x = 0;
        while(col < width)
        {
                AnsiString caption = FloatToStrF(x, ffFixed, 5, 2);
                image->Canvas->TextOutA(x0+col-(caption.Length()/2+1)*8, top+height+10, caption);
                x += xStep;
                col += cellWidth*2;
        }
}
//---------------------------------------------------------------------------
void drawStrokesCaption3(TImage*& image, double left, double top, double width, double height,
double cellWidth, double cellHeight, double xMin, double xMax, double yMax)
{
        image->Canvas->Pen->Width = 1;
        image->Canvas->Pen->Color = clBlack;
        image->Canvas->Brush->Color = clWhite;

        int colCount = (int)(width/2 / cellWidth) * 2;
        int rowCount = (int)(height/2 / cellHeight) * 2;

        double xStep = (xMax-xMin) / colCount * 2;
        double yStep = yMax / rowCount * 2;

        double y0 = top + height/2 + cellHeight*((int)(height/2 / cellHeight));
        double row = 0;
        double y = 0;
        while(row < height)
        {
                AnsiString caption = FloatToStrF(y, ffFixed, 5, 2);
                image->Canvas->TextOutA(left-10-caption.Length()*5, y0-row, caption);
                y += yStep;
                row += cellHeight*2;
        }

        double x0 = left + width/2 - cellWidth*((int)(width/2 / cellWidth));
        double col = 0;
        double x = xMin;
        while(col < width)
        {
                AnsiString caption = FloatToStrF(x, ffFixed, 5, 2);
                image->Canvas->TextOutA(x0+col-(caption.Length()/2+1)*8, top+height+10, caption);
                x += xStep;
                col += cellWidth*2;
        }
}
//---------------------------------------------------------------------------
TformMain *formMain;
//---------------------------------------------------------------------------
__fastcall TformMain::TformMain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformMain::FormCreate(TObject *Sender)
{
        srand(time(0));
        Image1->Canvas->ClipRect;
        Image2->Canvas->ClipRect;

        Panel1->Visible = true;
        Panel2->Visible = false;
        Panel3->Visible = false;
        N1->Caption = "Завдання_1";
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button1Click(TObject *Sender)
{
        int _M = 0, _count = 0;
        double _T = 0;

        if(TryStrToFloat(Edit1->Text, _T) && TryStrToInt(Edit2->Text, _M) && TryStrToInt(Edit3->Text, _count))
        {
                Image1->Picture->Bitmap = NULL;

                double h = (double) _T / _M;

                double left = 50, top = 0, width = Image1->Width-left, height = Image1->Height-left-top, cellWidth = 60, cellHeight = 30;
                drawGrid(Image1, left, top, width, height, cellWidth, cellHeight);
                drawStrokes(Image1, left, top, width, height, cellWidth, cellHeight);

                double x0 = left + width/2 - cellWidth*((int)(width/2 / cellWidth));
                double y0 = top + height/2;

                int colCount = (int)(width/2 / cellWidth) * 2;
                int rowCount = (int)(height/2 / cellHeight) * 2;

                double xK = 1. / _T * colCount * cellWidth;

                vector< map<double, double> > trajectory(_count+2);
                double yMax = 0;
                for(int i = 0; i < _count; i++)
                {
                        double t = 0;
                        double W = 0;
                        while(t < _T)
                        {
                                t += h;
                                W += sqrt(h) * rozpodil_8_Normal(0, 1);
                                if(fabs(W) > yMax)
                                        yMax = fabs(W);
                                trajectory[i].insert(pair<double, double>(t, W));
                        }
                }

                //Parabola
                double t = 0;
                double W = 0;
                while(t < _T)
                {
                        t += h;
                        W = sqrt(2 * t * log( log(t) ));
                        if(fabs(W) > yMax)
                                        yMax = fabs(W);
                        trajectory[_count].insert(pair<double, double>(t, W));
                        W = - sqrt(2 * t * log( log(t) ));
                        trajectory[_count+1].insert(pair<double, double>(t, W));
                }
                //Parabola

                double yK = 1. / yMax * rowCount/2 * cellHeight;

                drawStrokesCaption(Image1, left, top, width, height, cellWidth, cellHeight, _T, yMax);

                Image1->Canvas->Pen->Width = 2;
                for(int i = 0; i < _count; i++)
                {
                        Image1->Canvas->Pen->Color = getRandomColor();
                        Image1->Canvas->MoveTo(x0, y0);
                        for(map<double, double>::iterator j = trajectory[i].begin(); j != trajectory[i].end(); j++)
                                Image1->Canvas->LineTo(x0 + j->first*xK, y0 - j->second*yK);
                }

                //Draw Parabola
                Image1->Canvas->Pen->Color = clBlack;
                Image1->Canvas->MoveTo(x0, y0);
                for(map<double, double>::iterator j = trajectory[_count].begin(); j != trajectory[_count].end(); j++)
                        Image1->Canvas->LineTo(x0 + j->first*xK, y0 - j->second*yK);
                Image1->Canvas->MoveTo(x0, y0);
                for(map<double, double>::iterator j = trajectory[_count+1].begin(); j != trajectory[_count+1].end(); j++)
                        Image1->Canvas->LineTo(x0 + j->first*xK, y0 - j->second*yK);
                //Draw Parabola
        }
        else
                ShowMessage("Введіть цілі значення");
}
//---------------------------------------------------------------------------


void __fastcall TformMain::N11Click(TObject *Sender)
{
        Panel1->Visible = true;
        Panel2->Visible = false;
        Panel3->Visible = false;
        N1->Caption = "Завдання_1";
}
//---------------------------------------------------------------------------

void __fastcall TformMain::N21Click(TObject *Sender)
{
        Panel1->Visible = false;
        Panel2->Visible = true;
        Panel3->Visible = false;
        N1->Caption = "Завдання_2";
}
//---------------------------------------------------------------------------

void __fastcall TformMain::N31Click(TObject *Sender)
{
        Panel1->Visible = false;
        Panel2->Visible = false;
        Panel3->Visible = true;
        N1->Caption = "Завдання_3";
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button2Click(TObject *Sender)
{
        int _count = 0;
        double _h = 0, _r = 0, _sigma = 0, _So = 0, _T = 0;
        if(TryStrToFloat(Edit6->Text, _So) && _So <= 0) ShowMessage("Введіть So більше нуля"); else
        if(TryStrToFloat(Edit4->Text, _T) && TryStrToInt(Edit9->Text, _count) && TryStrToFloat(Edit5->Text, _h) && TryStrToFloat(Edit7->Text, _r) && TryStrToFloat(Edit8->Text, _sigma) && TryStrToFloat(Edit6->Text, _So))
        {
                Image2->Picture->Bitmap = NULL;

                double left = 50, top = 0, width = Image2->Width-left, height = Image2->Height-left-top, cellWidth = 60, cellHeight = 30;
                drawGrid(Image2, left, top, width, height, cellWidth, cellHeight);
                drawStrokes(Image2, left, top, width, height, cellWidth, cellHeight);

                double x0 = left + width/2 - cellWidth*((int)(width/2 / cellWidth));
                double y0 = top + height/2 + cellHeight*((int)(height/2 / cellHeight));

                int colCount = (int)(width/2 / cellWidth) * 2;
                int rowCount = (int)(height/2 / cellHeight) * 2;

                switch(RadioGroup1->ItemIndex)
                {
                        case 0:
                        {
                                double xK = 1. / _T * colCount * cellWidth;

                                vector< map<double, double> > trajectory(_count);
                                double yMax = 0;
                                for(int i = 0; i < _count; i++)
                                {
                                        double t = 0;
                                        double W = 0;
                                        double S = _So;
                                        while(t < _T)
                                        {
                                                t += _h;
                                                W += sqrt(_h) * rozpodil_8_Normal(0, 1);
                                                S = _So * exp( (_r - _sigma*_sigma/2) * t + _sigma * W);
                                                if(fabs(S) > yMax)
                                                        yMax = fabs(S);
                                                trajectory[i].insert(pair<double, double>(t, S));
                                        }
                                }

                                double yK = 1. / yMax * rowCount * cellHeight;
                                drawStrokesCaption2(Image2, left, top, width, height, cellWidth, cellHeight, _T, yMax);

                                Image2->Canvas->Pen->Width = 2;
                                for(int i = 0; i < _count; i++)
                                {
                                        Image2->Canvas->Pen->Color = getRandomColor();
                                        Image2->Canvas->MoveTo(x0, y0 - _So*yK);
                                        for(map<double, double>::iterator j = trajectory[i].begin(); j != trajectory[i].end(); j++)
                                                Image2->Canvas->LineTo(x0 + j->first*xK, y0 - j->second*yK);
                                }
                        break;
                        }
                        case 1:
                        {
                                vector<double> values(_count);
                                double xMax = 0;
                                double xMin = 0;
                                for(int i = 0; i < _count; i++)
                                {
                                        double t = 0;
                                        double W = 0;
                                        double S = _So;
                                        while(t < _T)
                                        {
                                                t += _h;
                                                W += sqrt(_h) * rozpodil_8_Normal(0, 1);
                                                S = _So * exp( (_r - _sigma*_sigma/2) * t + _sigma * W);
                                        }
                                        if(i == 0)
                                        {
                                                xMax = S;
                                                xMin = S;
                                        }
                                        if(S > xMax)
                                                xMax = S;
                                        if(S < xMin)
                                                xMin = S;
                                        values[i] = S;
                                }

                                int K = (int) (1 + 3.322*log10(_count));
                                double h = (xMax-xMin) / (double)K;

                                double xK = 1. / ((xMax-h/2)-(xMin + h/2)) * colCount * cellWidth;

                                map<double, double> densities;

                                double x = xMin + h/2;
                                while(x <= xMax-h/2)
                                {
                                        int d = 0;
                                        for(unsigned int j = 0; j < values.size(); j++)
                                        {
                                                if(x == xMax-h/2 && values[j] >= x-h/2 && values[j] <= x+h/2)
                                                        d++;
                                                else if(values[j] >= x-h/2 && values[j] < x+h/2)
                                                        d++;
                                        }
                                        densities.insert(pair<double, double>(x, (double)d/(double)_count));
                                        x += h;
                                }

                                double yMax = densities.begin()->second;
                                for(map<double,double>::iterator i = densities.begin(); i != densities.end(); i++)
                                        if(i->second > yMax)
                                                yMax = i->second;

                                double yK = 1. / yMax * rowCount * cellHeight;

                                drawStrokesCaption3(Image2, left, top, width, height, cellWidth, cellHeight, xMin + h/2, xMax-h/2, yMax);

                                Image2->Canvas->Pen->Width = 2;
                                Image2->Canvas->Pen->Color = getRandomColor();

                                map<double,double>::iterator i = densities.begin();
                                Image2->Canvas->MoveTo(x0, y0 - i->second*yK);
                                i++;
                                while( i != densities.end() )
                                {
                                        Image2->Canvas->LineTo(x0 + (i->first-(xMin+h/2))*xK, y0 - i->second*yK);
                                        i++;
                                }
                        break;
                        }
                }


        }
        else
                ShowMessage("Заповніть поля коректно");
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button3Click(TObject *Sender)
{
        double _lambda = 0;
        int _count = 0;
        if(TryStrToFloat(Edit10->Text, _lambda) && TryStrToInt(Edit11->Text, _count))
        {
            vector< map<int,double> > trajectories(_count);
            int yMax = 0;
            for(int i = 0; i < _count; i++)
            {
                int y = 0;
                double x = 0;
                while(x < _lambda)
                {
                    double r = rozpodil_5_Exp(_lambda);
                    trajectories[i].insert(pair<int, double>(y, r));
                    y++;
                    x += r;
                }
                if (y-1 > yMax)
                    yMax = y-1;
            }

            double left = 50, top = 0, width = Image3->Width-left, height = Image3->Height-left-top, cellWidth = 60, cellHeight = 30;
            drawGrid(Image3, left, top, width, height, cellWidth, cellHeight);
            drawStrokes(Image3, left, top, width, height, cellWidth, cellHeight);
            double x0 = left + width/2 - cellWidth*((int)(width/2 / cellWidth));
            double y0 = top + height/2 + cellHeight*((int)(height/2 / cellHeight));
            int colCount = (int)(width/2 / cellWidth) * 2;
            int rowCount = (int)(height/2 / cellHeight) * 2;
            drawStrokesCaption2(Image3, left, top, width, height, cellWidth, cellHeight, _lambda, yMax);

            Image3->Canvas->Pen->Width = 3;

            double xK = 1.0 / _lambda * colCount * cellWidth;
            double yK = 1.0 / yMax * rowCount * cellHeight;

            for(int t = 0; t < _count; t++)
            {
                Image3->Canvas->Pen->Color = getNextColor();
                double x = 0;
                for(map<int,double>::iterator i = trajectories[t].begin(); i != trajectories[t].end(); i++)
                {
                    Image3->Canvas->MoveTo(x0 + x*xK, y0 - i->first*yK);
                    x += i->second;
                    if(x <= _lambda)
                        Image3->Canvas->LineTo(x0 + x*xK, y0 - i->first*yK);
                    else
                        Image3->Canvas->LineTo(x0 + _lambda*xK, y0 - i->first*yK);
                }
            }
        }
        else
            ShowMessage("Заповніть поля коректно");
}
//---------------------------------------------------------------------------

