using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CodeLab
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = utxt.Text.Trim();
            string password = passtxt.Text.Trim();

            // ===== ADMIN LOGIN =====
            if (username == "admin1" && password == "adminpass")
            {
                AdminDashboard ad = new AdminDashboard();
                ad.Show();
                this.Hide();
                return;
            }

            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;
    AttachDbFilename=D:\C# Codes\CodeLab\CodeLab\CodeLabdb.mdf;
    Integrated Security=True;
    Connect Timeout=30";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                
                SqlCommand cmdInstructor = new SqlCommand(
                    "SELECT COUNT(*) FROM InstructorsInfo WHERE UserName=@u AND Password=@p", con);

                cmdInstructor.Parameters.AddWithValue("@u", username);
                cmdInstructor.Parameters.AddWithValue("@p", password);

                int instructor = (int)cmdInstructor.ExecuteScalar();

                if (instructor > 0)
                {
                    InstructorDashboard id = new InstructorDashboard();
                    id.Show();
                    this.Hide();
                    return;
                }

                
                SqlCommand cmdLearner = new SqlCommand(
                    "SELECT COUNT(*) FROM LearnersInfo WHERE UserName=@u AND Password=@p", con);

                cmdLearner.Parameters.AddWithValue("@u", username);
                cmdLearner.Parameters.AddWithValue("@p", password);

                int learner = (int)cmdLearner.ExecuteScalar();

                if (learner > 0)
                {
                    LearnerDashboard ld = new LearnerDashboard();
                    ld.Show();
                    this.Hide();
                    return;
                }

                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
            this.Hide();
        }

        private void utxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
