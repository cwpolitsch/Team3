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
    public partial class frmMain : Form
    {
        // Allow Window to be dragged by Titlebar
        bool mouseDown;

        // login check & array of privileges of the user (1 = lowest, 4 = Highest)
        bool isLoggedIn = false;
        private int[] securityLevel = { 1, 2, 3, 4 };

        private Point offset;
        Panel current;

        public frmMain()
        {
            InitializeComponent();
            // Open Applcation with the Form at this size
            this.Size = new Size(1150, 650);
            customMenu();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {



            pnlLogin.Visible = false;

            showMenu(pnlSubMnuHome);
            current = pnlLogin;
            btnHomeLogin_Click(this, e);

            pnlTeachersGrades.Hide();
            // to 
            /* center.X = 350;
             center.Y = 75;*/


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
            if (pnlSubMnuHome.Visible == true)
            {
                pnlSubMnuHome.Visible = false;
            }
            // STUDENTS
            if (pnlSubMnuStudents.Visible == true)
            {
                pnlSubMnuStudents.Visible = false;
            }
            // TEACHERS
            if (pnlSubMnuTeachers.Visible == true)
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
        // Method to Track the current Tab (Closes a 'tab'/page and Displays a new one when Menu btn is clicked)
        private void newTab(Panel newPage)
        {
            if (newPage != current)
            {
                current.Visible = false;
                newPage.Location = new Point(350, 75);
                newPage.Visible = true;
                current = newPage;
            }
            /*     if (pnlLogin.Visible == true)
                 {
                     pnlLogin.Visible = false;
                 }
                 if (pnlStudentsPage.Visible == true)
                 {
                     pnlStudentsPage.Visible = false;
                 }
                 if (pnlTeachersGrades.Visible == true)
                 {
                     pnlTeachersGrades.Visible = false;
                 }*/
        }
        // --------------- HOME ---------------
        private void btnHome_Click(object sender, EventArgs e)
        {
            showMenu(pnlSubMnuHome);
        }
        private void btnHomeLogin_Click(object sender, EventArgs e)
        {
            if (pnlLogin.Visible == false)
            {
                pnlLogin.Visible = true;
            }
            newTab(pnlLogin);
            hideMenu();
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
            newTab(pnlStudentsGrades);
        }
        private void btnStudentsDemo_Click(object sender, EventArgs e)
        {
            hideMenu();
            newTab(pnlStudentsDemo);
        }
        // --------------- TEACHERS ---------------

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            showMenu(pnlSubMnuTeachers);
        }
        private void btnTeachersGrades_Click(object sender, EventArgs e)
        {
            hideMenu();
            newTab(pnlTeachersGrades);
        }
        private void btnTeachersAttendance_Click(object sender, EventArgs e)
        {
            // Attendance
            hideMenu();
            newTab(pnlAttendance);
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
            newTab(pnlAdminDb);
        }
        // ----------------------------------------------------- SIDE MENU  ~End ---------------


        // ----------------------------------------------------- Custom Title Bar ~Start -------
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
        // ----------------------------------------------------- Custom Title Bar ~End  -------


        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            // FORGOT PASSWORD MODAL FORM HERE
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            isLoggedIn = true;
            int userType = -1;

            if (tbxLoginUser.Text.ToLower() == "student")
            {
                userType = 1;
            }
            if (tbxLoginUser.Text.ToLower() == "teacher")
            {
                userType = 2;
            }
            if (tbxLoginUser.Text.ToLower() == "admin")
            {
                userType = 3;
            }

            // int usertype = Convert.ToInt32(tbxLoginUser.Text); 

            //userType = securityLevel[1];

            switch (userType)
            {
                case 1:
                    btnStudents.Enabled = true;
                    btnTeachers.Enabled = false;
                    btnAdmin.Enabled = false;
                    break;
                case 2:
                    btnStudents.Enabled = true;
                    btnTeachers.Enabled = true;
                    btnForgotPassword.Enabled = false;
                    break;
                case 3:
                    btnStudents.Enabled = true;
                    btnTeachers.Enabled = true;
                    btnAdmin.Enabled = true;
                    break;
                case 4:
                    btnStudents.Enabled = true;
                    btnTeachers.Enabled = true;
                    btnAdmin.Enabled = true;
                    break;

                default:
                    MessageBox.Show("Please Check your credentials and Try Again", "Error: Invalid Login");
                    tbxLoginUser.Text = "";
                    tbxLoginPassword.Text = "";
                    tbxLoginUser.Focus();
                    break;
            }


        }

        private void getStudentsGrades(object sender, EventArgs e)
        {
            string currentClass = cbxClass.SelectedItem.ToString();
            if (cbxClass.SelectedIndex == 0)
            {

                string[] class0 = {
                    "Homework (10%) \t\t Range \t\tGrade  ",
                    "Homework 1-1 \t\t 0-100 \t\t 85",
                    "Homework 1-2 \t\t 0-100 \t\t 85",
                    "Homework 1-3 \t\t 0-100 \t\t 85",
                    "",
                    "Quiz (15%)   \t\t Range \t\tGrade",
                    "Quiz 1-1     \t\t 0-100   \t\t 85",
                    "Quiz 1-2     \t\t 0-100   \t\t 85",
                    "Quiz 1-3     \t\t 0-100   \t\t 85",
                    "",
                    "Lab (25%)   \t\t Range \t\tGrade",
                    "Lab 1-1     \t\t 0-100   \t\t 85",
                    "Lab 1-2     \t\t 0-100   \t\t 85",
                    "Lab 1-3     \t\t 0-100   \t\t 85",
                    "",
                    "Code & Test (25%) \t Range \t\tGrade",
                    "Test 1-1    \t\t 0-100 \t\t 85",
                    "Test 1-2    \t\t 0-100 \t\t 85",
                    "Test 1-3    \t\t 0-100 \t\t 85",
                    "",
                    "Class Participation (5%) \t Range \t\tGrade",
                    "Participation \t\t 0-100 \t\t 85",
                    "",
                    "Overall Grade \t\t 0-100 \t\t  85"

                };

                lbxStudentsGrades.Items.AddRange(class0);


            }
        }

        private void getTeachersGrades(object sender, EventArgs e)
        {
            string currentAssign = cbxAssign.SelectedItem.ToString();
            if (cbxAssign.SelectedIndex == 0)
            {

                string[] class0 = {
                    "Homework (10%) \t\t Range \t\tGrade  ",
                    "Homework 1-1 \t\t 0-100 \t\t 85",
                    "Homework 1-2 \t\t 0-100 \t\t 85",
                    "Homework 1-3 \t\t 0-100 \t\t 85",
                    "",
                    "Quiz (15%)   \t\t Range \t\tGrade",
                    "Quiz 1-1     \t\t 0-100   \t\t 85",
                    "Quiz 1-2     \t\t 0-100   \t\t 85",
                    "Quiz 1-3     \t\t 0-100   \t\t 85",
                    "",
                    "Lab (25%)   \t\t Range \t\tGrade",
                    "Lab 1-1     \t\t 0-100   \t\t 85",
                    "Lab 1-2     \t\t 0-100   \t\t 85",
                    "Lab 1-3     \t\t 0-100   \t\t 85",
                    "",
                    "Code & Test (25%) \t Range \t\tGrade",
                    "Test 1-1    \t\t 0-100 \t\t 85",
                    "Test 1-2    \t\t 0-100 \t\t 85",
                    "Test 1-3    \t\t 0-100 \t\t 85",
                    "",
                    "Class Participation (5%) \t Range \t\tGrade",
                    "Participation \t\t 0-100 \t\t 85",
                    "",
                    "Overall Grade \t\t 0-100 \t\t  85"

                };

                lbxTeachersGrades.Items.AddRange(class0);


            }
        }



        private void studentDemo()
        {

            string[] info = {
            "First, Middle, Last Name",
            "Student id#",
            "Date of Birth",
            "Mailing address",
            "Street address",
            "City",
            "State",
            "Zip",
            "Phone number",
            "Guardian 1 name (if under 18)",
            "Cell phone number guardian 1",
            "Work number guardian 1",
            "Place of work guardian 1",
            "Guardian 2 name(if under 18)-not required",
            "Cell phone number guardian 2 - not required",
            "Work number guardian 2 - not required",
            "Place of work guardian 2 - not required",
            "Emergency Contact",
            };
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void attendanceButtons(Button seat)
        {
            if (seat.BackColor == Color.Silver)
            {
                seat.BackColor = Color.FromArgb(63, 81, 181);
                cbxAttendStudents.SetItemChecked(Convert.ToInt32(seat.Text)-1, true);
            }

            else if (seat.BackColor == Color.FromArgb(63, 81, 181)) 
            {
                seat.BackColor = Color.Silver;
                cbxAttendStudents.SetItemChecked(Convert.ToInt32(seat.Text) - 1, false);
            }
        }
        
/*        private void seatingCheck() 
        {
            string[] students =
            {
            "Jacob",
            "Mary",
            "Todd",
            "Adam",
            "Johann",
            "Alexa",
            "Katie",
            "Tyler",
            "Joe",
            "Savanna" 
            };
            cbxAttendStudents.Items.AddRange(students);
        }*/

        private void btnSeat1_Click(object sender, EventArgs e)
        {
            attendanceButtons(btnSeat1);
        }
        private void btnSeat2_Click(object sender, EventArgs e)
        {
            attendanceButtons(btnSeat2);
        }

        private void btnSeat3_Click(object sender, EventArgs e)
        {
            attendanceButtons(btnSeat3);
        }

        private void btnSeat4_Click(object sender, EventArgs e)
        {
            attendanceButtons(btnSeat4);
        }

        private void btnSeat5_Click(object sender, EventArgs e)
        {
            attendanceButtons(btnSeat5);
        }

        private void btnSeat6_Click(object sender, EventArgs e)
        {
            attendanceButtons(btnSeat6);
        }

        private void btnSeat7_Click(object sender, EventArgs e)
        {
            attendanceButtons(btnSeat7);
        }

        private void btnSeat8_Click(object sender, EventArgs e)
        {
            attendanceButtons(btnSeat8);
        }

        private void btnSeat9_Click(object sender, EventArgs e)
        {
            attendanceButtons(btnSeat9);
        }

        private void btnSeat10_Click(object sender, EventArgs e)
        {
            attendanceButtons(btnSeat10);
        }
        private void cbxAttendStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] students =
        {
            "Jacob",
            "Mary",
            "Todd",
            "Adam",
            "Johann",
            "Alexa",
            "Katie",
            "Tyler",
            "Joe",
            "Savanna"
            };

            Button[] btns = {btnSeat1, btnSeat2, btnSeat3, btnSeat4, btnSeat5, btnSeat6, btnSeat7, btnSeat8, btnSeat9, btnSeat10};
            
            for (int x = 0; x < students.Length; x++)
            {
                if (cbxAttendStudents.GetItemChecked(x))
                {
                    attendanceButtons(btns[x]);
                }
            }
        }

        private void pnlStudentsGrades_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
