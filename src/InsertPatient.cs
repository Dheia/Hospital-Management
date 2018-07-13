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
    public partial class InsertPatient : Form
    {
        private Menu parent;

        public InsertPatient()
        {
            InitializeComponent();
        }

        public InsertPatient(Menu parent)
        {
            // TODO: Complete member initialization
            this.parent = parent;
            InitializeComponent();

            Database db = new Database();
            List<String> listofDocs = db.getDocs();
            foreach (String s in listofDocs)
                comboBox1.Items.Add(s);
        }

        private void InsertPatient_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            MessageBox.Show(db.InsertPatient(textBox1.Text, textBox2.Text, textBox3.Text, db.getDocId(comboBox1.Text)));
        }
    }
}
