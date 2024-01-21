#include "Student.h"
//-----------------------------------------------------------------------------------------
Student::Student()
{
	_lastName = "";
	_firstName = "";
	_secondName = "";
	_bornYear = 0;
	_marks[0] = _marks[1] = _marks[2] = _marks[3] = _marks[4] = 0;
}
//-----------------------------------------------------------------------------------------
Student::~Student()
{
}
//-----------------------------------------------------------------------------------------
Student& Student::operator = (Student other)
{
	_lastName = other._lastName;
	_firstName = other._firstName;
	_secondName = other._secondName;
	_bornYear = other._bornYear;
	for (int i = 0; i < 5; i++)
	{
		_marks[i] = other._marks[i];
	}
	
	return *this;
}
//-----------------------------------------------------------------------------------------
ofstream& operator << (ofstream& outFile, Student student)
{	
	/*outFile << student._lastName << "\t" << student._firstName << "\t" << student._secondName
		<< "\t" << student._bornYear << "\t" << student._marks[0] << "\t" << student._marks[1]
		<< "\t" << student._marks[2] << "\t" << student._marks[3] << "\t" << student._marks[4];
	*/
	//outFile.width(20);
	outFile << setw(15) << left << student._lastName << "\t" 
		<< setw(15) << left << student._firstName << "\t" 
		<< setw(15) << left << student._secondName << "\t" 
		<< setw(10) << left << student._bornYear << "\t" 
		<< setw(10) << left << student._marks[0] << "\t" 
		<< setw(10) << left << student._marks[1] << "\t" 
		<< setw(10) << left << student._marks[2] << "\t" 
		<< setw(10) << left << student._marks[3] << "\t" 
		<< setw(10) << left << student._marks[4];
		
	return outFile;
}
//-----------------------------------------------------------------------------------------
int Student::compareBy_SecondName(Student other)
{
	System::String^ _this = gcnew System::String(_secondName.c_str());
	System::String^ _other = gcnew System::String(other._secondName.c_str());
	return _this->CompareTo(_other);
}
//-----------------------------------------------------------------------------------------
Student getRandomStudent
	(
	vector<string> &LastName, 
	vector<string> &FirstNameMale, vector<string> &FirstNameFemale,
	vector<string> &SecondNameMale, vector<string> &SecondNameFemale,
	Random^ random
	)
{
	Student student;
	
	student._lastName = LastName[random->Next(LastName.size())];

	if(random->Next(2) == 0)
	{
		student._firstName = FirstNameFemale[random->Next(FirstNameFemale.size())];
		student._secondName = SecondNameFemale[random->Next(SecondNameFemale.size())];
	}
	else
	{
		student._firstName = FirstNameMale[random->Next(FirstNameMale.size())];
		student._secondName = SecondNameMale[random->Next(SecondNameMale.size())];
	}

	student._bornYear = random->Next(1995, 2001);

	for (int i = 0; i < 5; i++)
	{
		student._marks[i] = random->Next(50, 101);
	}

	return student;
}
//-----------------------------------------------------------------------------------------
void ReadFromFileInVector(string _fileName, vector<string> &_vec)
{
	ifstream inFile;

	inFile.open(_fileName);
	while(!inFile.eof())
	{
		string next;
		inFile >> next;
		_vec.push_back(next);
	}
	inFile.close();
}
//-----------------------------------------------------------------------------------------
void sortBy_SecondName(vector<Student>& _vector)
{
    unsigned int iMin;
    	
	for(unsigned int i = 0; i < _vector.size()-1; i++)
	{
    	iMin = i;
    	for(unsigned int j = i+1; j < _vector.size(); j++)
			if(_vector[iMin].compareBy_SecondName(_vector[j]) > 0)
				iMin = j;
    	Student temp = _vector[iMin];
    	_vector[iMin] = _vector[i];
    	_vector[i] = temp;
	}
}
//-----------------------------------------------------------------------------------------
void rsortBy_SecondName(vector<Student>& _vector)
{
    unsigned int iMin;
    	
	for(unsigned int i = 0; i < _vector.size()-1; i++)
	{
    	iMin = i;
    	for(unsigned int j = i+1; j < _vector.size(); j++)
			if(_vector[iMin].compareBy_SecondName(_vector[j]) < 0)
				iMin = j;
    	Student temp = _vector[iMin];
    	_vector[iMin] = _vector[i];
    	_vector[i] = temp;
	}
}
//-----------------------------------------------------------------------------------------