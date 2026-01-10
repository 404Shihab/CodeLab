using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeLab
{
    public partial class LearnerSignUp : Form
    {
        public LearnerSignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void signUpbtn_Click(object sender, EventArgs e)
        {
            string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
                AttachDbFilename=D:\C# Codes\CodeLab\CodeLab\CodeLabdb.mdf;
                Integrated Security=True;
                Connect Timeout=30";

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO LearnersInfo (FirstName, LastName, UserName, Password, ConfirmPassword) " +
                    "VALUES (@FirstName, @LastName, @UserName, @Password, @ConfirmPassword)", con);

                cmd.Parameters.AddWithValue("@FirstName", fntextBox.Text);
                cmd.Parameters.AddWithValue("@LastName", lntextBox.Text);
                cmd.Parameters.AddWithValue("@UserName", untextBox.Text);
                cmd.Parameters.AddWithValue("@Password", passtextBox.Text);
                cmd.Parameters.AddWithValue("@ConfirmPassword", cptextBox.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Learner Added Successfully");

            fntextBox.Clear();
            lntextBox.Clear();
            untextBox.Clear();
            passtextBox.Clear();
            cptextBox.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            clSignUp cs = new clSignUp();
            cs.Show();
            this.Hide();
        }
    }
}
