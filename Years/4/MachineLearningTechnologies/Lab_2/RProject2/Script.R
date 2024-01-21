db <- read.csv(file = '../pima-indians-diabetes.csv')
print(db)
dbl <- db[(sample(nrow(db))),]
print(dbl)
dbl$X9 <- as.factor(dbl$X9)
train <- dbl[1:467,]
test <- dbl[468:767,]
levels(train$X9)
print(train)
model <- naiveBayes(X9 ~ ., data = train)
print(model)
pred <- predict(model, test)
table(pred)
table(test$X9)
table(test$X9, pred)