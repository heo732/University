//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
#pragma resource "*.dfm"

#include "ClassVector.h"
//---------------------------------------------------------------------------
Tfrm *frm;

TVector V1, V2;
//---------------------------------------------------------------------------
__fastcall Tfrm::Tfrm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::FormCreate(TObject *Sender)
{
  V1.PrintToStg(stg1);
  V2.PrintToStg(stg2);
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnCnt1Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(edtCnt1->Text == "" || StrToInt(edtCnt1->Text) <= 0)
    ShowMessage("Вкажіть кількість елементів першого вектора (>0)");
  else{

    unsigned int cnt = StrToInt(edtCnt1->Text);
    TVector v(cnt);
    V1 = v;

    V1.PrintToStg(stg1);
    lblCnt1->Caption = "( " + IntToStr(V1.GetCntElements()) + " )";
    lblCntObjects->Caption = "Кількість об'єктів: " + IntToStr(V1.GetCntObjects());
  }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnCnt2Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(edtCnt2->Text == "" || StrToInt(edtCnt2->Text) <= 0)
    ShowMessage("Вкажіть кількість елементів другого вектора (>0)");
  else{

    unsigned int cnt = StrToInt(edtCnt2->Text);
    TVector v(cnt);
    V2 = v;

    V2.PrintToStg(stg2);
    lblCnt2->Caption = "( " + IntToStr(V2.GetCntElements()) + " )";
    lblCntObjects->Caption = "Кількість об'єктів: " + IntToStr(V1.GetCntObjects());
  }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnInitializeValue1Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(edtInitializeValue1->Text == "")
    ShowMessage("Заповніть поле \"Значення ініціалізації\" для першого вектора");
  else{

    TVector v(V1.GetCntElements(), StrToInt(edtInitializeValue1->Text));
    V1 = v;

    V1.PrintToStg(stg1);

    lblCntObjects->Caption = "Кількість об'єктів: " + IntToStr(V1.GetCntObjects());
  }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnInitializeValue2Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

   if(edtInitializeValue2->Text == "")
    ShowMessage("Заповніть поле \"Значення ініціалізації\" для другого вектора");
  else{

    TVector v(V2.GetCntElements(), StrToInt(edtInitializeValue2->Text));
    V2 = v;

    V2.PrintToStg(stg2);

    lblCntObjects->Caption = "Кількість об'єктів: " + IntToStr(V1.GetCntObjects());
  }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnRandomFilling1Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  V1.RandomFilling();
  V1.PrintToStg(stg1);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnRandomFilling2Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  V2.RandomFilling();
  V2.PrintToStg(stg2);
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnReadFromStg1Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(V1.ReadFromStg(stg1) == 1)
    ShowMessage("Заповніть першу таблицю повністю");
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnReadFromStg2Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(V2.ReadFromStg(stg2) == 1)
    ShowMessage("Заповніть другу таблицю повністю");
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnReadFromFile1Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(odl->Execute()){
    String fname = odl->FileName;

    if(V1.ReadFromFile(fname) == 1)
      ShowMessage("Файл не знайдено");
    else{
      lblFile1Name->Caption = fname;
      V1.PrintToStg(stg1);
    }
  }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnReadFromFile2Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(odl->Execute()){
    String fname = odl->FileName;

    if(V2.ReadFromFile(fname) == 1)
      ShowMessage("Файл не знайдено");
    else{
      lblFile2Name->Caption = fname;
      V2.PrintToStg(stg2);
    }
  }
}
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
//Операції над елементом вектора
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnAssignClick(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(edtElement->Text == "" || StrToInt(edtElement->Text) < 0)
    ShowMessage("Заповніть поле \"Елемент\" невід'ємним цілим числом");
  else
    if(edtValue->Text == "")
      ShowMessage("Заповніть поле \"Значення\" цілим числом");
    else{

      char vNum = rgVector1->ItemIndex + 1;
      TVector v;

      if(vNum == 1)
        v = V1;
      else
        v = V2;

      unsigned int element = StrToInt(edtElement->Text);
      short value = StrToInt(edtValue->Text);
      /////
      v.Assign(element, value);
      /////
      if(v.GetStan() == 1)
        ShowMessage("У векторі " + IntToStr(vNum) + " немає елемента з номером " + IntToStr(v.GetErrorPos()));
      else{

        if(vNum == 1)
          {V1 = v; V1.PrintToStg(stg1);}
        else
          {V2 = v; V2.PrintToStg(stg2);}

        edtResult1->Text = IntToStr(v.GetElValue(element));
      }
    }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnAddToElClick(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(edtElement->Text == "" || StrToInt(edtElement->Text) < 0)
    ShowMessage("Заповніть поле \"Елемент\" невід'ємним цілим числом");
  else
    if(edtValue->Text == "")
      ShowMessage("Заповніть поле \"Значення\" цілим числом");
    else{

      char vNum = rgVector1->ItemIndex + 1;
      TVector v;

      if(vNum == 1)
        v = V1;
      else
        v = V2;

      unsigned int element = StrToInt(edtElement->Text);
      short value = StrToInt(edtValue->Text);
      /////
      v.AddToEl(element, value);
      /////
      if(v.GetStan() == 1)
        ShowMessage("У векторі " + IntToStr(vNum) + " немає елемента з номером " + IntToStr(v.GetErrorPos()));
      else{

        if(vNum == 1)
          {V1 = v; V1.PrintToStg(stg1);}
        else
          {V2 = v; V2.PrintToStg(stg2);}

        edtResult1->Text = IntToStr(v.GetElValue(element));
      }
    }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnSubFromElClick(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(edtElement->Text == "" || StrToInt(edtElement->Text) < 0)
    ShowMessage("Заповніть поле \"Елемент\" невід'ємним цілим числом");
  else
    if(edtValue->Text == "")
      ShowMessage("Заповніть поле \"Значення\" цілим числом");
    else{

      char vNum = rgVector1->ItemIndex + 1;
      TVector v;

      if(vNum == 1)
        v = V1;
      else
        v = V2;

      unsigned int element = StrToInt(edtElement->Text);
      short value = StrToInt(edtValue->Text);
      /////
      v.SubFromEl(element, value);
      /////
      if(v.GetStan() == 1)
        ShowMessage("У векторі " + IntToStr(vNum) + " немає елемента з номером " + IntToStr(v.GetErrorPos()));
      else{

        if(vNum == 1)
          {V1 = v; V1.PrintToStg(stg1);}
        else
          {V2 = v; V2.PrintToStg(stg2);}

        edtResult1->Text = IntToStr(v.GetElValue(element));
      }
    }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnMultElClick(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(edtElement->Text == "" || StrToInt(edtElement->Text) < 0)
    ShowMessage("Заповніть поле \"Елемент\" невід'ємним цілим числом");
  else
    if(edtValue->Text == "")
      ShowMessage("Заповніть поле \"Значення\" цілим числом");
    else{

      char vNum = rgVector1->ItemIndex + 1;
      TVector v;

      if(vNum == 1)
        v = V1;
      else
        v = V2;

      unsigned int element = StrToInt(edtElement->Text);
      short value = StrToInt(edtValue->Text);
      /////
      v.MultElOnValue(element, value);
      /////
      if(v.GetStan() == 1)
        ShowMessage("У векторі " + IntToStr(vNum) + " немає елемента з номером " + IntToStr(v.GetErrorPos()));
      else{

        if(vNum == 1)
          {V1 = v; V1.PrintToStg(stg1);}
        else
          {V2 = v; V2.PrintToStg(stg2);}

        edtResult1->Text = IntToStr(v.GetElValue(element));
      }
    }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnElMoreValueClick(TObject *Sender)
{
  edtResult1->Text = "";

  if(edtElement->Text == "" || StrToInt(edtElement->Text) < 0)
    ShowMessage("Заповніть поле \"Елемент\" невід'ємним цілим числом");
  else
    if(edtValue->Text == "")
      ShowMessage("Заповніть поле \"Значення\" цілим числом");
    else{

      char vNum = rgVector1->ItemIndex + 1;
      TVector v;

      if(vNum == 1)
        v = V1;
      else
        v = V2;

      unsigned int element = StrToInt(edtElement->Text);
      short value = StrToInt(edtValue->Text);
      /////
      bool res = v.ElMoreValue(element, value);
      /////
      if(v.GetStan() == 1)
        ShowMessage("У векторі " + IntToStr(vNum) + " немає елемента з номером " + IntToStr(v.GetErrorPos()));
      else{

        if(vNum == 1)
          {V1 = v; V1.PrintToStg(stg1);}
        else
          {V2 = v; V2.PrintToStg(stg2);}

        String resStr; if(res == 0)resStr="FALSE"; else resStr="TRUE";
        edtResult1->Text = resStr;
      }
    }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnElEqualValueClick(TObject *Sender)
{
  edtResult1->Text = "";

  if(edtElement->Text == "" || StrToInt(edtElement->Text) < 0)
    ShowMessage("Заповніть поле \"Елемент\" невід'ємним цілим числом");
  else
    if(edtValue->Text == "")
      ShowMessage("Заповніть поле \"Значення\" цілим числом");
    else{

      char vNum = rgVector1->ItemIndex + 1;
      TVector v;

      if(vNum == 1)
        v = V1;
      else
        v = V2;

      unsigned int element = StrToInt(edtElement->Text);
      short value = StrToInt(edtValue->Text);
      /////
      bool res = v.ElEqualValue(element, value);
      /////
      if(v.GetStan() == 1)
        ShowMessage("У векторі " + IntToStr(vNum) + " немає елемента з номером " + IntToStr(v.GetErrorPos()));
      else{

        if(vNum == 1)
          {V1 = v; V1.PrintToStg(stg1);}
        else
          {V2 = v; V2.PrintToStg(stg2);}

        String resStr; if(res == 0)resStr="FALSE"; else resStr="TRUE";
        edtResult1->Text = resStr;
      }
    }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnElNotEqualValueClick(TObject *Sender)
{
  edtResult1->Text = "";

  if(edtElement->Text == "" || StrToInt(edtElement->Text) < 0)
    ShowMessage("Заповніть поле \"Елемент\" невід'ємним цілим числом");
  else
    if(edtValue->Text == "")
      ShowMessage("Заповніть поле \"Значення\" цілим числом");
    else{

      char vNum = rgVector1->ItemIndex + 1;
      TVector v;

      if(vNum == 1)
        v = V1;
      else
        v = V2;

      unsigned int element = StrToInt(edtElement->Text);
      short value = StrToInt(edtValue->Text);
      /////
      bool res = v.ElNotEqualValue(element, value);
      /////
      if(v.GetStan() == 1)
        ShowMessage("У векторі " + IntToStr(vNum) + " немає елемента з номером " + IntToStr(v.GetErrorPos()));
      else{

        if(vNum == 1)
          {V1 = v; V1.PrintToStg(stg1);}
        else
          {V2 = v; V2.PrintToStg(stg2);}

        String resStr; if(res == 0)resStr="FALSE"; else resStr="TRUE";
        edtResult1->Text = resStr;
      }
    }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::rgVector1Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::edtElementChange(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::edtValueChange(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";
}
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
//Операції над векторами
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
void __fastcall Tfrm::rgVector2Click(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnAddVectorClick(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  TVector v_1, v_2;
  char vNum = rgVector2->ItemIndex;
  if(vNum == 0){
    v_1 = V1;
    v_2 = V2;
  }
  else{
    v_1 = V2;
    v_2 = V1;
  }

  /////
  v_1.AddVector(&v_2);
  /////

  if(v_1.GetStan() == 2)
    ShowMessage("Розміри векторів несумісні");

  else{

    if(vNum == 0){
      V1 = v_1;
      V1.PrintToStg(stg1);
    }
    else{
      V2 = v_1;
      V2.PrintToStg(stg2);
    }

  }

}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnSubVectorClick(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  TVector v_1, v_2;
  char vNum = rgVector2->ItemIndex;
  if(vNum == 0){
    v_1 = V1;
    v_2 = V2;
  }
  else{
    v_1 = V2;
    v_2 = V1;
  }

  /////
  v_1.SubVector(&v_2);
  /////

  if(v_1.GetStan() == 2)
    ShowMessage("Розміри векторів несумісні");

  else{

    if(vNum == 0){
      V1 = v_1;
      V1.PrintToStg(stg1);
    }
    else{
      V2 = v_1;
      V2.PrintToStg(stg2);
    }

  }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnMultVectorClick(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  TVector v_1, v_2;
  char vNum = rgVector2->ItemIndex;
  if(vNum == 0){
    v_1 = V1;
    v_2 = V2;
  }
  else{
    v_1 = V2;
    v_2 = V1;
  }

  /////
  v_1.MultVector(&v_2);
  /////

  if(v_1.GetStan() == 2)
    ShowMessage("Розміри векторів несумісні");

  else{

    if(vNum == 0){
      V1 = v_1;
      V1.PrintToStg(stg1);
    }
    else{
      V2 = v_1;
      V2.PrintToStg(stg2);
    }

  }
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnMultVectorOnValueClick(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  TVector v_1;
  char vNum = rgVector2->ItemIndex;
  if(vNum == 0)
    v_1 = V1;
  else
    v_1 = V2;

  unsigned char value;
  if(edtValue2->Text == "")
    ShowMessage("Заповніть поле числа множення");
  else{

    value = StrToInt(edtValue2->Text);

    /////
    v_1.MultVectorOnValue(value);
    /////



    if(vNum == 0){
      V1 = v_1;
      V1.PrintToStg(stg1);
    }
    else{
      V2 = v_1;
      V2.PrintToStg(stg2);
    }


  }
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnMultVectors_ScalarClick(TObject *Sender)
{
  edtResult2->Text = "";

  /////
  int res = V1.MultVectors_Scalar(&V2);
  /////

  if(V1.GetStan() == 2)
    ShowMessage("Розміри векторів несумісні");

  else{
    edtResult2->Text = IntToStr(res);
  }
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnVectorAssignVectorClick(TObject *Sender)
{
  edtResult1->Text = "";
  edtResult2->Text = "";

  if(rgVector2->ItemIndex == 0){
    V1 = V2;
    V1.PrintToStg(stg1);
    lblCnt1->Caption = "( " + IntToStr(V1.GetCntElements()) + " )";
  }
  else{
    V2 = V1;
    V2.PrintToStg(stg2);
    lblCnt2->Caption = "( " + IntToStr(V2.GetCntElements()) + " )";
  }
}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnVectorMoreVectorClick(TObject *Sender)
{
  edtResult2->Text = "";

  TVector v_1, v_2;
  if(rgVector2->ItemIndex == 0){
    v_1 = V1;
    v_2 = V2;
  }
  else{
    v_1 = V2;
    v_2 = V1;
  }

  /////
  bool res = v_1.VectorMoreVector(&v_2);
  /////

  if(v_1.GetStan() == 2)
    ShowMessage("Розміри векторів несумісні");
  else
    if(res == TRUE)
      edtResult2->Text = "TRUE";
    else
      edtResult2->Text = "FALSE";

}
//---------------------------------------------------------------------------
void __fastcall Tfrm::btnVectorEqualVectorClick(TObject *Sender)
{
  edtResult2->Text = "";

  TVector v_1, v_2;
  if(rgVector2->ItemIndex == 0){
    v_1 = V1;
    v_2 = V2;
  }
  else{
    v_1 = V2;
    v_2 = V1;
  }

  /////
  bool res = v_1.VectorEqualVector(&v_2);
  /////

  if(v_1.GetStan() == 2)
    ShowMessage("Розміри векторів несумісні");
  else
    if(res == TRUE)
      edtResult2->Text = "TRUE";
    else
      edtResult2->Text = "FALSE";
}
//---------------------------------------------------------------------------

void __fastcall Tfrm::btnVectorNotEqualVectorClick(TObject *Sender)
{
  edtResult2->Text = "";

  TVector v_1, v_2;
  if(rgVector2->ItemIndex == 0){
    v_1 = V1;
    v_2 = V2;
  }
  else{
    v_1 = V2;
    v_2 = V1;
  }

  /////
  bool res = v_1.VectorNotEqualVector(&v_2);
  /////

  if(v_1.GetStan() == 2)
    ShowMessage("Розміри векторів несумісні");
  else
    if(res == TRUE)
      edtResult2->Text = "TRUE";
    else
      edtResult2->Text = "FALSE";
}
//---------------------------------------------------------------------------

