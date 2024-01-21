#include "FormMain.h"

using namespace System;
using namespace System::Windows::Forms;

void main()
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);

	Lab_7::FormMain formMain;
	Application::Run(%formMain);
}