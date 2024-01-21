#include <iostream>

using namespace std;
int main()
{
 int x1, x2, x3, y1, y2, y3;
 cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3;
 int maxx = x1, minx = x1;
 int maxy = y1, miny = y1;
 if (x2 > maxx) maxx = x2;
 if (x3 > maxx) maxx = x3;
 if (x2 < minx) minx = x2;
 if (x3 < minx) minx = x3;
 if (y2 > maxy) maxy = y2;
 if (y3 > maxy) maxy = y3;
 if (y2 < miny) miny = y2;
 if (y3 < miny) miny = y3;
 cout << maxx - minx - 1 + maxy - miny - 1;
    return 0;
}