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
    public partial class Report : Form
    {
        private Menu parent;

        public Report()
        {
            InitializeComponent();
        }

        public Report(Menu parent)
        {
            // TODO: Complete member initialization
            this.parent = parent;
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            List<String> listofDocs = db.getDocs();
            List<String> listofDiseases = db.getDiseases();
            foreach (String s in listofDocs)
                comboBox1.Items.Add(s);
            foreach (String s in listofDiseases)
                comboBox2.Items.Add(s);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Database db = new Database();
            List<String> patients = db.getPatients(comboBox1.Text);
            foreach(String name in patients)
                listView1.Items.Add(name).SubItems.Add(db.getDisease(name));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            Database db = new Database();
            List<String> patients = db.getPatientsWithDisease(comboBox2.Text);
            foreach (String name in patients)
                listView2.Items.Add(name).SubItems.Add(comboBox2.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
