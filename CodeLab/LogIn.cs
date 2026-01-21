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
            try
            {
                string username = utxt.Text.Trim();
                string password = passtxt.Text.Trim();

                
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
                        "SELECT FirstName, LastName FROM InstructorsInfo WHERE UserName=@u AND Password=@p", con);

                    cmdInstructor.Parameters.AddWithValue("@u", username);
                    cmdInstructor.Parameters.AddWithValue("@p", password);

                    SqlDataReader rdr1 = cmdInstructor.ExecuteReader();

                    if (rdr1.Read())
                    {
                        string fname = rdr1["FirstName"].ToString();
                        string lname = rdr1["LastName"].ToString();

                        InstructorDashboard id = new InstructorDashboard(fname, lname);
                        id.Show();
                        this.Hide();
                        return;
                    }

                    rdr1.Close();

                    
                    SqlCommand cmdLearner = new SqlCommand(
                        "SELECT FirstName, LastName FROM LearnersInfo WHERE UserName=@u AND Password=@p", con);

                    cmdLearner.Parameters.AddWithValue("@u", username);
                    cmdLearner.Parameters.AddWithValue("@p", password);

                    SqlDataReader rdr2 = cmdLearner.ExecuteReader();

                    if (rdr2.Read())
                    {
                        string fname = rdr2["FirstName"].ToString();
                        string lname = rdr2["LastName"].ToString();

                        LearnerDashboard ld = new LearnerDashboard(fname, lname);
                        ld.Show();
                        this.Hide();
                        return;
                    }

                    MessageBox.Show("Invalid Username or Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clSignUp csignup = new clSignUp();
            csignup.Show();
            this.Hide();
        }

        private void utxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
