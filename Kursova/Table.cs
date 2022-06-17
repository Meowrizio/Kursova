using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursova
{
    public partial class Storage : Form
    {
        public Storage()
        {
            InitializeComponent();
        }

        private void BExit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void tKG5_Click(object sender, EventArgs e)
        {

        }

        private void tKG6_Click(object sender, EventArgs e)
        {

        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            
        }

        
        private void btnLast_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Вивести останню поставка поточного дня?",
               "Поставка",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Information,
               MessageBoxDefaultButton.Button1,
               MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                 MessageBox.Show($"Назва фірми: {"Фосагро"}\nДата: {"28.05.2022"}\nФІО директора: {"Волков М.В"}\nЧас поставки: {"18:00"}\nВага: {"1000"}кг");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Вивести поставки які плануються на завтра до 12:00? ",
               "Поставки",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Information,
               MessageBoxDefaultButton.Button1,
               MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show($"Назва фірми: {"Техносила"}\nДата: {"29.05.2022"}\nФІО директора: {"Антипов А.С"}\nЧас поставки: {"8:00"}\nВага: {"2500"}кг");
                MessageBox.Show($"Назва фірми: {"ЛАНІТ"}\nДата: {"29.05.2022"}\nФІО директора: {"Генс И.Н"}\nЧас поставки: {"11:00"}\nВага: {"1300"}кг");
            }
        }

        private void tKG1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string data = textBox2.Text;
            string fio = textBox3.Text;
            string time = textBox4.Text;
            string KG = textBox5.Text;

            dataGridView1.Rows.Add(name,data,fio,time,KG);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.Unicode);
                try
                {
                    List<int> col_n = new List<int>();
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                        if (col.Visible)
                        {
                            col_n.Add(col.Index);
                        }
                    int x = dataGridView1.RowCount;
                    if (dataGridView1.AllowUserToAddRows) x--;

                    for (int i = 0; i < x; i++)
                    {
                        for (int y = 0; y < col_n.Count; y++)
                            sw.Write(dataGridView1[col_n[y], i].Value + "\t");
                        sw.Write(" \r\n");
                    }
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<string[]> rows = File.ReadAllLines("C:/Users/Meowrizio/Desktop/k/Kursova/Table.txt").Select(x => x.Split('|')).ToList();

            // добавить строки в  dataGridView
            for (int i = 0; i < rows.Count; i++)
            {
                dataGridView1.Rows.Add(rows[i]);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
