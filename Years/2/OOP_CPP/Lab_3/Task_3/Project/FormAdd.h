#include "TDomain_IP.h"
#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Runtime::InteropServices;
using namespace Domain_IP;


namespace Project {

	/// <summary>
	/// Сводка для FormAdd
	///
	/// Внимание! При изменении имени этого класса необходимо также изменить
	///          свойство имени файла ресурсов ("Resource File Name") для средства компиляции управляемого ресурса,
	///          связанного со всеми файлами с расширением .resx, от которых зависит данный класс. В противном случае,
	///          конструкторы не смогут правильно работать с локализованными
	///          ресурсами, сопоставленными данной форме.
	/// </summary>
	public ref class FormAdd : public System::Windows::Forms::Form
	{
	public:
		FormAdd(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~FormAdd()
		{
			if (components)
			{
				delete components;
			}
		}
  private: System::Windows::Forms::TextBox^  TextBox_Domain;
  private: System::Windows::Forms::TextBox^  TextBox_IP;
  protected: 

  private: System::Windows::Forms::Label^  label1;
  private: System::Windows::Forms::Label^  label2;
  private: System::Windows::Forms::Button^  Button_OK;

	private:
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
      this->TextBox_Domain = (gcnew System::Windows::Forms::TextBox());
      this->TextBox_IP = (gcnew System::Windows::Forms::TextBox());
      this->label1 = (gcnew System::Windows::Forms::Label());
      this->label2 = (gcnew System::Windows::Forms::Label());
      this->Button_OK = (gcnew System::Windows::Forms::Button());
      this->SuspendLayout();
      // 
      // TextBox_Domain
      // 
      this->TextBox_Domain->Location = System::Drawing::Point(87, 28);
      this->TextBox_Domain->Name = L"TextBox_Domain";
      this->TextBox_Domain->Size = System::Drawing::Size(185, 20);
      this->TextBox_Domain->TabIndex = 0;
      // 
      // TextBox_IP
      // 
      this->TextBox_IP->Location = System::Drawing::Point(87, 65);
      this->TextBox_IP->Name = L"TextBox_IP";
      this->TextBox_IP->Size = System::Drawing::Size(185, 20);
      this->TextBox_IP->TabIndex = 1;
      // 
      // label1
      // 
      this->label1->AutoSize = true;
      this->label1->Location = System::Drawing::Point(12, 28);
      this->label1->Name = L"label1";
      this->label1->Size = System::Drawing::Size(43, 13);
      this->label1->TabIndex = 2;
      this->label1->Text = L"Domain";
      // 
      // label2
      // 
      this->label2->AutoSize = true;
      this->label2->Location = System::Drawing::Point(12, 65);
      this->label2->Name = L"label2";
      this->label2->Size = System::Drawing::Size(17, 13);
      this->label2->TabIndex = 3;
      this->label2->Text = L"IP";
      // 
      // Button_OK
      // 
      this->Button_OK->Location = System::Drawing::Point(99, 114);
      this->Button_OK->Name = L"Button_OK";
      this->Button_OK->Size = System::Drawing::Size(75, 23);
      this->Button_OK->TabIndex = 4;
      this->Button_OK->Text = L"OK";
      this->Button_OK->UseVisualStyleBackColor = true;
      this->Button_OK->Click += gcnew System::EventHandler(this, &FormAdd::Button_OK_Click);
      // 
      // FormAdd
      // 
      this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
      this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
      this->ClientSize = System::Drawing::Size(284, 158);
      this->Controls->Add(this->Button_OK);
      this->Controls->Add(this->label2);
      this->Controls->Add(this->label1);
      this->Controls->Add(this->TextBox_IP);
      this->Controls->Add(this->TextBox_Domain);
      this->Name = L"FormAdd";
      this->Text = L"Додати новий запис";
      this->ResumeLayout(false);
      this->PerformLayout();

    }
#pragma endregion
  private: System::Void Button_OK_Click(System::Object^  sender, System::EventArgs^  e) {
             TDomain_IP B;
             if(B.ReadFromFile("BASE.txt")){
               IntPtr temp = Marshal::StringToHGlobalAnsi(this->TextBox_Domain->Text);
               string d = static_cast<const char*>(temp.ToPointer());
               temp = Marshal::StringToHGlobalAnsi(this->TextBox_IP->Text);
               string ip = static_cast<const char*>(temp.ToPointer());

               if(B.Add(d, ip))
                 B.WriteInFile("BASE.txt");
               this->Owner->Enabled = true;
               this->Close();
             }
             else
               MessageBox::Show("Не вдалося знайти файл BASE.txt");
           }
};
}
