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
using Genetic;

namespace Lab_5
{
    public partial class Form1 : Form
    {
        private double sygmoid_Alpha = 3.1;

        private double[,] tests = null;
        private NeuralNetwork.Neuron.ActivationFunction activationFunction = null;
        private GeneticAlgorithm.FitnessFunction fitnessFunction = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //            
        }

        // Use tests and activationFunction to calculate adapting.
        private double CalculateAdapdtingViaAnswerOnTests(List<double> wages, int numberNeuronsOfHidenLayer)
        {
            int index = 0;
            var layers = new List<NeuralLayer>();
            var neurons = new List<Neuron>();
            while (index < numberNeuronsOfHidenLayer * 3)
            {
                var w = new List<double>() {
                    wages[index],
                    wages[index + 1],
                    wages[index + 2]
                };
                index += 3;
                neurons.Add(new Neuron(w, activationFunction));
            }

            layers.Add(new NeuralLayer(neurons)); // Hiden layer

            neurons = new List<Neuron>();
            var wOut = new List<double>() {
                wages[index]
            };
            index++;
            for (int i = 0; i < numberNeuronsOfHidenLayer; i++)
            {
                wOut.Add(wages[index]);
                index++;
            }

            neurons.Add(new Neuron(wOut, activationFunction));

            layers.Add(new NeuralLayer(neurons)); // Out layer

            var neuralNetwork = new MultiLayerPerseptron(layers);


            double points = 0.0;

            double res1 = neuralNetwork.MakeOutputSignals(new List<double>(){
                        1.0, tests[0,0], tests[0,1]
                    })[0];
            double res2 = neuralNetwork.MakeOutputSignals(new List<double>(){
                        1.0, tests[1,0], tests[1,1]
                    })[0];
            double res3 = neuralNetwork.MakeOutputSignals(new List<double>(){
                        1.0, tests[2,0], tests[2,1]
                    })[0];
            double res4 = neuralNetwork.MakeOutputSignals(new List<double>(){
                        1.0, tests[3,0], tests[3,1]
                    })[0];

            double must1 = tests[0, 2];
            double must2 = tests[1, 2];
            double must3 = tests[2, 2];
            double must4 = tests[3, 2];
                       
            points -= Math.Abs(must1 - res1);
            points -= Math.Abs(must2 - res2);
            points -= Math.Abs(must3 - res3);
            points -= Math.Abs(must4 - res4);

            return points;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Items.Contains(comboBox1.Text))
                MessageBox.Show("Оберіть логічну функцію");            
            else
            {
                int numberNeurons = int.Parse(numericUpDown1.Text);
                double educationSpeed = double.Parse(numericUpDown2.Text);
                int numberEpochs = Convert.ToInt32(numericUpDown3.Value);



                // Create tests                
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

                activationFunction = (double sum) =>
                {
                    return (1.0) / (1.0 + Math.Exp(-sygmoid_Alpha * sum));
                };



                // Use GeneticAlgorithm
                int numberOfWages = (int)(numericUpDown1.Value * 4 + 1);
                int populationSize = (int)numericUpDown4.Value;
                int numberGenesInChromosome = (int)numericUpDown5.Value;
                double probabilityCrossover = (double)numericUpDown6.Value;
                double probabilityMutation = (double)numericUpDown7.Value;
                double wageLeftBorder = (double)numericUpDown8.Value;
                

                fitnessFunction = new GeneticAlgorithm.FitnessFunction((ulong x) => {
                        
                        // Gets wages and pass it into function CalculateAdapdtingViaAnswerOnTests
                        var wages = new List<double>();

                        int len = numberGenesInChromosome / numberOfWages;
                        int mod = numberGenesInChromosome % numberOfWages;
                        var mods = new List<int>();
                        for (int i = 0; i < numberOfWages; i++)
                        {
                            int plus = mod > 0 ? 1 : 0;
                            mods.Add(plus);
                            if (mod > 0)
                                mod--;
                        }
                        int currentLandslide = 0;
                        foreach (var item in mods)
                        {
                            // Get next item + len bits of x, start in currentLandSlide
                            ulong mask = 1;
                            for (int i = 0; i < item + len; i++)
                                mask <<= 1; // * 2
                            mask -= 1; // get [1111111..] length of which = item + len
                            mask <<= currentLandslide;                            
                            ulong wage = x & mask;
                            wage >>= currentLandslide;
                            currentLandslide += item + len;
                            wages.Add(wageLeftBorder + (double)wage);
                        }

                        return CalculateAdapdtingViaAnswerOnTests(wages, numberNeurons);
                    });


                var geneticAlgorithm = new GeneticAlgorithm(populationSize, numberGenesInChromosome,
                    probabilityCrossover, probabilityMutation, fitnessFunction);


                int limitGeneration = (int)numericUpDown10.Value;
                int limitTime = (int)numericUpDown11.Value;
                int generation = 0;
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                ulong maxPhenotype = 0;
                double adaptingMaxPhenotype = double.MinValue;
                while (generation < limitGeneration && limitTime > sw.ElapsedMilliseconds / 1000.0)
                {
                    geneticAlgorithm.NextGeneration();
                    generation++;

                    ulong tempX = geneticAlgorithm.GetPhenotypeOfMaxAdaptedPerson();
                    double tempY = fitnessFunction(tempX);

                    if (tempY > adaptingMaxPhenotype)
                    {
                        maxPhenotype = tempX;
                        adaptingMaxPhenotype = tempY;
                    }
                } // End of work genetic algorithm.


                // Translate maxPhenotype to wages
                var wages1 = new List<double>();

                int len1 = numberGenesInChromosome / numberOfWages;
                int mod1 = numberGenesInChromosome % numberOfWages;
                var mods1 = new List<int>();
                for (int i = 0; i < numberOfWages; i++)
                {
                    int plus = mod1 > 0 ? 1 : 0;
                    mods1.Add(plus);
                    if (mod1 > 0)
                        mod1--;
                }
                int currentLandslide1 = 0;
                foreach (var item in mods1)
                {
                    // Get next item + len bits of x, start in currentLandSlide
                    ulong mask = 1;
                    for (int i = 0; i < item + len1; i++)
                        mask <<= 1; // * 2
                    mask -= 1; // get [1111111..] length of which = item + len
                    mask <<= currentLandslide1;
                    ulong wage = maxPhenotype & mask;
                    wage >>= currentLandslide1;
                    currentLandslide1 += item + len1;
                    wages1.Add(wageLeftBorder + (double)wage);
                }



                //create NeuralNetwork
                int index = 0;
                var layers = new List<NeuralLayer>();
                var neurons = new List<Neuron>();
                while (index < numberNeurons * 3)
                {
                    var w = new List<double>() {
                        wages1[index],
                        wages1[index + 1],
                        wages1[index + 2]
                    };
                    index += 3;
                    neurons.Add(new Neuron(w, activationFunction));
                }

                layers.Add(new NeuralLayer(neurons)); // Hiden layer.

                neurons = new List<Neuron>();
                var wOut = new List<double>() {
                    wages1[index]
                };
                index++;
                for (int i = 0; i < numberNeurons; i++)
                {
                    wOut.Add(wages1[index]);
                    index++;
                }

                neurons.Add(new Neuron(wOut, activationFunction)); // Out neuron.

                layers.Add(new NeuralLayer(neurons)); // Out layer

                var perseptron = new MultiLayerPerseptron(layers);


                

                // Education via BackPropagation
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



                // Calculate
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

                label_Time.Text = "Час виконання:  " + sw.ElapsedMilliseconds / 1000.0;
                sw.Stop();
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

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            // Recomended number of neurons via borders of one wage.
            long len = (long)(numericUpDown9.Value - numericUpDown8.Value);
            long value = 1;
            int step = 0; // Number of bits require for define one wage.
            while (value < len)
            {
                value *= 2;
                step++;
            }
            // Number of bits require for define all wages.
            step *= (int)(numericUpDown1.Value * 4 + 1);

            label_recomendNumberOfGenesInChromosome.Text = "Рекомендовано:  " + step.ToString();
        }
        
        

    }
}
