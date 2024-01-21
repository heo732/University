GetDistance = function(x, y, method = 'Euclidean', p = NA, W = NA)
{
    return(switch(method,
        'Euclidean' = sqrt(sum((x - y) ^ 2)),
        'Minkowski' = (sum(abs(x - y) ^ p)) ^ (1 / p),
        'Manhattan' = sum(abs(x - y)),
        'Chebyshev' = max(abs(x - y)),
        'Mahalonobis' = t(x - y) %*% W %*% (x - y)));
}

GetDistanceMatrix = function(X, method = 'Euclidean', p = NA, W = NA)
{
    N = dim(X)[1];
    result = matrix(NA, nrow = N, ncol = N);
    for (i in 1:N)
    {
        for (j in 1:N)
        {
            result[i, j] = GetDistance(X[i,], X[j,], method, p, W);
        }
    }
    return(result);
}

GetSimilarityMatrix = function(X)
{
    N = dim(X)[1];

    result = matrix(NA, nrow = N, ncol = N);
    for (i in 1:N)
    {
        M = max(X[i,]);
        m = min(X[i,]);
        result[i,] = 1 - (X[i,] - m) / (M - m);
    }

    return(result);
}

testMatrix_1 = matrix(c(1, 0, 0, 1, 1, 2, 7, 5, 2), nrow = 3, ncol = 3, byrow = TRUE);
print('==================================================================');
print('Test matrix 1:');
print(testMatrix_1);
print('==================================================================');
print('Distance matrix:');
distanceMatrix = GetDistanceMatrix(testMatrix_1);
print(distanceMatrix);
print('==================================================================');
print('Similarity matrix:');
print(GetSimilarityMatrix(distanceMatrix));
print('==================================================================');


testMatrix_2 = matrix(rexp(20, rate = 0.5), 10, 2);
testMatrix_2 = testMatrix_2[order(testMatrix_2[,2]),];
print('Test matrix 2:');
print(testMatrix_2);
plot(testMatrix_2);
print('==================================================================');
print('Distance matrix:');
print(GetDistanceMatrix(testMatrix_2, 'Chebyshev'));