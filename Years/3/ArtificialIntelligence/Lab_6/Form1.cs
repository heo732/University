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

namespace Lab_6
{
    public partial class Form1 : Form
    {
        MultiLayerPerseptron perseptron = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void setColumns(DataGridViewColumnCollection columns, bool format)
        {
            columns.Add("col1", "Температура");
            columns.Add("col2", "Кашель");
            columns.Add("col3", "Слабкість");
            columns.Add("col4", "Біль у м'язах");
            if (format)
                columns.Add("col5", "Грип");
        }

        private DataGridViewRow getRow(bool format)
        {
            var row = new DataGridViewRow();

            //Температура
            DataGridViewCell cell = new DataGridViewCheckBoxCell();
            cell.Value = false;            
            row.Cells.Add(cell);

            //Кашель
            cell = new DataGridViewCheckBoxCell();
            cell.Value = false;
            row.Cells.Add(cell);

            //Слабкість
            cell = new DataGridViewCheckBoxCell();
            cell.Value = false;
            row.Cells.Add(cell);

            //Біль у м'язах
            cell = new DataGridViewCheckBoxCell();
            cell.Value = false;
            row.Cells.Add(cell);
            
            if (format)
            {
                //Грип
                cell = new DataGridViewCheckBoxCell();
                cell.Value = false;
                row.Cells.Add(cell);
            }

            return row;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setColumns(dataGridView1.Columns, true);
            setColumns(dataGridView2.Columns, false);

            dataGridView1.Rows.Add(getRow(true));
            dataGridView2.Rows.Add(getRow(false));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows.RemoveAt( dataGridView1.Rows.Count - 1 );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add( getRow(true) );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (perseptron == null)
                MessageBox.Show("Спочатку необхідно провести навчання");
            else
            {
                var example = new Example();
                example.temperature = bool.Parse(dataGridView2.Rows[0].Cells[0].Value.ToString());
                example.caugh = bool.Parse(dataGridView2.Rows[0].Cells[1].Value.ToString());
                example.weakness = bool.Parse(dataGridView2.Rows[0].Cells[2].Value.ToString());
                example.musclePain = bool.Parse(dataGridView2.Rows[0].Cells[3].Value.ToString());

                var inputSignals = new List<double>()
                    {
                        1.0,
                        example.temperature == true ? 1.0 : 0.0,
                        example.caugh == true ? 1.0 : 0.0,
                        example.weakness == true ? 1.0 : 0.0,
                        example.musclePain == true ? 1.0 : 0.0
                    };

                List<double> output = perseptron.MakeOutputSignals(inputSignals);

                label6.Text = output[0].ToString();
            }
        }

        private struct Example
        {
            public bool temperature;
            public bool caugh;
            public bool weakness;
            public bool musclePain;

            //desire response
            public bool flu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                MessageBox.Show("Додайте в таблицю приклади для навчання");
            else
            {
                //Get examples
                List<Example> examples = new List<Example>();

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    var example = new Example();

                    example.temperature = bool.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    example.caugh = bool.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    example.weakness = bool.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    example.musclePain = bool.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    example.flu = bool.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());

                    examples.Add(example);
                }

                //Create perseptron
                int numberNeurons = int.Parse(numericUpDown3.Text);
                double educationSpeed = double.Parse(numericUpDown2.Text);
                int numberEpochs = int.Parse(numericUpDown1.Text);
                double alpha = double.Parse(numericUpDown4.Text);

                var neurons = new List<Neuron>();
                Neuron neuron = null;
                Neuron neuronOut = null;
                NeuralNetwork.Neuron.ActivationFunction activationFunction = (double sum) =>
                {
                    return (1.0) / (1.0 + Math.Exp(-alpha * sum));
                };
                var layers = new List<NeuralLayer>();
                
                neuronOut = new Neuron(
                            (numberNeurons != 0 ? numberNeurons : 4) + 1,
                            activationFunction
                        );
                if (numberNeurons > 0)
                {
                    for (int i = 0; i < numberNeurons; i++)
                    {
                        neuron = new Neuron(5, activationFunction);
                        neurons.Add(neuron);
                    }
                    layers.Add(new NeuralLayer(neurons));
                }
                neurons.Clear();
                neurons.Add(neuronOut);
                layers.Add(new NeuralLayer(neurons));
                perseptron = new MultiLayerPerseptron(layers);

                //Education
                int exampleIndex = 0;
                for (int i = 0; i < numberEpochs; i++)
                {
                    var inputSignals = new List<double>()
                    {
                        1.0,
                        examples[exampleIndex].temperature == true ? 1.0 : 0.0,
                        examples[exampleIndex].caugh == true ? 1.0 : 0.0,
                        examples[exampleIndex].weakness == true ? 1.0 : 0.0,
                        examples[exampleIndex].musclePain == true ? 1.0 : 0.0
                    };

                    var desireResponse = new List<double>()
                    {
                        examples[exampleIndex].flu == true ? 1.0 : 0.0
                    };

                    List<double> output = perseptron.MakeOutputSignals(inputSignals);
                    perseptron.Educate(desireResponse, educationSpeed);


                    exampleIndex++;
                    if (exampleIndex >= examples.Count)
                        exampleIndex = 0;
                }
            }
        }
    }
}
