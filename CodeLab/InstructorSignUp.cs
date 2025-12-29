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
        public InstructorSignUp()
        {
            InitializeComponent();
        }

        private void SingUpbtn_Click(object sender, EventArgs e)
        {
            string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=D:\C# Codes\CodeLab\CodeLab\CodeLabdb.mdf;
                    Integrated Security=True;
                    Connect Timeout=30";

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO dbo.InstructorsInfo " +
                    "(FirstName, LastName, ProgLang, UserName, Password, ConfirmPassword) " +
                    "VALUES (@FirstName, @LastName, @ProgLang, @UserName, @Password, @ConfirmPassword)", con);

                cmd.Parameters.AddWithValue("@FirstName", fntextBox.Text);
                cmd.Parameters.AddWithValue("@LastName", lntextBox.Text);
                cmd.Parameters.AddWithValue("@ProgLang", pltextBox.Text);
                cmd.Parameters.AddWithValue("@UserName", untextBox.Text);
                cmd.Parameters.AddWithValue("@Password", passtextBox.Text);
                cmd.Parameters.AddWithValue("@ConfirmPassword", cpasstextBox.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Instructor Added Successfully");

            fntextBox.Clear();
            lntextBox.Clear();
            pltextBox.Clear();
            untextBox.Clear();
            passtextBox.Clear();
            cpasstextBox.Clear();
        }

    }
}
