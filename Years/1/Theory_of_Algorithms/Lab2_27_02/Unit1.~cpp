//---------------------------------------------------------------------------
#include <iostream>
//#include <fstream>
#include <cstring>
#include <conio.h>
#include <cctype.h>
//#include <string>
using namespace std;
//---------------------------------------------------------------------------

const int LEN=0x50;
int main()
{
 char s1[LEN],s2[LEN],*i;
 int count;

 
   cout << "Vvedit ryadok S1: ";
   cin.getline(s1,LEN);
   cout << "\nVvedit ryadok S2: ";
   cin.getline(s2,LEN);

   count=0;
   if(strcmp(s1,s2)==0)
        cout<<endl<<"Kilkist vhodzhen: 1"<<endl;
   else
        if((strcmp(s1,s2)!=0)&&((strlen(s1)==strlen(s2))))
                cout<<endl<<"Kilkist vhodzhen: 0"<<endl;
        else
                if(strlen(s2)>strlen(s1))
                        cout<<endl<<"Kilkist vhodzhen: 0"<<endl;
                else
                        if(((s2[0]!=' ')&&(s2[1]==' '))||((s2[0]==' ')&&(s2[1]!=' ')))
                                cout<<endl<<"Ne vvodit porozhnij r9dok,\na takozh propysk pered i pisl9 odnoho symvolu!"<<endl;
                        else
                                if(!(strstr(s1,s2)))
                                        cout<<endl<<"Kilkist vhodzhen: 0"<<endl;
                                else
                                {
                                i=strstr(s1,s2)+strlen(s2);
                                while(strstr(i,s2))
                                {
                                i=strstr(i,s2)+strlen(s2);
                                count++;
                                }
                                cout<<endl<<"Kilkist vhodzhen: "<<count+1<<endl;
                                }


getch();
return 0;
}
//---------------------------------------------------------------------------

