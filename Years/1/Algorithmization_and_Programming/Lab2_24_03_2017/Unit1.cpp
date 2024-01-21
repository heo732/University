//---------------------------------------------------------------------------
#pragma argsused
#include <clx.h>
#pragma hdrstop
#include <iostream.h>
#include <conio.h>  
#define LEN 100
//---------------------------------------------------------------------------
bool IsNum(char b)
{
if((b=='0')||(b=='1')||(b=='2')
||(b=='3')||(b=='4')||(b=='5')||(b=='6')
||(b=='7')||(b=='8')||(b=='9'))
        return 1;
else
        return 0;        
}

bool IsPunct(char a,int j,char s[])
{
bool q=0;
char p[]=",.:;!?";
int z;
if((a=='-')&&(s[j-1]!='0')&&(s[j-1]!='1')&&(s[j-1]!='2')
&&(s[j-1]!='3')&&(s[j-1]!='4')&&(s[j-1]!='5')&&(s[j-1]!='6')
&&(s[j-1]!='7')&&(s[j-1]!='8')&&(s[j-1]!='9')
&&(s[j+1]!='0')&&(s[j+1]!='1')&&(s[j+1]!='2')
&&(s[j+1]!='3')&&(s[j+1]!='4')&&(s[j+1]!='5')&&(s[j+1]!='6')
&&(s[j+1]!='7')&&(s[j+1]!='8')&&(s[j+1]!='9'))
        q=1;
else
        for(z=0;z<strlen(p);z++)
                if(p[z]==a)
                        q=1;

return q;
}

bool IsMath(char a,int j,char s[])
{
bool q=0;
char p[]="+*/=";
int z;
if((a=='-')&&(IsNum(s[j-1]))&&(IsNum(s[j+1])))
        q=1;
else
        for(z=0;z<strlen(p);z++)
                if(p[z]==a)
                        q=1;
return q;
}

int main(int argc, char* argv[])
{
char s[LEN];
int i;

printf("Input Text: ");
gets(s);
printf("New Text:   ");

for(i=0;i<strlen(s);i++)
{
if(IsPunct(s[i],i,s))
       { printf("*"); continue; }

if(IsMath(s[i],i,s))
       { printf("O"); continue; }

printf("%c",s[i]);
}
printf("\n");
getch();
return 0;
}
//---------------------------------------------------------------------------
 