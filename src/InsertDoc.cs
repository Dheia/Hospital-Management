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
    public partial class InsertDoc : Form
    {
        Menu parent;
        public InsertDoc(Menu parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void InsertDoc_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            MessageBox.Show(db.InsertDoc(textBox1.Text, textBox2.Text, textBox3.Text));
        }

    }
}
