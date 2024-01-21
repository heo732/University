//---------------------------------------------------------------------------
#ifndef LMH
#define LMH
//---------------------------------------------------------------------------
#include <string>
#include <vector>
#include <Classes.hpp>
using namespace std;
//---------------------------------------------------------------------------
string AnsiToString(AnsiString in)
{
        return in.c_str();
}
//---------------------------------------------------------------------------
AnsiString StringToAnsi(string in)
{
        return in.c_str();
}
//---------------------------------------------------------------------------
class LM
{
        private:

        int _countOfPossibleStates;
        vector<string> _possibleStates;
        string _startState;
        vector< vector<double> > _matrixOfProbabilities;
        int _countGeneration;

        public:

        ~LM() {}

        LM(int countOfPossibleStates, vector<string> possibleStates, string startState, vector< vector<double> > matrixOfProbabilities, int countGeneration)
        {
                _countOfPossibleStates = countOfPossibleStates;

                _possibleStates.clear();
                for(int i = 0; i < _countOfPossibleStates; i++)
                        _possibleStates.push_back(possibleStates[i]);

                _startState = startState;

                _matrixOfProbabilities.clear();
                _matrixOfProbabilities.resize(_countOfPossibleStates);
                for(int i = 0; i < _countOfPossibleStates; i++)
                        for(int j = 0; j < _countOfPossibleStates; j++)
                                _matrixOfProbabilities.operator [](i).push_back(matrixOfProbabilities[i][j]);

                _countGeneration = countGeneration;                 
        }

        string generate(vector<string>& arrayResult)
        {       
                bool flag = true;
                for(int i = 0; i < _countOfPossibleStates; i++)
                        if(_possibleStates[i] == _startState)
                                flag = false;
                if(flag)
                        return "Incorrect start state. No matches in array of possible states.";

                for(int i = 0; i < _countOfPossibleStates; i++)
                {
                        double sum = 0;
                        for(int j = 0; j < _countOfPossibleStates; j++)
                                sum += _matrixOfProbabilities[i][j];
                        if(sum != 1)
                                return "Incorrect row[" +  AnsiToString(IntToStr(i)) + "] in Matrix of probabilities. Sum elements of this row not equal 1.";
                }

                for(int i = 0; i < _countOfPossibleStates-1; i++)
                {
                        for(int j = i+1; j < _countOfPossibleStates; j++)
                        {
                                flag = false;
                                if(_possibleStates[i] == _possibleStates[j])
                                        flag = true;
                        }
                        if(flag)
                                return "There is a repetition in array of possible states.";
                }

                string currentState = _startState;
                arrayResult.clear();
                arrayResult.push_back(_startState);

                

                for(int i = 1; i <= _countGeneration; i++)
                {
                        int rowIndexOfCurrentState;
                        for(int j = 0; j < _countOfPossibleStates; j++)
                                if(_possibleStates[j] == currentState)
                                        rowIndexOfCurrentState = j;

                        int colIndex = 0;
                        double sum = 0;
                        double z = (double)rand() / (double)RAND_MAX;
                        while(sum < z)
                        {
                                sum += _matrixOfProbabilities[rowIndexOfCurrentState][colIndex];
                                colIndex++;
                        }
                        colIndex--;

                        currentState = _possibleStates[colIndex];
                        arrayResult.push_back(currentState);
                }

                return "";
        }
};
//---------------------------------------------------------------------------
#endif
