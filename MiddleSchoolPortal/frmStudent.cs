using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MiddleSchoolPortal
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }
        CurrencyManager stuManager;
        private void frmStudent_Load(object sender, EventArgs e)
        {

        }

        private void frmStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ProgOps.Dispose();
            Application.Exit();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (stuManager.Position == stuManager.Count - 1)
            {
                SystemSounds.Beep.Play();
            }
            stuManager.Position++;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (stuManager.Position == stuManager.Count - 1)
            {
                SystemSounds.Beep.Play();
            }
            stuManager.Position--;
        }
    }
}
