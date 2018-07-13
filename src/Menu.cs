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
    public partial class Menu : Form
    {
        private Form1 parent;
        public Menu(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertDoc doc = new InsertDoc(this);
            doc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewDoc vd = new ViewDoc(this);
            vd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report rd = new Report(this);
            rd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertPatient ip = new InsertPatient(this);
            ip.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewPatient vp = new ViewPatient(this);
            vp.Show();
        }
    }
}
