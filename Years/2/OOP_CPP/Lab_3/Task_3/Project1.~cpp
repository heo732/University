//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------------
USEFORM("UMain.cpp", Form_Main);
USEFORM("UAdd.cpp", Form_Add);
USEFORM("URemove.cpp", Form_Remove);
USEFORM("URemoveConfirm.cpp", Form_RemoveConfirm);
USEFORM("UBackup.cpp", Form_Backup);
USEFORM("UBackupConfirm.cpp", Form_BackupConfirm);
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
        try
        {
                 Application->Initialize();
                 Application->CreateForm(__classid(TForm_Main), &Form_Main);
                 Application->CreateForm(__classid(TForm_Add), &Form_Add);
                 Application->CreateForm(__classid(TForm_Remove), &Form_Remove);
                 Application->CreateForm(__classid(TForm_RemoveConfirm), &Form_RemoveConfirm);
                 Application->CreateForm(__classid(TForm_Backup), &Form_Backup);
                 Application->CreateForm(__classid(TForm_BackupConfirm), &Form_BackupConfirm);
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
