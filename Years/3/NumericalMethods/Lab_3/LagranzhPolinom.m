function result = LagranzhPolinom(xVec, yVec, x)

if (length(xVec) ~= length(yVec))
	disp('Error: Nesumisni rozmiry vektoriv.') 
else
	n = length(xVec);
	sum = 0;
	
	for k = 1:n
		
		top = 1;
		if (k >= 2)
			for i = 1:k-1
				top = top * (x - xVec(i)); 
			end
		end
		if (k < n)
			for i = k+1:n
				top = top * (x - xVec(i));
			end
		end

		bottom = 1;
		if (k >= 2)
			for i = 1:k-1
				bottom = bottom * (xVec(k) - xVec(i));
			end
		end
		if (k < n)
			for i = k+1:n
				bottom = bottom * (xVec(k) - xVec(i));
			end
		end

		sum = sum + yVec(k) * top / bottom;

	end

	result = sum;
end