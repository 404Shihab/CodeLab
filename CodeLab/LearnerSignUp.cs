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
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=D:\C# Codes\CodeLab\CodeLab\CodeLabdb.mdf;
        Integrated Security=True;
        Connect Timeout=30";

        public LearnerSignUp()
        {
            InitializeComponent();
        }

        // 🔹 Auto Username Generator (L1, L2, L3 ...)
        private string getAutoUsername()
        {
            string uname = "L1";

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"SELECT MAX(CAST(SUBSTRING(UserName,2,LEN(UserName)) AS INT)) FROM LearnersInfo", con);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int next = Convert.ToInt32(result) + 1;
                        uname = "L" + next;
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Username Generate Error: " + ex.Message);
            }

            return uname;
        }

        // 🔹 Form Load
        private void LearnerSignUp_Load(object sender, EventArgs e)
        {
            untextBox.ReadOnly = true;
            untextBox.Enabled = true;

            untextBox.Text = getAutoUsername();
        }

        private void signUpbtn_Click(object sender, EventArgs e)
        {
            // Password match validation
            if (passtextBox.Text != cptextBox.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match");
                return;
            }

            try
            {
                string autoUser = untextBox.Text;

                if (string.IsNullOrWhiteSpace(autoUser))
                {
                    autoUser = getAutoUsername();
                    untextBox.Text = autoUser;
                }

                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO LearnersInfo " +
                        "(FirstName, LastName, UserName, Password, ConfirmPassword) " +
                        "VALUES (@FirstName, @LastName, @UserName, @Password, @ConfirmPassword)", con);

                    cmd.Parameters.AddWithValue("@FirstName", fntextBox.Text);
                    cmd.Parameters.AddWithValue("@LastName", lntextBox.Text);
                    cmd.Parameters.AddWithValue("@UserName", autoUser);
                    cmd.Parameters.AddWithValue("@Password", passtextBox.Text);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", cptextBox.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Learner Added Successfully\nUsername: " + autoUser);

                    // Clear form
                    fntextBox.Clear();
                    lntextBox.Clear();
                    passtextBox.Clear();
                    cptextBox.Clear();

                    // Next username
                    untextBox.Text = getAutoUsername();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Signup Error: " + ex.Message);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // intentionally empty
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
