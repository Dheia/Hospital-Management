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
    public partial class ViewDoc : Form
    {
        private Menu parent;
        public ViewDoc(Menu parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void ViewDoc_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                label2.Text = db.getDocName(textBox1.Text);
                label3.Text = db.getDocSpec(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("No doctor linked with that ID");
            }

        }
    }
}
