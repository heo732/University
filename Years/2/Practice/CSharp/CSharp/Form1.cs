using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSharp
{
    public partial class Form1 : Form
    {
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            AcceptButton = button5;

            dataGridView1.Rows.Add();
            dataGridView1[0, 0].Value = "1";
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            задача1ToolStripMenuItem.Text = "Задача_1";            
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            AcceptButton = button5;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            задача1ToolStripMenuItem.Text = "Задача_2";            
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            AcceptButton = button6;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            задача1ToolStripMenuItem.Text = "Задача_3";            
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            AcceptButton = button7;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label3.Text = saveFileDialog1.FileName;
                label3.Visible = true;

                dataGridView2.Rows.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataGridView1.Rows.Count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1[1, i].Value = random.Next(101);

            dataGridView2.Rows.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label3.Visible)
            {
                dataGridView2.Rows.Clear();
                saveFileDialog1.FileName = label3.Text;

                try
                {
                    FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    BinaryWriter fout = new BinaryWriter(fs);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        int value = -1;
                        if (Int32.TryParse(Convert.ToString(dataGridView1[1, i].Value), out value) && value % 2 == 0)
                            fout.Write(value);
                    }
                    fout.Close();

                    fs = new FileStream(saveFileDialog1.FileName, FileMode.Open);
                    BinaryReader fin = new BinaryReader(fs);
                    for (long i = 0; i < fs.Length; i += 4)
                    {
                        fs.Seek(i, SeekOrigin.Begin);
                        int value = fin.ReadInt32();
                        dataGridView2.Rows.Add();
                        dataGridView2[0, dataGridView2.Rows.Count - 1].Value = dataGridView2.Rows.Count;
                        dataGridView2[1, dataGridView2.Rows.Count - 1].Value = value;
                    }
                    fin.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Оберіть двійковий файл для роботи", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label4.Text = openFileDialog1.FileName;
                label4.Visible = true;

                string line = "";
                int index = 0;
                int indexOfMaxLengthLine = 0;

                try
                {
                    StreamReader fin = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                    while (!fin.EndOfStream)
                    {
                        string tempLine = fin.ReadLine();
                        if (tempLine.Length > line.Length)
                        {
                            line = tempLine;
                            indexOfMaxLengthLine = index;
                        }
                        index++;
                    }
                    fin.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                label6.Text = indexOfMaxLengthLine.ToString();
                label6.Visible = true;
                textBox1.Text = line;                
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0)
            {
                MessageBox.Show("Заповніть всі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox5.Clear();

                string studentSurname = textBox2.Text;
                string text1 = textBox3.Text;
                string text2 = textBox4.Text;

                try
                {
                    Directory.CreateDirectory("D:\\temp\\" + studentSurname + "1");
                    textBox5.AppendText("Створено папку 'D:\\temp\\" + studentSurname + "1'." + Environment.NewLine + Environment.NewLine);

                    Directory.CreateDirectory("D:\\temp\\" + studentSurname + "2");
                    textBox5.AppendText("Створено папку 'D:\\temp\\" + studentSurname + "2'." + Environment.NewLine + Environment.NewLine);

                    StreamWriter fout = File.CreateText("D:\\temp\\" + studentSurname + "1\\t1.txt");
                    fout.Write(text1);
                    fout.Close();
                    textBox5.AppendText("Створено файл 'D:\\temp\\" + studentSurname + "1\\t1.txt' з наступним текстом: " 
                        + "'" + text1 + "'." + Environment.NewLine + Environment.NewLine);

                    fout = File.CreateText("D:\\temp\\" + studentSurname + "1\\t2.txt");
                    fout.Write(text2);
                    fout.Close();
                    textBox5.AppendText("Створено файл 'D:\\temp\\" + studentSurname + "1\\t2.txt' з наступним текстом: " 
                        + "'" + text2 + "'." + Environment.NewLine + Environment.NewLine);

                    fout = File.CreateText("D:\\temp\\" + studentSurname + "2\\t3.txt");
                    fout.Write(text1 + Environment.NewLine + text2);
                    fout.Close();
                    textBox5.AppendText("Створено файл 'D:\\temp\\" + studentSurname + "2\\t3.txt' з текстом файлів 't1.txt' та 't2.txt'." 
                        + Environment.NewLine + Environment.NewLine);

                    textBox5.AppendText("Інформація про створені файли:" + Environment.NewLine);
                    textBox5.AppendText("//////////////////////////////////////" + Environment.NewLine);
                    FileInfo[] files = new FileInfo[3];
                    files[0] = new FileInfo("D:\\temp\\" + studentSurname + "1\\t1.txt");
                    files[1] = new FileInfo("D:\\temp\\" + studentSurname + "1\\t2.txt");
                    files[2] = new FileInfo("D:\\temp\\" + studentSurname + "2\\t3.txt");
                    foreach (var i in files)
                    {
                        textBox5.AppendText("FullName: " + i.FullName + Environment.NewLine);
                        textBox5.AppendText("Length: " + i.Length + Environment.NewLine);
                        textBox5.AppendText("Attributes: " + i.Attributes + Environment.NewLine);
                        textBox5.AppendText("IsReadOnly: " + i.IsReadOnly + Environment.NewLine);
                        textBox5.AppendText("CreationTime: " + i.CreationTime + Environment.NewLine);
                        textBox5.AppendText("LastAccessTime: " + i.LastAccessTime + Environment.NewLine);
                        textBox5.AppendText("LastWriteTime: " + i.LastWriteTime + Environment.NewLine);
                        textBox5.AppendText("//////////////////////////////////////" + Environment.NewLine);
                    }

                    files[1].MoveTo("D:\\temp\\" + studentSurname + "2\\t2.txt");                    
                    textBox5.AppendText(Environment.NewLine + "Файл 't2.txt' перенесено у папку 'D:\\temp\\" + studentSurname + "2'." + Environment.NewLine + Environment.NewLine);

                    files[0].CopyTo("D:\\temp\\" + studentSurname + "2\\t1.txt", true);
                    textBox5.AppendText("Файл 't1.txt' скопійовано у папку 'D:\\temp\\" + studentSurname + "2'." + Environment.NewLine + Environment.NewLine);

                    Directory.Move("D:\\temp\\" + studentSurname + "2", "D:\\temp\\ALL");
                    textBox5.AppendText("Папку '" + studentSurname + "2' перейменовано в 'ALL'." + Environment.NewLine + Environment.NewLine);

                    Directory.Delete("D:\\temp\\" + studentSurname + "1", true);
                    textBox5.AppendText("Папку '" + studentSurname + "1' вилучено." + Environment.NewLine + Environment.NewLine);

                    textBox5.AppendText("Інформація про файли папки 'ALL':" + Environment.NewLine);
                    textBox5.AppendText("//////////////////////////////////////" + Environment.NewLine);
                    foreach (var i in new DirectoryInfo("D:\\temp\\ALL").GetFiles())
                    {
                        textBox5.AppendText("FullName: " + i.FullName + Environment.NewLine);
                        textBox5.AppendText("Length: " + i.Length + Environment.NewLine);
                        textBox5.AppendText("Attributes: " + i.Attributes + Environment.NewLine);
                        textBox5.AppendText("IsReadOnly: " + i.IsReadOnly + Environment.NewLine);
                        textBox5.AppendText("CreationTime: " + i.CreationTime + Environment.NewLine);
                        textBox5.AppendText("LastAccessTime: " + i.LastAccessTime + Environment.NewLine);
                        textBox5.AppendText("LastWriteTime: " + i.LastWriteTime + Environment.NewLine);
                        textBox5.AppendText("//////////////////////////////////////" + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
