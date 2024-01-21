#pragma once

#include <vector>
#include <array>
#include <fstream>
#include "Student.h"
#include <valarray>
#include <cmath>


namespace Lab_7 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace std;

	/// <summary>
	/// Сводка для FormMain
	/// </summary>
	public ref class FormMain : public System::Windows::Forms::Form
	{
	public:
		
		FormMain(void)
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
		~FormMain()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::MenuStrip^  menuStrip1;
	protected: 
	private: System::Windows::Forms::ToolStripMenuItem^  завданняToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  toolStripMenuItem2;
	private: System::Windows::Forms::ToolStripMenuItem^  toolStripMenuItem3;
	private: System::Windows::Forms::Panel^  panelTop;

	private: System::Windows::Forms::Panel^  panel1;
	private: System::Windows::Forms::ListView^  listView1;
	private: System::Windows::Forms::MaskedTextBox^  maskedTextBox1;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Panel^  panel2;
	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::MaskedTextBox^  maskedTextBox2;
	private: System::Windows::Forms::Label^  label6;












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
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->завданняToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripMenuItem2 = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripMenuItem3 = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->panelTop = (gcnew System::Windows::Forms::Panel());
			this->panel2 = (gcnew System::Windows::Forms::Panel());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->maskedTextBox2 = (gcnew System::Windows::Forms::MaskedTextBox());
			this->label6 = (gcnew System::Windows::Forms::Label());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->maskedTextBox1 = (gcnew System::Windows::Forms::MaskedTextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->listView1 = (gcnew System::Windows::Forms::ListView());
			this->menuStrip1->SuspendLayout();
			this->panelTop->SuspendLayout();
			this->panel2->SuspendLayout();
			this->panel1->SuspendLayout();
			this->SuspendLayout();
			// 
			// menuStrip1
			// 
			this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) {this->завданняToolStripMenuItem});
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = System::Drawing::Size(840, 24);
			this->menuStrip1->TabIndex = 0;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// завданняToolStripMenuItem
			// 
			this->завданняToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2) {this->toolStripMenuItem2, 
				this->toolStripMenuItem3});
			this->завданняToolStripMenuItem->Name = L"завданняToolStripMenuItem";
			this->завданняToolStripMenuItem->Size = System::Drawing::Size(81, 20);
			this->завданняToolStripMenuItem->Text = L"Завдання_1";
			// 
			// toolStripMenuItem2
			// 
			this->toolStripMenuItem2->Name = L"toolStripMenuItem2";
			this->toolStripMenuItem2->Size = System::Drawing::Size(80, 22);
			this->toolStripMenuItem2->Text = L"1";
			this->toolStripMenuItem2->Click += gcnew System::EventHandler(this, &FormMain::toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem3
			// 
			this->toolStripMenuItem3->Name = L"toolStripMenuItem3";
			this->toolStripMenuItem3->Size = System::Drawing::Size(80, 22);
			this->toolStripMenuItem3->Text = L"2";
			this->toolStripMenuItem3->Click += gcnew System::EventHandler(this, &FormMain::toolStripMenuItem3_Click);
			// 
			// panelTop
			// 
			this->panelTop->Controls->Add(this->panel2);
			this->panelTop->Controls->Add(this->panel1);
			this->panelTop->Dock = System::Windows::Forms::DockStyle::Top;
			this->panelTop->Location = System::Drawing::Point(0, 24);
			this->panelTop->Name = L"panelTop";
			this->panelTop->Size = System::Drawing::Size(840, 100);
			this->panelTop->TabIndex = 1;
			// 
			// panel2
			// 
			this->panel2->Controls->Add(this->button2);
			this->panel2->Controls->Add(this->maskedTextBox2);
			this->panel2->Controls->Add(this->label6);
			this->panel2->Location = System::Drawing::Point(0, 0);
			this->panel2->Name = L"panel2";
			this->panel2->Size = System::Drawing::Size(840, 100);
			this->panel2->TabIndex = 1;
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(12, 21);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(158, 58);
			this->button2->TabIndex = 2;
			this->button2->Text = L"Get";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &FormMain::button2_Click);
			// 
			// maskedTextBox2
			// 
			this->maskedTextBox2->Location = System::Drawing::Point(208, 41);
			this->maskedTextBox2->Mask = L"099999";
			this->maskedTextBox2->Name = L"maskedTextBox2";
			this->maskedTextBox2->Size = System::Drawing::Size(100, 20);
			this->maskedTextBox2->TabIndex = 1;
			this->maskedTextBox2->Text = L"3";
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Location = System::Drawing::Point(205, 25);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(13, 13);
			this->label6->TabIndex = 0;
			this->label6->Text = L"k";
			// 
			// panel1
			// 
			this->panel1->Controls->Add(this->label3);
			this->panel1->Controls->Add(this->label2);
			this->panel1->Controls->Add(this->button1);
			this->panel1->Controls->Add(this->maskedTextBox1);
			this->panel1->Controls->Add(this->label1);
			this->panel1->Location = System::Drawing::Point(0, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(840, 100);
			this->panel1->TabIndex = 0;
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(388, 48);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(35, 13);
			this->label3->TabIndex = 4;
			this->label3->Text = L"label3";
			this->label3->Visible = false;
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(388, 25);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(35, 13);
			this->label2->TabIndex = 3;
			this->label2->Text = L"label2";
			this->label2->Visible = false;
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(12, 21);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(158, 58);
			this->button1->TabIndex = 2;
			this->button1->Text = L"Get";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &FormMain::button1_Click);
			// 
			// maskedTextBox1
			// 
			this->maskedTextBox1->Location = System::Drawing::Point(208, 41);
			this->maskedTextBox1->Mask = L"099999";
			this->maskedTextBox1->Name = L"maskedTextBox1";
			this->maskedTextBox1->Size = System::Drawing::Size(100, 20);
			this->maskedTextBox1->TabIndex = 1;
			this->maskedTextBox1->Text = L"30";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(205, 25);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(89, 13);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Число студентів";
			// 
			// listView1
			// 
			this->listView1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->listView1->FullRowSelect = true;
			this->listView1->GridLines = true;
			this->listView1->Location = System::Drawing::Point(0, 124);
			this->listView1->Name = L"listView1";
			this->listView1->Size = System::Drawing::Size(840, 367);
			this->listView1->TabIndex = 2;
			this->listView1->UseCompatibleStateImageBehavior = false;
			this->listView1->View = System::Windows::Forms::View::Details;
			// 
			// FormMain
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(840, 491);
			this->Controls->Add(this->listView1);
			this->Controls->Add(this->panelTop);
			this->Controls->Add(this->menuStrip1);
			this->MainMenuStrip = this->menuStrip1;
			this->Name = L"FormMain";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"OOP | Lab_7 | Var_4";
			this->Load += gcnew System::EventHandler(this, &FormMain::FormMain_Load);
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			this->panelTop->ResumeLayout(false);
			this->panel2->ResumeLayout(false);
			this->panel2->PerformLayout();
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void FormMain_Load(System::Object^  sender, System::EventArgs^  e) {
				 panel1->Visible = true;
				 panel2->Visible = false;
				 завданняToolStripMenuItem->Text = "Завдання_1";
				 this->AcceptButton = button1;
				 listView1->Clear();
			 }
