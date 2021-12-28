using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            db.Database.EnsureCreated();
            string usrName = textBox1.Text;
            string password = textBox2.Text;

            user s = (from c in db.user.ToList()
                            where c.name == usrName && c.password == password
                            select c).FirstOrDefault();


            if (s == null)
            {
                MessageBox.Show("faild Login");
            }
            else
            {
                var res = MessageBox.Show("Do you want log in", "log in", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    hello f = new hello();
                    f.Show();
                    Hide();
                }
                else
                {
                    textBox1.Text = null;
                    textBox2.Text = null;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
