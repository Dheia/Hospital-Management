using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalMgmt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("admin") && textBox2.Text.Equals("123"))
            {
                this.Hide();
                Menu m = new Menu(this);
                m.Show();
            }
            else
            {
                MessageBox.Show("Invalid Password");
                textBox1.Text = "";
                textBox2.Text = "";
            }

        }
    }
}
