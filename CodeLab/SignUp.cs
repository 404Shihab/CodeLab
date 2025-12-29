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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LearnerSignUp learnersignup = new LearnerSignUp();
            learnersignup.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InstructorSignUp instructorSignUp = new InstructorSignUp();
            instructorSignUp.Show();
            this.Hide();
        }
    }
}
