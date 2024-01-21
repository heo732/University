#include <string>
#include <fstream>

using namespace System;
using namespace std;  
using namespace System::Runtime::InteropServices;
//----------------------------------------
namespace Domain_IP{
typedef struct OBase{
  string domain;
  string IP;
  OBase *next;
  OBase *prev;
}TBase;
//----------------------------------------
class TDomain_IP{	  

    TBase* base;
    TBase* backup;
	
  public:

    TDomain_IP(){base = NULL; backup = NULL;}
    //----------------------------------------
    ~TDomain_IP(){
	    if(base != NULL){
		    while(base->prev != NULL)
          base = base->prev;
		    while(base != NULL){
			    TBase *temp = base;
			    base = base->next;
          if(temp->next != NULL)
            temp->next->prev = temp->prev;
          if(temp->prev != NULL)
            temp->prev->next = temp->next;
          delete temp;
		    }
	    }

	    if(backup != NULL){
		    while(backup->prev != NULL)
          backup = backup->prev;
		    while(backup != NULL){
			    TBase *temp = backup;
			    backup = backup->next;
          if(temp->next != NULL)
            temp->next->prev = temp->prev;
          if(temp->prev != NULL)
            temp->prev->next = temp->next;
          delete temp;
		    }
	    }
	  }
    //----------------------------------------
    void Erase(){
      if(base != NULL){
		    while(base->prev != NULL)
          base = base->prev;
		    while(base != NULL){
			    TBase *temp = base;
			    base = base->next;
          if(temp->next != NULL)
            temp->next->prev = temp->prev;
          if(temp->prev != NULL)
            temp->prev->next = temp->next;
          delete temp;
		    }
	    }
    }
    //----------------------------------------
    void EraseBackup(){
      if(backup != NULL){
		    while(backup->prev != NULL)
          backup = backup->prev;
		    while(backup != NULL){
			    TBase *temp = backup;
			    backup = backup->next;
          if(temp->next != NULL)
            temp->next->prev = temp->prev;
          if(temp->prev != NULL)
            temp->prev->next = temp->next;
          delete temp;
		    }
	    }
    }
    //----------------------------------------
	  bool IsIn(string d){
      if(base != NULL){
        TBase* temp = base;
        while(temp->domain.compare(d) != 0 && temp->next != NULL)
          temp = temp->next;
        if(temp->domain.compare(d) == 0)
          return true;
      }
      return false;
    }
    //----------------------------------------
    bool IsInBackup(string d){
      if(backup != NULL){
        TBase* temp = backup;
        while(temp->domain.compare(d) != 0 && temp->next != NULL)
          temp = temp->next;
        if(temp->domain.compare(d) == 0)
          return true;
      }
      return false;
    }
    //----------------------------------------
    TBase* operator [](unsigned int k){
	    unsigned int i = 0;
	    TBase *temp = base;
	    while(i != k && temp->next != NULL){
		    i++;
		    temp = temp->next;
	    }
	    return temp;
	  }
    //----------------------------------------
	  TBase* operator ()(unsigned int k){
	    unsigned int i = 0;
	    TBase *temp = backup;
	    while(i != k && temp->next != NULL){
		    i++;
		    temp = temp->next;
	    }
	    return temp;
	  }
    //----------------------------------------
	  unsigned int Size(){	  
	    unsigned int i = 0;
	    TBase *temp = base;
	    while(temp != NULL){
		    i++;
		    temp = temp->next;
	    }
	    return i;
	  }
    //----------------------------------------
	  unsigned int SizeBackup(){	  
	    unsigned int i = 0;
	    TBase *temp = backup;
	    while(temp != NULL){
		    i++;
		    temp = temp->next;
	    }
	    return i;
	  }
    //----------------------------------------
	  bool Add(string d, string i){	    
			if(base != NULL && IsIn(d) == false && IsInBackup(d) == false){
        while(base->next != NULL && base->domain.compare(d) == -1)
          base = base->next;
        
        TBase* temp;
        temp = new TBase;
        temp->domain = d;
        temp->IP = i;
        temp->prev = base;
        temp->next = base->next;

        if(base->next != NULL)  
          base->next->prev = temp;
        base->next = temp;
        

        while(base->prev != NULL)
          base = base->prev;

        return true;
			} 
			else
        if(base == NULL && IsIn(d) == false && IsInBackup(d) == false){
			    base = new TBase;
			    base->next = NULL;
			    base->prev = NULL;
          base->domain = d;
          base->IP = i;
          return true;
			  }
        else
          if(base == NULL && IsInBackup(d) == true){
            RemoveBackup(d);
            base = new TBase;
            base->next = NULL;
            base->prev = NULL;
            base->domain = d;
            base->IP = i;
            return true;
          }
          else
            if(base != NULL && IsInBackup(d) == true){
              RemoveBackup(d);
              while(base->next != NULL && base->domain.compare(d) == -1)
                base = base->next;
        
              TBase* temp;
              temp = new TBase;
              temp->domain = d;
              temp->IP = i;
              temp->prev = base;
              temp->next = base->next;

              if(base->next != NULL)  
                base->next->prev = temp;
              base->next = temp;
              

              while(base->prev != NULL)
                base = base->prev;

              return true;
            }
            else
              if(IsIn(d))
                return false;
            return false;
	  }
    //----------------------------------------
    bool AddBackup(string d, string i){	    
			if(backup != NULL && IsInBackup(d) == false){
        while(backup->next != NULL && backup->domain.compare(d) == -1)
          backup = backup->next;
        
        TBase* temp;
        temp = new TBase;
        temp->domain = d;
        temp->IP = i;
        temp->prev = backup;
        temp->next = backup->next;

        if(backup->next != NULL)  
          backup->next->prev = temp;
        backup->next = temp;

        while(backup->prev != NULL)
          backup = backup->prev;

        return true;
			} 
			else
        if(backup == NULL && IsInBackup(d) == false){
			    backup = new TBase;
			    backup->next = NULL;
			    backup->prev = NULL;
          backup->domain = d;
          backup->IP = i;

          return true;
			  }	
        else
          if(IsInBackup(d))
            return false;
      return false;
	  }
    //----------------------------------------
    bool Remove(string d){
      if(Size() > 1){
        unsigned int i = 0;
        while(base->domain.compare(d)!=0 && base->next!=NULL){
          base = base->next;
          i++;
        }
        
        if(base->domain.compare(d) == 0){
          AddBackup(d, base->IP);

          if(base->prev != NULL)
            base->prev->next = base->next;
          
          if(base->next != NULL)
            base->next->prev = base->prev;
          
          TBase* temp = base;
          
          while(base->prev != NULL)
            base = base->prev;
          
          if(i == 0)
            base = base->next;
          delete temp;          
          return true;
        }
      }
      if(Size() == 1){
        delete base;
        base = NULL;
      }

      return false;
    }
    //----------------------------------------
    bool RemoveBackup(string d){
      if(Size() > 1){
        unsigned int i = 0;
        while(backup->domain.compare(d)!=0 && backup->next!=NULL){
          backup = backup->next;
          i++;
        }
        
        if(backup->domain.compare(d) == 0){

          if(backup->prev != NULL)
            backup->prev->next = backup->next;
          
          if(backup->next != NULL)
            backup->next->prev = backup->prev;
          
          TBase* temp = backup;
          
          while(backup->prev != NULL)
            backup = backup->prev;
          
          if(i == 0)
            backup = backup->next;
          delete temp;          
          return true;
        }
      }
      
      if(Size() == 1){
        delete backup;
        backup = NULL;
      }

      return false;
    }
    //----------------------------------------
    friend ofstream& operator << (ofstream& foutput, TBase*& a){
      TBase* temp = a;
      while(temp != NULL){
        foutput << temp->domain << endl << temp->IP << endl;
        temp = temp->next;
      }

      return foutput;
    }
    //----------------------------------------
    void WriteInFile(string FileName){
      ofstream file(FileName.c_str());

      file << base;
    }
    //----------------------------------------
    void WriteBackupInFile(string FileName){
      ofstream file(FileName.c_str());

      file << backup;
    }
    //----------------------------------------
    bool ReadFromFile(string FileName){
      
      ifstream file(FileName.c_str());

      if(!file.is_open())
        return false;
      else{
        Erase();

        while(!file.eof()){
          string d, i;
          file >> d >> i;
          Add(d, i);
        }          
        
        file.close();        
        return true;
      }
    }
    //----------------------------------------
    bool ReadBackupFromFile(string FileName){
      
      ifstream file(FileName.c_str());

      if(!file.is_open())
        return false;
      else{
        EraseBackup();

        while(!file.eof()){
          string d, i;
          file >> d >> i;
          AddBackup(d, i);
        }          
        
        file.close();        
        return true;
      }
    }
    //----------------------------------------
    void WriteInGrid(System::Windows::Forms::DataGridView^ grid){
      TBase* temp = base;
      int i = 0;
      grid->RowCount = Size();
      while(temp != NULL){
        grid[0, i]->Value = gcnew String(temp->domain.c_str());
        grid[1, i]->Value = gcnew String(temp->IP.c_str());
        i++;
        temp = temp->next;
      }
    }
    //----------------------------------------
    void WriteBackupInGrid(System::Windows::Forms::DataGridView^ grid){
      TBase* temp = backup;
      int i = 0;
      grid->RowCount = SizeBackup();
      while(temp != NULL){
        grid[0, i]->Value = gcnew String(temp->domain.c_str());
        grid[1, i]->Value = gcnew String(temp->IP.c_str());
        i++;
        temp = temp->next;
      }
    }
    //----------------------------------------
    void ReadFromGrid(System::Windows::Forms::DataGridView^ grid){
      Erase();

      for(int i=0; i<grid->RowCount; i++){
        IntPtr temp1 = Marshal::StringToHGlobalAnsi(grid[0, i]->Value->ToString());
        string d = static_cast<const char*>(temp1.ToPointer());
        
        temp1 = Marshal::StringToHGlobalAnsi(grid[1, i]->Value->ToString());
        string ip = static_cast<const char*>(temp1.ToPointer());
        
        Add(d, ip);
      }
    }
    //----------------------------------------
    void ReadBackupFromGrid(System::Windows::Forms::DataGridView^ grid){
      EraseBackup();

      for(int i=0; i<grid->RowCount; i++){
        IntPtr temp1 = Marshal::StringToHGlobalAnsi(grid[0, i]->Value->ToString());
        string d = static_cast<const char*>(temp1.ToPointer());
        
        temp1 = Marshal::StringToHGlobalAnsi(grid[1, i]->Value->ToString());
        string ip = static_cast<const char*>(temp1.ToPointer());
        
        AddBackup(d, ip);
      }
    }
    //----------------------------------------
    void* operator new(size_t s){
      void *ptr = malloc(s);
      return ptr;
    }
    //---------------------------------------------------------------------------
    void* operator new[](size_t s){
      void *ptr = malloc(sizeof(TDomain_IP) * s);
      return ptr;
    }
    //---------------------------------------------------------------------------
    void operator delete(void* v){
      if(v != NULL){
        free(v);
        v = NULL;
      }
    }
    //---------------------------------------------------------------------------
    void operator delete[](void* v){
      if(v != NULL){
        free(v);
        v = NULL;
      }
    }
    //---------------------------------------------------------------------------
};
}