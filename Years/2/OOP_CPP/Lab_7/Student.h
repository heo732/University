#include <string>
#include <vector>
#include <fstream>
#include <iomanip>
using namespace std;
using namespace System;

class Student
{

public:

	string _lastName;
	string _firstName;
	string _secondName;
	unsigned int _bornYear;
	unsigned short _marks[5];

	Student();
	~Student();

	Student& operator = (Student);

	friend ofstream& operator << (ofstream&, Student);

	int compareBy_SecondName(Student);
};
//-----------------------------------------------------------------------------------------
Student getRandomStudent(vector<string>&, vector<string>&, vector<string>&, vector<string>&, vector<string>&, Random^);
void ReadFromFileInVector(string, vector<string>&);
//-----------------------------------------------------------------------------------------
void sortBy_SecondName(vector<Student>&);
void rsortBy_SecondName(vector<Student>&);
//-----------------------------------------------------------------------------------------