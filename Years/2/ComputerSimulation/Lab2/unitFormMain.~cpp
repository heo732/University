//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

#include "unitFormMain.h"
#include "LM.h"
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
void __fastcall TformMain::Button1Click(TObject *Sender)
{
        if(StringGrid1->ColCount > 1)
        {
                StringGrid1->ColCount--;
                StringGrid2->RowCount = StringGrid1->ColCount + 1;
                StringGrid2->ColCount = StringGrid1->ColCount + 1;
                for(int i = 0; i < StringGrid1->ColCount; i++)
                {
                        StringGrid2->Cells[i+1][0] = StringGrid1->Cells[i][0];
                        StringGrid2->Cells[0][i+1] = StringGrid1->Cells[i][0];
                }
        }
}
//---------------------------------------------------------------------------
void __fastcall TformMain::Button2Click(TObject *Sender)
{
        StringGrid1->ColCount++;
        StringGrid2->RowCount = StringGrid1->ColCount + 1;
        StringGrid2->ColCount = StringGrid1->ColCount + 1;
        for(int i = 0; i < StringGrid1->ColCount; i++)
        {
                StringGrid2->Cells[i+1][0] = StringGrid1->Cells[i][0];
                StringGrid2->Cells[0][i+1] = StringGrid1->Cells[i][0];
        }
}
//---------------------------------------------------------------------------
void __fastcall TformMain::Button3Click(TObject *Sender)
{
        if(RadioGroup1->ItemIndex != 3)
        {
                StringGrid3->ColCount = StrToInt(Edit2->Text) + 1;
                for(int i = 0; i < StringGrid3->ColCount; i++)
                {
                        StringGrid3->Cells[i][0] = "";
                        StringGrid3->Cells[i][1] = "";
                }

                for(int i = 0; i < StringGrid1->ColCount; i++)
                {
                        StringGrid2->Cells[i+1][0] = StringGrid1->Cells[i][0];
                        StringGrid2->Cells[0][i+1] = StringGrid1->Cells[i][0];
                }

                int countOfPossibleStates = StringGrid1->ColCount;

                vector<string> possibleStates(countOfPossibleStates);
                for(int i = 0; i < countOfPossibleStates; i++)
                        possibleStates[i] = AnsiToString(StringGrid1->Cells[i][0]);

                string startState = AnsiToString(Edit1->Text);

                vector< vector<double> > matrixOfProbabilities(countOfPossibleStates);
                for(int i = 0; i < countOfPossibleStates; i++)
                        for(int j = 0; j < countOfPossibleStates; j++)
                                matrixOfProbabilities[i].push_back(StrToFloat(StringGrid2->Cells[j+1][i+1]));

                int countGeneration = StrToInt(Edit2->Text);



                LM lm(countOfPossibleStates, possibleStates, startState, matrixOfProbabilities, countGeneration);
                vector<string> arrayResult;
                string resultMessage = lm.generate(arrayResult);

                if(resultMessage == "" && arrayResult.size() > 0)
                {
                        for(int i = 0; i < countGeneration+1; i++)
                        {
                                StringGrid3->Cells[i][0] = IntToStr(i);
                                StringGrid3->Cells[i][1] = StringToAnsi(arrayResult[i]);
                        }
                }
                else
                        ShowMessage(StringToAnsi(resultMessage));
        }
        else
        {
                for(int i = 0; i < StringGrid1->ColCount; i++)
                {
                        StringGrid2->Cells[i+1][0] = StringGrid1->Cells[i][0];
                        StringGrid2->Cells[0][i+1] = StringGrid1->Cells[i][0];
                }

                int countOfPossibleStates = StringGrid1->ColCount;

                vector<string> possibleStates(countOfPossibleStates);
                for(int i = 0; i < countOfPossibleStates; i++)
                        possibleStates[i] = AnsiToString(StringGrid1->Cells[i][0]);

                string startState = AnsiToString(Edit1->Text);

                vector< vector<double> > matrixOfProbabilities(countOfPossibleStates);
                for(int i = 0; i < countOfPossibleStates; i++)
                        for(int j = 0; j < countOfPossibleStates; j++)
                                matrixOfProbabilities[i].push_back(StrToFloat(StringGrid2->Cells[j+1][i+1]));

                int countGeneration = StrToInt(Edit2->Text);

                int countModeling = StrToInt(Edit3->Text);

                int countFails = 0;

                LM lm(countOfPossibleStates, possibleStates, startState, matrixOfProbabilities, countGeneration);
                vector<string> arrayResult;
                string resultMessage = lm.generate(arrayResult);
                if(resultMessage == "" && arrayResult.size() > 0)
                {
                        if(arrayResult[arrayResult.size() - 1] == "0")
                                countFails++;

                        for(int i = 1; i < countModeling; i++)
                        {
                                arrayResult.clear();
                                resultMessage = lm.generate(arrayResult);
                                if(arrayResult[arrayResult.size() - 1] == "0")
                                countFails++;
                        }

                        Label7->Caption = FloatToStr((double)countFails / (double)countModeling);
                }
                else
                        ShowMessage(StringToAnsi(resultMessage));
        }
}
//---------------------------------------------------------------------------
void __fastcall TformMain::FormCreate(TObject *Sender)
{
        srand(time(0));

        Edit3->Visible = false;
        Label6->Visible = false;
        Label7->Visible = false;       
}
//---------------------------------------------------------------------------
void __fastcall TformMain::RadioGroup1Click(TObject *Sender)
{
        switch(RadioGroup1->ItemIndex)
        {
        case 0:
                Edit3->Visible = false;
                Label6->Visible = false;
                Label7->Visible = false;
                StringGrid3->Visible = true;

                Edit1->Text = "1";
                Edit2->Text = "20";
                for(int i = 0; i < 6; i++)
                        StringGrid1->Cells[i][0] = IntToStr(i);
                StringGrid2->Cells[1][1] = FloatToStr(0);
                StringGrid2->Cells[2][1] = FloatToStr(1);
                StringGrid2->Cells[3][1] = FloatToStr(0);
                StringGrid2->Cells[4][1] = FloatToStr(0);
                StringGrid2->Cells[5][1] = FloatToStr(0);
                StringGrid2->Cells[6][1] = FloatToStr(0);
                StringGrid2->Cells[1][2] = FloatToStr(1.0/5);
                StringGrid2->Cells[2][2] = FloatToStr(0);
                StringGrid2->Cells[3][2] = FloatToStr(4.0/5);
                StringGrid2->Cells[4][2] = FloatToStr(0);
                StringGrid2->Cells[5][2] = FloatToStr(0);
                StringGrid2->Cells[6][2] = FloatToStr(0);
                StringGrid2->Cells[1][3] = FloatToStr(0);
                StringGrid2->Cells[2][3] = FloatToStr(2.0/5);
                StringGrid2->Cells[3][3] = FloatToStr(0);
                StringGrid2->Cells[4][3] = FloatToStr(3.0/5);
                StringGrid2->Cells[5][3] = FloatToStr(0);
                StringGrid2->Cells[6][3] = FloatToStr(0);
                StringGrid2->Cells[1][4] = FloatToStr(0);
                StringGrid2->Cells[2][4] = FloatToStr(0);
                StringGrid2->Cells[3][4] = FloatToStr(3.0/5);
                StringGrid2->Cells[4][4] = FloatToStr(0);
                StringGrid2->Cells[5][4] = FloatToStr(2.0/5);
                StringGrid2->Cells[6][4] = FloatToStr(0);
                StringGrid2->Cells[1][5] = FloatToStr(0);
                StringGrid2->Cells[2][5] = FloatToStr(0);
                StringGrid2->Cells[3][5] = FloatToStr(0);
                StringGrid2->Cells[4][5] = FloatToStr(4.0/5);
                StringGrid2->Cells[5][5] = FloatToStr(0);
                StringGrid2->Cells[6][5] = FloatToStr(1.0/5);
                StringGrid2->Cells[1][6] = FloatToStr(0);
                StringGrid2->Cells[2][6] = FloatToStr(0);
                StringGrid2->Cells[3][6] = FloatToStr(0);
                StringGrid2->Cells[4][6] = FloatToStr(0);
                StringGrid2->Cells[5][6] = FloatToStr(1);
                StringGrid2->Cells[6][6] = FloatToStr(0);

                StringGrid1->ColCount = 6;
                StringGrid2->ColCount = 7;
                StringGrid2->RowCount = 7;
                break;
        case 1:
                Edit3->Visible = false;
                Label6->Visible = false;
                Label7->Visible = false;
                StringGrid3->Visible = true;

                Edit1->Text = "Я";
                Edit2->Text = "20";

                StringGrid1->Cells[0][0] = "Я";
                StringGrid1->Cells[1][0] = "С";
                StringGrid1->Cells[2][0] = "Д";

                StringGrid2->Cells[1][1] = FloatToStr(0);
                StringGrid2->Cells[2][1] = FloatToStr(0.5);
                StringGrid2->Cells[3][1] = FloatToStr(0.5);
                StringGrid2->Cells[1][2] = FloatToStr(0.25);
                StringGrid2->Cells[2][2] = FloatToStr(0.5);
                StringGrid2->Cells[3][2] = FloatToStr(0.25);
                StringGrid2->Cells[1][3] = FloatToStr(0.25);
                StringGrid2->Cells[2][3] = FloatToStr(0.25);
                StringGrid2->Cells[3][3] = FloatToStr(0.5);

                StringGrid1->ColCount = 3;
                StringGrid2->ColCount = 4;
                StringGrid2->RowCount = 4;
                break;
        case 2:
                Edit3->Visible = false;
                Label6->Visible = false;
                Label7->Visible = false;
                StringGrid3->Visible = true;

                Edit1->Text = "3";
                Edit2->Text = "10";

                StringGrid1->Cells[0][0] = "0";
                StringGrid1->Cells[1][0] = "1";
                StringGrid1->Cells[2][0] = "2";
                StringGrid1->Cells[3][0] = "3";

                StringGrid2->Cells[1][1] = FloatToStr(1);
                StringGrid2->Cells[2][1] = FloatToStr(0);
                StringGrid2->Cells[3][1] = FloatToStr(0);
                StringGrid2->Cells[4][1] = FloatToStr(0);
                StringGrid2->Cells[1][2] = FloatToStr(0.25);
                StringGrid2->Cells[2][2] = FloatToStr(0.35);
                StringGrid2->Cells[3][2] = FloatToStr(0.4);
                StringGrid2->Cells[4][2] = FloatToStr(0);
                StringGrid2->Cells[1][3] = FloatToStr(0.25);
                StringGrid2->Cells[2][3] = FloatToStr(0);
                StringGrid2->Cells[3][3] = FloatToStr(0.35);
                StringGrid2->Cells[4][3] = FloatToStr(0.4);
                StringGrid2->Cells[1][4] = FloatToStr(0);
                StringGrid2->Cells[2][4] = FloatToStr(0.25);
                StringGrid2->Cells[3][4] = FloatToStr(0);
                StringGrid2->Cells[4][4] = FloatToStr(0.75);

                StringGrid1->ColCount = 4;
                StringGrid2->ColCount = 5;
                StringGrid2->RowCount = 5;
                break;
        case 3:
                Edit3->Visible = true;
                Label6->Visible = true;
                Label7->Visible = true;
                StringGrid3->Visible = false;
                Edit3->Text = "100000";
                Label6->Caption = "Ймовірність банкрутства компанії";
                Label7->Caption = "";

                Edit1->Text = "3";
                Edit2->Text = "5";

                StringGrid1->Cells[0][0] = "0";
                StringGrid1->Cells[1][0] = "1";
                StringGrid1->Cells[2][0] = "2";
                StringGrid1->Cells[3][0] = "3";

                StringGrid2->Cells[1][1] = FloatToStr(1);
                StringGrid2->Cells[2][1] = FloatToStr(0);
                StringGrid2->Cells[3][1] = FloatToStr(0);
                StringGrid2->Cells[4][1] = FloatToStr(0);
                StringGrid2->Cells[1][2] = FloatToStr(0.25);
                StringGrid2->Cells[2][2] = FloatToStr(0.35);
                StringGrid2->Cells[3][2] = FloatToStr(0.4);
                StringGrid2->Cells[4][2] = FloatToStr(0);
                StringGrid2->Cells[1][3] = FloatToStr(0.25);
                StringGrid2->Cells[2][3] = FloatToStr(0);
                StringGrid2->Cells[3][3] = FloatToStr(0.35);
                StringGrid2->Cells[4][3] = FloatToStr(0.4);
                StringGrid2->Cells[1][4] = FloatToStr(0);
                StringGrid2->Cells[2][4] = FloatToStr(0.25);
                StringGrid2->Cells[3][4] = FloatToStr(0);
                StringGrid2->Cells[4][4] = FloatToStr(0.75);

                StringGrid1->ColCount = 4;
                StringGrid2->ColCount = 5;
                StringGrid2->RowCount = 5;
                break;
        }

        for(int i = 0; i < StringGrid1->ColCount; i++)
        {
                StringGrid2->Cells[i+1][0] = StringGrid1->Cells[i][0];
                StringGrid2->Cells[0][i+1] = StringGrid1->Cells[i][0];
        }
}
//---------------------------------------------------------------------------
