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

        private string[] heroes = new string[] {
            "Залізна людина",
            "Капітан Америка",
            "Танос",
            "Халк",
            "Людина-Павук",
            "Чорна Пантера",
            "Зоряний Лорд",
            "Грут",
            "Ракета",
            "Тор"
        };

        private int paramsCount = 14;

        public Form1()
        {
            InitializeComponent();
        }

        private void setColumns(DataGridViewColumnCollection columns, bool format)
        {
            columns.Add("col", "Гігант");
            columns.Add("col", "Курдуплик");
            columns.Add("col", "Носить залізний костюм");
            columns.Add("col", "Носить залізний шолом");
            columns.Add("col", "Має щит");
            columns.Add("col", "Має металеву рукавицю");
            columns.Add("col", "Син Одіна");
            columns.Add("col", "Зелений");
            columns.Add("col", "Бузковий");
            columns.Add("col", "Чорний");
            columns.Add("col", "Жартівник");
            columns.Add("col", "Любить Walkman");
            columns.Add("col", "Розумник");
            columns.Add("col", "Може літати");
            if (format)
            {
                columns.Add("col", heroes[0]);
                columns.Add("col", heroes[1]);
                columns.Add("col", heroes[2]);
                columns.Add("col", heroes[3]);
                columns.Add("col", heroes[4]);
                columns.Add("col", heroes[5]);
                columns.Add("col", heroes[6]);
                columns.Add("col", heroes[7]);
                columns.Add("col", heroes[8]);
                columns.Add("col", heroes[9]);
            }
        }

        private DataGridViewRow getRow(bool format)
        {
            var row = new DataGridViewRow();

            for (int i = 0; i < paramsCount; i++)
            {
                DataGridViewCell cell = new DataGridViewCheckBoxCell();
                cell.Value = false;
                row.Cells.Add(cell);
            }
            
            if (format)
            {
                for (int i = 0; i < heroes.Length; i++)
                {
                    DataGridViewCell cell = new DataGridViewCheckBoxCell();
                    cell.Value = false;
                    row.Cells.Add(cell);
                }
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
                var inputSignals = new List<double>()
                {
                    1.0
                };

                for (int i = 0; i < paramsCount; i++)
                {
                    inputSignals.Add(
                        bool.Parse(dataGridView2.Rows[0].Cells[i].Value.ToString()) == true ? 1.0 : 0.0
                    );
                }

                List<double> output = perseptron.MakeOutputSignals(inputSignals);

                label6.Text = "";
                for (int i = 0; i < heroes.Length; i++)
                    if (output[i] > 0.7)
                        label6.Text = label6.Text + heroes[i] + " ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                MessageBox.Show("Додайте в таблицю приклади для навчання");
            else
            {
                //Get examples
                var examples = new List<List<double>>();

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    var example = new List<double>();

                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        example.Add(
                            bool.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) == true ? 1.0 : 0.0
                        );
                    }

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
                                
                if (numberNeurons > 0)
                {
                    for (int i = 0; i < numberNeurons; i++)
                    {
                        neuron = new Neuron(paramsCount + 1, activationFunction);
                        neurons.Add(neuron);
                    }
                    layers.Add(new NeuralLayer(neurons));
                }
                neurons.Clear();
                for (int i = 0; i < heroes.Length; i++)
                {
                    neuronOut = new Neuron(
                            (numberNeurons != 0 ? numberNeurons : paramsCount) + 1,
                            activationFunction
                        );
                    neurons.Add(neuronOut);
                }
                layers.Add(new NeuralLayer(neurons));
                perseptron = new MultiLayerPerseptron(layers);

                //Education
                int exampleIndex = 0;
                for (int i = 0; i < numberEpochs; i++)
                {
                    var inputSignals = new List<double>()
                    {
                        1.0
                    };
                    for (int j = 0; j < paramsCount; j++)
                    {
                        inputSignals.Add( examples[exampleIndex][j] );
                    }

                    var desireResponse = new List<double>();
                    for (int j = 0; j < heroes.Length; j++)
                    {
                        desireResponse.Add( examples[exampleIndex][paramsCount + j] );
                    }

                    List<double> output = perseptron.MakeOutputSignals(inputSignals);
                    perseptron.Educate(desireResponse, educationSpeed);


                    exampleIndex++;
                    if (exampleIndex >= examples.Count)
                        exampleIndex = 0;
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = this.Width - 90;
            dataGridView2.Width = this.Width - 50;
        }
    }
}
