#include <iostream>
#include <fstream>
#include <string>

using namespace std;
//---------------------------------------------------------------------------
class Game
{
        private:

        char _map[16][16];
        bool _gameIsOver;

        bool isGameOver()
        {
                for(short i = 0; i < 16; i++)
                        for(short j = 0; j < 16; j++)
                                if(_map[i+3][j+3] == '#')
                                        return false;
                return true;                        
        }

        bool isDead(unsigned short row, unsigned short col)
        {
                if(_map[row][col] == '.' && )
        }

        public:

        Game(char* map)
        {
                _gameIsOver = false;

                for(short i = 0; i < 16; i++)
                        for(short j = 0; j < 16; j++)
                                _map[i][j] = '.';

                for(short i = 0; i < 10; i++)
                        for(short j = 0; j < 10; j++)
                                _map[i+3][j+3] = *(map+i*10+j);
        }

        string doHit(unsigned short row, char coloumn)
        {
                if(_gameIsOver)
                        return "GAME OVER";

                row--;
                unsigned short col = 0;
                switch(coloumn)
                {
                        case 'a':{col = 0; break;}
                        case 'b':{col = 1; break;}
                        case 'c':{col = 2; break;}
                        case 'd':{col = 3; break;}
                        case 'e':{col = 4; break;}
                        case 'f':{col = 5; break;}
                        case 'g':{col = 6; break;}
                        case 'h':{col = 7; break;}
                        case 'i':{col = 8; break;}
                        case 'k':{col = 9; break;}
                }

                if(_map[row][col] == '.')
                        return "MISS";

                _map[row][col] = '.';

                if(isGameOver())
                {
                        _gameIsOver = true;
                        return "GAME OVER";
                }
                if(isDead(row, col))
                        return "DEAD";


                return "HIT";
        }

};
//---------------------------------------------------------------------------
int main()
{
        char map[10][10];

        unsigned short N = 0;

        ifstream inFile("input.txt");

        for(short i = 0; i < 10; i++)
                for(short j = 0; j < 10; j++)
                        inFile >> map[i][j];

        Game game(map[0]);

        inFile >> N;

        unsigned int n = 0;
        bool over = false;
        ofstream outFile("output.txt");
        
        while(n < N && over == false)
        {
                unsigned short row = 0;
                char col = 'a';
                inFile >> row >> col;
                string hitResult = game.doHit(row, col);
                outFile << hitResult << endl;
                if(hitResult == "GAME OVER")
                        over = true;
                n++;        
        }

        inFile.close();
        outFile.close();
        return 0;
}
//---------------------------------------------------------------------------
