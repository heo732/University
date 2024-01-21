function [r, a] = fun_1(x, y, z)
	if (nargin == 1)
		r = x;
		a = 1;
	end
	if (nargin == 2)
		r = x + y;
		a = 2;		
	end
	if (nargin == 3)
		r = x + y + z;
		a = 3;
	end