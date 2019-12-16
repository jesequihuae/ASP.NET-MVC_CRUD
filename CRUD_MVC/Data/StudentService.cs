using CRUD_MVC.Models;
using CRUD_MVC.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRUD_MVC
{
    public class StudentService
    {
        private const String PROCEDURE_GET_ALL_STUDENTS = "getStudents";
        private const String PROCEDURE_FIND_STUDENT_BY_ID = "findStudentById";

        DataAccess dataAccess = new DataAccess();

        public List<Student> getStudents()
        {
            List<Student> listStudents = new List<Student>();
            DataTable dtStudents = new DataTable("students");

            dtStudents = dataAccess.executeStoredProcedureDataTable(PROCEDURE_GET_ALL_STUDENTS);

            listStudents = dtStudents.Rows
                            .Cast<DataRow>()
                            .Select(row => new Student(
                                int.Parse(row["idStudent"].ToString()),
                                row["Name"].ToString(),
                                row["LastName"].ToString(),
                                DateTime.Parse(row["DOB"].ToString())
                             ))
                            .ToList();

            return listStudents;
        }

        public Student findStudentById(int StudentID)
        {
            Student student = new Student();
            DataTable dtStudent = new DataTable("");

            dtStudent = dataAccess.executeStoredProcedureDataTable(
                    PROCEDURE_FIND_STUDENT_BY_ID,
                    new Dictionary<string, object> {
                        { "@idStudent", StudentID } 
                    }
            );

            student = dtStudent.Rows
                            .Cast<DataRow>()
                            .Select(row => new Student(
                                int.Parse(row["idStudent"].ToString()),
                                row["Name"].ToString(),
                                row["LastName"].ToString(),
                                DateTime.Parse(row["DOB"].ToString())
                             ))
                            .ToList()
                            .First();

            return student;
        }
    }
}