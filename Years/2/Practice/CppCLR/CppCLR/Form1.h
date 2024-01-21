#pragma once

#include "Figure.h"

namespace CppCLR {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections::Generic;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{

		List<Figure^>^ figureList = gcnew List<Figure^>();
	private: System::Windows::Forms::ColorDialog^  colorDialog1;
	private: System::Windows::Forms::PictureBox^  pictureBox2;
			 Random^ random = gcnew Random();

	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Panel^  panel1;
	private: System::Windows::Forms::PictureBox^  pictureBox1;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::GroupBox^  groupBox1;
	private: System::Windows::Forms::RadioButton^  radioButton4;
	private: System::Windows::Forms::RadioButton^  radioButton3;
	private: System::Windows::Forms::RadioButton^  radioButton2;
	private: System::Windows::Forms::RadioButton^  radioButton1;

	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::MaskedTextBox^  maskedTextBox1;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::ComboBox^  comboBox1;
	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::Button^  button3;
	protected:		

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->pictureBox2 = (gcnew System::Windows::Forms::PictureBox());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->comboBox1 = (gcnew System::Windows::Forms::ComboBox());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->maskedTextBox1 = (gcnew System::Windows::Forms::MaskedTextBox());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->radioButton4 = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton3 = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton2 = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton1 = (gcnew System::Windows::Forms::RadioButton());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			this->colorDialog1 = (gcnew System::Windows::Forms::ColorDialog());
			this->panel1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox2))->BeginInit();
			this->groupBox1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
			this->SuspendLayout();
			// 
			// panel1
			// 
			this->panel1->Controls->Add(this->pictureBox2);
			this->panel1->Controls->Add(this->button3);
			this->panel1->Controls->Add(this->comboBox1);
			this->panel1->Controls->Add(this->button2);
			this->panel1->Controls->Add(this->maskedTextBox1);
			this->panel1->Controls->Add(this->label3);
			this->panel1->Controls->Add(this->label2);
			this->panel1->Controls->Add(this->textBox1);
			this->panel1->Controls->Add(this->label1);
			this->panel1->Controls->Add(this->groupBox1);
			this->panel1->Controls->Add(this->button1);
			this->panel1->Dock = System::Windows::Forms::DockStyle::Right;
			this->panel1->Location = System::Drawing::Point(564, 0);
			this->panel1->MaximumSize = System::Drawing::Size(220, 511);
			this->panel1->MinimumSize = System::Drawing::Size(220, 511);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(220, 511);
			this->panel1->TabIndex = 0;
			// 
			// pictureBox2
			// 
			this->pictureBox2->BackColor = System::Drawing::Color::RoyalBlue;
			this->pictureBox2->Location = System::Drawing::Point(14, 247);
			this->pictureBox2->Name = L"pictureBox2";
			this->pictureBox2->Size = System::Drawing::Size(194, 20);
			this->pictureBox2->TabIndex = 11;
			this->pictureBox2->TabStop = false;
			this->pictureBox2->Click += gcnew System::EventHandler(this, &Form1::pictureBox2_Click);
			// 
			// button3
			// 
			this->button3->Location = System::Drawing::Point(14, 453);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(194, 46);
			this->button3->TabIndex = 10;
			this->button3->Text = L"Очистити";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &Form1::button3_Click);
			// 
			// comboBox1
			// 
			this->comboBox1->AutoCompleteMode = System::Windows::Forms::AutoCompleteMode::Suggest;
			this->comboBox1->FormattingEnabled = true;
			this->comboBox1->Location = System::Drawing::Point(14, 389);
			this->comboBox1->Name = L"comboBox1";
			this->comboBox1->Size = System::Drawing::Size(194, 21);
			this->comboBox1->TabIndex = 9;
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(14, 359);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(194, 23);
			this->button2->TabIndex = 8;
			this->button2->Text = L"Видалити";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &Form1::button2_Click);
			// 
			// maskedTextBox1
			// 
			this->maskedTextBox1->Location = System::Drawing::Point(14, 294);
			this->maskedTextBox1->Mask = L"0999";
			this->maskedTextBox1->Name = L"maskedTextBox1";
			this->maskedTextBox1->Size = System::Drawing::Size(194, 20);
			this->maskedTextBox1->TabIndex = 7;
			this->maskedTextBox1->Text = L"30";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(11, 277);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(39, 13);
			this->label3->TabIndex = 6;
			this->label3->Text = L"Радіус";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(11, 230);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(34, 13);
			this->label2->TabIndex = 4;
			this->label2->Text = L"Колір";
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(14, 203);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(194, 20);
			this->textBox1->TabIndex = 3;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(11, 187);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(37, 13);
			this->label1->TabIndex = 2;
			this->label1->Text = L"Текст";
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->radioButton4);
			this->groupBox1->Controls->Add(this->radioButton3);
			this->groupBox1->Controls->Add(this->radioButton2);
			this->groupBox1->Controls->Add(this->radioButton1);
			this->groupBox1->Location = System::Drawing::Point(14, 65);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(194, 114);
			this->groupBox1->TabIndex = 1;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Фігура";
			// 
			// radioButton4
			// 
			this->radioButton4->AutoSize = true;
			this->radioButton4->Location = System::Drawing::Point(6, 89);
			this->radioButton4->Name = L"radioButton4";
			this->radioButton4->Size = System::Drawing::Size(52, 17);
			this->radioButton4->TabIndex = 3;
			this->radioButton4->TabStop = true;
			this->radioButton4->Text = L"Зірка";
			this->radioButton4->UseVisualStyleBackColor = true;
			this->radioButton4->CheckedChanged += gcnew System::EventHandler(this, &Form1::radioButton4_CheckedChanged);
			// 
			// radioButton3
			// 
			this->radioButton3->AutoSize = true;
			this->radioButton3->Location = System::Drawing::Point(6, 66);
			this->radioButton3->Name = L"radioButton3";
			this->radioButton3->Size = System::Drawing::Size(141, 17);
			this->radioButton3->TabIndex = 2;
			this->radioButton3->TabStop = true;
			this->radioButton3->Text = L"Правильний трикутник";
			this->radioButton3->UseVisualStyleBackColor = true;
			this->radioButton3->CheckedChanged += gcnew System::EventHandler(this, &Form1::radioButton3_CheckedChanged);
			// 
			// radioButton2
			// 
			this->radioButton2->AutoSize = true;
			this->radioButton2->Location = System::Drawing::Point(6, 43);
			this->radioButton2->Name = L"radioButton2";
			this->radioButton2->Size = System::Drawing::Size(67, 17);
			this->radioButton2->TabIndex = 1;
			this->radioButton2->TabStop = true;
			this->radioButton2->Text = L"Квадрат";
			this->radioButton2->UseVisualStyleBackColor = true;
			this->radioButton2->CheckedChanged += gcnew System::EventHandler(this, &Form1::radioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this->radioButton1->AutoSize = true;
			this->radioButton1->Checked = true;
			this->radioButton1->Location = System::Drawing::Point(6, 19);
			this->radioButton1->Name = L"radioButton1";
			this->radioButton1->Size = System::Drawing::Size(50, 17);
			this->radioButton1->TabIndex = 0;
			this->radioButton1->TabStop = true;
			this->radioButton1->Text = L"Коло";
			this->radioButton1->UseVisualStyleBackColor = true;
			this->radioButton1->CheckedChanged += gcnew System::EventHandler(this, &Form1::radioButton1_CheckedChanged);
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(14, 12);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(194, 46);
			this->button1->TabIndex = 0;
			this->button1->Text = L"Додати";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// pictureBox1
			// 
			this->pictureBox1->BackColor = System::Drawing::Color::White;
			this->pictureBox1->Dock = System::Windows::Forms::DockStyle::Fill;
			this->pictureBox1->Location = System::Drawing::Point(0, 0);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(564, 511);
			this->pictureBox1->TabIndex = 1;
			this->pictureBox1->TabStop = false;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(784, 511);
			this->Controls->Add(this->pictureBox1);
			this->Controls->Add(this->panel1);
			this->Name = L"Form1";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"C++/CLR";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->panel1->ResumeLayout(false);
			this->panel1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox2))->EndInit();
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void button3_Click(System::Object^  sender, System::EventArgs^  e) 
	{
		Bitmap^ bmp = gcnew Bitmap(pictureBox1->Width, pictureBox1->Height);
		Graphics::FromImage(bmp)->Clear(Color::White);
		pictureBox1->Image = bmp;
		figureList->Clear();

		comboBox1->Items->Clear();
		comboBox1->Text = "";
	}
	
	private: System::Void radioButton1_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
	{
		if (radioButton1->Checked)
			label3->Text = "Радіус";
	}

	private: System::Void radioButton2_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
	{
		if (radioButton2->Checked)
			label3->Text = "Сторона";
	}

	private: System::Void radioButton3_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
	{
		if (radioButton3->Checked)
			label3->Text = "Сторона";
	}

	private: System::Void radioButton4_CheckedChanged(System::Object^  sender, System::EventArgs^  e) 
	{
		if (radioButton4->Checked)
			label3->Text = "Сторона";
	}

	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) 
	{
		//
	}

	private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) 
	{
		if (comboBox1->Items->Contains(comboBox1->Text))
		{
			String^ index = "";

			int i = 0;
			while (comboBox1->Text[i] != ' ')
			{
				index += comboBox1->Text[i];
				i++;	
			}

			figureList->RemoveAt(Convert::ToInt32(index));

			comboBox1->Items->Clear();
			comboBox1->Text = "";
			for (int j = 0; j < figureList->Count; j++)
			{
				comboBox1->Items->Add(j.ToString() + " " + figureList[j]->GetType() + " " + figureList[j]->color.ToString() + " " + figureList[j]->text);
			}
			if (comboBox1->Items->Count > 0)
				comboBox1->Text = comboBox1->Items[comboBox1->Items->Count - 1]->ToString();

			Bitmap^ bmp = gcnew Bitmap(pictureBox1->Width, pictureBox1->Height);
			Graphics::FromImage(bmp)->Clear(Color::White);
			pictureBox1->Image = bmp;

			for each(auto item in figureList)
			{
				item->DrawToPictureBox(pictureBox1);
			}
		}
	}	

	private: System::Void pictureBox2_Click(System::Object^  sender, System::EventArgs^  e) 
	{
		if (colorDialog1->ShowDialog() == System::Windows::Forms::DialogResult::OK)
		{
			pictureBox2->BackColor = colorDialog1->Color;
		}
	}

	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) 
	{
		if (!maskedTextBox1->MaskCompleted)
			MessageBox::Show("Заповніть вірно поле " + (radioButton1->Checked ? "'Радіус'" : "'Сторона'"), "Помилка", MessageBoxButtons::OK, MessageBoxIcon::Error);
		else
		{
			if (radioButton1->Checked)
			{
				figureList->Add(gcnew Circle(Convert::ToDouble(maskedTextBox1->Text), gcnew Point(random->Next(pictureBox1->Width), random->Next(pictureBox1->Height)), pictureBox2->BackColor, textBox1->Text));				
			}
			else if (radioButton2->Checked)
			{
				figureList->Add(gcnew Square(Convert::ToDouble(maskedTextBox1->Text), gcnew Point(random->Next(pictureBox1->Width), random->Next(pictureBox1->Height)), pictureBox2->BackColor, textBox1->Text));
			}
			else if (radioButton3->Checked)
			{
				figureList->Add(gcnew EquilateralTriangle(Convert::ToDouble(maskedTextBox1->Text), gcnew Point(random->Next(pictureBox1->Width), random->Next(pictureBox1->Height)), pictureBox2->BackColor, textBox1->Text));
			}
			else if (radioButton4->Checked)
			{
				figureList->Add(gcnew HexagonalStar(Convert::ToDouble(maskedTextBox1->Text), gcnew Point(random->Next(pictureBox1->Width), random->Next(pictureBox1->Height)), pictureBox2->BackColor, textBox1->Text));
			}

			figureList[figureList->Count - 1]->DrawToPictureBox(pictureBox1);

			comboBox1->Items->Clear();
			for (int i = 0; i < figureList->Count; i++)
			{
				comboBox1->Items->Add(i.ToString() + " " + figureList[i]->GetType() + " " + figureList[i]->color.ToString() + " " + figureList[i]->text);
			}
			comboBox1->Text = comboBox1->Items[comboBox1->Items->Count - 1]->ToString();
		}
	}

};
}
