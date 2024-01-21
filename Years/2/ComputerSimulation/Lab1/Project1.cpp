//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------------
USEFORM("unitFormMain.cpp", formMain);
USEFORM("unitFormTask1.cpp", formTask1);
USEFORM("unitFormExample1.cpp", formExample1);
USEFORM("unitFormExample2.cpp", formExample2);
USEFORM("unitFormExample3.cpp", formExample3);
USEFORM("unitFormExample4.cpp", formExample4);
USEFORM("unitFormExample5.cpp", formExample5);
USEFORM("unitFormExample6.cpp", formExample6);
USEFORM("unitFormExample7.cpp", formExample7);
USEFORM("unitFormExample8.cpp", formExample8);
USEFORM("unitFormTask2.cpp", formTask2);
USEFORM("unitFormTask3.cpp", formTask3);
USEFORM("unitFormTask4.cpp", formTask4);
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TformMain), &formMain);
                 Application->CreateForm(__classid(TformTask1), &formTask1);
                 Application->CreateForm(__classid(TformExample1), &formExample1);
                 Application->CreateForm(__classid(TformExample2), &formExample2);
                 Application->CreateForm(__classid(TformExample3), &formExample3);
                 Application->CreateForm(__classid(TformExample4), &formExample4);
                 Application->CreateForm(__classid(TformExample5), &formExample5);
                 Application->CreateForm(__classid(TformExample6), &formExample6);
                 Application->CreateForm(__classid(TformExample7), &formExample7);
                 Application->CreateForm(__classid(TformExample8), &formExample8);
                 Application->CreateForm(__classid(TformTask2), &formTask2);
                 Application->CreateForm(__classid(TformTask3), &formTask3);
                 Application->CreateForm(__classid(TformTask4), &formTask4);
                 Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        catch (...)
        {
                 try
                 {
                         throw Exception("");
                 }
                 catch (Exception &exception)
                 {
                         Application->ShowException(&exception);
                 }
        }
        return 0;
}
//---------------------------------------------------------------------------