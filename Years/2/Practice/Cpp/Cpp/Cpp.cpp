#include <iostream>
#include <fstream>
#include <string>
#include <cmath>
#include <map>
#include <Windows.h>
//===============================================================
using namespace std;
//===============================================================
double x, y, z;
string text;
//===============================================================
namespace Algorithm2
{
	//===============================================================
	double T1(double x)
	{
		return atan(acos(sin(2 * x)));
	}
	//===============================================================
	double U1(double x)
	{
		return atan(asin(sin(3 * x)));
	}
	//===============================================================
	double Qqn1(double x, double y, double z)
	{
		return x / U1(x) + y * T1(y) - U1(z) * T1(z);
	}
	//===============================================================
	double Qnk1(double x, double y)
	{
		return 1.1 * Qqn1(x, y, x + y) - 0.9 * Qqn1(y, x, x - y);
	}
	//===============================================================
	double Rnk(double x, double y)
	{
		return x * Qnk1(x, y) + y * Qnk1(y, x) - 0.03 * Qnk1(x, y) * Qnk1(y, x);
	}
	//===============================================================
}
//===============================================================
namespace Algorithm3
{
	//===============================================================
	double T1(double x)
	{
		return atan(acos(sin(2 * x)));
	}
	//===============================================================
	double U1(double x)
	{
		return atan(asin(sin(3 * x)));
	}
	//===============================================================
	double Qqn2(double x, double y, double z)
	{
		return x / U1(x) + y * T1(y) - 0.9 * U1(z) * T1(z);
	}
	//===============================================================
	double Qnk2(double x, double y)
	{
		return 1.3 * Algorithm2::Qqn1(x, y, x) - 0.7 * Algorithm2::Qqn1(y, x, x);
	}
	//===============================================================
	double funk(double x, double y, double z)
	{
		return 1.75 * x * Qnk2(x, y) + 1.25 * y * Qnk2(y, x) - 1.5 * Qnk2(x, y) * Qnk2(y, x);
	}
	//===============================================================
}
//===============================================================
namespace Algorithm1
{
	//===============================================================
	double Gtext(string text)
	{
		map<string, double> table;

		try
		{
			ifstream fin;
			fin.open("dat3.dat");

			if (!fin.is_open())
				throw 1;

			while (!fin.eof())
			{
				string key;
				double value;
				fin >> key >> value;
				table.insert(pair<string, double>(key, value));
			}
			fin.close();
		}
		catch (...)
		{
			throw exception("Не вдалося відкрити файл 'dat3.dat'");
		}

		for (auto i : table)
			if (text.compare(i.first) == 0)
				return i.second;

		return 0;
	}
	//===============================================================
	double CText(double x, string text)
	{
		if (x > 0)
			return Gtext(text) + x;

		if (text.size() == 0)
			return Gtext("set") + Gtext("get") - x;

		if (x <= 0)
			return Gtext("set") + Gtext(text);

		return -1;
	}
	//===============================================================
	double f()
	{
		return CText(x, text);
	}
	//===============================================================
	double Max(double x, double y, double z, double u)
	{
		return max(x, max(y, max(z, u)));
	}
	//===============================================================
	double RText(double x, double y, double z, string text)
	{
		return CText(Max(x, y, x + z, y + z), text);
	}
	//===============================================================
	double k()
	{
		return RText(x, y, z, text);
	}
	//===============================================================	
	double T(double x)
	{
		map<double, double> table;

		try
		{
			ifstream fin;
			fin.open("dat2.dat");

			if (!fin.is_open())
				throw 64;

			while (!fin.eof())
			{
				double key, value;
				fin >> key >> value;
				table.insert(pair<double, double>(key, value));
			}
			fin.close();
		}
		catch (...)
		{
			throw 64;
		}

		if (abs(x) <= 10)
			throw 65;

		for (auto i : table)
			if (i.first == x)
				return i.second;

		for (auto i = table.begin(); i != table.end(); i++)
			if (x > (*i++).first)
				if (i != table.end() && x < (*i--).first)
				{
					double x_i = (*i++).first, x_iplus1 = (*i--).first;
					return T(x_i) + (T(x_iplus1) - T(x_i)) * (x - x_i) / (x_iplus1 - x_i);
				}
				else
					return T((*i++).first);

		return -1;
	}
	//===============================================================
	double U(double x)
	{
		map<double, double> table;

		try
		{
			ifstream fin;
			fin.open("dat1.dat");

			if (!fin.is_open())
				throw 61;

			while (!fin.eof())
			{
				double key, value;
				fin >> key >> value;
				table.insert(pair<double, double>(key, value));
			}
			fin.close();
		}
		catch (...)
		{
			throw 61;
		}

		if (abs(x) <= 5)
			throw 62;

		for (auto i : table)
			if (i.first == x)
				return i.second;

		for (auto i = table.begin(); i != table.end(); i++)
			if (x > (*i++).first)
				if (i != table.end() && x < (*i--).first)
				{
					double x_i = (*i++).first, x_iplus1 = (*i--).first;
					return U(x_i) + (U(x_iplus1) - U(x_i)) * (x - x_i) / (x_iplus1 - x_i);
				}
				else
					return U((*i++).first);

		return -1;
	}
	//===============================================================
	double Qqn(double x, double y, double z)
	{
		return x / U(x) + y * T(y) - U(z) * T(z);
	}
	//===============================================================
	double Qnk(double x, double y)
	{
		return Qqn(x, y, x + y) - Qqn(y, x, x - y);
	}
	//===============================================================
	double Rnk(double x, double y)
	{
		try 
		{
			return x * Qnk(x, y) + y * Qnk(y, x);
		}
		catch (int code)
		{
			if (code == 61 || code == 62 || code == 65)
				return Algorithm2::Rnk(x, y);
			else
				throw code;
		}		
	}
	//===============================================================
	double func(double x, double y, double z)
	{
		try
		{
			return Rnk(x, y) + Rnk(y, z) * Rnk(x, y);
		}
		catch (int code)
		{
			if (code == 64)
				return Algorithm3::funk(x, y, z);
			else
				throw code;
		}
	}	
	//===============================================================
	double r()
	{
		return func(x, y, z);
	}
	//===============================================================
	double Y(double x)
	{
		if (100 - pow(x, 2) < 0)
			throw 141;

		if (x * sqrt(100 - pow(x, 2)) < 1)
			throw 142;

		return log(x * sqrt(100 - pow(x, 2)));
	}
	//===============================================================
	double Yrr(double f, double r)
	{
		return Y(f) * r + 0.5 * Y(r);
	}
	//===============================================================
	double Trr(double f, double r)
	{
		if (4 * pow(f, 2) - r < 0)
			throw 121;
		return sqrt(4 * pow(f, 2) - r) + 0.5 * Yrr(r, f);
	}
	//===============================================================
	double Rrr(double f, double r)
	{
		return f * Trr(f, r) + r * Trr(f, 2 * k());
	}
	//===============================================================
	double k11()
	{
		try
		{
			return Rrr(f(), r());
		}
		catch (int code)
		{
			if (code == 121 || code == 141 || code == 142)
				return 0;
			else
				throw code;
		}
	}
	//===============================================================
	double Variant(double &r, double &k)
	{
		r = Algorithm1::r();
		k = Algorithm1::k11();
		return 0.8973 * r + 0.1027 * k;
	}
	//===============================================================
}
//===============================================================
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	system("title C++");

	cout << "Задача 4" << endl;
	cout << "===============================================================" << endl;

	try
	{
		double v = -1, r, k;

		cout << "Введіть текстовий рядок:  ";
		getline(cin, text);

		cout << "Введіть x, y та z розділені пробілом:  ";
		cin >> x >> y >> z;		

		v = Algorithm1::Variant(r, k);
		cout << "Variant(" << r << "," << k << ") = " << v << endl;
	}
	catch (exception ex)
	{
		cout << ex.what() << endl;
	}
	catch (...)
	{
		cout << "Something wrong." << endl;
	}

	cout << "===============================================================" << endl;
	system("pause");
	return 0;
}