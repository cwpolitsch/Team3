using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MiddleSchoolPortal
{
    class ProgOps
    {
        //connection string
        private const string CONNECT_STRING = @"Server=cstnt.tstc.edu;Database= inew2330su22; User Id= group3su222330; password=3562415";
        //build connection to database
        private static SqlConnection _cntDatabase = new SqlConnection(CONNECT_STRING);
        // add cmd object
        private static SqlCommand _sqlStudentsCommand;
        // add data adapter
        private static SqlDataAdapter _daStudents = new SqlDataAdapter();
        // add data tables
        private static DataTable _dtStudentsTable = new DataTable();


    // setter and getter for ProgOps
        public static DataTable DTStudentsTable
        {
            get { return _dtStudentsTable; }
        }
        public static void OpenDatabase()
        {
            //method to open database and to allow use of data
            //open the connection to Books database
            _cntDatabase.Open();

            //message stating connection was successful
            MessageBox.Show("Connection to database was opened successfully", "Database Connection",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Dispose()
        {
            //method to close and dispose data
            //close connection
            _cntDatabase.Close();

            MessageBox.Show("Connection to database was closed successfully", "Database Connection",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);

            //dispose of the connect, command, adapter, and table objects.
            _cntDatabase.Dispose();
            _sqlStudentsCommand.Dispose();
            _daStudents.Dispose();
            _dtStudentsTable.Dispose();

        }
        public static void DatabaseCommand(TextBox tbFirstName, TextBox tbLastName)
        {
            try
            {
                //string to build query
                string query = "SELECT * FROM group3su222330.students ORDER BY StudentID";

                //establisch command object
                _sqlStudentsCommand = new SqlCommand(query, _cntDatabase);

                //establish data adapter
                _daStudents = new SqlDataAdapter();
                _daStudents.SelectCommand = _sqlStudentsCommand;

                //fill data table
                _dtStudentsTable = new DataTable();
                _daStudents.Fill(_dtStudentsTable);

                //bind to controls to datatable
                tbLastName.DataBindings.Add("Text", _dtStudentsTable, "LastName");
                tbFirstName.DataBindings.Add("Text", _dtStudentsTable, "FirstName");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
