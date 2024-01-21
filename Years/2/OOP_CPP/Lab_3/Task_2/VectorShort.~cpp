//---------------------------------------------------------------------------
#pragma hdrstop
#include "VectorShort.h"
#pragma package(smart_init)
#include <time.h>
//---------------------------------------------------------------------------
unsigned int VectorShort::cntObjects = 0;
//---------------------------------------------------------------------------
VectorShort::VectorShort(){
  elements = new short;
  elements[0] = 0;

  size = 1;
  codeError = 0;
  cntObjects++;
}
//---------------------------------------------------------------------------
VectorShort::VectorShort(unsigned int s){
  size = s;

  elements = new short[size];
  for(unsigned int i=0; i<size; i++)
    elements[i] = 0;

  codeError = 0;
  cntObjects++;
}
//---------------------------------------------------------------------------
VectorShort::VectorShort(unsigned int s, short value){
  size = s;

  elements = new short[size];
  for(unsigned int i=0; i<size; i++)
    elements[i] = value;

  codeError = 0;
  cntObjects++;
}
//---------------------------------------------------------------------------
VectorShort::VectorShort(VectorShort& a){
  size = a.size;

  elements = new short[size];
  for(unsigned int i=0; i<size; i++)
    elements[i] = a.elements[i];

  codeError = 0;
  cntObjects++;
}
//---------------------------------------------------------------------------
VectorShort::~VectorShort(){
  if(elements != NULL){
    delete elements;
    elements = NULL;
  }
}
//---------------------------------------------------------------------------
unsigned int VectorShort::GetSize(){
  return size;
}
//---------------------------------------------------------------------------
unsigned int VectorShort::GetCntObjects(){
  return cntObjects;
}
//---------------------------------------------------------------------------
char VectorShort::GetCodeError(){
  return codeError;
}
//---------------------------------------------------------------------------
void VectorShort::PrintToStg(TStringGrid*& stg){
  stg->RowCount = size;
  stg->ColCount = 2;
  stg->FixedRows = 0;
  stg->FixedCols = 1;
  for(unsigned int i=0; i<size; i++){
    stg->Cells[0][i] = IntToStr(i+1);
    stg->Cells[1][i] = IntToStr(elements[i]);
  }
}
//---------------------------------------------------------------------------
//1 - good, 0 - таблиця заповнена некоректно
bool VectorShort::ReadFromStg(TStringGrid* stg){
  size = stg->RowCount;

  if(elements != NULL){
    delete elements;
    elements = NULL;
  }
  elements = new short[size];

  int tmp;
  for(unsigned int i=0; i<size; i++)
    if(!(TryStrToInt(stg->Cells[1][i], tmp))){
      ShowMessage("Заповніть таблицю коректно");
      return false;
    }
    else
      elements[i] = StrToInt(stg->Cells[1][i]);

  return true;
}
//---------------------------------------------------------------------------
short RandomShortValue(){

  short value = (rand() % 200) - 100;

  return value;
}
//---------------------------------------------------------------------------
void VectorShort::RandomFilling(){

  srand(time(0));

  for(unsigned int i=0; i<size; i++)
    elements[i] = RandomShortValue();
}
//---------------------------------------------------------------------------
//1 - good, 0 - file is not open
bool VectorShort::ReadFromFile(String FileName){

  ifstream file(FileName.c_str());

  if(!file.is_open()) //якщо файл не відкрито
    return false;
  else{
    file >> *this;
    file.close();
    return true;
  }
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator ++ (){
  for(unsigned int i=0; i<size; i++) elements[i]++;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator -- (){
  for(unsigned int i=0; i<size; i++) elements[i]--;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator ++ (int){
  for(unsigned int i=0; i<size; i++) elements[i]++;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator -- (int){
  for(unsigned int i=0; i<size; i++) elements[i]--;
  return *this;
}
//--------------------------------------------------------------------------
bool VectorShort::operator ! (){
  if(size != 0) return true;
  else return false;
}
//--------------------------------------------------------------------------
VectorShort VectorShort::operator ~ (){
  VectorShort temp(*this);
  for(unsigned int i=0; i<size; i++) temp[i] = ~temp[i];
  return temp;
}
//--------------------------------------------------------------------------
VectorShort VectorShort::operator - (){
  VectorShort temp(*this);
  for(unsigned int i=0; i<size; i++) temp[i] = -temp[i];
  return temp;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator = (VectorShort in){
  if(elements != NULL){
    delete elements;
    elements = NULL;
  }
  size = in.size;
  elements = new short[size];

  for(unsigned int i=0; i<size; i++)
    elements[i] = in.elements[i];

  return *this;
}
//------------------- -------------------------------------------------------
VectorShort  VectorShort::operator + (VectorShort& a){
  VectorShort temp(*this);

  if(size != a.size){
    codeError = 2;
    return temp;
  }
  else{
    codeError = 0;
    for(unsigned int i=0; i<size; i++) temp[i] += a[i];
    return temp;
  }
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator + (short a){
  VectorShort temp(*this);
  for(unsigned int i=0; i<size; i++) temp[i] += a;
  return temp;                                   
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator - (VectorShort& a){
  VectorShort temp(*this);

  if(size != a.size){
    codeError = 2;
    return temp;
  }
  else{
    codeError = 0;
    for(unsigned int i=0; i<size; i++) temp[i] -= a[i];
    return temp;
  }
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator - (short a){
  VectorShort temp(*this);
  for(unsigned int i=0; i<size; i++) temp[i] -= a;
  return temp;                                   
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator * (VectorShort& a){
  VectorShort temp(*this);

  if(size != a.size){
    codeError = 2;
    return temp;
  }
  else{
    codeError = 0;
    for(unsigned int i=0; i<size; i++) temp[i] *= a[i];
    return temp;
  }
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator * (short a){
  VectorShort temp(*this);
  for(unsigned int i=0; i<size; i++) temp[i] *= a;
  return temp;
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator / (VectorShort& a){
  VectorShort temp(*this);

  if(size != a.size){
    codeError = 2;
    return temp;
  }
  else{
    codeError = 0;
    for(unsigned int i=0; i<size; i++) temp[i] /= a[i];
    return temp;
  }
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator / (short a){
  VectorShort temp(*this);
  for(unsigned int i=0; i<size; i++) temp[i] /= a;
  return temp;
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator % (VectorShort& a){
  VectorShort temp(*this);

  if(size != a.size){
    codeError = 2;
    return temp;
  }
  else{
    codeError = 0;
    for(unsigned int i=0; i<size; i++) temp[i] %= a[i];
    return temp;
  }
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator % (short a){
  VectorShort temp(*this);
  for(unsigned int i=0; i<size; i++) temp[i] %= a;
  return temp;
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator | (VectorShort& a){
  VectorShort temp(*this);

  if(size != a.size){
    codeError = 2;
    return temp;
  }
  else{
    codeError = 0;
    for(unsigned int i=0; i<size; i++) temp[i] |= a[i];
    return temp;
  }
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator | (short a){
  VectorShort temp(*this);
  for(unsigned int i=0; i<size; i++) temp[i] |= a;
  return temp;
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator ^ (VectorShort& a){
  VectorShort temp(*this);

  if(size != a.size){
    codeError = 2;
    return temp;
  }
  else{
    codeError = 0;
    for(unsigned int i=0; i<size; i++) temp[i] ^= a[i];
    return temp;
  }
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator ^ (short a){
  VectorShort temp(*this);
  for(unsigned int i=0; i<size; i++) temp[i] ^= a;
  return temp;
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator & (VectorShort& a){
  VectorShort temp(*this);

  if(size != a.size){
    codeError = 2;
    return temp;
  }
  else{
    codeError = 0;
    for(unsigned int i=0; i<size; i++) temp[i] &= a[i];
    return temp;
  }
}
//--------------------------------------------------------------------------
VectorShort  VectorShort::operator & (short a){
  VectorShort temp(*this);
  for(unsigned int i=0; i<size; i++) temp[i] &= a;
  return temp;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator += (VectorShort a){
  *this = *this + a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator += (short a){
  *this = *this + a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator -= (VectorShort a){
  *this = *this - a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator -= (short a){
  *this = *this - a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator *= (VectorShort a){
  *this = *this * a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator *= (short a){
  *this = *this * a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator /= (VectorShort a){
  *this = *this / a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator /= (short a){
  *this = *this / a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator %= (VectorShort a){
  *this = *this % a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator %= (short a){
  *this = *this % a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator |= (VectorShort a){
  *this = *this | a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator |= (short a){
  *this = *this | a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator ^= (VectorShort a){
  *this = *this ^ a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator ^= (short a){
  *this = *this ^ a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator &= (VectorShort a){
  *this = *this & a;
  return *this;
}
//--------------------------------------------------------------------------
VectorShort& VectorShort::operator &= (short a){
  *this = *this & a;
  return *this;
}
//--------------------------------------------------------------------------
istream& operator >> (istream& input, VectorShort& v){
  for(unsigned int i=0; i<v.GetSize(); i++) input >> v[i];
  return input;
}
//--------------------------------------------------------------------------
ostream& operator << (ostream& output, VectorShort& v){
  for(unsigned int i=0; i<v.GetSize(); i++) output << v[i] << "  ";
  return output;
}
//--------------------------------------------------------------------------
ifstream& operator >> (ifstream& finput, VectorShort& v){
  for(unsigned int i=0; i<v.GetSize(); i++) finput >> v[i];
  return finput;
}
//--------------------------------------------------------------------------
ofstream& operator << (ofstream& foutput, VectorShort& v){
  for(unsigned int i=0; i<v.GetSize(); i++) foutput << v[i] << "  ";
  return foutput;
}
//--------------------------------------------------------------------------
bool VectorShort::operator == (VectorShort& a){
  for(unsigned int i=0; i<size; i++)
    if(elements[i] != a[i])
      return false;
  return true;    
}
//--------------------------------------------------------------------------
bool VectorShort::operator != (VectorShort& a){
  for(unsigned int i=0; i<size; i++)
    if(elements[i] == a[i])
      return false;
  return true;
}
//--------------------------------------------------------------------------
bool VectorShort::operator > (VectorShort& a){
  for(unsigned int i=0; i<size; i++)
    if(elements[i] <= a[i])
      return false;
  return true;
}
//--------------------------------------------------------------------------
bool VectorShort::operator >= (VectorShort& a){
  for(unsigned int i=0; i<size; i++)
    if(elements[i] < a[i])
      return false;
  return true;
}
//--------------------------------------------------------------------------
bool VectorShort::operator < (VectorShort& a){
  for(unsigned int i=0; i<size; i++)
    if(elements[i] >= a[i])
      return false;
  return true;
}
//--------------------------------------------------------------------------
bool VectorShort::operator <= (VectorShort& a){
  for(unsigned int i=0; i<size; i++)
    if(elements[i] > a[i])
      return false;
  return true;
}
//--------------------------------------------------------------------------
short& VectorShort::operator [](unsigned int pos){
  if(pos >= size){
    codeError = 1;
    return elements[size-1];
  }
  else{
    codeError = 0;
    return elements[pos];
  }
}
//--------------------------------------------------------------------------
void* VectorShort::operator new(size_t s){
  void *ptr = malloc(s);
  return ptr;
}
//--------------------------------------------------------------------------
void* VectorShort::operator new[](size_t s){
  void *ptr = malloc(sizeof(VectorShort) * s);
  return ptr;
}
//--------------------------------------------------------------------------
void VectorShort::operator delete(void* v){
  if(v != NULL){
    free(v);
    v = NULL;
  }
}
//--------------------------------------------------------------------------
void VectorShort::operator delete[](void* v){
  if(v != NULL){
    free(v);
    v = NULL;
  }
}
//--------------------------------------------------------------------------
long VectorShort::operator ()(VectorShort& a){
  long res;
  VectorShort temp(*this);
  res = temp.MultiplyScalar(a);
  return res;
}
//--------------------------------------------------------------------------
long VectorShort::MultiplyScalar(VectorShort& a){
  long res = 0;
  VectorShort temp(*this);
  temp *= a;

  for(unsigned int i=0; i<size; i++)
    res += temp[i];

  return res;
}
//--------------------------------------------------------------------------
