import javax.swing.*;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;
import java.util.Random;

public class JFrame1 extends JFrame
{
    JMenuBar menuBar;
    JMenu menu;
    JMenuItem menuItem1, menuItem2;
    JPanel panelContent, panel1, panel2;

    JTextField textFieldSpeed;
    JLabel labelSpeed;
    JTextField textFieldTimeDirection;
    JLabel labelTimeDirection1;
    JLabel labelTimeDirection2;
    JLabel labelTimeDirection3;

    ArrayList<Thread> albinoesThreads = new ArrayList<Thread>();
    ArrayList<Thread> rabbitsThreads = new ArrayList<Thread>();
    //ArrayList<Thread> changeDirectionOfRabbitsThreads = new ArrayList<Thread>();
    ArrayList<Albino> albinoes = new ArrayList<Albino>();
    ArrayList<Rabbit> rabbits = new ArrayList<Rabbit>();
    //ArrayList<ChangeDirectionOfRabbit> changeDirectionOfRabbits = new ArrayList<ChangeDirectionOfRabbit>();

    private Random random;

    public JFrame1()
    {
        random = new Random();

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(800, 600);
        setTitle("Java  |  Lab_7  |  Var_4");
        setLocationByPlatform(true);
        this.setVisible(true);

        panelContent = new JPanel(new CardLayout());
        panelContent.setVisible(true);
        this.add(panelContent);

        //Panel1 with components
        panel1 = new JPanel();
        panel1.setLayout(null);
        panel1.setVisible(true);
        panel1.setSize(panelContent.getSize());
        panel1.setBackground(Color.WHITE);
        panelContent.add(panel1);

        labelSpeed = new JLabel("Швидкість");
        labelSpeed.setSize(70, 30);
        labelSpeed.setLocation(10, 20);
        panel1.add(labelSpeed);

        textFieldSpeed = new JTextField("50");
        textFieldSpeed.setSize(70, 30);
        textFieldSpeed.setLocation(10, 45);
        textFieldSpeed.setHorizontalAlignment(JTextField.CENTER);
        textFieldSpeed.setBackground(Color.getHSBColor(0.1f,0.005f, 0.9f));
        textFieldSpeed.setBorder(BorderFactory.createLineBorder(Color.BLACK, 1));
        textFieldSpeed.getDocument().addDocumentListener(new DocumentListener() {
            @Override
            public void insertUpdate(DocumentEvent e) {
                try{
                    int value = Integer.parseInt(textFieldSpeed.getText());
                    if (value > 0) {
                        for (Albino i : albinoes) {
                            i.setSpeed(value);
                        }
                        for (Rabbit i : rabbits) {
                            i.setSpeed(value);
                        }
                    }
                } catch (NumberFormatException ex) {}
            }

            @Override
            public void removeUpdate(DocumentEvent e) {
                try{
                    int value = Integer.parseInt(textFieldSpeed.getText());
                    if (value > 0) {
                        for (Albino i : albinoes) {
                            i.setSpeed(value);
                        }
                        for (Rabbit i : rabbits) {
                            i.setSpeed(value);
                        }
                    }
                } catch (NumberFormatException ex) {}
            }

            @Override
            public void changedUpdate(DocumentEvent e) {
                try{
                    int value = Integer.parseInt(textFieldSpeed.getText());
                    if (value > 0) {
                        for (Albino i : albinoes) {
                            i.setSpeed(value);
                        }
                        for (Rabbit i : rabbits) {
                            i.setSpeed(value);
                        }
                    }
                } catch (NumberFormatException ex) {}
            }
        });
        panel1.add(textFieldSpeed);

        labelTimeDirection1 = new JLabel("Змінювати випадковий напрям");
        labelTimeDirection1.setSize(200, 30);
        labelTimeDirection1.setLocation(10, 90);
        panel1.add(labelTimeDirection1);

        labelTimeDirection2 = new JLabel("руху кроликів кожні");
        labelTimeDirection2.setSize(200, 30);
        labelTimeDirection2.setLocation(10, 105);
        panel1.add(labelTimeDirection2);

        textFieldTimeDirection = new JTextField("3");
        textFieldTimeDirection.setSize(70, 30);
        textFieldTimeDirection.setLocation(10, 130);
        textFieldTimeDirection.setHorizontalAlignment(JTextField.CENTER);
        textFieldTimeDirection.setBackground(Color.getHSBColor(0.1f,0.005f, 0.9f));
        textFieldTimeDirection.setBorder(BorderFactory.createLineBorder(Color.BLACK, 1));
        textFieldTimeDirection.getDocument().addDocumentListener(new DocumentListener() {
            @Override
            public void insertUpdate(DocumentEvent e) {
                try {
                    int value = Integer.parseInt(textFieldTimeDirection.getText());
                    if (value > 0)
                        for (Rabbit i : rabbits)
                            i.setTimeDirection(value);
                } catch (NumberFormatException ex) {}
            }

            @Override
            public void removeUpdate(DocumentEvent e) {
                try {
                    int value = Integer.parseInt(textFieldTimeDirection.getText());
                    if (value > 0)
                        for (Rabbit i : rabbits)
                            i.setTimeDirection(value);
                } catch (NumberFormatException ex) {}
            }

            @Override
            public void changedUpdate(DocumentEvent e) {
                try {
                    int value = Integer.parseInt(textFieldTimeDirection.getText());
                    if (value > 0)
                        for (Rabbit i : rabbits)
                            i.setTimeDirection(value);
                } catch (NumberFormatException ex) {}
            }
        });
        panel1.add(textFieldTimeDirection);

        labelTimeDirection3 = new JLabel("секунд (и)");
        labelTimeDirection3.setSize(70, 30);
        labelTimeDirection3.setLocation(85, 130);
        panel1.add(labelTimeDirection3);

        //Albinoes and Rabbits
        for (int i = 0; i < 10; i++) {

            albinoes.add(new Albino(panel1, random, 50, 60, 40));
            albinoesThreads.add(new Thread(albinoes.get(albinoes.size() - 1)));
            albinoesThreads.get(albinoesThreads.size() - 1).start();

            try{
                Thread.sleep(200 + random.nextInt(801));
            } catch (Exception ex) {}

            rabbits.add(new Rabbit(panel1, random, 50, 70, 70, 3));
            rabbitsThreads.add(new Thread(rabbits.get(rabbits.size() - 1)));
            rabbitsThreads.get(rabbitsThreads.size() - 1).start();

            //changeDirectionOfRabbits.add(new ChangeDirectionOfRabbit(rabbits.get(rabbits.size() - 1), random));
            //changeDirectionOfRabbitsThreads.add(new Thread(changeDirectionOfRabbits.get(changeDirectionOfRabbits.size() - 1)));
            //changeDirectionOfRabbitsThreads.get(changeDirectionOfRabbitsThreads.size() - 1).start();

        }



        //Panel2 with components
        GridBagLayout gridBagLayout = new GridBagLayout();
        GridBagConstraints constraints = new GridBagConstraints();

        panel2 = new JPanel(gridBagLayout);
        panel2.setLayout(gridBagLayout);
        panel2.setVisible(false);
        panel2.setSize(panelContent.getSize());
        panelContent.add(panel2);

        panel2.setBackground(Color.RED);

        //MenuBar with components and events
        menuBar = new JMenuBar();

        menu = new JMenu("Завдання_1");
        menuBar.add(menu);

        menuItem1 = new JMenuItem("1");
        menuItem1.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                menu.setText("Завдання_1");
                panel1.setVisible(true);
                panel2.setVisible(false);
            }
        });
        menu.add(menuItem1);

        menuItem2 = new JMenuItem("2");
        menuItem2.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                menu.setText("Завдання_2");
                panel1.setVisible(false);
                panel2.setVisible(true);
            }
        });
        menu.add(menuItem2);

        this.setJMenuBar(menuBar);
        this.setVisible(true);
    }
}