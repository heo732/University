import javax.swing.*;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.*;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

public class JFrame1 extends JFrame
{
    JMenuBar menuBar;
    JMenu menu;
    JMenuItem menuItem1, menuItem2;
    JPanel panelContent, panel1, panel2;

    JTextField textFieldMoveStepSize;
    JButton buttonMoveUp;
    JButton buttonMoveRight;
    JButton buttonMoveDown;
    JButton buttonMoveLeft;
    JLabel labelLength;
    JTextField textFieldLength;
    JLabel labelStroke;
    JTextField textFieldStroke;
    JCheckBox checkBoxModeRotating;
    JLabel labelRotateAngleByStep;
    JTextField textFieldRotateAngleByStep;
    JLabel labelTimeRotateStep;
    JTextField textFieldTimeRotateStep;

    JLabel labelSize;
    JButton buttonSizeDecrement;
    JButton buttonSizeIncrement;
    JLabel labelMatrix;
    JTable tableMatrix;
    JLabel labelVector;
    JTable tableVector;

    DefaultTableModel tableModelMatrix;
    DefaultTableModel tableModelVector;
    ArrayList<Double> doubleList = new ArrayList<Double>();

    private Random random;

    RotatingLine rotatingLine = new RotatingLine(new Point(400,260), 90, 3.0f, true, 3, -3, 50);
    Thread threadRotatingLine;

