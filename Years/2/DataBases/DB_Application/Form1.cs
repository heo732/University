using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace DB_Application
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        CultureInfo provider = CultureInfo.InvariantCulture;

        public void hidePanels()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9_1.Visible = false;
            panel9_2.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
        }
        
        public void showPanel(string panel)
        {
            switch (panel)
            {
                case "1":
                    {
                        panel1.Visible = true;
                        break;
                   }
                case "2":
                    {
                        panel2.Visible = true;
                        break;
                    }
                case "3":
                    {
                        panel3.Visible = true;
                        break;
                    }
                case "4":
                    {
                        panel4.Visible = true;
                        break;
                    }
                case "5":
                    {
                        panel5.Visible = true;
                        break;
                    }
                case "6":
                    {
                        panel6.Visible = true;
                        break;
                    }
                case "7":
                    {
                        panel7.Visible = true;
                        break;
                    }
                case "8":
                    {
                        panel8.Visible = true;
                        break;
                    }
                case "9_1":
                    {
                        panel9_1.Visible = true;
                        break;
                    }
                case "9_2":
                    {
                        panel9_2.Visible = true;
                        break;
                    }
                case "10":
                    {
                        panel10.Visible = true;
                        break;
                    }
                case "11":
                    {
                        panel11.Visible = true;
                        break;
                    }
                case "12":
                    {
                        panel12.Visible = true;
                        break;
                    }
                case "13":
                    {
                        panel13.Visible = true;
                        break;
                    }
            }                
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=COMPUTER;Initial Catalog=Airport;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            hidePanels();
            showPanel("1");
            listView1.Clear();            
            this.AcceptButton = button1;

            panelTop.VerticalScroll.Maximum = 0;
            panelTop.AutoScroll = false;
            panelTop.VerticalScroll.Visible = false;
            panelTop.AutoScroll = true;

            comboBox2.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Назва FROM Відділи", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox2.Items.Add(Convert.ToString(sqlReader["Назва"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private async void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("1");
            query11ToolStripMenuItem.Text = "Query_1";
            listView1.Clear();
            this.AcceptButton = button1;

            comboBox1.SelectedItem = "всі";

            comboBox2.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Назва FROM Відділи", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox2.Items.Add(Convert.ToString(sqlReader["Назва"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            
            listView1.Columns.Add("Прізвище");
            listView1.Columns.Add("Ім'я");
            listView1.Columns.Add("ПоБатькові");
            listView1.Columns.Add("Відділ");
            listView1.Columns.Add("КількістьДітей");
            listView1.Columns.Add("ЗаробітнаПлата");
            listView1.Columns.Add("Вік");
            listView1.Columns.Add("Стаж");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query1", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;


            if(comboBox1.Text == "начальники")
                command.Parameters.AddWithValue("@начальники", "начальники");
            else
                command.Parameters.AddWithValue("@начальники", null);

            if (comboBox2.Items.IndexOf(comboBox2.Text) >= 0)
                command.Parameters.AddWithValue("@відділ", comboBox2.Text);
            else
                command.Parameters.AddWithValue("@відділ", null);

            if(comboBox3.Text == "жін")
                command.Parameters.AddWithValue("@стать", false);
            else if(comboBox3.Text == "чол")
                command.Parameters.AddWithValue("@стать", true);
            else
                command.Parameters.AddWithValue("@стать", null);
            
            command.Parameters.AddWithValue("@кількістьДітейНижняМежа", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@кількістьДітейВерхняМежа", maskedTextBox2.Text);

            command.Parameters.AddWithValue("@ЗПНижняМежа", maskedTextBox4.Text);
            command.Parameters.AddWithValue("@ЗПВерхняМежа", maskedTextBox3.Text);

            command.Parameters.AddWithValue("@вікНижняМежа", maskedTextBox6.Text);
            command.Parameters.AddWithValue("@вікВерхняМежа", maskedTextBox5.Text);

            command.Parameters.AddWithValue("@стажНижняМежа", maskedTextBox8.Text);
            command.Parameters.AddWithValue("@стажВерхняМежа", maskedTextBox7.Text);


            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["Прізвище"]),
                        Convert.ToString(sqlReader["Ім'я"]),
                        Convert.ToString(sqlReader["ПоБатькові"]),
                        Convert.ToString(sqlReader["Відділ"]),
                        Convert.ToString(sqlReader["КількістьДітей"]),
                        Convert.ToString(sqlReader["ЗаробітнаПлата"]),
                        Convert.ToString(sqlReader["Вік"]),
                        Convert.ToString(sqlReader["Стаж"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("2");
            query11ToolStripMenuItem.Text = "Query_2";
            listView1.Clear();
            this.AcceptButton = button2;
                        
            comboBox6.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT Назва FROM Бригади", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox6.Items.Add(Convert.ToString(sqlReader["Назва"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            comboBox5.Items.Clear();
            command = new SqlCommand("SELECT Назва FROM Відділи", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox5.Items.Add(Convert.ToString(sqlReader["Назва"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            comboBox4.Items.Clear();
            command = new SqlCommand("SELECT ID FROM Рейси", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox4.Items.Add(Convert.ToString(sqlReader["ID"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("Прізвище");
            listView1.Columns.Add("Ім'я");
            listView1.Columns.Add("ПоБатькові");
            listView1.Columns.Add("Бригада");
            listView1.Columns.Add("Відділ");
            listView1.Columns.Add("РейсID");
            listView1.Columns.Add("Вік");
            listView1.Columns.Add("ЗаробітнаПлата");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query2", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            
            if(comboBox6.Items.Contains(comboBox6.Text))
                command.Parameters.AddWithValue("@бригада", comboBox6.Text);
            else
                command.Parameters.AddWithValue("@бригада", null);

            if (comboBox5.Items.Contains(comboBox5.Text))
                command.Parameters.AddWithValue("@відділ", comboBox5.Text);
            else
                command.Parameters.AddWithValue("@відділ", null);

            if (comboBox4.Items.Contains(comboBox4.Text))
                command.Parameters.AddWithValue("@рейс", comboBox4.Text);
            else
                command.Parameters.AddWithValue("@рейс", null);

            command.Parameters.AddWithValue("@вікНижняМежа", maskedTextBox12.Text);
            command.Parameters.AddWithValue("@вікВерхняМежа", maskedTextBox11.Text);

            command.Parameters.AddWithValue("@ЗПНижняМежа", maskedTextBox14.Text);
            command.Parameters.AddWithValue("@ЗПВерхняМежа", maskedTextBox13.Text);

            command.Parameters.AddWithValue("@середняЗПуБригадіНижняМежа", maskedTextBox10.Text);
            command.Parameters.AddWithValue("@середняЗПуБригадіВерхняМежа", maskedTextBox9.Text);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["Прізвище"]),
                        Convert.ToString(sqlReader["Ім'я"]),
                        Convert.ToString(sqlReader["ПоБатькові"]),
                        Convert.ToString(sqlReader["Бригада"]),
                        Convert.ToString(sqlReader["Відділ"]),
                        Convert.ToString(sqlReader["РейсID"]),
                        Convert.ToString(sqlReader["Вік"]),
                        Convert.ToString(sqlReader["ЗаробітнаПлата"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("3");
            query11ToolStripMenuItem.Text = "Query_3";
            listView1.Clear();
            this.AcceptButton = button3;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("Прізвище");
            listView1.Columns.Add("Ім'я");
            listView1.Columns.Add("ПоБатькові");
            listView1.Columns.Add("Вік");
            listView1.Columns.Add("ЗаробітнаПлата");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query3", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;


            if (comboBox9.Text == "пройшли")
                command.Parameters.AddWithValue("@пройшли_неПройшли", true);
            else if(comboBox9.Text == "не пройшли")
                command.Parameters.AddWithValue("@пройшли_неПройшли", false);
            else
                command.Parameters.AddWithValue("@пройшли_неПройшли", null);

            command.Parameters.AddWithValue("@рікНижняМежа", maskedTextBox16.Text);
            command.Parameters.AddWithValue("@рікВерхняМежа", maskedTextBox15.Text);

            if (comboBox8.Text == "жін")
                command.Parameters.AddWithValue("@стать", false);
            else if (comboBox8.Text == "чол")
                command.Parameters.AddWithValue("@стать", true);
            else
                command.Parameters.AddWithValue("@стать", null);
                        
            command.Parameters.AddWithValue("@вікНижняМежа", maskedTextBox18.Text);
            command.Parameters.AddWithValue("@вікВерхняМежа", maskedTextBox17.Text);

            command.Parameters.AddWithValue("@ЗПНижняМежа", maskedTextBox20.Text);
            command.Parameters.AddWithValue("@ЗПВерхняМежа", maskedTextBox19.Text);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["Прізвище"]),
                        Convert.ToString(sqlReader["Ім'я"]),
                        Convert.ToString(sqlReader["ПоБатькові"]),
                        Convert.ToString(sqlReader["Вік"]),
                        Convert.ToString(sqlReader["ЗаробітнаПлата"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("4");
            query11ToolStripMenuItem.Text = "Query_4";
            listView1.Clear();
            this.AcceptButton = button4;

            comboBox10.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT DISTINCT КінцевийПункт FROM Маршрути", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox10.Items.Add(Convert.ToString(sqlReader["КінцевийПункт"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("Номер");
            listView1.Columns.Add("Тип");
            listView1.Columns.Add("ДатаВипуску");
            listView1.Columns.Add("КількістьМісць");
            listView1.Columns.Add("Бригада");
            listView1.Columns.Add("ДатаЧасНатходження");
            listView1.Columns.Add("КількістьЗдійсненихРейсів");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query4", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;


            if (comboBox10.Items.Contains(comboBox10.Text))
                command.Parameters.AddWithValue("@аеропорт", comboBox10.Text);
            else
                command.Parameters.AddWithValue("@аеропорт", "Чернівці");

            try
            {
                command.Parameters.AddWithValue("@датаЧасНижняМежа", DateTime.ParseExact(maskedTextBox22.Text, "dd.MM.yyyy hh:mm", provider));
                command.Parameters.AddWithValue("@датаЧасВерхняМежа", DateTime.ParseExact(maskedTextBox21.Text, "dd.MM.yyyy hh:mm", provider));
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.Parameters.AddWithValue("@кількістьРейсівНижняМежа", maskedTextBox26.Text);
            command.Parameters.AddWithValue("@кількістьРейсівВерхняМежа", maskedTextBox25.Text);
            
            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["Номер"]),
                        Convert.ToString(sqlReader["Тип"]),
                        Convert.ToString(sqlReader["ДатаВипуску"]),
                        Convert.ToString(sqlReader["КількістьМісць"]),
                        Convert.ToString(sqlReader["Бригада"]),
                        Convert.ToString(sqlReader["ДатаЧасНатходження"]),
                        Convert.ToString(sqlReader["КількістьЗдійсненихРейсів"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("5");
            query11ToolStripMenuItem.Text = "Query_5";
            listView1.Clear();
            this.AcceptButton = button5;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("Номер");
            listView1.Columns.Add("Тип");
            listView1.Columns.Add("ДатаВипуску");
            listView1.Columns.Add("КількістьМісць");
            listView1.Columns.Add("Бригада");
            listView1.Columns.Add("Вік");
            listView1.Columns.Add("ЧислоРемонтів");
            listView1.Columns.Add("РейсівДоРемонту");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query5", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;


            if (comboBox7.Text == "пройшов")
                command.Parameters.AddWithValue("@чиПройшов", true);
            else if (comboBox7.Text == "не пройшов")
                command.Parameters.AddWithValue("@чиПройшов", false);
            else
                command.Parameters.AddWithValue("@чиПройшов", null);

            try
            {
                command.Parameters.AddWithValue("@датаНижняМежа", DateTime.ParseExact(maskedTextBox24.Text, "dd.MM.yyyy", provider));
                command.Parameters.AddWithValue("@датаВерхняМежа", DateTime.ParseExact(maskedTextBox23.Text, "dd.MM.yyyy", provider));
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.Parameters.AddWithValue("@числоРемонтівНижняМежа", maskedTextBox28.Text);
            command.Parameters.AddWithValue("@числоРемонтівВерхняМежа", maskedTextBox27.Text);

            command.Parameters.AddWithValue("@рейсівДоРемонтуНижняМежа", maskedTextBox30.Text);
            command.Parameters.AddWithValue("@рейсівДоРемонтуВерхняМежа", maskedTextBox29.Text);

            command.Parameters.AddWithValue("@вікНижняМежа", maskedTextBox32.Text);
            command.Parameters.AddWithValue("@вікВерхняМежа", maskedTextBox31.Text);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["Номер"]),
                        Convert.ToString(sqlReader["Тип"]),
                        Convert.ToString(sqlReader["ДатаВипуску"]),
                        Convert.ToString(sqlReader["КількістьМісць"]),
                        Convert.ToString(sqlReader["Бригада"]),
                        Convert.ToString(sqlReader["Вік"]),
                        Convert.ToString(sqlReader["ЧислоРемонтів"]),
                        Convert.ToString(sqlReader["РейсівДоРемонту"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("6");
            query11ToolStripMenuItem.Text = "Query_6";
            listView1.Clear();
            this.AcceptButton = button6;

            comboBox11.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT  ID, ПочатковийПункт, ПунктПересадки, КінцевийПункт FROM Маршрути", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox11.Items.Add(
                        Convert.ToString(sqlReader["ID"]) +
                        "   " +
                        Convert.ToString(sqlReader["ПочатковийПункт"]) +
                        "/" +
                        Convert.ToString(sqlReader["ПунктПересадки"]) +
                        "/" +
                        Convert.ToString(sqlReader["КінцевийПункт"])
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("НомерЛітака");
            listView1.Columns.Add("СтатусРейсу");
            listView1.Columns.Add("ТипРейсу");
            listView1.Columns.Add("ЦінаКвитка");
            listView1.Columns.Add("ТривалістьПерельоту");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query6", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;


            if (comboBox11.Items.Contains(comboBox11.Text))
            {
                int wayInt = 0;
                string wayString = "";
                int i = 0;
                while (comboBox11.Text[i] != ' ')
                {
                    wayString += comboBox11.Text[i];
                    i++;
                }
                wayInt = int.Parse(wayString);
                command.Parameters.AddWithValue("@маршрут", wayInt);
            }
            else
                command.Parameters.AddWithValue("@маршрут", null);

            command.Parameters.AddWithValue("@тривалістьПерельотуНижняМежа", maskedTextBox40.Text);
            command.Parameters.AddWithValue("@тривалістьПерельотуВерхняМежа", maskedTextBox39.Text);

            command.Parameters.AddWithValue("@цінаКвиткаНижняМежа", maskedTextBox36.Text);
            command.Parameters.AddWithValue("@цінаКвиткаВерхняМежа", maskedTextBox35.Text);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["НомерЛітака"]),
                        Convert.ToString(sqlReader["СтатусРейсу"]),
                        Convert.ToString(sqlReader["ТипРейсу"]),
                        Convert.ToString(sqlReader["ЦінаКвитка"]),
                        Convert.ToString(sqlReader["ТривалістьПерельоту"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("7");
            query11ToolStripMenuItem.Text = "Query_7";
            listView1.Clear();
            this.AcceptButton = button7;

            comboBox12.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT  ID, ПочатковийПункт, ПунктПересадки, КінцевийПункт FROM Маршрути", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox12.Items.Add(
                        Convert.ToString(sqlReader["ID"]) +
                        "   " +
                        Convert.ToString(sqlReader["ПочатковийПункт"]) +
                        "/" +
                        Convert.ToString(sqlReader["ПунктПересадки"]) +
                        "/" +
                        Convert.ToString(sqlReader["КінцевийПункт"])
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            comboBox13.Items.Clear();
            command = new SqlCommand("SELECT DISTINCT КінцевийПункт FROM Маршрути ORDER BY КінцевийПункт", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox13.Items.Add(Convert.ToString(sqlReader["КінцевийПункт"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("НомерРейсу");
            listView1.Columns.Add("НомерЛітака");
            listView1.Columns.Add("ТипРейсу");
            listView1.Columns.Add("КількістьНевикористанихМісць");
            listView1.Columns.Add("ВідсотокНевикористанихМісць");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query7", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            if (comboBox12.Items.Contains(comboBox12.Text))
            {
                int wayInt = 0;
                string wayString = "";
                int i = 0;
                while (comboBox12.Text[i] != ' ')
                {
                    wayString += comboBox12.Text[i];
                    i++;
                }
                wayInt = int.Parse(wayString);
                command.Parameters.AddWithValue("@маршрут", wayInt);
            }
            else
                command.Parameters.AddWithValue("@маршрут", null);

            if (comboBox13.Items.Contains(comboBox13.Text))
                command.Parameters.AddWithValue("@напрямок", comboBox13.Text);
            else
                command.Parameters.AddWithValue("@напрямок", null);

            command.Parameters.AddWithValue("@кількістьНевикористанихМісцьНижняМежа", maskedTextBox38.Text);
            command.Parameters.AddWithValue("@кількістьНевикористанихМісцьВерхняМежа", maskedTextBox37.Text);

            command.Parameters.AddWithValue("@відсотокНевикористанихМісцьНижняМежа", maskedTextBox34.Text);
            command.Parameters.AddWithValue("@відсотокНевикористанихМісцьВерхняМежа", maskedTextBox33.Text);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["НомерРейсу"]),
                        Convert.ToString(sqlReader["НомерЛітака"]),
                        Convert.ToString(sqlReader["ТипРейсу"]),
                        Convert.ToString(sqlReader["КількістьНевикористанихМісць"]),
                        Convert.ToString(sqlReader["ВідсотокНевикористанихМісць"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("8");
            query11ToolStripMenuItem.Text = "Query_8";
            listView1.Clear();
            this.AcceptButton = button8;

            comboBox14.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT  ID, ПочатковийПункт, ПунктПересадки, КінцевийПункт FROM Маршрути", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox14.Items.Add(
                        Convert.ToString(sqlReader["ID"]) +
                        "   " +
                        Convert.ToString(sqlReader["ПочатковийПункт"]) +
                        "/" +
                        Convert.ToString(sqlReader["ПунктПересадки"]) +
                        "/" +
                        Convert.ToString(sqlReader["КінцевийПункт"])
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            comboBox15.Items.Clear();
            command = new SqlCommand("SELECT DISTINCT Статус FROM СтатусРейсу WHERE Статус LIKE '%затрим%' ORDER BY Статус", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox15.Items.Add(Convert.ToString(sqlReader["Статус"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("НомерРейсу");
            listView1.Columns.Add("НомерЛітака");
            listView1.Columns.Add("ТипРейсу");
            listView1.Columns.Add("ПричинаЗатримки");
            listView1.Columns.Add("КількістьЗданихКвитків");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query8", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            if (comboBox14.Items.Contains(comboBox14.Text))
            {
                int wayInt = 0;
                string wayString = "";
                int i = 0;
                while (comboBox14.Text[i] != ' ')
                {
                    wayString += comboBox14.Text[i];
                    i++;
                }
                wayInt = int.Parse(wayString);
                command.Parameters.AddWithValue("@маршрут", wayInt);
            }
            else
                command.Parameters.AddWithValue("@маршрут", null);

            if (comboBox15.Items.Contains(comboBox15.Text))
                command.Parameters.AddWithValue("@причинаЗатримки", comboBox15.Text);
            else
                command.Parameters.AddWithValue("@причинаЗатримки", null);

            command.Parameters.AddWithValue("@кількістьЗданихКвитківНижняМежа", maskedTextBox44.Text);
            command.Parameters.AddWithValue("@кількістьЗданихКвитківВерхняМежа", maskedTextBox43.Text);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["НомерРейсу"]),
                        Convert.ToString(sqlReader["НомерЛітака"]),
                        Convert.ToString(sqlReader["ТипРейсу"]),
                        Convert.ToString(sqlReader["ПричинаЗатримки"]),
                        Convert.ToString(sqlReader["КількістьЗданихКвитків"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("НомерРейсу");
            listView1.Columns.Add("НомерЛітака");
            listView1.Columns.Add("ТипЛітака");
            listView1.Columns.Add("ТипРейсу");
            listView1.Columns.Add("СтатусРейсу");
            listView1.Columns.Add("ТривалістьПерельоту");
            listView1.Columns.Add("ЦінаКвитка");
            listView1.Columns.Add("ЧасВильоту");
            listView1.Columns.Add("НомерМаршруту");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query9_1", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
                        
            if (comboBox17.Items.Contains(comboBox17.Text))
                command.Parameters.AddWithValue("@типЛітака", comboBox17.Text);
            else
                command.Parameters.AddWithValue("@типЛітака", null);

            command.Parameters.AddWithValue("@тривалістьПерельотуНижняМежа", maskedTextBox42.Text);
            command.Parameters.AddWithValue("@тривалістьПерельотуВерхняМежа", maskedTextBox41.Text);

            command.Parameters.AddWithValue("@цінаКвиткаНижняМежа", maskedTextBox46.Text);
            command.Parameters.AddWithValue("@цінаКвиткаВерхняМежа", maskedTextBox45.Text);

            command.Parameters.AddWithValue("@часВильотуНижняМежа", maskedTextBox48.Text);
            command.Parameters.AddWithValue("@часВильотуВерхняМежа", maskedTextBox47.Text);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["НомерРейсу"]),
                        Convert.ToString(sqlReader["НомерЛітака"]),
                        Convert.ToString(sqlReader["ТипЛітака"]),
                        Convert.ToString(sqlReader["ТипРейсу"]),
                        Convert.ToString(sqlReader["СтатусРейсу"]),
                        Convert.ToString(sqlReader["ТривалістьПерельоту"]),
                        Convert.ToString(sqlReader["ЦінаКвитка"]),
                        Convert.ToString(sqlReader["ЧасВильоту"]),
                        Convert.ToString(sqlReader["НомерМаршруту"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("9_1");
            query11ToolStripMenuItem.Text = "Query_9_1";
            listView1.Clear();
            this.AcceptButton = button9_1;
                        
            comboBox17.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT DISTINCT Тип FROM ТипиЛітаків ORDER BY Тип", sqlConnection);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox17.Items.Add(Convert.ToString(sqlReader["Тип"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("9_2");
            query11ToolStripMenuItem.Text = "Query_9_2";
            listView1.Clear();
            this.AcceptButton = button9_2;

            comboBox16.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT DISTINCT Тип FROM ТипиЛітаків ORDER BY Тип", sqlConnection);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox16.Items.Add(Convert.ToString(sqlReader["Тип"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            comboBox18.Items.Clear();
            command = new SqlCommand("SELECT  ID, ПочатковийПункт, ПунктПересадки, КінцевийПункт FROM Маршрути", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox18.Items.Add(
                        Convert.ToString(sqlReader["ID"]) +
                        "   " +
                        Convert.ToString(sqlReader["ПочатковийПункт"]) +
                        "/" +
                        Convert.ToString(sqlReader["ПунктПересадки"]) +
                        "/" +
                        Convert.ToString(sqlReader["КінцевийПункт"])
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button9_2_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("НомерМаршруту");
            listView1.Columns.Add("СередняКількістьПроданихКвитків");
            listView1.Columns.Add("ПочатковийПункт");
            listView1.Columns.Add("ПунктПересадки");
            listView1.Columns.Add("КінцевийПункт");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query9_2", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            if (comboBox18.Items.Contains(comboBox18.Text))
            {
                int wayInt = 0;
                string wayString = "";
                int i = 0;
                while (comboBox18.Text[i] != ' ')
                {
                    wayString += comboBox18.Text[i];
                    i++;
                }
                wayInt = int.Parse(wayString);
                command.Parameters.AddWithValue("@маршрут", wayInt);
            }
            else
                command.Parameters.AddWithValue("@маршрут", null);

            if (comboBox16.Items.Contains(comboBox16.Text))
                command.Parameters.AddWithValue("@типЛітака", comboBox16.Text);
            else
                command.Parameters.AddWithValue("@типЛітака", null);

            command.Parameters.AddWithValue("@тривалістьПерельотуНижняМежа", maskedTextBox54.Text);
            command.Parameters.AddWithValue("@тривалістьПерельотуВерхняМежа", maskedTextBox53.Text);

            command.Parameters.AddWithValue("@цінаКвиткаНижняМежа", maskedTextBox52.Text);
            command.Parameters.AddWithValue("@цінаКвиткаВерхняМежа", maskedTextBox51.Text);

            command.Parameters.AddWithValue("@часВильотуНижняМежа", maskedTextBox50.Text);
            command.Parameters.AddWithValue("@часВильотуВерхняМежа", maskedTextBox49.Text);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["НомерМаршруту"]),
                        Convert.ToString(sqlReader["СередняКількістьПроданихКвитків"]),
                        Convert.ToString(sqlReader["ПочатковийПункт"]),
                        Convert.ToString(sqlReader["ПунктПересадки"]),
                        Convert.ToString(sqlReader["КінцевийПункт"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("10");
            query11ToolStripMenuItem.Text = "Query_10";
            listView1.Clear();
            this.AcceptButton = button10;

            comboBox20.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT DISTINCT Тип FROM ТипиРейсів ORDER BY Тип", sqlConnection);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox20.Items.Add(Convert.ToString(sqlReader["Тип"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            comboBox19.Items.Clear();
            command = new SqlCommand("SELECT DISTINCT КінцевийПункт FROM Маршрути ORDER BY КінцевийПункт", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox19.Items.Add(Convert.ToString(sqlReader["КінцевийПункт"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            comboBox21.Items.Clear();
            command = new SqlCommand("SELECT DISTINCT Тип FROM ТипиЛітаків ORDER BY Тип", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox21.Items.Add(Convert.ToString(sqlReader["Тип"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("НомерРейсу");
            listView1.Columns.Add("НомерЛітака");
            listView1.Columns.Add("ТипРейсу");
            listView1.Columns.Add("СтатусРейсу");
            listView1.Columns.Add("Напрямок");
            listView1.Columns.Add("ТипЛітака");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query10", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            if (comboBox20.Items.Contains(comboBox20.Text))
                command.Parameters.AddWithValue("@типРейсу", comboBox20.Text);
            else
                command.Parameters.AddWithValue("@типРейсу", null);

            if (comboBox19.Items.Contains(comboBox19.Text))
                command.Parameters.AddWithValue("@напрямок", comboBox19.Text);
            else
                command.Parameters.AddWithValue("@напрямок", null);

            if (comboBox21.Items.Contains(comboBox21.Text))
                command.Parameters.AddWithValue("@типЛітака", comboBox21.Text);
            else
                command.Parameters.AddWithValue("@типЛітака", null);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["НомерРейсу"]),
                        Convert.ToString(sqlReader["НомерЛітака"]),
                        Convert.ToString(sqlReader["ТипРейсу"]),
                        Convert.ToString(sqlReader["СтатусРейсу"]),
                        Convert.ToString(sqlReader["Напрямок"]),
                        Convert.ToString(sqlReader["ТипЛітака"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("11");
            query11ToolStripMenuItem.Text = "Query_11";
            listView1.Clear();
            this.AcceptButton = button11;
            
            comboBox23.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT ID FROM Рейси", sqlConnection);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox23.Items.Add(Convert.ToString(sqlReader["ID"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }            
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("НомерРейсу");
            listView1.Columns.Add("ТипРейсу");
            listView1.Columns.Add("ДеньВідльоту");
            listView1.Columns.Add("Пасажир");
            listView1.Columns.Add("Стать");
            listView1.Columns.Add("Вік");
            listView1.Columns.Add("Багаж");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query11", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            if (comboBox23.Items.Contains(comboBox23.Text))
                command.Parameters.AddWithValue("@рейс", comboBox23.Text);
            else
                command.Parameters.AddWithValue("@рейс", null);

            try
            {
                if (maskedTextBox55.MaskFull)
                    command.Parameters.AddWithValue("@деньВідльоту", DateTime.ParseExact(maskedTextBox55.Text, "dd.MM.yyyy", provider));
                else
                    command.Parameters.AddWithValue("@деньВідльоту", null);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (comboBox24.Text == "True")
                command.Parameters.AddWithValue("@заКордон", true);
            else if (comboBox24.Text == "False")
                command.Parameters.AddWithValue("@заКордон", false);
            else
                command.Parameters.AddWithValue("@заКордон", null);

            if (comboBox25.Text == "True")
                command.Parameters.AddWithValue("@наявністьБагажу", true);
            else if (comboBox25.Text == "False")
                command.Parameters.AddWithValue("@наявністьБагажу", false);
            else
                command.Parameters.AddWithValue("@наявністьБагажу", null);

            if (comboBox26.Text == "чол")
                command.Parameters.AddWithValue("@стать", true);
            else if (comboBox26.Text == "жін")
                command.Parameters.AddWithValue("@стать", false);
            else
                command.Parameters.AddWithValue("@стать", null);

            command.Parameters.AddWithValue("@вікНижняМежа", maskedTextBox60.Text);
            command.Parameters.AddWithValue("@вікВерхняМежа", maskedTextBox59.Text);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["НомерРейсу"]),
                        Convert.ToString(sqlReader["ТипРейсу"]),
                        Convert.ToString(sqlReader["ДеньВідльоту"]),
                        Convert.ToString(sqlReader["Пасажир"]),
                        Convert.ToString(sqlReader["Стать"]),
                        Convert.ToString(sqlReader["Вік"]),
                        Convert.ToString(sqlReader["Багаж"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("12");
            query11ToolStripMenuItem.Text = "Query_12";
            listView1.Clear();
            this.AcceptButton = button12;

            comboBox29.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT ID FROM Рейси", sqlConnection);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox29.Items.Add(Convert.ToString(sqlReader["ID"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            comboBox28.Items.Clear();
            command = new SqlCommand("SELECT  ID, ПочатковийПункт, ПунктПересадки, КінцевийПункт FROM Маршрути", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox28.Items.Add(
                        Convert.ToString(sqlReader["ID"]) +
                        "   " +
                        Convert.ToString(sqlReader["ПочатковийПункт"]) +
                        "/" +
                        Convert.ToString(sqlReader["ПунктПересадки"]) +
                        "/" +
                        Convert.ToString(sqlReader["КінцевийПункт"])
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("НомерРейсу");
            listView1.Columns.Add("НомерМаршруту");
            listView1.Columns.Add("ДеньВильоту");
            listView1.Columns.Add("ЧасВильоту");
            listView1.Columns.Add("ЦінаКвитка");
            listView1.Columns.Add("ЗаброньованихМісць");
            listView1.Columns.Add("ВільнихМісць");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query12", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            if (comboBox29.Items.Contains(comboBox29.Text))
                command.Parameters.AddWithValue("@рейс", comboBox29.Text);
            else
                command.Parameters.AddWithValue("@рейс", null);

            try
            {
                if (maskedTextBox56.MaskFull)
                    command.Parameters.AddWithValue("@день", DateTime.ParseExact(maskedTextBox56.Text, "dd.MM.yyyy", provider));
                else
                    command.Parameters.AddWithValue("@день", null);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (comboBox28.Items.Contains(comboBox28.Text))
            {
                int wayInt = 0;
                string wayString = "";
                int i = 0;
                while (comboBox28.Text[i] != ' ')
                {
                    wayString += comboBox28.Text[i];
                    i++;
                }
                wayInt = int.Parse(wayString);
                command.Parameters.AddWithValue("@маршрут", wayInt);
            }
            else
                command.Parameters.AddWithValue("@маршрут", null);

            command.Parameters.AddWithValue("@цінаКвиткаНижняМежа", maskedTextBox62.Text);
            command.Parameters.AddWithValue("@цінаКвиткаВерхняМежа", maskedTextBox61.Text);

            try
            {
                command.Parameters.AddWithValue("@часВильотуНижняМежа", DateTime.ParseExact(maskedTextBox58.Text, "HH:mm:ss", provider));
                command.Parameters.AddWithValue("@часВильотуВерхняМежа", DateTime.ParseExact(maskedTextBox57.Text, "HH:mm:ss", provider));
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["НомерРейсу"]),
                        Convert.ToString(sqlReader["НомерМаршруту"]),
                        Convert.ToString(sqlReader["ДеньВильоту"]),
                        Convert.ToString(sqlReader["ЧасВильоту"]),
                        Convert.ToString(sqlReader["ЦінаКвитка"]),
                        Convert.ToString(sqlReader["ЗаброньованихМісць"]),
                        Convert.ToString(sqlReader["ВільнихМісць"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.Items.Add("");
                listView1.Items.Add("");
                ListViewItem item1 = new ListViewItem(new string[] { "Всього:", (listView1.Items.Count - 2).ToString() });
                listView1.Items.Add(item1);

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            hidePanels();
            showPanel("13");
            query11ToolStripMenuItem.Text = "Query_13";
            listView1.Clear();
            this.AcceptButton = button13;

            comboBox27.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT ID FROM Рейси", sqlConnection);
            SqlDataReader sqlReader = null;
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox27.Items.Add(Convert.ToString(sqlReader["ID"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

            comboBox22.Items.Clear();
            command = new SqlCommand("SELECT  ID, ПочатковийПункт, ПунктПересадки, КінцевийПункт FROM Маршрути", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox22.Items.Add(
                        Convert.ToString(sqlReader["ID"]) +
                        "   " +
                        Convert.ToString(sqlReader["ПочатковийПункт"]) +
                        "/" +
                        Convert.ToString(sqlReader["ПунктПересадки"]) +
                        "/" +
                        Convert.ToString(sqlReader["КінцевийПункт"])
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            listView1.Clear();

            listView1.Columns.Add("ЧислоЗданихКвитків");

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Query13", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            if (comboBox27.Items.Contains(comboBox27.Text))
                command.Parameters.AddWithValue("@рейс", comboBox27.Text);
            else
                command.Parameters.AddWithValue("@рейс", null);

            try
            {
                if (maskedTextBox65.MaskFull)
                    command.Parameters.AddWithValue("@деньВильоту", DateTime.ParseExact(maskedTextBox65.Text, "dd.MM.yyyy", provider));
                else
                    command.Parameters.AddWithValue("@деньВильоту", null);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (comboBox22.Items.Contains(comboBox22.Text))
            {
                int wayInt = 0;
                string wayString = "";
                int i = 0;
                while (comboBox22.Text[i] != ' ')
                {
                    wayString += comboBox22.Text[i];
                    i++;
                }
                wayInt = int.Parse(wayString);
                command.Parameters.AddWithValue("@маршрут", wayInt);
            }
            else
                command.Parameters.AddWithValue("@маршрут", null);

            command.Parameters.AddWithValue("@цінаКвиткаНижняМежа", maskedTextBox64.Text);
            command.Parameters.AddWithValue("@цінаКвиткаВерхняМежа", maskedTextBox63.Text);

            command.Parameters.AddWithValue("@вікНижняМежа", maskedTextBox67.Text);
            command.Parameters.AddWithValue("@вікВерхняМежа", maskedTextBox66.Text);           

            if (comboBox30.Text == "чол")
                command.Parameters.AddWithValue("@стать", true);
            else if (comboBox30.Text == "жін")
                command.Parameters.AddWithValue("@стать", false);
            else
                command.Parameters.AddWithValue("@стать", null);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {                       
	
                        Convert.ToString(sqlReader["ЧислоЗданихКвитків"])
                    });

                    listView1.Items.Add(item);
                }

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

                
    }
}
