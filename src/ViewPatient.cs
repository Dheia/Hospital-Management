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
    public partial class ViewPatient : Form
    {
        private Menu menu;

        public ViewPatient()
        {
            InitializeComponent();
        }

        public ViewPatient(Menu menu)
        {
            // TODO: Complete member initialization
            this.menu = menu;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();
                label2.Text = db.getPatientName(textBox1.Text);
                label3.Text = db.getPatientDisease(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("No patient linked with that ID");
            }
        }
    }
}
