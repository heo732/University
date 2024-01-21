interface Car {
    void drive();
}

class Toyota implements Car {
    public void drive() {
        System.out.println("drive Toyota");
    }
}

class Audi implements Car {
    public void drive() {
        System.out.println("drive Audi");
    }
}

class CarFactory implements Factory {
    public Car createCar(String typeOfCar) {
        switch (typeOfCar) {
            case "Toyota" : return new Toyota();
            case "Audi" : return new Audi();
            default : return null;
        }
    }

    public Tank createTank(String typeOfTank) {
        return null;
    }
}

interface Tank {
    void drive();
}

class T34 implements Tank {
    @Override
    public void drive() {
        System.out.println("drive T34");
    }
}

class T150 implements Tank {
    @Override
    public void drive() {
        System.out.println("drive T150");
    }
}

class TankFactory implements Factory {
    public Tank createTank(String typeOfTank) {
        switch (typeOfTank) {
            case "T34" : return new T34();
            case "T150" : return new T150();
            default : return null;
        }
    }

    public Car createCar(String typeOfCar) {
        return null;
    }
}

interface Factory {
    Car createCar(String typeOfCar);
    Tank createTank(String typeOfTank);
}

class AbstractFactory {
    Factory createFactory(String typeOfFactory) {
        switch (typeOfFactory) {
            case "Car" : return new CarFactory();
            case "Tank" : return new TankFactory();
            default : return null;
        }
    }
}