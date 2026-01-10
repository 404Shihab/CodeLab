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
    public partial class clSignUp : Form
    {
        public clSignUp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InstructorSignUp instructorSignUp = new InstructorSignUp();
            instructorSignUp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LearnerSignUp learnersignup = new LearnerSignUp();
            learnersignup.Show();
            this.Hide();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Hide();      
        }
    }
}
