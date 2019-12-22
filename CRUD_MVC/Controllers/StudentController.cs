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

        public ActionResult Edit(int id = 0)
        {
            if (id.ToString().Equals("0"))
                return RedirectToAction("List");

            Student student = studentService.findStudentById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID, Name, LastName, DOB")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentService.ModifyStudentById(student);
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            studentService.DeleteStudentById(id);
            return RedirectToAction("List");
        }
    }
}