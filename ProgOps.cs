﻿using System;

class ProgOps
{
    // connection string
    private const string CONNECT_STRING = @"Server=cstnt.tstc.edu;Database= inew2330su22; User Id= group3su222330; password=3562415";
    // build connection to database
    private static SqlConnection _cntDatabase = new SqlConnection(CONNECT_STRING);
    // add cmd object
    private static SqlCommand _sqlStudentsCommand;
    // add data adapter
    private static SqlDataAdapter _daStudentss = new SqlDataAdapter();
    // add data tables
    private static DataTable _dtStudentsTable = new DataTable();


    // setter and getter for ProgOps
    public static DataTable DTStudentsTable
    {
        get { return _dtStudentsTable; }
        set { _dtStudentsTable = value; }
    }

}
