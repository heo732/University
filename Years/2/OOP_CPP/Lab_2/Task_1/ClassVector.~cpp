//---------------------------------------------------------------------------
#pragma hdrstop
#include "ClassVector.h"
#pragma package(smart_init)
#include <time.h>
#include <fstream>
#include <iostream>
using namespace std;
//---------------------------------------------------------------------------
unsigned int TVector::cntObjects = 0;
//---------------------------------------------------------------------------
TVector::TVector(){
  pointer = new short;
  pointer[0] = 0;

  cntElements = 1;

  stan = 0;

  cntObjects++;
}
//---------------------------------------------------------------------------
TVector::TVector(unsigned int size){
  pointer = new short[size];
  for(unsigned int i=0; i<size; i++)
    pointer[i] = 0;

  cntElements = size;

  stan = 0;

  cntObjects++;
}
//---------------------------------------------------------------------------
TVector::TVector(unsigned int size, short value){
  pointer = new short[size];
  for(unsigned int i=0; i<size; i++)
    pointer[i] = value;

  cntElements = size;

  stan = 0;

  cntObjects++;
}
//---------------------------------------------------------------------------
TVector::~TVector(){
  if(pointer != NULL)
    delete pointer;
  pointer = NULL;
}
//---------------------------------------------------------------------------
void TVector::Assign(unsigned int pos=0, short value=1){
  if(pos > cntElements-1){ //Помилка. Вихід за межі масиву
    stan = 1;
    ErrorPos = pos;
  }
  else{
    pointer[pos] = value;
    stan = 0;
  }
}
//---------------------------------------------------------------------------
short TVector::GetElValue(unsigned int pos){
  if(pos > cntElements-1){ //Помилка. Вихід за межі масиву
    stan = 1;
    return pos;
  }
  else{
    stan = 0;
    return pointer[pos];
  }
}
//---------------------------------------------------------------------------
unsigned int TVector::GetCntElements() const{
  return cntElements;
}
//---------------------------------------------------------------------------
unsigned int TVector::GetCntObjects() const{
  return cntObjects;
}
//---------------------------------------------------------------------------
char TVector::GetStan() const{
  return stan;
}
//---------------------------------------------------------------------------
unsigned int TVector::GetErrorPos() const{
  return ErrorPos;
}
//---------------------------------------------------------------------------
void TVector::PrintToStg(TStringGrid *&stg) const{
  stg->RowCount = cntElements;
  stg->ColCount = 2;
  stg->FixedRows = 0;
  stg->FixedCols = 1;
  for(unsigned int i=0; i<cntElements; i++){
    stg->Cells[0][i] = IntToStr(i);
    stg->Cells[1][i] = IntToStr(pointer[i]);
  }
}
//---------------------------------------------------------------------------
void TVector::AddToEl(unsigned int pos, short value){
  if(pos > cntElements-1){ //Помилка. Вихід за межі масиву
    stan = 1;
    ErrorPos = pos;
  }
  else{
    pointer[pos] += value;
    stan = 0;
  }
}
//---------------------------------------------------------------------------
void TVector::SubFromEl(unsigned int pos, short value){
  if(pos > cntElements-1){ //Помилка. Вихід за межі масиву
    stan = 1;
    ErrorPos = pos;
  }
  else{
    pointer[pos] -= value;
    stan = 0;
  }
}
//---------------------------------------------------------------------------
void TVector::MultElOnValue(unsigned int pos, unsigned char value){
  if(pos > cntElements-1){ //Помилка. Вихід за межі масиву
    stan = 1;
    ErrorPos = pos;
  }
  else{
    pointer[pos] *= value;
    stan = 0;
  }
}
//---------------------------------------------------------------------------
bool TVector::ElMoreValue(unsigned int pos, short value){
  if(pos > cntElements-1){ //Помилка. Вихід за межі масиву
    stan = 1;
    ErrorPos = pos;
    return false;
  }
  else
    if(pointer[pos] > value){
      stan = 0;
      return true;
    }
    else{
      stan = 0;
      return false;
    }
}
//---------------------------------------------------------------------------
bool TVector::ElEqualValue(unsigned int pos, short value){
  if(pos > cntElements-1){ //Помилка. Вихід за межі масиву
    stan = 1;
    ErrorPos = pos;
    return false;
  }
  else
    if(pointer[pos] == value){
      stan = 0;
      return true;
    }
    else{
      stan = 0;
      return false;
    }
}
//---------------------------------------------------------------------------
bool TVector::ElNotEqualValue(unsigned int pos, short value){
  if(pos > cntElements-1){ //Помилка. Вихід за межі масиву
    stan = 1;
    ErrorPos = pos;
    return false;
  }
  else
    if(pointer[pos] != value){
      stan = 0;
      return true;
    }
    else{
      stan = 0;
      return false;
    }
}
//---------------------------------------------------------------------------
void TVector::AddVector(TVector *in){
  if(cntElements != in->GetCntElements()){
    stan = 2;
  }
  else{
    for(unsigned int i=0; i<cntElements; i++)
      pointer[i] += in->GetElValue(i);
    stan = 0;
  }
}
//---------------------------------------------------------------------------
void TVector::SubVector(TVector *in){
  if(cntElements != in->GetCntElements()){
    stan = 2;
  }
  else{
    for(unsigned int i=0; i<cntElements; i++)
      pointer[i] -= in->GetElValue(i);
    stan = 0;
  }
}
//---------------------------------------------------------------------------
void TVector::MultVector(TVector *in){
  if(cntElements != in->GetCntElements()){
    stan = 2;
  }
  else{
    for(unsigned int i=0; i<cntElements; i++)
      pointer[i] *= in->GetElValue(i);
    stan = 0;
  }
}
//---------------------------------------------------------------------------
int TVector::MultVectors_Scalar(TVector *in){
  if(cntElements != in->GetCntElements()){
    stan = 2; //несумісні розміри векторів
    return 0;
  }
  else{
    int res = 0;
    for(unsigned int i=0; i<cntElements; i++)
      res += pointer[i] * in->GetElValue(i);
    stan = 0;
    return res;
  }
}
//---------------------------------------------------------------------------
void TVector::MultVectorOnValue(unsigned char value){
  for(unsigned int i=0; i<cntElements; i++)
    pointer[i] *= value;
}
//---------------------------------------------------------------------------
//Чи всі елементи цього вектора більші за відповідні елементи вектора-параметра (T/F)
//Якщо False, то в ErrorPos номер першої пари що (x1>x2)->false
bool TVector::VectorMoreVector(TVector *in){
  if(cntElements != in->GetCntElements()){
    stan = 2; //несумісні розміри векторів
    return false;
  }
  else{
    for(unsigned int i=0; i<cntElements; i++)
      if(pointer[i] <= in->GetElValue(i)){
        ErrorPos = i;
        stan = 0;
        return false;
      }
    stan = 0;
    return true;
  }
}
//---------------------------------------------------------------------------
//Чи всі елементи цього вектора рівні відповідним елементам вектора-параметра (T/F)
//Якщо False, то в ErrorPos номер першої пари що (x1==x2)->false
bool TVector::VectorEqualVector(TVector *in){
  if(cntElements != in->GetCntElements()){
    stan = 2; //несумісні розміри векторів
    return false;
  }
  else{
    for(unsigned int i=0; i<cntElements; i++)
      if(pointer[i] <= in->GetElValue(i)){
        ErrorPos = i;
        stan = 0;
        return false;
      }
    stan = 0;
    return true;
  }
}
//---------------------------------------------------------------------------
//Чи всі елементи цього вектора нерівні відповідним елементам вектора-параметра (T/F)
//Якщо False, то в ErrorPos номер першої пари що (x1!=x2)->false
bool TVector::VectorNotEqualVector(TVector *in){
  if(cntElements != in->GetCntElements()){
    stan = 2; //несумісні розміри векторів
    return false;
  }
  else{
    for(unsigned int i=0; i<cntElements; i++)
      if(pointer[i] <= in->GetElValue(i)){
        ErrorPos = i;
        stan = 0;
        return false;
      }
    stan = 0;
    return true;
  }
}
//---------------------------------------------------------------------------
//0 - good, 1 - таблиця не заповнена повністю
char TVector::ReadFromStg(TStringGrid *stg){

  for(int i=0; i<stg->RowCount; i++)
    if(stg->Cells[1][i] == "")
      return 1;
    else
      pointer[i] = StrToInt(stg->Cells[1][i]);

  return 0;
}
//---------------------------------------------------------------------------
short RandomShortValue(){

  short value = (rand() % 200) - 100;

  return value;
}
//---------------------------------------------------------------------------
void TVector::RandomFilling(){

  srand(time(0));

  for(unsigned int i=0; i<cntElements; i++)
    pointer[i] = RandomShortValue();
}
//---------------------------------------------------------------------------
//0 - good, 1 - file not is open
char TVector::ReadFromFile(String FileName){

  ifstream file(FileName.c_str());

  if(!file.is_open()) //якщо файл не відкрито
    return 1;
  else{

    for(unsigned int i=0; i<cntElements; i++)
      file>>pointer[i];
    file.close();

    return 0;

  }
}
//--------------------------------------------------------------------------
TVector& TVector::operator = (const TVector& in){

      this->~TVector();

      cntElements = in.GetCntElements();
      pointer = new short[cntElements];

      for(unsigned int i=0; i<cntElements; i++)
        pointer[i] = in.GetElValue(i);

      return *this;  
    };
//--------------------------------------------------------------------------
