//---------------------------------------------------------------------------
#ifndef unitTask3H
#define unitTask3H

#include <string>
#include <iostream>
#include <fstream>
#include <vector>
#include <Classes.hpp>
using namespace std;
//---------------------------------------------------------------------------
class Strings
{

        protected:

        vector<string> _lines;

        public:

        Strings() {}

        Strings(string str, int cnt = 1)
        {
                if(cnt <= 0)
                        cnt = 1;
                for(int i = 0; i < cnt; i++)
                        _lines.push_back(str);        
        }

        ~Strings()
        {
                _lines.clear();
        }

        string& operator [] (unsigned int i)
        {
                if(i >= _lines.size())
                        return _lines[_lines.size()-1];
                return _lines[i];
        }

        AnsiString operator () (unsigned int i)
        {
                AnsiString ret = "";
                if(i >= _lines.size())
                        ret = _lines[_lines.size()-1].c_str();
                ret = _lines[i].c_str();
                return ret;
        }

        int getCountLines()
        {
                return _lines.size();
        }
        
        void addLine(string str, unsigned int cnt = 1)
        {
                for(unsigned int i = 0; i < cnt; i++)
                        _lines.push_back(str);
        }

        void addLine(AnsiString str, unsigned int cnt)
        {
                string str1 = str.c_str();
                for(unsigned int i = 0; i < cnt; i++)
                        _lines.push_back(str1);
        }

        friend istream& operator >> (istream& input, Strings& v)
        {
                string str;
                input >> str;
                v.addLine(str);
                return input;
        }

        friend ostream& operator << (ostream& output, Strings& v)
        {
                for(int i = 0; i < v.getCountLines(); i++)
                        output << v[i] << endl;
                return output;
        }

        friend ifstream& operator >> (ifstream& finput, Strings& v)
        {
                string str;
                finput >> str;
                v.addLine(str);
                return finput;
        }

        friend ofstream& operator << (ofstream& foutput, Strings& v)
        {
                for(int i = 0; i < v.getCountLines(); i++)
                        foutput << v[i] << endl;
                return foutput;
        }

        Strings& operator = (Strings in)
        {
                _lines.clear();
                for(int i = 0; i < in.getCountLines(); i++)
                        addLine(in[i]);
                return *this;
        }

        Strings(Strings& in)
        {
                _lines.clear();
                for(int i = 0; i < in.getCountLines(); i++)
                        addLine(in[i]);
        }

        void clear()
        {
                _lines.clear();
        }

};
//---------------------------------------------------------------------------
class DigitStrings : public Strings
{

        public:

        DigitStrings() : Strings() {}
        ~DigitStrings() {}

        void addLine(string str, unsigned int cnt = 1)
        {
                string add = "";
                string digits = "0123456789";
                for(unsigned int i = 0; i < str.length(); i++)
                        if(digits.find(str[i]) != -1)
                                add = add + str[i];
                if(add.length() != 0)
                        for(unsigned int i = 0; i < cnt; i++)
                                _lines.push_back(add);
        }

        void addLine(AnsiString str1, unsigned int cnt = 1)
        {
                string str = str1.c_str();
                string add = "";
                string digits = "0123456789";
                for(unsigned int i = 0; i < str.length(); i++)
                        if(digits.find(str[i]) != -1)
                                add = add + str[i];
                if(add.length() != 0)
                        for(unsigned int i = 0; i < cnt; i++)
                                _lines.push_back(add);
        }

        DigitStrings(string str, unsigned int cnt = 1)
        {
                addLine(str, cnt);       
        }

        DigitStrings(DigitStrings& in)
        {
                _lines.clear();
                for(int i = 0; i < in.getCountLines(); i++)
                        addLine(in[i]);
        }

        DigitStrings& operator = (DigitStrings in)
        {
                _lines.clear();
                for(int i = 0; i < in.getCountLines(); i++)
                        addLine(in[i]);
                return *this;        
        }

};
//---------------------------------------------------------------------------
#endif
