using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CRUD_MVC.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public DateTime DOB { get; set; }

        public Student(int StudentID, String Name, String LastName, DateTime DOB)
        {
            this.StudentID = StudentID;
            this.Name = Name;
            this.LastName = LastName;
            this.DOB = DOB;
        }

        public Student()
        {
        }
    }
}