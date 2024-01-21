#include <iostream>
#include <string>

using namespace std;
bool  eqw = false;
string S2;
/*void print(string A, int size)
{
  cout << A << endl;
}*/
void swap(int &x, int &y)
{
  int tmp = x;
  x = y;
  y = tmp;
}
void next_perm(int k1, int k2, string A, int size, int depth)
{
  //print(A, size);
  for (int i = k1; i <= (k2 + k1) / 2; i++)
  {
    swap(A[k2 - (i - k1)], A[i]);
    //next_perm(k + 1, A, size);
    //swap(A[k], A[i]);

  }
  if (A == S2 || eqw == true)
  {
    eqw = true;
    return;
  }
  //print(A, size);
  //if (depth >= 4 || k1 >= size - 1 || k2<=0 || k1 >= k2)
  if ((depth < 4) /*&& (k1 < (size - 1)) && (k2 > 0) && (k1 < k2)*/)
  {
    /*for (int i = 0; i < size ; i++)
      next_perm(i, k2, A, size, depth + 1);
    for (int i = size-1; i > 0; i--)
      next_perm(k1, i, A, size, depth + 1);*/
    for (int i = 0 +1; i < size - 1; i++)
      for (int j = size - 1 -1; j > i; j--)
        next_perm(i, j, A, size, depth + 1);
    
  }
  
  return;
  
  
}
int main()
{
  string S1;
  cin >> S1 >> S2;
  //const int n = S.length();
  //int *a = new int[n];
  int N1 = S1.length();
  int N2 = S2.length();
  //print(S1, N1);
  next_perm(0, N1-1, S1, N1, 0); 
  if (eqw == true)
  {
    cout << "Yes";
  }
  else {
    
    for (int i = 0; i < N1/2; i++)
    {
      swap(S1[N1-1 - (i - 0)], S1[i]);
    }
  
    next_perm(0, N1 - 1, S1, N1, 0);
    if (eqw == true)
      cout << "Yes";
    else 
      cout << "No";
  }
  
  //print(S1, N1);
  //system("pause");
  return 0;
}