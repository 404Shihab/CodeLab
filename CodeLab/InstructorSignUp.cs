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
    public partial class InstructorSignUp : Form
    {

        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=D:\C# Codes\CodeLab\CodeLab\CodeLabdb.mdf;
        Integrated Security=True;
        Connect Timeout=30";

        public InstructorSignUp()
        {
            InitializeComponent();
        }

  
        private string getAutoUsername()
        {
            string uname = "I1";

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"SELECT MAX(CAST(SUBSTRING(UserName,2,LEN(UserName)) AS INT)) FROM InstructorsInfo", con);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int next = Convert.ToInt32(result) + 1;
                        uname = "I" + next;
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

        private void InstructorSignUp_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("C++");
            comboBox1.Items.Add("Java");
            comboBox1.Items.Add("C#");
            comboBox1.Items.Add("Python");
            comboBox1.Items.Add("JavaScript");

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            untextBox.ReadOnly = true;
            untextBox.Enabled = true;

           
            untextBox.Text = getAutoUsername();
        }


        private void SingUpbtn_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a programming language");
                return;
            }

           
            if (passtextBox.Text != cpasstextBox.Text)
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
                        "INSERT INTO InstructorsInfo " +
                        "(FirstName, LastName, ProgLang, UserName, Password, ConfirmPassword) " +
                        "VALUES (@FirstName, @LastName, @ProgLang, @UserName, @Password, @ConfirmPassword)",
                        con);

                    cmd.Parameters.AddWithValue("@FirstName", fntextBox.Text);
                    cmd.Parameters.AddWithValue("@LastName", lntextBox.Text);
                    cmd.Parameters.AddWithValue("@ProgLang", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UserName", autoUser);
                    cmd.Parameters.AddWithValue("@Password", passtextBox.Text);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", cpasstextBox.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Instructor Added Successfully\nUsername: " + autoUser);

   
                    fntextBox.Clear();
                    lntextBox.Clear();
                    passtextBox.Clear();
                    cpasstextBox.Clear();
                    comboBox1.SelectedIndex = -1;

           
                    untextBox.Text = getAutoUsername();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Signup Error: " + ex.Message);
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }


        private void backbtn_Click(object sender, EventArgs e)
        {
            clSignUp cs = new clSignUp();
            cs.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 
        }
    }
}
