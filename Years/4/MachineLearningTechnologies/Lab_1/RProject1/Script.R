d <- iris
describe(d)

p <- iris$Sepal.Width
# середнє
m1 <- mean(p)
# медіана
m2 <- median(p)
# стандартне відхилення
var <- sd(p)
# функція обчслення моди
getmode <- function(v) {
    uniqv <- unique(v)
    uniqv[which.max(tabulate(match(v, uniqv)))]
}
# мода
m3 <- getmode(p)

x <- seq(0, 12, by = 0.1)
# емпірична функція розподілу
plot(ecdf(p))
# графік функції розподілу
lines(x, pnorm(x, m1, var), type = "l", col = "red")
# щільність розподілу
plot(p, dnorm(p, mean = 5, sd = 0.8), col = "black")
# гістограма
hist(p)

# 6
IF <- ifelse(p < m1, -1, ifelse(p > m1, 1, 0))

y <- seq(0, 15, by = 0.2)
# функція рівномірного розподілу
plot(y, punif(y, 1, 5), type = "l", col = "red")
lines(y, punif(y, min = 2, max = 7), col = "black")
lines(y, punif(y, min = 3, max = 10), col = "green")
# щільність розподілу
plot(y, dunif(y, min = 1, max = 5), type = "l", col = "red")
lines(y, dunif(y, min = 2, max = 7), col = "black")
lines(y, dunif(y, min = 3, max = 10), col = "green")



# генеруємо рівномірний розподіл
rivn <- runif(500, min = 1, max = 15)
# емпірична функція розподілу
plot(ecdf(rivn))
lines(rivn, punif(rivn, min = 1, max = 15), col = "red")
# щільність
plot(rivn, dunif(rivn, min = 1, max = 15), col = "red")