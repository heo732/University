//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------------
USEFORM("unitMain.cpp", formMain);
USEFORM("unitFormTask1.cpp", formTask1);
USEFORM("unitFormTask2.cpp", formTask2);
USEFORM("unitFormTask3.cpp", formTask3);
USEFORM("unitFormTask4.cpp", formTask4);
USEFORM("unitFormTask5.cpp", formTask5);
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TformMain), &formMain);
                 Application->CreateForm(__classid(TformTask1), &formTask1);
                 Application->CreateForm(__classid(TformTask2), &formTask2);
                 Application->CreateForm(__classid(TformTask3), &formTask3);
                 Application->CreateForm(__classid(TformTask4), &formTask4);
                 Application->CreateForm(__classid(TformTask5), &formTask5);
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
