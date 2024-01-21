//---------------------------------------------------------------------------
#pragma hdrstop
#include "MatrixShort.h"
#pragma package(smart_init)
#include <time.h>
#include <math.h>
//---------------------------------------------------------------------------
int MatrixShort::num_matrix = 0;
//---------------------------------------------------------------------------
MatrixShort::MatrixShort(int s){
  if(s <= 0){
    codeError = -1;
    n=size = 0;
    num_matrix++;
    ShortArray = NULL;
  }
  else{
    codeError = 0;
    n=size = s;
    num_matrix++;
    ShortArray = new VectorShort[n];
    for(int i=0; i<n; i++)
      ShortArray[i] = VectorShort(size);
  }
}
//---------------------------------------------------------------------------
MatrixShort::MatrixShort(int n_1, int size_1){
  if(n_1 > 0 && size_1 > 0){
    codeError = 0;
    n = n_1;
    size = size_1;
    num_matrix++;
    ShortArray = new VectorShort[n];
    for(int i=0; i<n; i++)
      ShortArray[i] = VectorShort(size);
  }
  else{
    codeError = -1;
    n=size = 0;
    num_matrix++;
    ShortArray = NULL;
  }
}
//---------------------------------------------------------------------------
MatrixShort::MatrixShort(int n_1, int size_1, short value){
  if(n_1 > 0 && size_1 > 0){
    codeError = 0;
    n = n_1;
    size = size_1;
    num_matrix++;
    ShortArray = new VectorShort[n];
    for(int i=0; i<n; i++)
      ShortArray[i] = VectorShort(size, value);
  }
  else{
    codeError = -1;
    n=size = 0;
    num_matrix++;
    ShortArray = NULL;
  }
}
//---------------------------------------------------------------------------
MatrixShort::MatrixShort(MatrixShort& a){
  codeError = 0;
  n = a.n;
  size = a.size;
  num_matrix++;
  ShortArray = new VectorShort[n];
  for(int i=0; i<n; i++){
    ShortArray[i] = VectorShort(size);
    for(int j=0; j<size; j++)
      ShortArray[i][j] = a.ShortArray[i][j];
  }
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator ++(){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      ShortArray[i][j]++;

  return *this;    
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator --(){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      ShortArray[i][j]--;

  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator ++(int){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      ShortArray[i][j]++;

  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator --(int){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      ShortArray[i][j]--;

  return *this;
}
//---------------------------------------------------------------------------
bool MatrixShort::operator !(){
  if(n!=0 && size!=0) return true; else return false;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator ~(){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      ShortArray[i][j] = ~ShortArray[i][j];

  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator -(){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      (*this)[i][j] = - (*this)[i][j];

  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator =(MatrixShort a){
  n = a.n;
  size = a.size;

  if(ShortArray != NULL){delete ShortArray; ShortArray = NULL;}

  ShortArray = new VectorShort[n];
  for(int i=0; i<n; i++){
    ShortArray[i] = VectorShort(size);
    for(int j=0; j<size; j++)
      ShortArray[i][j] = a[i][j];
  }

  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator =(short a){

  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      (*this)[i][j] = a;

  return *this;
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator +(MatrixShort& a){
  if(n!=a.n || size!=a.size){codeError = 2; return *this;}
  else{

    codeError = 0;
    MatrixShort temp(*this);
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
        temp[i][j] += a[i][j];

    return temp;
 }
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator +(short& a){
  MatrixShort temp(*this);

  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      temp[i][j] += a;

  return temp;
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator -(MatrixShort& a){
  if(n!=a.n || size!=a.size){codeError = 2; return *this;}
  else{

    codeError = 0;
    MatrixShort temp(*this);
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
        temp[i][j] -= a[i][j];

    return temp;
 }
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator -(short& a){
  MatrixShort temp(*this);

  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      temp[i][j] -= a;

  return temp;
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator *(MatrixShort& a){
  if(size != a.n){codeError = 2; return *this;}
  else{

    codeError = 0;
    MatrixShort temp(n, size);
    for(int i=0; i<n; i++)
      for(int j=0; j<a.size; j++)
        for(int q=0; q<size; q++)
          temp[i][j] += (*this)[i][q] * a[q][j];

    return temp;
 }
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator *(VectorShort& a){
  if(size == 1){
    MatrixShort temp(n, a.GetSize());
    for(int i=0; i<n; i++)
      for(int j=0; j<a.GetSize(); j++)
        temp[i][j] += (*this)[i][0] * a[j];
    return temp;
  }

  if(size == a.GetSize()){
    MatrixShort temp(n, 1);
    for(int i=0; i<n; i++)
      for(int q=0; q<size; q++)
        temp[i][0] += (*this)[i][q] * a[q];
    return temp;
  }

  codeError = 2;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator *(short& a){
  MatrixShort temp(*this);

  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      temp[i][j] *= a;

  return temp;    
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator /(MatrixShort& a){
  if(size != a.size || n != a.n){codeError = 2; return *this;}
  else{

    codeError = 0;
    MatrixShort temp(*this);
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
        if(a[i][j] != 0)temp[i][j] = (*this)[i][j] / a[i][j];

    return temp;
 }
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator /(short& a){
  MatrixShort temp(*this);
  if(a == 0) return temp;

  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      temp[i][j] /= a;

  return temp;
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator %(MatrixShort& a){
  if(size != a.size || n != a.n){codeError = 2; return *this;}
  else{

    codeError = 0;
    MatrixShort temp(n, size);
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
        temp[i][j] = (*this)[i][j] % a[i][j];

    return temp;
 }
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator %(short& a){
  MatrixShort temp(*this);

  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      temp[i][j] %= a;

  return temp;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator +=(MatrixShort& a){
  *this = *this + a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator +=(short& a){
  *this = *this + a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator -=(MatrixShort& a){
  *this = *this - a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator -=(short& a){
  *this = *this - a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator *=(MatrixShort& a){
  *this = *this * a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator *=(VectorShort& a){
  *this = *this * a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator *=(short& a){
  *this = *this * a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator /=(MatrixShort& a){
  *this = *this / a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator /=(short& a){
  *this = *this / a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator %=(MatrixShort& a){
  *this = *this % a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator %=(short& a){
  *this = *this % a;
  return *this;
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator |(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    MatrixShort temp(*this);
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          temp[i][j] |= a[i][j];

    return temp;
 }
 else{codeError = 2; return *this;}
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator |(short& a){

  MatrixShort temp(*this);
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      temp[i][j] |= a;

  return temp;
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator ^(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    MatrixShort temp(*this);
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          temp[i][j] ^= a[i][j];

    return temp;
 }
 else{codeError = 2; return *this;}
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator ^(short& a){

  MatrixShort temp(*this);
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      temp[i][j] ^= a;

  return temp;
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator &(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    MatrixShort temp(*this);
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          temp[i][j] &= a[i][j];

    return temp;
 }
 else{codeError = 2; return *this;}
}
//---------------------------------------------------------------------------
MatrixShort MatrixShort::operator &(short& a){

  MatrixShort temp(*this);
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      temp[i][j] &= a;

  return temp;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator >>=(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          (*this)[i][j] >>= abs(a[i][j]);

    return *this;
 }
 else{codeError = 2; return *this;}
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator >>=(short& a){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      (*this)[i][j] >>= abs(a);

  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator <<=(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          (*this)[i][j] <<= abs(a[i][j]);

    return *this;
 }
 else{codeError = 2; return *this;}
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator <<=(short& a){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      (*this)[i][j] <<= abs(a);

  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator |=(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          (*this)[i][j] |= a[i][j];

    return *this;
 }
 else{codeError = 2; return *this;}
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator |=(short& a){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      (*this)[i][j] |= a;

  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator ^=(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          (*this)[i][j] ^= a[i][j];

    return *this;
 }
 else{codeError = 2; return *this;}
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator ^=(short& a){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      (*this)[i][j] ^= a;

  return *this;
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator &=(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          (*this)[i][j] &= a[i][j];

    return *this;
 }
 else{codeError = 2; return *this;}
}
//---------------------------------------------------------------------------
MatrixShort& MatrixShort::operator &=(short& a){
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      (*this)[i][j] &= a;

  return *this;
}
//---------------------------------------------------------------------------
bool MatrixShort::operator ==(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          if( (*this)[i][j] != a[i][j] ) return false;

    return true;
 }
 else{codeError = 2; return false;}
}
//---------------------------------------------------------------------------
bool MatrixShort::operator !=(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          if( (*this)[i][j] == a[i][j] ) return false;

    return true;
 }
 else{codeError = 2; return false;}
}
//---------------------------------------------------------------------------
bool MatrixShort::operator >(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          if( (*this)[i][j] <= a[i][j] ) return false;

    return true;
 }
 else{codeError = 2; return false;}
}
//---------------------------------------------------------------------------
bool MatrixShort::operator >=(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          if( (*this)[i][j] < a[i][j] ) return false;

    return true;
 }
 else{codeError = 2; return false;}
}
//---------------------------------------------------------------------------
bool MatrixShort::operator <(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          if( (*this)[i][j] >= a[i][j] ) return false;

    return true;
 }
 else{codeError = 2; return false;}
}
//---------------------------------------------------------------------------
bool MatrixShort::operator <=(MatrixShort& a){
  if(size == a.size && n == a.n){
    codeError = 0;
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
          if( (*this)[i][j] > a[i][j] ) return false;

    return true;
 }
 else{codeError = 2; return false;}
}
//---------------------------------------------------------------------------
VectorShort& MatrixShort::operator [](int& p){
  if(p<0 || p>=n){
    codeError = 1;
    return ShortArray[0];
  }
  else{
    codeError = 0;
    return ShortArray[p];
  }
}
//---------------------------------------------------------------------------
void* MatrixShort::operator new(size_t s){
  void *ptr = malloc(s);
  return ptr;
}
//---------------------------------------------------------------------------
void* MatrixShort::operator new[](size_t s){
  void *ptr = malloc(sizeof(MatrixShort) * s);
  return ptr;
}
//---------------------------------------------------------------------------
void MatrixShort::operator delete(void* v){
  if(v != NULL){
    free(v);
    v = NULL;
  }
}
//---------------------------------------------------------------------------
void MatrixShort::operator delete[](void* v){
  if(v != NULL){
    free(v);
    v = NULL;
  }
}
//---------------------------------------------------------------------------
long MatrixShort::operator ()(MatrixShort& a){
  long res = 0;

  if(size == a.size && n == a.n)
    for(int i=0; i<n; i++)
      for(int j=0; j<size; j++)
        res += (*this)[i][j] * a[i][j];

  return res;      
}
//---------------------------------------------------------------------------
istream& operator >> (istream& input, MatrixShort& v){
  for(int i=0; i<v.GetN(); i++) input >> v[i];
  return input;
}
//---------------------------------------------------------------------------
ostream& operator << (ostream& output, MatrixShort& v){
  for(int i=0; i<v.GetN(); i++) output << v[i] << "\n";
  return output;
}
//---------------------------------------------------------------------------
ifstream& operator >> (ifstream& finput, MatrixShort& v){
  for(int i=0; i<v.GetN(); i++) finput >> v[i];
  return finput;
}
//---------------------------------------------------------------------------
ofstream& operator << (ofstream& foutput, MatrixShort& v){
  for(int i=0; i<v.GetN(); i++) foutput << v[i] << "\n";
  return foutput;
}
//---------------------------------------------------------------------------
void MatrixShort::ReadFromStg(TStringGrid*& stg){

  if(ShortArray != NULL){delete ShortArray; ShortArray = NULL;}

  n = stg->RowCount-1;
  size = stg->ColCount-1;
  ShortArray = new VectorShort[n];
  for(int i=0; i<n; i++)
    ShortArray[i] = VectorShort(size);

  int temp;
  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      if( !(TryStrToInt(stg->Cells[j+1][i+1], temp)) )
        (*this)[i][j] = 0;
      else
        (*this)[i][j] = StrToInt(stg->Cells[j+1][i+1]);
}
//---------------------------------------------------------------------------
short RandomShortValue(){

  short value = (rand() % 200) - 100;

  return value;
}
//---------------------------------------------------------------------------
void MatrixShort::RandomFilling(){
  srand(time(0));

  for(int i=0; i<n; i++)
    for(int j=0; j<size; j++)
      (*this)[i][j] = RandomShortValue();
}
//---------------------------------------------------------------------------
//true - good, false - file is not open
bool MatrixShort::ReadFromFile(String FileName){

  ifstream file(FileName.c_str());

  if(!file.is_open()) //���� ���� �� �������
    return false;
  else{
    file >> (*this);
    file.close();
    return true;
  }
}
//--------------------------------------------------------------------------
void MatrixShort::PrintToStg(TStringGrid*& stg){
  stg->RowCount = n+1;
  stg->ColCount = size+1;
  stg->FixedRows = 1;
  stg->FixedCols = 1;

  for(int i=0; i<n; i++){
    for(int j=0; j<size; j++){
      stg->Cells[j+1][i+1] = IntToStr((*this)[i][j]);
      stg->Cells[j+1][0] = IntToStr(j+1);
    }
    stg->Cells[0][i+1] = IntToStr(i+1);
  }
}
//---------------------------------------------------------------------------