private: System::Void toolStripMenuItem2_Click(System::Object^  sender, System::EventArgs^  e) {
			panel1->Visible = true;
			panel2->Visible = false;
			завданняToolStripMenuItem->Text = "Завдання_1";
			this->AcceptButton = button1;
			listView1->Clear();
			label2->Visible = false;
			label3->Visible = false;
		 }
private: System::Void toolStripMenuItem3_Click(System::Object^  sender, System::EventArgs^  e) {
			 panel1->Visible = false;
			 panel2->Visible = true;
			 завданняToolStripMenuItem->Text = "Завдання_2";
			 this->AcceptButton = button2;
			 listView1->Clear();
		 }
//-----------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {

			 label2->Visible = false;
			 label3->Visible = false;

			 if (!maskedTextBox1->MaskCompleted || int::Parse(maskedTextBox1->Text) == 0)
				 MessageBox::Show("Коректно заповніть поле 'Число студентів'", "Помилка", MessageBoxButtons::OK, MessageBoxIcon::Error);
			 else
			 {	
				 try
				 {
					 vector<string> LastName;
					 ReadFromFileInVector("LastName.txt", LastName);
					 vector<string> FirstNameMale;
					 ReadFromFileInVector("FirstNameMale.txt", FirstNameMale);
					 vector<string> FirstNameFemale;
					 ReadFromFileInVector("FirstNameFemale.txt", FirstNameFemale);
					 vector<string> SecondNameMale;
					 ReadFromFileInVector("SecondNameMale.txt", SecondNameMale);
					 vector<string> SecondNameFemale;
					 ReadFromFileInVector("SecondNameFemale.txt", SecondNameFemale);

					 int _count = int::Parse(maskedTextBox1->Text);
					 vector<Student> students;

					 Random^ random = gcnew Random();

					 for (int i = 0; i < _count; i++)
					 {
						 students.push_back(getRandomStudent(LastName, FirstNameMale, FirstNameFemale, SecondNameMale, SecondNameFemale, random));
					 }

					 sortBy_SecondName(students);

					 listView1->Clear();
					 listView1->Columns->Add("No");
					 listView1->Columns->Add("Last Name");
					 listView1->Columns->Add("First Name");
					 listView1->Columns->Add("Second Name");
					 listView1->Columns->Add("Born Year");
					 listView1->Columns->Add("Mark 1");
					 listView1->Columns->Add("Mark 2");
					 listView1->Columns->Add("Mark 3");
					 listView1->Columns->Add("Mark 4");
					 listView1->Columns->Add("Mark 5");

					 int No = 1;
					 for(Student i : students)
					 { 					 
						 ListViewItem^ item = gcnew ListViewItem(No.ToString());

						 ListViewItem::ListViewSubItem^ subItem1 = gcnew ListViewItem::ListViewSubItem(item, gcnew String(i._lastName.c_str()));
						 item->SubItems->Add(subItem1);
						 ListViewItem::ListViewSubItem^ subItem2 = gcnew ListViewItem::ListViewSubItem(item, Convert::ToString(gcnew String(i._firstName.c_str())));
						 item->SubItems->Add(subItem2);
						 ListViewItem::ListViewSubItem^ subItem3 = gcnew ListViewItem::ListViewSubItem(item, Convert::ToString(gcnew String(i._secondName.c_str())));
						 item->SubItems->Add(subItem3);
						 ListViewItem::ListViewSubItem^ subItem4 = gcnew ListViewItem::ListViewSubItem(item, Convert::ToString(i._bornYear));
						 item->SubItems->Add(subItem4);
						 ListViewItem::ListViewSubItem^ subItem5 = gcnew ListViewItem::ListViewSubItem(item, Convert::ToString(i._marks[0]));
						 item->SubItems->Add(subItem5);
						 ListViewItem::ListViewSubItem^ subItem6 = gcnew ListViewItem::ListViewSubItem(item, Convert::ToString(i._marks[1]));
						 item->SubItems->Add(subItem6);
						 ListViewItem::ListViewSubItem^ subItem7 = gcnew ListViewItem::ListViewSubItem(item, Convert::ToString(i._marks[2]));
						 item->SubItems->Add(subItem7);
						 ListViewItem::ListViewSubItem^ subItem8 = gcnew ListViewItem::ListViewSubItem(item, Convert::ToString(i._marks[3]));
						 item->SubItems->Add(subItem8);
						 ListViewItem::ListViewSubItem^ subItem9 = gcnew ListViewItem::ListViewSubItem(item, Convert::ToString(i._marks[4]));
						 item->SubItems->Add(subItem9);
					 
						 listView1->Items->Add(item);
						 No++;
					 }

					 listView1->AutoResizeColumns(ColumnHeaderAutoResizeStyle::HeaderSize);

					 ofstream outFile("StudRec.dat");
					 outFile << "Last Name      \tFirst Name     \tSecond Name    \tBorn Year \tMark 1    \tMark 2    \tMark 3    \tMark 4    \tMark 5    " << endl;
					 for (auto i = students.begin(); i != students.end(); i++)
					 {
						 outFile << *i << endl;
					 }
					 outFile.close();

					 outFile.open("RStudRec.dat");
					 outFile << "Last Name      \tFirst Name     \tSecond Name    \tBorn Year \tMark 1    \tMark 2    \tMark 3    \tMark 4    \tMark 5    " << endl;
					 for (auto i = students.rbegin(); i != students.rend(); i++)
					 {
						 outFile << *i << endl;
					 }
					 outFile.close(); 

					 label2->Text = "Список студентів знаходиться у файлі 'StudRec.dat'";
					 label3->Text = "Зворотній список студентів знаходиться у файлі 'RStudRec.dat'";
					 label2->ForeColor = Color::Green;
					 label3->ForeColor = Color::Green;
					 label2->Visible = true;
					 label3->Visible = true;
				 }
				 catch(Exception^ ex)
				 {
					 MessageBox::Show(ex->Message, ex->Source, MessageBoxButtons::OK, MessageBoxIcon::Error);
					 Console::WriteLine(ex->Message);
				 }
			 }
		 }
