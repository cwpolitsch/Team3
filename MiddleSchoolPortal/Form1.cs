using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiddleSchoolPortal
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Email sent to username to change!");
        }

        private void btnLogOn_Click(object sender, EventArgs e)
        {
            new frmStudent().ShowDialog();
        }
    }
}
