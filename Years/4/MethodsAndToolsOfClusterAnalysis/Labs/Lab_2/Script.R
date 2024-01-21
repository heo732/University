# 1

mu1 = c(1, 1);
mu2 = c(1, -9);
mu3 = c(-7, -2);

cov1 = rbind(c(1, 1), c(1, 2));
cov2 = rbind(c(1, -1), c(-1, 2));
cov3 = rbind(c(2, 0.5), c(0.5, 0.3));

N = 100;

x1 = MASS::mvrnorm(n = N, mu = mu1, Sigma = cov1);
x2 = MASS::mvrnorm(n = N, mu = mu2, Sigma = cov2);
x3 = MASS::mvrnorm(n = N, mu = mu3, Sigma = cov3);

par(mar = c(5, 5, 5, 5), xpd = TRUE);
plot(NULL, xlim = c(-11, 5), ylim = c(-13, 5),
    xlab = "Перша координата", ylab = "Друга координата");
rect(par("usr")[1], par("usr")[3], par("usr")[2], par("usr")[4], col = "gray");
grid(lty = 1, col = "white");
lines(x1, type = "p", col = "red", pch = 20);
lines(x2, type = "p", col = "green", pch = 20);
lines(x3, type = "p", col = "blue", pch = 20);
legend("right", inset = c(-0.2, 0), legend = c("1", "2", "3"),
    col = c("red", "green", "blue"), pch = 20, title = "group",
    box.lty = 0, border = 0);

#=====================================================================================

# 2

V = data.frame(c(x1[, 1], x2[, 1], x3[, 1]),
               c(x1[, 2], x2[, 2], x3[, 2]));

A1 = kmeans(V, centers = 3, iter.max = 10, nstart = 1);
A2 = kmeans(V, centers = 2, iter.max = 10, nstart = 1);
A3 = kmeans(V, centers = 4, iter.max = 10, nstart = 1);

plot(V, type = "p", col = A1$cluster);
lines(A1$centers, type = "p", col = "blue");

plot(V, type = "p", col = A2$cluster);
lines(A2$centers, type = "p", col = "blue");

plot(V, type = "p", col = A3$cluster);
lines(A3$centers, type = "p", col = "blue");

#=====================================================================================

# 3

H1 = hclust(dist(V, method = "euclidean"));

sub_grp = cutree(H1, k = 3);

table(sub_grp);
factoextra::fviz_cluster(list(data = V, cluster = sub_grp), geom = "point");

sub_grp1 = cutree(H1, k = 2);

table(sub_grp1);
factoextra::fviz_cluster(list(data = V, cluster = sub_grp1), geom = "point");

sub_grp2 = cutree(H1, k = 4);

table(sub_grp2);
factoextra::fviz_cluster(list(data = V, cluster = sub_grp2), geom = "point");

#=====================================================================================

# 4

V1 = V[1:5,];

d1 = dist(V1);
H2 = hclust(d1);
sub_grp3 = cutree(H2, k = 2);
table(sub_grp3);

hcd = ape::as.phylo(H2);
plot(hcd, type = "fan");

#=====================================================================================

# 5

t = table(A1$cluster, sub_grp);
t;
P = combinat::permn(1:3);
P;
for (i in 6)
{

    t1 = t[, P[[i]]];
    AC = sum(diag(t1)) / sum(t1) * 100;
}
AC;