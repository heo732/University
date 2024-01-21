//---------------------------------------------------------------------------
#pragma hdrstop
#include "TDomain_IP.h"
#pragma package(smart_init)
//---------------------------------------------------------------------------
TDomain_IP::TDomain_IP(){

  field = NULL;

}
//---------------------------------------------------------------------------
TDomain_IP::~TDomain_IP(){

  if(field != NULL){
    while(field->prev != NULL)
      field = field->prev;
    while(field->next != NULL){
      field = field->next;
      delete field->prev;
    }
    delete field;
    field = NULL;
  }

}
//---------------------------------------------------------------------------
void TDomain_IP::Erase(){
  if(field != NULL){
    while(field->prev != NULL)
      field = field->prev;
    while(field->next != NULL){
      field = field->next;
      delete field->prev;
    }
    delete field;
    field = NULL;
  }
}
//---------------------------------------------------------------------------
bool TDomain_IP::IsIn(string d){
  if(field != NULL){
    TBase* temp = field;
    while(temp->domain.compare(d) != 0 && temp->next != NULL)
      temp = temp->next;
    if(temp->domain.compare(d) == 0)
      return true;
  }
  return false;
}
//---------------------------------------------------------------------------
TBase* TDomain_IP::operator [](unsigned int k){
  unsigned int i = 0;
  TBase *temp = field;

  while(i != k && temp->next != NULL){
    i++;
    temp = temp->next;
  }

  return temp;
}
//---------------------------------------------------------------------------
unsigned int TDomain_IP::Size(){
  unsigned int i = 0;
  TBase *temp = field;

  while(temp != NULL){
    i++;
    temp = temp->next;
  }

  return i;
}
//---------------------------------------------------------------------------
void TDomain_IP::Add(string d, string i){
  if(field != NULL && IsIn(d) == false && d != "" && i != ""){
    while(field->next != NULL && field->domain.compare(d) < 0)
      field = field->next;

    TBase* temp;
    temp = new TBase;
    temp->domain = d;
    temp->IP = i;

    if(field->next == NULL){

      if(field->domain.compare(d) < 0){ //push right hand
        temp->next = NULL;
        temp->prev = field;
        field->next = temp;
      }
      else{  //push left hand
        temp->next = field;
        temp->prev = field->prev;

        if(field->prev != NULL)
          field->prev->next = temp;
        field->prev = temp;
      }

    }
    else{
      temp->next = field;
      temp->prev = field->prev;

      if(field->prev != NULL)
        field->prev->next = temp;
      field->prev = temp;
    }

    while(field->prev != NULL)
      field = field->prev;

  }
  else
    if(field == NULL && IsIn(d) == false && d != "" && i != ""){
      field = new TBase;
      field->next = NULL;
      field->prev = NULL;
      field->domain = d;
      field->IP = i;
    }

}
//---------------------------------------------------------------------------
void TDomain_IP::Remove(string d){
  if(Size() > 1){
    unsigned int i = 0;
    while(field->domain.compare(d) != 0 && field->next != NULL){
      field = field->next;
      i++;
    }

    if(field->domain.compare(d) == 0){

      if(field->prev != NULL)
        field->prev->next = field->next;

      if(field->next != NULL)
        field->next->prev = field->prev;

      TBase* temp = field;

      while(field->prev != NULL)
        field = field->prev;

      if(i == 0)
        field = field->next;

      delete temp;
    }
  }

  if(Size() == 1 && field->domain.compare(d) == 0){
    delete field;
    field = NULL;
  }

}
//---------------------------------------------------------------------------
string Encryption(string in){

  string ret = "";

  for(unsigned int i=0; i<in.length(); i++){

    char letter_low = 1, letter_high = 127<<1;
    letter_low &= ~in[i];
    letter_high &= in[i];

    char temp = 0;
    temp |= letter_low;
    temp |= letter_high;

    ret += temp;
  }

  return ret;

}
//---------------------------------------------------------------------------
ofstream& operator << (ofstream& foutput, TBase*& a){
  TBase* temp = a;

  if(temp != NULL){
    foutput << Encryption(temp->domain) << endl << Encryption(temp->IP);
    temp = temp->next;


    while(temp != NULL){
      foutput << endl << Encryption(temp->domain) << endl << Encryption(temp->IP);
      temp = temp->next;
    }

  }

  return foutput;
}
//---------------------------------------------------------------------------
ostream& operator << (ostream& output, TBase*& a){
  TBase* temp = a;

  if(temp != NULL){
    output << temp->domain << endl << temp->IP;
    temp = temp->next;


    while(temp != NULL){
      output << endl << temp->domain << endl << temp->IP;
      temp = temp->next;
    }

  }

  return output;
}
//---------------------------------------------------------------------------
void TDomain_IP::WriteInFile(string FileName){

  ofstream file(FileName.c_str());

  file << field;

  file.close();
}
//---------------------------------------------------------------------------
bool TDomain_IP::ReadFromFile(string FileName){
      
  ifstream file(FileName.c_str());

  if(!file.is_open())
    return false;
  else{
    Erase();

    while(!file.eof()){
      string d, i;
      file >> d >> i;
      Add(Encryption(d), Encryption(i));
    }

    file.close();
    return true;
  }
}
//---------------------------------------------------------------------------
void TDomain_IP::WriteInGrid(TStringGrid*& grid){

  if( Size() > 0 ){

    grid->RowCount = Size() + 1;
    grid->ColCount = 3;
    grid->FixedRows = 1;
    grid->FixedCols = 1;
    grid->Cells[1][0] = "Доменне ім'я";
    grid->Cells[2][0] = "IP-адрес";

    TBase* temp = field;
    int i = 1;

    while(temp != NULL){
      grid->Cells[0][i] = IntToStr(i);
      grid->Cells[1][i] = temp->domain.c_str();
      grid->Cells[2][i] = temp->IP.c_str();
      i++;
      temp = temp->next;
    }

  }
  else{
    grid->RowCount = 2;
    grid->ColCount = 3;
    grid->FixedRows = 1;
    grid->FixedCols = 1;
    grid->Cells[1][0] = "Доменне ім'я";
    grid->Cells[2][0] = "IP-адрес";
    grid->Cells[0][1] = "";
    grid->Cells[1][1] = "";
    grid->Cells[2][1] = "";
  }
}
//---------------------------------------------------------------------------
void TDomain_IP::ReadFromGrid(TStringGrid*& grid){

  Erase();

  for(int i=1; i<grid->RowCount; i++)
    Add(grid->Cells[1][i].c_str(), grid->Cells[2][i].c_str());
}
//---------------------------------------------------------------------------
void* TDomain_IP::operator new(size_t s){
      void *ptr = malloc(s);
      return ptr;
}
//---------------------------------------------------------------------------
void* TDomain_IP::operator new[](size_t s){
  void *ptr = malloc(sizeof(TDomain_IP) * s);
  return ptr;
}
//---------------------------------------------------------------------------
void TDomain_IP::operator delete(void* v){
  if(v != NULL){
    free(v);
    v = NULL;
  }
}
//---------------------------------------------------------------------------
void TDomain_IP::operator delete[](void* v){
  if(v != NULL){
    free(v);
    v = NULL;
  }
}
//---------------------------------------------------------------------------

