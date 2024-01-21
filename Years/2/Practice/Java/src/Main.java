import java.io.IOException;

public class Main {
    public static void main(String[] args) {

        System.out.println("======================================================");
        System.out.println("Варiант №4");
        System.out.println("======================================================");
        System.out.println();
        System.out.println("======================================================");
        System.out.println("Abstract Factory");
        System.out.println("======================================================");


        Factory carFactory = new AbstractFactory().createFactory("Car");
        Factory tankFactory = new AbstractFactory().createFactory("Tank");

        Car toyota = carFactory.createCar("Toyota");
        Car audi = carFactory.createCar("Audi");

        toyota.drive();
        audi.drive();

        Tank t34 = tankFactory.createTank("T34");
        Tank t150 = tankFactory.createTank("T150");

        t34.drive();
        t150.drive();

        System.out.println("======================================================");
        System.out.println();

        System.out.println("======================================================");
        System.out.println("Facade");
        System.out.println("======================================================");

        FileReadFacade fileReadFacade = new FileReadFacade();
        try {
            System.out.println(fileReadFacade.readFile("temp.txt"));
        }
        catch (IOException ex) {
            System.out.println(ex.getMessage());
        }

        System.out.println("======================================================");
        System.out.println();

        System.out.println("======================================================");
        System.out.println("Memento");
        System.out.println("======================================================");

        Originator originator = new Originator();
        originator.setState("one");
        CareTaker careTaker = new CareTaker();
        careTaker.setMemento(originator.createMemento());
        originator.setState("two");
        originator.getDataFromMemento(careTaker.getMemento());
        System.out.println(originator.getState());

        System.out.println("======================================================");
    }
}