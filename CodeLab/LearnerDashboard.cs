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
    public partial class LearnerDashboard : Form
    {
        public LearnerDashboard()
        {
            InitializeComponent();
        }

        private void LearnerDashboard_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            LogIn login =new LogIn();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cpp cpp = new Cpp();
            cpp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Java java = new Java();
            java.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CSharp csharp = new CSharp();
            csharp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LearnerDashboard learn = new LearnerDashboard();
            learn.Show();
            this.Hide();
        }
    }
}
