using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Benefit_1 : Form
    {
        Repo re = new Repo();
        booking s = new booking();
        public Benefit_1()
        {
            InitializeComponent();
            re.Database.EnsureCreated();

            load();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int Id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                s = (from c in re.booking.ToList()
                     where c.id == Id
                     select c).FirstOrDefault();

                s.price.ToString();
                
            }
        }
        void load()
        {
            string date1 = dateTimePicker1.Value.ToShortDateString();
            string date2 = dateTimePicker2.Value.ToShortDateString();

            var list = re.booking.ToList();

            var res = (from c in list
                      let t = DateTime.Parse(c.date)
                      where t >= DateTime.Parse(date1)
                      && t <= DateTime.Parse(date2)
                      select c).ToList();





            dataGridView1.DataSource = res.ToList();

            textBox1.Text = res.Sum(c=>c.price).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            hello h = new hello();
            h.Show();
            Hide();
        }

        private void Benefit_1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            load();


        }
    }
}
