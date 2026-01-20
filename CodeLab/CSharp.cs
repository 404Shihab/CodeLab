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
    public partial class CSharp : Form
    {
        public CSharp()
        {
            InitializeComponent();
        }

        private void CSharp_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LearnerDashboard learn = new LearnerDashboard();
            learn.Show();
            this.Hide();
        }
    }
}