    public JFrame1()
    {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(800, 600);
        setTitle("Java  |  Lab_6  |  Var_4");
        setLocationByPlatform(true);

        FlowLayout flowLayout = new FlowLayout();

        panelContent = new JPanel(new CardLayout());
        panelContent.setVisible(true);
        this.add(panelContent);

        //Panel1 with components
        panel1 = new JPanel();
        panel1.setLayout(null);
        panel1.setVisible(true);
        panel1.setBackground(Color.WHITE);
        panelContent.add(panel1);

        textFieldMoveStepSize = new JTextField("30");
        textFieldMoveStepSize.setSize(30, 30);
        textFieldMoveStepSize.setLocation(50, 50);
        textFieldMoveStepSize.setHorizontalAlignment(JTextField.CENTER);
        textFieldMoveStepSize.setBackground(Color.getHSBColor(0.1f,0.005f, 0.9f));
        textFieldMoveStepSize.setBorder(BorderFactory.createLineBorder(Color.BLACK, 1));
        panel1.add(textFieldMoveStepSize);

        buttonMoveUp = new JButton("U");
        buttonMoveUp.setSize(30, 30);
        buttonMoveUp.setLocation(50, 10);
        buttonMoveUp.setHorizontalAlignment(JTextField.CENTER);
        buttonMoveUp.setMargin(new Insets(1,1,1,1));
        buttonMoveUp.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                try{
                    rotatingLine.position = new Point(rotatingLine.position.x, rotatingLine.position.y - Integer.parseInt(textFieldMoveStepSize.getText()));
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }
        });
        panel1.add(buttonMoveUp);

        buttonMoveRight = new JButton("R");
        buttonMoveRight.setSize(30, 30);
        buttonMoveRight.setLocation(90, 50);
        buttonMoveRight.setHorizontalAlignment(JTextField.CENTER);
        buttonMoveRight.setMargin(new Insets(1,1,1,1));
        buttonMoveRight.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                try{
                    rotatingLine.position = new Point(rotatingLine.position.x + Integer.parseInt(textFieldMoveStepSize.getText()), rotatingLine.position.y);
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }
        });
        panel1.add(buttonMoveRight);

        buttonMoveDown = new JButton("D");
        buttonMoveDown.setSize(30, 30);
        buttonMoveDown.setLocation(50, 90);
        buttonMoveDown.setHorizontalAlignment(JTextField.CENTER);
        buttonMoveDown.setMargin(new Insets(1,1,1,1));
        buttonMoveDown.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                try{
                    rotatingLine.position = new Point(rotatingLine.position.x, rotatingLine.position.y + Integer.parseInt(textFieldMoveStepSize.getText()));
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }
        });
        panel1.add(buttonMoveDown);

        buttonMoveLeft = new JButton("L");
        buttonMoveLeft.setSize(30, 30);
        buttonMoveLeft.setLocation(10, 50);
        buttonMoveLeft.setHorizontalAlignment(JTextField.CENTER);
        buttonMoveLeft.setMargin(new Insets(1,1,1,1));
        buttonMoveLeft.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                try{
                    rotatingLine.position = new Point(rotatingLine.position.x - Integer.parseInt(textFieldMoveStepSize.getText()), rotatingLine.position.y);
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }
        });
        panel1.add(buttonMoveLeft);

        labelLength = new JLabel("Довжина відрізку");
        labelLength.setSize(110, 30);
        labelLength.setLocation(10, 120);
        panel1.add(labelLength);

        textFieldLength = new JTextField("90.0");
        textFieldLength.setSize(110, 30);
        textFieldLength.setLocation(10, 145);
        textFieldLength.setHorizontalAlignment(JTextField.LEFT);
        textFieldLength.setBackground(Color.getHSBColor(0.1f,0.005f, 0.9f));
        textFieldLength.setBorder(BorderFactory.createLineBorder(Color.BLACK, 1));
        textFieldLength.getDocument().addDocumentListener(new DocumentListener() {
            @Override
            public void insertUpdate(DocumentEvent e) {
                try{
                    rotatingLine.length = Double.parseDouble(textFieldLength.getText());
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }

            @Override
            public void removeUpdate(DocumentEvent e) {
                try{
                    rotatingLine.length = Double.parseDouble(textFieldLength.getText());
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }

            @Override
            public void changedUpdate(DocumentEvent e) {
                try{
                    rotatingLine.length = Double.parseDouble(textFieldLength.getText());
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }
        });
        panel1.add(textFieldLength);

        labelStroke = new JLabel("Товщина лінії");
        labelStroke.setSize(110, 30);
        labelStroke.setLocation(10, 170);
        panel1.add(labelStroke);

        textFieldStroke = new JTextField("3.0");
        textFieldStroke.setSize(110, 30);
        textFieldStroke.setLocation(10, 195);
        textFieldStroke.setHorizontalAlignment(JTextField.LEFT);
        textFieldStroke.setBackground(Color.getHSBColor(0.1f,0.005f, 0.9f));
        textFieldStroke.setBorder(BorderFactory.createLineBorder(Color.BLACK, 1));
        textFieldStroke.getDocument().addDocumentListener(new DocumentListener() {
            @Override
            public void insertUpdate(DocumentEvent e) {
                try{
                    rotatingLine.stroke = Float.parseFloat(textFieldStroke.getText());
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }

            @Override
            public void removeUpdate(DocumentEvent e) {
                try{
                    rotatingLine.stroke = Float.parseFloat(textFieldStroke.getText());
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }

            @Override
            public void changedUpdate(DocumentEvent e) {
                try{
                    rotatingLine.stroke = Float.parseFloat(textFieldStroke.getText());
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }
        });
        panel1.add(textFieldStroke);

        checkBoxModeRotating = new JCheckBox("За годинниковою стрілкою");
        checkBoxModeRotating.setSize(185, 30);
        checkBoxModeRotating.setLocation(6, 225);
        checkBoxModeRotating.setBackground(Color.WHITE);
        checkBoxModeRotating.setSelected(true);
        checkBoxModeRotating.addChangeListener(new ChangeListener() {
            @Override
            public void stateChanged(ChangeEvent e) {
                rotatingLine.modeRotating = checkBoxModeRotating.isSelected();
            }
        });
        panel1.add(checkBoxModeRotating);

        labelRotateAngleByStep = new JLabel("Кут повороту за один крок (градуси)");
        labelRotateAngleByStep.setSize(210, 30);
        labelRotateAngleByStep.setLocation(10, 250);
        panel1.add(labelRotateAngleByStep);

        textFieldRotateAngleByStep = new JTextField("3.0");
        textFieldRotateAngleByStep.setSize(110, 30);
        textFieldRotateAngleByStep.setLocation(10, 275);
        textFieldRotateAngleByStep.setHorizontalAlignment(JTextField.LEFT);
        textFieldRotateAngleByStep.setBackground(Color.getHSBColor(0.1f,0.005f, 0.9f));
        textFieldRotateAngleByStep.setBorder(BorderFactory.createLineBorder(Color.BLACK, 1));
        textFieldRotateAngleByStep.getDocument().addDocumentListener(new DocumentListener() {
            @Override
            public void insertUpdate(DocumentEvent e) {
                try{
                    rotatingLine.setRotateAngleByStep(Double.parseDouble(textFieldRotateAngleByStep.getText()));
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }

            @Override
            public void removeUpdate(DocumentEvent e) {
                try{
                    rotatingLine.setRotateAngleByStep(Double.parseDouble(textFieldRotateAngleByStep.getText()));
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }

            @Override
            public void changedUpdate(DocumentEvent e) {
                try{
                    rotatingLine.setRotateAngleByStep(Double.parseDouble(textFieldRotateAngleByStep.getText()));
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }
        });
        panel1.add(textFieldRotateAngleByStep);

        labelTimeRotateStep = new JLabel("Тривалість кроку (мілісекунди)");
        labelTimeRotateStep.setSize(200, 30);
        labelTimeRotateStep.setLocation(10, 305);
        panel1.add(labelTimeRotateStep);

        textFieldTimeRotateStep = new JTextField("50");
        textFieldTimeRotateStep.setSize(110, 30);
        textFieldTimeRotateStep.setLocation(10, 330);
        textFieldTimeRotateStep.setHorizontalAlignment(JTextField.LEFT);
        textFieldTimeRotateStep.setBackground(Color.getHSBColor(0.1f,0.005f, 0.9f));
        textFieldTimeRotateStep.setBorder(BorderFactory.createLineBorder(Color.BLACK, 1));
        textFieldTimeRotateStep.getDocument().addDocumentListener(new DocumentListener() {
            @Override
            public void insertUpdate(DocumentEvent e) {
                try{
                    rotatingLine.timeRotateStep = Long.parseLong(textFieldTimeRotateStep.getText());
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }

            @Override
            public void removeUpdate(DocumentEvent e) {
                try{
                    rotatingLine.timeRotateStep = Long.parseLong(textFieldTimeRotateStep.getText());
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }

            @Override
            public void changedUpdate(DocumentEvent e) {
                try{
                    rotatingLine.timeRotateStep = Long.parseLong(textFieldTimeRotateStep.getText());
                }catch (Exception ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }
        });
        panel1.add(textFieldTimeRotateStep);

        //Panel2 with components
        GridBagLayout gridBagLayout = new GridBagLayout();
        GridBagConstraints constraints = new GridBagConstraints();

        panel2 = new JPanel(gridBagLayout);
        panel2.setLayout(gridBagLayout);
        panel2.setVisible(false);
        panelContent.add(panel2);

        JButton buttonFile = new JButton("Файл");
        constraints.anchor = GridBagConstraints.CENTER;
        constraints.fill = GridBagConstraints.NONE;
        constraints.gridwidth = GridBagConstraints.REMAINDER;
        constraints.gridheight = 1;
        constraints.gridx = GridBagConstraints.RELATIVE;
        constraints.gridy = GridBagConstraints.RELATIVE;
        constraints.insets = new Insets(10,10,10,10);
        buttonFile.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                doubleList.clear();
                JFileChooser fileChooser = new JFileChooser();
                if (fileChooser.showDialog(panel2, "Обрати") == JFileChooser.APPROVE_OPTION) {

                    if (readArraysFromFile(fileChooser.getSelectedFile().getAbsolutePath())) {

                        int indexInArray = 0;
                        Double[] array = doubleList.toArray(new Double[1]);
                        for (int i = 0; i < tableModelMatrix.getRowCount(); i++) {

                            if (indexInArray >= array.length - 1)
                                break;
                            for (int j = 0; j < tableModelMatrix.getColumnCount(); j++) {

                                if (indexInArray >= array.length - 1)
                                    break;
                                tableModelMatrix.setValueAt(array[indexInArray], i, j);
                                indexInArray++;
                            }
                        }
                    }
                }

            }
        });
        gridBagLayout.setConstraints(buttonFile, constraints);
        panel2.add(buttonFile);

        JLabel tempLabel1 = new JLabel("");
        constraints.anchor = GridBagConstraints.EAST;
        constraints.fill = GridBagConstraints.NONE;
        constraints.gridwidth = 1;
        constraints.gridheight = 1;
        constraints.gridx = GridBagConstraints.RELATIVE;
        constraints.gridy = GridBagConstraints.RELATIVE;
        constraints.insets = new Insets(0,0,0,0);
        constraints.weightx = 1.0;
        gridBagLayout.setConstraints(tempLabel1, constraints);
        panel2.add(tempLabel1);

        buttonSizeDecrement = new JButton("– –");
        constraints.insets = new Insets(10,10,10,10);
        constraints.weightx = 0.0;
        buttonSizeDecrement.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if (tableVector.getColumnCount() > 1){
                    tableModelVector.setColumnCount(tableModelVector.getColumnCount()-1);

                    tableModelMatrix.setColumnCount(tableModelMatrix.getColumnCount()-1);
                    tableModelMatrix.setRowCount(tableModelMatrix.getRowCount()-1);

                    labelSize.setText("Розмір матриці (" + tableModelVector.getColumnCount() + ")");
                    labelMatrix.setText("Матриця А(" + tableModelVector.getColumnCount() + "," + tableModelVector.getColumnCount() + ")");
                    labelVector.setText("B(" + tableModelVector.getColumnCount() + ") - вектор середніх арифметичних значень елементів рядків матриці A");
                }
            }
        });
        gridBagLayout.setConstraints(buttonSizeDecrement, constraints);
        panel2.add(buttonSizeDecrement);

        labelSize = new JLabel("Розмір матриці (5)");
        constraints.anchor = GridBagConstraints.CENTER;
        gridBagLayout.setConstraints(labelSize, constraints);
        panel2.add(labelSize);

        buttonSizeIncrement = new JButton("+ +");
        constraints.anchor = GridBagConstraints.WEST;
        buttonSizeIncrement.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                tableModelVector.setColumnCount(tableModelVector.getColumnCount()+1);

                tableModelMatrix.setColumnCount(tableModelMatrix.getColumnCount()+1);
                tableModelMatrix.setRowCount(tableModelMatrix.getRowCount()+1);

                labelSize.setText("Розмір матриці (" + tableModelVector.getColumnCount() + ")");
                labelMatrix.setText("Матриця А(" + tableModelVector.getColumnCount() + "," + tableModelVector.getColumnCount() + ")");
                labelVector.setText("B(" + tableModelVector.getColumnCount() + ") - вектор середніх арифметичних значень елементів рядків матриці A");
            }
        });
        gridBagLayout.setConstraints(buttonSizeIncrement, constraints);
        panel2.add(buttonSizeIncrement);

        JLabel tempLabel2 = new JLabel("");
        constraints.insets = new Insets(0,0,0,0);
        constraints.weightx = 1.0;
        constraints.gridwidth = GridBagConstraints.REMAINDER;
        gridBagLayout.setConstraints(tempLabel2, constraints);
        panel2.add(tempLabel2);

        labelMatrix = new JLabel("Матриця А(5,5)");
        constraints.anchor = GridBagConstraints.CENTER;
        constraints.insets = new Insets(10,10,10,10);
        gridBagLayout.setConstraints(labelMatrix, constraints);
        panel2.add(labelMatrix);

        tableMatrix = new JTable(5,5);
        tableModelMatrix = (DefaultTableModel) tableMatrix.getModel();
        tableMatrix.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
        constraints.fill = GridBagConstraints.BOTH;

        JScrollPane scrollPaneMatrix = new JScrollPane(tableMatrix);
        constraints.weighty = 1.5;
        //scrollPaneMatrix.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS);
        //scrollPaneMatrix.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_ALWAYS);
        gridBagLayout.setConstraints(scrollPaneMatrix, constraints);
        constraints.weighty = 0.0;
        panel2.add(scrollPaneMatrix);

        JButton buttonCalculate = new JButton("Обчислити");
        constraints.anchor = GridBagConstraints.CENTER;
        constraints.fill = GridBagConstraints.NONE;
        constraints.gridwidth = GridBagConstraints.REMAINDER;
        constraints.gridheight = 1;
        constraints.gridx = GridBagConstraints.RELATIVE;
        constraints.gridy = GridBagConstraints.RELATIVE;
        constraints.insets = new Insets(10,10,10,10);
        buttonCalculate.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                tableModelVector.setColumnCount(0);
                tableModelVector.setColumnCount(tableModelMatrix.getColumnCount());

                try {
                    String indexesOfRowsWithIncorrect = "";
                    int size = tableModelMatrix.getRowCount();

                    for (int i = 0; i < size; i++) {
                        int count = 0;
                        double sum = 0;
                        for (int j = 0; j < size; j++)
                            try {
                                sum += Double.parseDouble(tableModelMatrix.getValueAt(i, j).toString());
                                count++;
                            } catch (Exception ex) {
                                indexesOfRowsWithIncorrect += "[" + String.valueOf(i) + "," + String.valueOf(j) + "], ";
                                if (j == size-1 && i != size-1)
                                    indexesOfRowsWithIncorrect += System.getProperty("line.separator");
                            }
                        if (count == 0)
                            tableModelVector.setValueAt("NULL", 0, i);
                        else
                            tableModelVector.setValueAt(String.valueOf(sum / count), 0, i);
                    }

                    if (indexesOfRowsWithIncorrect.compareTo("") != 0)
                        throw new MyArithmeticException("Виявлено некоректні дані в наступних комірках матриці: " + System.getProperty("line.separator") + indexesOfRowsWithIncorrect.substring(0, indexesOfRowsWithIncorrect.length()-2));
                }catch (MyArithmeticException ex){
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
            }
        });
        gridBagLayout.setConstraints(buttonCalculate, constraints);
        panel2.add(buttonCalculate);

        labelVector = new JLabel("B(5) - вектор середніх арифметичних значень елементів рядків матриці A");
        constraints.fill = GridBagConstraints.NONE;
        gridBagLayout.setConstraints(labelVector, constraints);
        panel2.add(labelVector);

        tableVector = new JTable(1, 5);
        tableVector.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
        tableModelVector = (DefaultTableModel) tableVector.getModel();
        constraints.fill = GridBagConstraints.BOTH;

        JScrollPane scrollPaneVector = new JScrollPane(tableVector);
        constraints.weighty = 0.5;
        gridBagLayout.setConstraints(scrollPaneVector, constraints);
        constraints.weighty = 0.0;
        panel2.add(scrollPaneVector);

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

        //Thread with rotating line
        threadRotatingLine = new Thread(rotatingLine);
        threadRotatingLine.start();

        random = new Random();
    }

    public class RotatingLine implements Runnable
    {
        public Point position;
        public double length;
        public float stroke;
        public boolean modeRotating;
        public double rotateAngleByStep;
        private double currentAngle;
        public long timeRotateStep;

        public void setRotateAngleByStep(double _rotateAngleByStep)
        {
            rotateAngleByStep = _rotateAngleByStep / 180 * Math.PI;
        }

        public RotatingLine(Point _point, double _length, float _stroke, boolean _modeRotating, double _rotateAngleByStep, double _currentAngle, long _timeRotateStep)
        {
            position = _point;
            length = _length;
            stroke = _stroke;
            modeRotating = _modeRotating;
            rotateAngleByStep = _rotateAngleByStep / 180 * Math.PI;
            currentAngle = _currentAngle / 180 * Math.PI;
            timeRotateStep = _timeRotateStep;
        }

        public void run()
        {
            for(;;)
                try {
                        double tempX = 0, tempY = 0;

                        if (modeRotating == true) {
                            tempX = ((position.x + length - position.x) * Math.cos(currentAngle + rotateAngleByStep)) + position.x;
                            tempY = ((position.x + length - position.x) * Math.sin(currentAngle + rotateAngleByStep)) + position.y;
                            currentAngle += rotateAngleByStep;
                        } else if (modeRotating == false) {
                            tempX = ((position.x + length - position.x) * Math.cos(currentAngle - rotateAngleByStep)) + position.x;
                            tempY = ((position.x + length - position.x) * Math.sin(currentAngle - rotateAngleByStep)) + position.y;
                            currentAngle -= rotateAngleByStep;
                        }

                        if (!panel2.isVisible()) {
                            Graphics2D graphics = (Graphics2D)panel1.getGraphics();
                            graphics.setColor(Color.white);
                            graphics.fillRect(0,0, panel1.getWidth(), panel1.getHeight());
                            graphics.setColor(Color.getHSBColor(random.nextFloat(), 0.8f + random.nextFloat() * 0.2f, 0.8f + random.nextFloat() * 0.2f));
                            graphics.setStroke(new BasicStroke(stroke));
                            graphics.drawLine(position.x, position.y, (int) tempX, (int) tempY);

                            textFieldMoveStepSize.repaint();
                            buttonMoveUp.repaint();
                            buttonMoveDown.repaint();
                            buttonMoveRight.repaint();
                            buttonMoveLeft.repaint();
                            labelLength.repaint();
                            textFieldLength.repaint();
                            labelStroke.repaint();
                            textFieldStroke.repaint();
                            checkBoxModeRotating.repaint();
                            menuItem1.repaint();
                            menuItem2.repaint();
                            labelRotateAngleByStep.repaint();
                            textFieldRotateAngleByStep.repaint();
                            labelTimeRotateStep.repaint();
                            textFieldTimeRotateStep.repaint();
                        }

                        Thread.sleep(timeRotateStep);

                } catch (Exception ex) {
                    JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
                }
        }
    }

    boolean readArraysFromFile(String filePath){
        try{
            Scanner inFile = new Scanner(new FileReader(filePath));

            while(inFile.hasNextLine()){
                try{
                    doubleList.add(Double.parseDouble(inFile.nextLine()));
                }
                catch(NumberFormatException e){
                }
            }

            inFile.close();
            return true;
        }
        catch(FileNotFoundException ex){
            JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
            return false;
        }
        catch(IOException ex){
            JOptionPane.showMessageDialog(null, ex.getMessage(), "Помилка", JOptionPane.ERROR_MESSAGE);
            return false;
        }
    }
}