using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeLab
{
    public partial class InstructorDashboard : Form
    {
        string fullName;

        public InstructorDashboard(string fname, string lname)
        {
            InitializeComponent();
            fullName = fname + " " + lname;
        }

        public InstructorDashboard()
        {
            InitializeComponent();
        }


        private void InstructorDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + fullName;
        }

        private void label3_Click(object sender, EventArgs e)//Learner's List
        {

        }

        private void label2_Click(object sender, EventArgs e)//Name
        {

        }

        private void button1_Click(object sender, EventArgs e)//Add
        {

        }

        private void button2_Click(object sender, EventArgs e)//Update
        {

        }

        private void button3_Click(object sender, EventArgs e)//Delete
        {

        }
    }
}
