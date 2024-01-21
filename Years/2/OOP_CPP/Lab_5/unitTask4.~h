//---------------------------------------------------------------------------
#ifndef unitTask4H
#define unitTask4H
//---------------------------------------------------------------------------
#include "unitTask3.h"
#include <fstream>
#include <Extctrls.hpp>
using namespace std;
//---------------------------------------------------------------------------
class Data
{

        protected:

        Strings _data;

        public:

        virtual void printInMemo(TMemo*& memo) = 0;

        virtual void setData(Strings) = 0;
        virtual Strings getData() = 0;
        virtual void saveToFile(string) = 0;

};
//---------------------------------------------------------------------------
class SignalData : public Data
{

        void setData(Strings strings)
        {
                _data.clear();
                _data.addLine("SignalData");
                for(int i = 0; i < strings.getCountLines(); i++)
                        _data.addLine(strings[i]);
        }

        Strings getData()
        {
                return _data;
        }

        void saveToFile(string fileName)
        {
                ofstream outFile;
                outFile.open(fileName.c_str());
                outFile << _data;
                outFile.close();
        }
        
        void printInMemo(TMemo*& memo)
        {
                memo->Clear();
                for(int i = 0; i < _data.getCountLines(); i++)
                {
                        AnsiString str = _data[i].c_str();
                        memo->Lines->Add(str);
                }
        }

};
//---------------------------------------------------------------------------
class ResultProcessingData : public Data
{

        void setData(Strings strings)
        {
                _data.clear();
                _data.addLine("ResultProcessingData");
                for(int i = 0; i < strings.getCountLines(); i++)
                        _data.addLine(strings[i]);
        }

        Strings getData()
        {
                return _data;
        }

        void saveToFile(string fileName)
        {
                ofstream outFile;
                outFile.open(fileName.c_str());
                outFile << _data;
                outFile.close();
        }

        void printInMemo(TMemo*& memo)
        {
                memo->Clear();
                for(int i = 0; i < _data.getCountLines(); i++)
                {
                        AnsiString str = _data[i].c_str();
                        memo->Lines->Add(str);
                }
        }

};
//---------------------------------------------------------------------------
class AuxiliaryData : public Data
{

        void setData(Strings strings)
        {
                _data.clear();
                _data.addLine("AuxiliaryData");
                for(int i = 0; i < strings.getCountLines(); i++)
                        _data.addLine(strings[i]);
        }

        Strings getData()
        {
                return _data;
        }

        void saveToFile(string fileName)
        {
                ofstream outFile;
                outFile.open(fileName.c_str());
                outFile << _data;
                outFile.close();
        }

        void printInMemo(TMemo*& memo)
        {
                memo->Clear();
                for(int i = 0; i < _data.getCountLines(); i++)
                {
                        AnsiString str = _data[i].c_str();
                        memo->Lines->Add(str);
                }
        }

};
//---------------------------------------------------------------------------
#endif
