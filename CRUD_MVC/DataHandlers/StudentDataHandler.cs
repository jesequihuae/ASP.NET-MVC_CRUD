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
        //STORED PROCEDURES NAMES
        private const String PROCEDURE_GET_ALL_STUDENTS = "getStudents";
        private const String PROCEDURE_FIND_STUDENT_BY_ID = "findStudentById";
        private const String PROCEDURE_MODIFY_STUDENT_BY_ID = "ModifyStudentById";
        private const String PROCEDURE_DELETE_STUDENT_BY_ID = "DeleteStudentById";

        //ROW NAMES IN DATABASE
        private const String StudentID_DB = "idStudent";
        private const String Name_DB = "Name";
        private const String LastName_DB = "LastName";
        private const String DOB_DB = "DOB";


        DataAccess dataAccess = new DataAccess();

        public List<Student> getStudents()
        {
            List<Student> listStudents = new List<Student>();
            DataTable dtStudents = new DataTable("students");

            dtStudents = dataAccess.executeStoredProcedureDataTable(PROCEDURE_GET_ALL_STUDENTS);

            listStudents = dtStudents.Rows
                            .Cast<DataRow>()
                            .Select(row => new Student
                            {
                                StudentID = int.Parse(row[StudentID_DB].ToString()),
                                Name = row[Name_DB].ToString(),
                                LastName = row[LastName_DB].ToString(),
                                DOB = DateTime.Parse(row[DOB_DB].ToString())
                            })
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
                           .Select(row => new Student {
                              StudentID = int.Parse(row[StudentID_DB].ToString()),
                              Name = row[Name_DB].ToString(),
                              LastName = row[LastName_DB].ToString(),
                              DOB = DateTime.Parse(row[DOB_DB].ToString())
                           })
                           .ToList()
                           .First();


            return student;
        }

        public void ModifyStudentById(Student student)
        {
            dataAccess.executeStoreProcedureNonQuery(
                      PROCEDURE_MODIFY_STUDENT_BY_ID,
                      new Dictionary<string, object> {
                          { "@idStudent", student.StudentID },
                          { "@Name", student.Name },
                          { "@LastName", student.LastName },
                          { "@DOB", student.DOB} 
                      }
                );
        }

        public void DeleteStudentById(int id)
        {
            dataAccess.executeStoreProcedureNonQuery(
                PROCEDURE_DELETE_STUDENT_BY_ID,
                new Dictionary<string, object> {
                    { "@idStudent", id}
                });
        }

        public Boolean IsStudentActive(int idStudent)
        {
            Boolean IsActive;

            Student student = findStudentById(idStudent);
            IsActive = student.StudentID > 1 ? true : false;

            return false;
        }
    }
}