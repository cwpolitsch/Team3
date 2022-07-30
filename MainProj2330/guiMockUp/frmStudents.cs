using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guiMockUp
{
    public partial class frmStudents : Form
    {
        bool mouseDown;
        private Point offset;

        public frmStudents()
        {
            InitializeComponent();
            customMenu();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;

            showMenu(pnlSubMnuHome);
            btnHomeLogin_Click(this, e);
        }

        // ----------------------------------------------------- SIDE MENU ~Start ---------------
        // App starts with Menu Collapsed  
        private void customMenu()
        {
            pnlSubMnuHome.Visible = false;
            pnlSubMnuStudents.Visible = false;
            pnlSubMnuTeachers.Visible = false;
            pnlSubMnuAdmin.Visible = false;
        }
        // Method to hide/collapse the Menu sub items 
        private void hideMenu()
        {
            // HOME
            if(pnlSubMnuHome.Visible == true)
            {
                pnlSubMnuHome.Visible = false;
            }
            // STUDENTS
            if (pnlSubMnuStudents.Visible == true)
            {
                pnlSubMnuStudents.Visible = false;
            }
            // TEACHERS
            if (pnlSubMnuTeachers.Visible== true)
            {
                pnlSubMnuTeachers.Visible = false;
            }
            // ADMINISTRATORS
            if (pnlSubMnuAdmin.Visible == true)
            {
                pnlSubMnuAdmin.Visible = false;
            }
        }
        // Method to show/expand the sub Menu items (ex: showMenu(pnlSubMnuHome); expands the 'Home' Sub Items)
        private void showMenu(Panel subMenu) 
        {
            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;

        }

        // --------------- HOME ---------------
        private void btnHome_Click(object sender, EventArgs e)
        {
            showMenu(pnlSubMnuHome);
        }
        private void btnHomeLogin_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible=true;
            //hideMenu();
        }
        private void btnHomeDash_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        // --------------- STUDENTS ---------------
        private void btnStudents_Click(object sender, EventArgs e)
        {
            showMenu(pnlSubMnuStudents);
        }
        private void btnStudentsGrades_Click(object sender, EventArgs e)
        {
            hideMenu();
        }
        private void btnStudentsDemo_Click(object sender, EventArgs e)
        {
            hideMenu();
        }
        // --------------- TEACHERS ---------------

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            showMenu(pnlSubMnuTeachers);
        }
        
        private void btnTeachersGrades_Click(object sender, EventArgs e)
        {
            // Grade Book
            hideMenu();
        }
        
        private void btnTeachersAttendance_Click(object sender, EventArgs e)
        {
            // Attendance
            hideMenu();
        }
        private void btnTeachersSeating_Click(object sender, EventArgs e)
        {
            // Seating Chart
            hideMenu();
        }

        // --------------- ADMINISTRATORS ---------------
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            showMenu(pnlSubMnuAdmin);
        }
        private void btnAdminManage_Click(object sender, EventArgs e)
        {
            // Database Managment Tools
            hideMenu();
        }
        // ----------------------------------------------------- SIDE MENU  ~End ---------------



        private void mouseDown_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void mouseMove_Event(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void mouseUp_Event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void mnuMainItmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }


    }
}
