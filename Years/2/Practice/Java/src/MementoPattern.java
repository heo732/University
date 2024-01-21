class CareTaker {
    Memento memento;

    public Memento getMemento() {
        return memento;
    }

    public void setMemento(Memento memento) {
        this.memento = memento;
    }
}

class  Originator {
    String state;

    public String getState() { return state; }

    public void setState(String state) { this.state = state; }

    Memento createMemento() {
        return new Memento(state);
    }

    void getDataFromMemento(Memento memento) {
        this.state = memento.getState();
    }
}

class  Memento {
    String state;

    public Memento(String state) {
        this.state = state;
    }

    public String getState() { return state; }
}