private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {

			 int k = 0;

			 if (!maskedTextBox2->MaskCompleted || Int32::TryParse(maskedTextBox2->Text, k) == 0)
				 MessageBox::Show("Корректно заповніть поле 'k'", "Помилка", MessageBoxButtons::OK, MessageBoxIcon::Error);
			 else
			 {
				 int N = 4 * k;

				 valarray<double> vArray(N);

				 Random^ random = gcnew Random();

				 for (int i = 0; i < N; i++)
				 {
					 vArray[i] = Convert::ToDouble( Convert::ToInt32(random->Next(100)).ToString() + "," + Convert::ToInt32(random->Next(100)).ToString() );
				 }

				 valarray<double> g1Array = vArray[slice(3, k, 4)];
				 double g1 = 0;
				 for (auto i : g1Array)
					 g1 += i;

				 valarray<double> test = vArray[slice(4, k, 4)];

				 valarray<double> g2Array = sin(static_cast<valarray<double> >(vArray[slice(4, k, 4)])) + cos(static_cast<valarray<double> >(vArray[slice(3, k, 4)]));
				 double g2 = 0;
				 for (auto i : g2Array)
					 g2 += i;

				 valarray<double> g3Array = tan(static_cast<valarray<double> >(vArray[slice(5, k, 4)])) + cos(static_cast<valarray<double> >(vArray[slice(3, k, 4)])) / sin(static_cast<valarray<double> >(vArray[slice(3, k, 4)]));
				 double g3 = 0;
				 for (auto i : g3Array)
					 g3 += i;
				 g3 *= g1;

				 valarray<double> g4Array = static_cast<valarray<double> >(vArray[slice(1, k, 2)]) + static_cast<valarray<double> >(vArray[slice(2, k, 3)]) + static_cast<valarray<double> >(vArray[slice(3, k, 4)]);
				 double g4 = 0;
				 for (auto i : g4Array)
					 g4 += i;

				 listView1->Clear();

				 listView1->Columns->Add("No");
				 listView1->Columns->Add("Array");
				 listView1->Columns->Add("");
				 listView1->Columns->Add("");
				 listView1->Columns->Add("");
				 				 
				 for (int i = 0; i < N; i++)
				 {
					 ListViewItem^ item = gcnew ListViewItem((i+1).ToString());
					 ListViewItem::ListViewSubItem^ subItem = gcnew ListViewItem::ListViewSubItem(item, vArray[i].ToString());
					 item->SubItems->Add(subItem);
					 listView1->Items->Add(item);
				 }

				 listView1->Items[0]->SubItems->Add("   g1  = ");
				 listView1->Items[1]->SubItems->Add("   g2  = ");
				 listView1->Items[2]->SubItems->Add("   g3  = ");
				 listView1->Items[3]->SubItems->Add("   g4  = ");

				 listView1->Items[0]->SubItems->Add(g1.ToString());
				 listView1->Items[1]->SubItems->Add(g2.ToString());
				 listView1->Items[2]->SubItems->Add(g3.ToString());
				 listView1->Items[3]->SubItems->Add(g4.ToString());

				 listView1->AutoResizeColumns(ColumnHeaderAutoResizeStyle::HeaderSize);				 
			 }
		 }
};
}
