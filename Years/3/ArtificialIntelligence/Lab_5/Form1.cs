using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork;

namespace Lab_5
{
    public partial class Form1 : Form
    {
        public double sygmoid_Alpha = 3.1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Items.Contains(comboBox1.Text))
                MessageBox.Show("Оберіть логічну функцію");
            else if (!comboBox2.Items.Contains(comboBox2.Text))
                MessageBox.Show("Оберіть функцію активації");
            else
            {
                int numberNeurons = int.Parse(numericUpDown1.Text);
                double educationSpeed = double.Parse(numericUpDown2.Text);
                int numberEpochs = Convert.ToInt32(numericUpDown3.Value);

                //create NeuralNetwork
                var neurons = new List<Neuron>();
                Neuron neuron = null;
                Neuron neuronOut = null;
                NeuralNetwork.Neuron.ActivationFunction activationFunction = null;
                var layers = new List<NeuralLayer>();
                switch (comboBox2.Text)
                {
                    case "Сигмоїда": 
                        {                       

                        activationFunction = (double sum) => {
                            return (1.0) / (1.0 + Math.Exp(-sygmoid_Alpha * sum));
                        };

                        break;
                        }
                    case "Сходинка":
                        {

                            activationFunction = (double sum) =>
                            {
                                return ( sum >= 0.0 ? 1.0 : 0.0 );
                            };

                            break;
                        }
                    case "Лінійна":
                        {

                            activationFunction = (double sum) =>
                            {
                                return ( 
                                    sum <= 0.0 ? 0.0 : ( 
                                        sum >= 1.0 ? 1.0 : sum
                                    ) 
                                );
                            };

                            break;
                        }
                }
                neuronOut = new Neuron(
                            (numberNeurons != 0 ? numberNeurons : 2) + 1,
                            activationFunction
                        );
                if (numberNeurons > 0)
                {
                    for (int i = 0; i < numberNeurons; i++)
                    {
                        neuron = new Neuron(3, activationFunction);
                        neurons.Add(neuron);
                    }
                    layers.Add(new NeuralLayer(neurons));
                }
                neurons.Clear();
                neurons.Add(neuronOut);
                layers.Add(new NeuralLayer(neurons));
                var perseptron = new MultiLayerPerseptron(layers);


                //Create tests
                double[,] tests = null;
                switch (comboBox1.Text)
                {
                    case "AND":
                        {
                            tests = new double[4, 3] {
                                {0,0,0},
                                {1,0,0},
                                {0,1,0},
                                {1,1,1}
                            };
                            break;
                        }
                    case "OR":
                        {
                            tests = new double[4, 3] {
                                {0,0,0},
                                {1,0,1},
                                {0,1,1},
                                {1,1,1}
                            };
                            break;
                        }
                    case "XOR":
                        {
                            tests = new double[4, 3] {
                                {0,0,0},
                                {1,0,1},
                                {0,1,1},
                                {1,1,0}
                            };
                            break;
                        }
                }


                //Education
                int testIndex = 0;
                for (int i = 0; i < numberEpochs; i++)
                {
                    var inputSignals = new List<double> ()
                    {
                        1.0,
                        tests[testIndex, 0],
                        tests[testIndex, 1]
                    };
                    
                    var desireResponse = new List<double>()
                    {
                        tests[testIndex, 2]
                    };

                    List<double> output = perseptron.MakeOutputSignals(inputSignals);
                    perseptron.Educate(desireResponse, educationSpeed);


                    testIndex++;
                    if (testIndex > 3)
                        testIndex = 0;
                }



                //Calculate
                listView1.Items.Clear();

                listView1.Items.Add(new ListViewItem(new string[]{
                    tests[0,0].ToString(),
                    tests[0,1].ToString(),
                    tests[0,2].ToString(),
                    perseptron.MakeOutputSignals(new List<double>(){
                        1.0, tests[0,0], tests[0,1]
                    })[0].ToString(),
                    ""
                }));

                listView1.Items.Add(new ListViewItem(new string[]{
                    tests[1,0].ToString(),
                    tests[1,1].ToString(),
                    tests[1,2].ToString(),
                    perseptron.MakeOutputSignals(new List<double>(){
                        1.0, tests[1,0], tests[1,1]
                    })[0].ToString(),
                    ""
                }));

                listView1.Items.Add(new ListViewItem(new string[]{
                    tests[2,0].ToString(),
                    tests[2,1].ToString(),
                    tests[2,2].ToString(),
                    perseptron.MakeOutputSignals(new List<double>(){
                        1.0, tests[2,0], tests[2,1]
                    })[0].ToString(),
                    ""
                }));

                listView1.Items.Add(new ListViewItem(new string[]{
                    tests[3,0].ToString(),
                    tests[3,1].ToString(),
                    tests[3,2].ToString(),
                    perseptron.MakeOutputSignals(new List<double>(){
                        1.0, tests[3,0], tests[3,1]
                    })[0].ToString(),
                    ""
                }));
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Epochs -> 100 000" + Environment.NewLine
                + "Sygmoid -> alpha 3.1" + Environment.NewLine
                + "XOR -> speed 1.3" + Environment.NewLine
                + "AND -> speed 0.01" + Environment.NewLine
                + "OR -> speed 0.01" + Environment.NewLine
            , "Info");
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "Сигмоїда":
                    {
                        Form_Linear f = new Form_Linear(this);
                        f.Show();
                        break;
                    }
            }
        }
    }
}
