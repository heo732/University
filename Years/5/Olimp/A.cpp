#include <iostream>

using namespace std;
int main()
{
 char line1[10] = {'q','w','e','r','t','y','u','i','o','p'};
 char line2[9] = {'a','s','d','f','g','h','j','k','l' };
 char line3[7] = { 'z','x','c','v','b','n','m' };
 int n;
 cin >> n;
 char arr1[1000];
 char arr2[1000];
 for (int i = 0; i < n; i++)
 {
  cin >> arr1[i];
  cin >> arr2[i];
 }
 for (int i = 0; i < n; i++)
 {
  int k = 0, y = 0;
  for (int j = 0; j < 10; j++)
  {
   if (arr1[i] == line1[j])
   {
    k = 1;
   }
   if (arr2[i] == line1[j])
   {
    y = 1;
   }
  }
  for (int j = 0; j < 9; j++)
  {
   if (arr1[i] == line2[j])
   {
    k = 2;
   }
   if (arr2[i] == line2[j])
   {
    y = 2;
   }
  }
  for (int j = 0; j < 7; j++)
  {
   if (arr1[i] == line3[j])
   {
    k = 3;
   }
   if (arr2[i] == line3[j])
   {
    y = 3;
   }
  }
  cout << (k == y ? "Yes" : "No") << endl;
 }
    return 0;
}