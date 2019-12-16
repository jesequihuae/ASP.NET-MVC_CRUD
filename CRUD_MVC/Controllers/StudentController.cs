using CRUD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC.Controllers
{
    public class StudentController : Controller
    {
        StudentService studentService = new StudentService();

        public ViewResult List()
        {
            List<Student> listStudents = studentService.getStudents();
            return View(listStudents);
        }

        public ViewResult Edit(int id)
        {
            Student student = studentService.findStudentById(id);
            return View(student);
        }
    }
}