using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Name is required*")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Last Name is required*")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Date of Birth is required*")]
        public DateTime DOB { get; set; }

        public Student() { }
    }
}