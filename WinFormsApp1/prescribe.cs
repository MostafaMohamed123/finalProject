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
    public partial class prescribe : Form
    {
        Repo re = new Repo();
        prescribe_1 s = new prescribe_1();
        

        public prescribe()
        {
            InitializeComponent();
            re.Database.EnsureCreated();

            load();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        void load()
        {
            dataGridView1.DataSource = re.prescribes.ToList();
        }
        private void prescribe_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {
                int Id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                s = (from c in re.prescribes.ToList()
                     where c.id == Id
                     select c).FirstOrDefault();



                textBox2.Text = s.patient_diagnosis;
                textBox1.Text = s.medication;
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prescribe_1 p = new prescribe_1();
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 )
            {
                Console.WriteLine("error");
            }
            else
            {

                
                p.patient_diagnosis = textBox2.Text;
                p.medication = textBox1.Text;



                re.prescribes.Add(p);
                re.SaveChanges();
                MessageBox.Show("you are add", "Add");

                textBox1.Text = " ";
                textBox2.Text = " ";
               

                load();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 )
            {
                Console.WriteLine("error");
            }
            else
            {

               
                s.patient_diagnosis = textBox2.Text;
                s.medication = textBox1.Text;

                re.prescribes.Update(s);
                re.SaveChanges();
                MessageBox.Show("you are update", "Update");

                textBox1.Text = " ";
                textBox2.Text = " ";
                

                load();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 )
            {
                Console.WriteLine("error");
            }
            else
            {

                re.prescribes.Remove(s);
                re.SaveChanges();
                MessageBox.Show("you are delete", "Delete");
                textBox1.Text = " ";
                textBox2.Text = " ";
               

                load();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hello h=new hello();
            h.Show();
            Hide();
        }
    }
}
