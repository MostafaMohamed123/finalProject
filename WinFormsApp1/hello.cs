using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class hello : Form
    {
        public hello()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patient_1 f = new patient_1();
            f.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Booking_1 f = new Booking_1();
            f.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Benefit_1 f = new Benefit_1();
            f.Show();
            Hide();
        }

        private void hello_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f=new Form1();
            f.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            prescribe p = new prescribe();
            p.Show();
            Hide();
        }
    }
}
