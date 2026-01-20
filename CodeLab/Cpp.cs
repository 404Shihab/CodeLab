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
    public partial class Cpp : Form
    {
        
        private string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                             AttachDbFilename=""D:\C# Codes\CodeLab\CodeLab\CodeLabdb.mdf"";
                             Integrated Security=True;Connect Timeout=30;";

        public Cpp()
        {
            InitializeComponent();
        }

       
        private string[] GetContent(string contentKey)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT title, description FROM Contents WHERE content_key = @key";
                    cmd.Parameters.AddWithValue("@key", contentKey);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new string[]
                            {
                                reader["title"].ToString(),
                                reader["description"].ToString()
                            };
                        }
                        else
                        {
                            MessageBox.Show("No content found for key: " + contentKey);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message);
            }

            return null;
        }

      
        private void ShowContentOnRightPanel(string title, string description)
        {
            try
            {
                rightPanel.Controls.Clear();
                rightPanel.AutoScroll = true;

                
                Label lblTitle = new Label
                {
                    Text = title,
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    Margin = new Padding(0, 0, 0, 10)
                };

                
                Label lblDesc = new Label
                {
                    Text = description,
                    Font = new Font("Segoe UI", 10),
                    MaximumSize = new Size(rightPanel.Width - 40, 0),
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    Margin = new Padding(0, 0, 0, 20)
                };

                rightPanel.Controls.Add(lblDesc);
                rightPanel.Controls.Add(lblTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show("UI error:\n" + ex.Message);
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string[] content = GetContent("cpp_intro"); 
            if (content != null)
                ShowContentOnRightPanel(content[0], content[1]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LearnerDashboard learn = new LearnerDashboard();
            learn.Show();
            this.Hide();
        }

        
        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string[] content = GetContent("loop"); 
            if (content != null)
                ShowContentOnRightPanel(content[0], content[1]);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string[] content = GetContent("array"); // DB key matches
            if (content != null)
                ShowContentOnRightPanel(content[0], content[1]);
        }
    }
}
