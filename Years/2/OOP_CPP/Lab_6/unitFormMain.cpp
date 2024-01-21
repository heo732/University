//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "unitFormMain.h"
#include "Templates.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
//---------------------------------------------------------------------------
TformMain *formMain;
//---------------------------------------------------------------------------
__fastcall TformMain::TformMain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TformMain::N11Click(TObject *Sender)
{
        Panel1->Visible = true;
        Panel2->Visible = false;
        Panel3->Visible = false;
        Panel4->Visible = false;
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button1Click(TObject *Sender)
{
        switch(RadioGroup1->ItemIndex)
        {
                case 0:
                {
                        short* array = new short[StringGrid1->ColCount];
                        for(int i = 0; i < StringGrid1->ColCount; i++)
                                array[i] = StrToInt(StringGrid1->Cells[i][1]);
                        labelAverage->Caption = IntToStr(average(array, StringGrid1->ColCount));
                        delete array;
                        break;
                }
                case 1:
                {
                        int* array = new int[StringGrid1->ColCount];
                        for(int i = 0; i < StringGrid1->ColCount; i++)
                                array[i] = StrToInt(StringGrid1->Cells[i][1]);
                        labelAverage->Caption = IntToStr(average(array, StringGrid1->ColCount));
                        delete array;
                        break;
                }
                case 2:
                {
                        long* array = new long[StringGrid1->ColCount];
                        for(int i = 0; i < StringGrid1->ColCount; i++)
                                array[i] = StrToInt(StringGrid1->Cells[i][1]);
                        labelAverage->Caption = IntToStr(average(array, StringGrid1->ColCount));
                        delete array;
                        break;
                }
                case 3:
                {
                        float* array = new float[StringGrid1->ColCount];
                        for(int i = 0; i < StringGrid1->ColCount; i++)
                                array[i] = StrToFloat(StringGrid1->Cells[i][1]);
                        labelAverage->Caption = FloatToStr(average(array, StringGrid1->ColCount));
                        delete array;
                        break;
                }
                case 4:
                {
                        double* array = new double[StringGrid1->ColCount];
                        for(int i = 0; i < StringGrid1->ColCount; i++)
                                array[i] = StrToFloat(StringGrid1->Cells[i][1]);
                        labelAverage->Caption = FloatToStr(average(array, StringGrid1->ColCount));
                        delete array;
                        break;
                }
                case 5:
                {     
                        char* array = new char[StringGrid1->ColCount];
                        for(int i = 0; i < StringGrid1->ColCount; i++)
                                array[i] = StringGrid1->Cells[i][1][1];
                        labelAverage->Caption = average(array, StringGrid1->ColCount);
                        delete array;
                        break;
                }
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::N21Click(TObject *Sender)
{
        Panel1->Visible = false;
        Panel2->Visible = true;
        Panel3->Visible = false;
        Panel4->Visible = false;
}
//---------------------------------------------------------------------------

void __fastcall TformMain::N31Click(TObject *Sender)
{
        Panel1->Visible = false;
        Panel2->Visible = false;
        Panel3->Visible = true;
        Panel4->Visible = false;
}
//---------------------------------------------------------------------------

void __fastcall TformMain::N41Click(TObject *Sender)
{
        Panel1->Visible = false;
        Panel2->Visible = false;
        Panel3->Visible = false;
        Panel4->Visible = true;
}
//---------------------------------------------------------------------------


void __fastcall TformMain::Button2Click(TObject *Sender)
{
        if(StringGrid1->ColCount > 1)
        {
                StringGrid1->ColCount--;
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button3Click(TObject *Sender)
{
        StringGrid1->Cells[StringGrid1->ColCount][0] = IntToStr(StringGrid1->ColCount+1);
        StringGrid1->Cells[StringGrid1->ColCount][1] = "";
        StringGrid1->ColCount++;
}
//---------------------------------------------------------------------------

void __fastcall TformMain::FormCreate(TObject *Sender)
{
        srand(time(0));

        StringGrid1->ColCount = 5;
        for(short i = 0; i < 5; i++)
        {
                StringGrid1->Cells[i][0] = IntToStr(i+1);
                StringGrid1->Cells[i][1] = IntToStr(i+1);
        }

        StringGrid2->ColCount = 5;
        for(short i = 0; i < 5; i++)
        {
                StringGrid2->Cells[i][0] = IntToStr(i+1);
                StringGrid2->Cells[i][1] = IntToStr(i+1);
                StringGrid3->Cells[i][0] = IntToStr(i+1);
        }

        CyclicQueue<int> queue(15, 5);
        queue.pop(20);
        queue.clear();
        queue.push(10, 40);
        queue.clear();
        queue.pop(queue.length());


        StringGrid5->ColCount = 5;
        StringGrid6->ColCount = 5;
        for(short i = 0; i < 5; i++)
        {
                StringGrid5->Cells[i][0] = IntToStr(i+1);
                StringGrid5->Cells[i][1] = IntToStr(i+1);
                StringGrid6->Cells[i][0] = IntToStr(i+1);
        }

        Panel1->Visible = true;
        Panel2->Visible = false;
        Panel3->Visible = false;
        Panel4->Visible = false;
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button4Click(TObject *Sender)
{
        switch(RadioGroup1->ItemIndex)
        {
                case 0 : case 1 : case 2:
                {
                        for(int i = 0; i < StringGrid1->ColCount; i++)
                                StringGrid1->Cells[i][1] = IntToStr(rand() % 201 - 100);
                        break;
                }
                case 3 : case 4:
                {
                        for(int i = 0; i < StringGrid1->ColCount; i++)
                                StringGrid1->Cells[i][1] = FloatToStr(rand() % 200 - 99 + rand()%100 / 100.);
                        break;
                }
                case 5:
                {
                        for(int i = 0; i < StringGrid1->ColCount; i++)
                                StringGrid1->Cells[i][1] = (char) (rand() % 256);
                        break;
                }
        }

}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button6Click(TObject *Sender)
{
        if(StringGrid2->ColCount > 1)
        {
                StringGrid2->ColCount--;
                StringGrid3->ColCount--;
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button7Click(TObject *Sender)
{
        StringGrid2->Cells[StringGrid2->ColCount][0] = IntToStr(StringGrid2->ColCount+1);
        StringGrid2->Cells[StringGrid2->ColCount][1] = "";
        StringGrid2->ColCount++;

        StringGrid3->Cells[StringGrid3->ColCount][0] = IntToStr(StringGrid3->ColCount+1);
        StringGrid3->Cells[StringGrid3->ColCount][1] = "";
        StringGrid3->ColCount++;
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button8Click(TObject *Sender)
{
        switch(RadioGroup2->ItemIndex)
        {
                case 0 : case 1 : case 2:
                {
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                StringGrid2->Cells[i][1] = IntToStr(rand() % 201 - 100);
                        break;
                }
                case 3 : case 4:
                {
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                StringGrid2->Cells[i][1] = FloatToStr(rand() % 200 - 99 + rand()%100 / 100.);
                        break;
                }
                case 5:
                {
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                StringGrid2->Cells[i][1] = (char) (rand() % 256);
                        break;
                }
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button5Click(TObject *Sender)
{
        switch(RadioGroup2->ItemIndex)
        {
                case 0:
                {
                        short* array = new short[StringGrid2->ColCount];
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                array[i] = StrToInt(StringGrid2->Cells[i][1]);
                        sortSelection(array, StringGrid2->ColCount);
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                StringGrid3->Cells[i][1] = IntToStr(array[i]);
                        delete array;
                        break;
                }
                case 1:
                {
                        int* array = new int[StringGrid2->ColCount];
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                array[i] = StrToInt(StringGrid2->Cells[i][1]);
                        sortSelection(array, StringGrid2->ColCount);
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                StringGrid3->Cells[i][1] = IntToStr(array[i]);
                        delete array;
                        break;
                }
                case 2:
                {
                        long* array = new long[StringGrid2->ColCount];
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                array[i] = StrToInt(StringGrid2->Cells[i][1]);
                        sortSelection(array, StringGrid2->ColCount);
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                StringGrid3->Cells[i][1] = IntToStr(array[i]);
                        delete array;
                        break;
                }
                case 3:
                {
                        float* array = new float[StringGrid2->ColCount];
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                array[i] = StrToFloat(StringGrid2->Cells[i][1]);
                        sortSelection(array, StringGrid2->ColCount);
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                StringGrid3->Cells[i][1] = FloatToStr(array[i]);
                        delete array;
                        break;
                }
                case 4:
                {
                        double* array = new double[StringGrid2->ColCount];
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                array[i] = StrToFloat(StringGrid2->Cells[i][1]);
                        sortSelection(array, StringGrid2->ColCount);
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                StringGrid3->Cells[i][1] = FloatToStr(array[i]);
                        delete array;
                        break;
                }
                case 5:
                {
                        char* array = new char[StringGrid2->ColCount];
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                array[i] = StringGrid2->Cells[i][1][1];
                        sortSelection(array, StringGrid2->ColCount);
                        for(int i = 0; i < StringGrid2->ColCount; i++)
                                StringGrid3->Cells[i][1] = array[i];
                        delete array;
                        break;
                }
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button12Click(TObject *Sender)
{
        switch(RadioGroup3->ItemIndex)
        {
                case 0 : case 1 : case 2:
                {
                        Edit1->Text = IntToStr(rand() % 201 - 100);
                        break;
                }
                case 3 : case 4:
                {
                        Edit1->Text = FloatToStr(rand() % 200 - 99 + rand()%100 / 100.);
                        break;
                }
                case 5:
                {
                        Edit1->Text = (char) (rand() % 256);
                        break;
                }
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button11Click(TObject *Sender)
{
        switch(RadioGroup3->ItemIndex)
        {
                case 0:
                {
                        CyclicQueue<short> queue;
                        if(StringGrid4->Visible)
                                for(int i = 0; i < StringGrid4->ColCount; i++)
                                        queue.push(StrToInt(StringGrid4->Cells[i][1]));
                        queue.push(StrToInt(Edit1->Text));
                        StringGrid4->Visible = true;
                        StringGrid4->ColCount = queue.length();
                        for(int i = 0; i < StringGrid4->ColCount; i++)
                        {
                                StringGrid4->Cells[i][0] = IntToStr(i+1);
                                StringGrid4->Cells[i][1] = IntToStr(queue.get());
                                queue.next();
                        }
                        break;
                }
                case 1:
                {
                        CyclicQueue<int> queue;
                        if(StringGrid4->Visible)
                                for(int i = 0; i < StringGrid4->ColCount; i++)
                                        queue.push(StrToInt(StringGrid4->Cells[i][1]));
                        queue.push(StrToInt(Edit1->Text));
                        StringGrid4->Visible = true;
                        StringGrid4->ColCount = queue.length();
                        for(int i = 0; i < StringGrid4->ColCount; i++)
                        {
                                StringGrid4->Cells[i][0] = IntToStr(i+1);
                                StringGrid4->Cells[i][1] = IntToStr(queue.get());
                                queue.next();
                        }
                        break;
                }
                case 2:
                {
                        CyclicQueue<long> queue;
                        if(StringGrid4->Visible)
                                for(int i = 0; i < StringGrid4->ColCount; i++)
                                        queue.push(StrToInt(StringGrid4->Cells[i][1]));
                        queue.push(StrToInt(Edit1->Text));
                        StringGrid4->Visible = true;
                        StringGrid4->ColCount = queue.length();
                        for(int i = 0; i < StringGrid4->ColCount; i++)
                        {
                                StringGrid4->Cells[i][0] = IntToStr(i+1);
                                StringGrid4->Cells[i][1] = IntToStr(queue.get());
                                queue.next();
                        }
                        break;
                }
                case 3:
                {
                        CyclicQueue<float> queue;
                        if(StringGrid4->Visible)
                                for(int i = 0; i < StringGrid4->ColCount; i++)
                                        queue.push(StrToFloat(StringGrid4->Cells[i][1]));
                        queue.push(StrToFloat(Edit1->Text));
                        StringGrid4->Visible = true;
                        StringGrid4->ColCount = queue.length();
                        for(int i = 0; i < StringGrid4->ColCount; i++)
                        {
                                StringGrid4->Cells[i][0] = IntToStr(i+1);
                                StringGrid4->Cells[i][1] = FloatToStr(queue.get());
                                queue.next();
                        }
                        break;
                }
                case 4:
                {
                        CyclicQueue<double> queue;
                        if(StringGrid4->Visible)
                                for(int i = 0; i < StringGrid4->ColCount; i++)
                                        queue.push(StrToFloat(StringGrid4->Cells[i][1]));
                        queue.push(StrToFloat(Edit1->Text));
                        StringGrid4->Visible = true;
                        StringGrid4->ColCount = queue.length();
                        for(int i = 0; i < StringGrid4->ColCount; i++)
                        {
                                StringGrid4->Cells[i][0] = IntToStr(i+1);
                                StringGrid4->Cells[i][1] = FloatToStr(queue.get());
                                queue.next();
                        }
                        break;
                }
                case 5:
                {
                        CyclicQueue<char> queue;
                        if(StringGrid4->Visible)
                                for(int i = 0; i < StringGrid4->ColCount; i++)
                                        queue.push(StringGrid4->Cells[i][1][1]);
                        queue.push(Edit1->Text[1]);
                        StringGrid4->Visible = true;
                        StringGrid4->ColCount = queue.length();
                        for(int i = 0; i < StringGrid4->ColCount; i++)
                        {
                                StringGrid4->Cells[i][0] = IntToStr(i+1);
                                StringGrid4->Cells[i][1] = queue.get();
                                queue.next();
                        }
                        break;
                }
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button9Click(TObject *Sender)
{
        if(StringGrid4->Visible)
        {
                CyclicQueue<AnsiString> queue;
                for(int i = 0; i < StringGrid4->ColCount; i++)
                        queue.push(StringGrid4->Cells[i][1]);
                queue.prev();
                for(int i = 0; i < StringGrid4->ColCount; i++)
                {
                        StringGrid4->Cells[i][0] = IntToStr(i+1);
                        StringGrid4->Cells[i][1] = queue.get();
                        queue.next();
                }
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button10Click(TObject *Sender)
{
        if(StringGrid4->Visible)
        {
                CyclicQueue<AnsiString> queue;
                for(int i = 0; i < StringGrid4->ColCount; i++)
                        queue.push(StringGrid4->Cells[i][1]);
                queue.next();
                for(int i = 0; i < StringGrid4->ColCount; i++)
                {
                        StringGrid4->Cells[i][0] = IntToStr(i+1);
                        StringGrid4->Cells[i][1] = queue.get();
                        queue.next();
                }
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button13Click(TObject *Sender)
{
        if(StringGrid4->Visible)
        {
                if(StringGrid4->ColCount == 1)
                        StringGrid4->Visible = false;
                else
                {
                        CyclicQueue<AnsiString> queue;
                        for(int i = 0; i < StringGrid4->ColCount; i++)
                                queue.push(StringGrid4->Cells[i][1]);
                        queue.pop();
                        StringGrid4->ColCount = queue.length();
                        for(int i = 0; i < StringGrid4->ColCount; i++)
                        {
                                StringGrid4->Cells[i][0] = IntToStr(i+1);
                                StringGrid4->Cells[i][1] = queue.get();
                                queue.next();
                        }
                }
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button15Click(TObject *Sender)
{
        StringGrid4->Visible = false;        
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button14Click(TObject *Sender)
{
        CyclicQueue<AnsiString> queue;
        if(StringGrid4->Visible)
                for(int i = 0; i < StringGrid4->ColCount; i++)
                        queue.push(StringGrid4->Cells[i][1]);
        ShowMessage("length = " + IntToStr(queue.length()));
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button19Click(TObject *Sender)
{
        switch(RadioGroup4->ItemIndex)
        {
                case 0 : case 1 : case 2:
                {
                        for(int i = 0; i < StringGrid5->ColCount; i++)
                                StringGrid5->Cells[i][1] = IntToStr(rand() % 201 - 100);
                        break;
                }
                case 3 : case 4:
                {
                        for(int i = 0; i < StringGrid5->ColCount; i++)
                                StringGrid5->Cells[i][1] = FloatToStr(rand() % 200 - 99 + rand()%100 / 100.);
                        break;
                }
                case 5:
                {
                        for(int i = 0; i < StringGrid5->ColCount; i++)
                                StringGrid5->Cells[i][1] = (char) (rand() % 256);
                        break;
                }
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button17Click(TObject *Sender)
{
        if(StringGrid5->ColCount > 1)
        {
                StringGrid5->ColCount--;
                StringGrid6->ColCount--;
        }
}
//---------------------------------------------------------------------------

void __fastcall TformMain::Button18Click(TObject *Sender)
{
        StringGrid5->Cells[StringGrid5->ColCount][0] = IntToStr(StringGrid5->ColCount+1);
        StringGrid5->Cells[StringGrid5->ColCount][1] = "";
        StringGrid5->ColCount++;

        StringGrid6->Cells[StringGrid6->ColCount][0] = IntToStr(StringGrid6->ColCount+1);
        StringGrid6->Cells[StringGrid6->ColCount][1] = "";
        StringGrid6->ColCount++;
}
//---------------------------------------------------------------------------
void __fastcall TformMain::Button16Click(TObject *Sender)
{
        switch(RadioGroup4->ItemIndex)
        {
                case 0:
                {
                        Array<short> array(StringGrid5->ColCount);
                        for(int i = 0; i < StringGrid5->ColCount; i++)
                                array[i] = StrToInt(StringGrid5->Cells[i][1]);

                        for(Array<short>::iterator it = array.begin(); it != array.end(); it++)
                                *it *= 2;

                        array.sort();

                        for(int i = 0; i < StringGrid6->ColCount; i++)
                                StringGrid6->Cells[i][1] = IntToStr(array[i]);

                        break;
                }
                case 1:
                {
                        Array<int> array(StringGrid5->ColCount);
                        for(int i = 0; i < StringGrid5->ColCount; i++)
                                array[i] = StrToInt(StringGrid5->Cells[i][1]);

                        for(Array<int>::iterator it = array.begin(); it != array.end(); it++)
                                *it *= 2;

                        array.sort();

                        for(int i = 0; i < StringGrid6->ColCount; i++)
                                StringGrid6->Cells[i][1] = IntToStr(array[i]);

                        break;
                }
                case 2:
                {
                        Array<long> array(StringGrid5->ColCount);
                        for(int i = 0; i < StringGrid5->ColCount; i++)
                                array[i] = StrToInt(StringGrid5->Cells[i][1]);

                        for(Array<long>::iterator it = array.begin(); it != array.end(); it++)
                                *it *= 2;

                        array.sort();

                        for(int i = 0; i < StringGrid6->ColCount; i++)
                                StringGrid6->Cells[i][1] = IntToStr(array[i]);

                        break;
                }
                case 3:
                {
                        Array<float> array(StringGrid5->ColCount);
                        for(int i = 0; i < StringGrid5->ColCount; i++)
                                array[i] = StrToFloat(StringGrid5->Cells[i][1]);

                        for(Array<float>::iterator it = array.begin(); it != array.end(); it++)
                                *it *= 2;

                        array.sort();

                        for(int i = 0; i < StringGrid6->ColCount; i++)
                                StringGrid6->Cells[i][1] = FloatToStr(array[i]);

                        break;
                }
                case 4:
                {
                        Array<double> array(StringGrid5->ColCount);
                        for(int i = 0; i < StringGrid5->ColCount; i++)
                                array[i] = StrToFloat(StringGrid5->Cells[i][1]);

                        for(Array<double>::iterator it = array.begin(); it != array.end(); it++)
                                *it *= 2;

                        array.sort();

                        for(int i = 0; i < StringGrid6->ColCount; i++)
                                StringGrid6->Cells[i][1] = FloatToStr(array[i]);

                        break;
                }
                case 5:
                {
                        Array<char> array(StringGrid5->ColCount);
                        for(int i = 0; i < StringGrid5->ColCount; i++)
                                array[i] = StringGrid5->Cells[i][1][1];

                        for(Array<char>::iterator it = array.begin(); it != array.end(); it++)
                                *it *= 2;

                        array.sort();

                        for(int i = 0; i < StringGrid6->ColCount; i++)
                                StringGrid6->Cells[i][1] = array[i];

                        break;
                }
        }
}
//---------------------------------------------------------------------------