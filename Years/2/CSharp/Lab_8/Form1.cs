using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab_8
{
    public partial class Form1 : Form
    {
        string pattern3;

        string DeleteWordFromMatch(Match match)
        {
            string ret = Regex.Replace(match.ToString(), pattern3, "");
            return ret;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;

            завдання1ToolStripMenuItem.Text = "Завдання_1";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;

            завдання1ToolStripMenuItem.Text = "Завдання_2";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;

            завдання1ToolStripMenuItem.Text = "Завдання_3";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            label1.Visible = false;
            label4.Visible = false;
            if (textBox1.Text != "")
            {
                int count = 0;
                int countReplace = 0;
                List<string> outStrings = new List<string>();
                Regex regex = new Regex(@"([01]{1,8}\.){3}[01]{1,8}");

                string stringIn = new string(textBox1.Text.ToCharArray());

                if (!regex.IsMatch(textBox3.Text))
                    MessageBox.Show(@"Поле 'Знайти' повинно містити ІР-адрес виду
'd.d.d.d',
де d - двійкове число від 0 до 11111111", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    countReplace = new Regex(textBox3.Text).Matches(stringIn).Count;
                    stringIn = new string(Regex.Replace(stringIn, regex.Matches(textBox3.Text)[0].ToString(), textBox4.Text).ToCharArray());

                    if (regex.IsMatch(stringIn))
                    {
                        MatchCollection matchCollection = regex.Matches(stringIn);
                        foreach (Match item in matchCollection)
                        {
                            count++;
                            outStrings.Add(item.ToString());
                        }
                    }

                    textBox2.Lines = outStrings.ToArray();
                    label1.Text = "Кількість:  " + count.ToString();
                    label1.Visible = true;
                    label4.Text = "Замінено:  " + countReplace.ToString();
                    label4.Visible = true;
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox7.Clear();
            label8.Visible = false;
            if (textBox8.Text != "")
            {
                int count = 0;

                if (textBox6.Text == "")
                    MessageBox.Show("Заповніть поле '" + label7.Text + "'", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string pattern = @"[";
                    foreach (var item in textBox6.Text.ToCharArray())
                        pattern += item;
                    pattern += ']';

                    count = new Regex(pattern).Matches(textBox8.Text).Count;

                    textBox7.Text = Regex.Replace(textBox8.Text, pattern, "");

                    label8.Text = "Видалено:  " + count.ToString();
                    label8.Visible = true;
                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            textBox9.Clear();

            if (textBox5.Text == "")
                MessageBox.Show("Заповніть поле 'Розділювачі слів'", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (textBox10.Text != "")
                {
                    if (textBox11.Text != "")
                    {
                        string pattern = "[";
                        pattern3 = "[^";
                        foreach (var item in textBox5.Text.ToCharArray())
                        {
                            pattern += item;
                            pattern3 += item;
                        }
                        pattern += @"]+";
                        pattern3 += @"]+";

                        List<string> wordsInText2 = new List<string>();

                        foreach (string line in textBox11.Lines)
                        {
                            foreach (string word in Regex.Split(line, pattern))
                                wordsInText2.Add(word);
                        }
                        

                        int count = 0;

                        List<string> Text1 = new List<string>();
                        foreach (string item in textBox10.Lines)
                        {
                            Text1.Add(item);
                        }

                        foreach (string word in wordsInText2)
                        {
                            if (word != "")
                            {
                                for (int i = 0; i < Text1.Count; i++)
                                {
                                    count += new Regex(
                                        @"(" + @"^" + word + pattern + @"|" + pattern + word + pattern + @"|" + pattern + word + @"$" + @"|" + @"^" + word + @"$" + @")"
                                        ).Matches(Text1[i]).Count;
                                    Text1[i] = Regex.Replace(Text1[i],
    @"(" + @"^" + word + pattern + @"|" + pattern + word + pattern + @"|" + pattern + word + @"$" + @"|" + @"^" + word + @"$" + @")",
    new MatchEvaluator(DeleteWordFromMatch));
                                }
                            }
                        }

                        textBox9.Lines = Text1.ToArray();
                        label6.Text = "Вилучено:  " + count.ToString();
                        label6.Visible = true;
                    }
                    else
                    {
                        textBox9.Text = textBox10.Text;
                        label6.Text = "Вилучено:  0";
                        label6.Visible = true;
                    }
                }
            }
        }
    }
}