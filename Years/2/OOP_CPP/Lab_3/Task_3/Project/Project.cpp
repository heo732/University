// Project.cpp: ������� ���� �������.

#include "stdafx.h"
#include "FormMain.h"

using namespace Project;

[STAThreadAttribute]
int main(array<System::String ^> ^args)
{
	// ��������� ���������� �������� Windows XP �� �������� �����-���� ��������� ����������
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false); 

	// �������� �������� ���� � ��� ������
	Application::Run(gcnew FormMain());
	return 0;
}
