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
    public partial class Booking_1 : Form
    {
        Repo re = new Repo();
        booking s = new booking();
       

        public Booking_1()
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



                textBox1.Text = s.price.ToString();
                textBox2.Text = s.date;
                textBox3.Text = s.booking_1;
                
            }
        }

        void load()
        {
            dataGridView1.DataSource = re.booking.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            booking p = new booking();
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                Console.WriteLine("error");
            }
            else
            {
                
                p.price = int.Parse(textBox1.Text);
                p.date = textBox2.Text;
                p.booking_1 = textBox3.Text;

               

                    re.booking.Add(p);
                    re.SaveChanges();
                MessageBox.Show("you are add", "Add");

                textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                
                load();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                Console.WriteLine("error");
            }
            else
            {

                s.price = int.Parse(textBox1.Text);
                s.date = textBox2.Text;
                s.booking_1 = textBox3.Text;
               
                    re.booking.Update(s);
                    re.SaveChanges();
                MessageBox.Show("you are update", "Update");

                textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                
                load();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hello h = new hello();
            h.Show();
            Hide();
        }

        private void Booking_1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 )
            {
                Console.WriteLine("error");
            }
            else
            {
                
                    re.booking.Remove(s);
                    re.SaveChanges();
                MessageBox.Show("you are delete", "Delete");
                textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                
                load();
               
               
            }
        }
    }
}
