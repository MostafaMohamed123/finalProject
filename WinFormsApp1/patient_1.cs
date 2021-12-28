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
    public partial class patient_1 : Form
    {
       
        Repo re = new Repo();
        patient s = new patient();
        public patient_1()
        {
            InitializeComponent();
            re.Database.EnsureCreated();

            load();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        void load()
        {
            dataGridView1.DataSource = re.patient.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            patient p = new patient();
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || comboBox1.Text.Length == 0 || textBox3.Text.Length == 0 || textBox5.Text.Length == 0 )
            {
                MessageBox.Show("Not Enter");
            }
            else if (textBox3.Text.Length != 11)
            {
                MessageBox.Show("error");
            }
            else
            {
              

                
                    p.name = textBox1.Text;
                    p.address = textBox2.Text;
                    p.gender = comboBox1.Text;
               
            
                    p.phone = textBox3.Text;
                 
                    p.age = int.Parse(textBox5.Text);
                   // p.date = textBox4.Text;
                    re.patient.Add(p);
                    re.SaveChanges();

                MessageBox.Show("you are Add","Add");
                    
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                 //   textBox6.Text = " ";
                    textBox3.Text = " ";
                    textBox5.Text = " ";
                   
                
                    load();
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {
                int Id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                s = (from c in re.patient.ToList()
                     where c.id == Id
                     select c).FirstOrDefault();


             
                 textBox1.Text = s.name ;
                textBox2.Text = s.address  ;
                comboBox1.Text = s.gender ;
                 textBox3.Text = s.phone ;
                 textBox5.Text = s.age.ToString();
               // textBox4.Text = s.date;
            }
        }





        private void button4_Click(object sender, EventArgs e)
        {
            hello h=new hello();
            h.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || comboBox1.Text.Length == 0 || textBox3.Text.Length == 0 || textBox5.Text.Length == 0 )
            {
                MessageBox.Show("Not Enter");
            }
            else
            {
                s.name = textBox1.Text;
                s.address = textBox2.Text;
                s.gender = comboBox1.Text;
                s.phone = textBox3.Text;
                s.age = int.Parse(textBox5.Text);
              //  s.date = textBox4.Text;
                

                    re.patient.Update(s);
                    re.SaveChanges();

                MessageBox.Show("you are update","Update");

                textBox1.Text = " ";
                    textBox2.Text = " ";
                //    textBox6.Text = " ";
                    textBox3.Text = " ";
                    textBox5.Text = " ";
                   
                
                load();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || comboBox1.Text.Length == 0 || textBox3.Text.Length == 0 || textBox5.Text.Length == 0)
            {
                MessageBox.Show("Not Enter");
            }
            else
            {
                
               
                    re.patient.Remove(s);
                    re.SaveChanges();

                MessageBox.Show("you are delete", "Delete");

                textBox1.Text = " ";
                    textBox2.Text = " ";
                //    textBox6.Text = " ";
                    textBox3.Text = " ";
                    textBox5.Text = " ";
                   
                
               

                load();
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void patient_1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
