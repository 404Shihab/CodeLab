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

    }
}
