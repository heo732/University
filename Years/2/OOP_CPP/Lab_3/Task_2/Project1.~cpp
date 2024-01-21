//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------------
USEFORM("UMain.cpp", FormMain);
USEFORM("UResult.cpp", FormResult);
USEFORM("USize.cpp", FormSize);
USEFORM("URead.cpp", FormRead);
USEFORM("UClear.cpp", FormClear);
USEFORM("UMultiply.cpp", FormMultiply);
USEFORM("UInitializeValue.cpp", FormInitializeValue);
USEFORM("UMultOnValue.cpp", FormMultOnValue);
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TFormMain), &FormMain);
                 Application->CreateForm(__classid(TFormResult), &FormResult);
                 Application->CreateForm(__classid(TFormSize), &FormSize);
                 Application->CreateForm(__classid(TFormRead), &FormRead);
                 Application->CreateForm(__classid(TFormClear), &FormClear);
                 Application->CreateForm(__classid(TFormMultiply), &FormMultiply);
                 Application->CreateForm(__classid(TFormInitializeValue), &FormInitializeValue);
                 Application->CreateForm(__classid(TFormMultOnValue), &FormMultOnValue);
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
