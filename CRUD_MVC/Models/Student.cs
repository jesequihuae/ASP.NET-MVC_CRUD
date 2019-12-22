using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Name is required*")]
        [DataType(DataType.Text)]
        [MaxLength(150)]
        public String Name { get; set; }

        [Required(ErrorMessage = "Last Name is required*")]
        [DataType(DataType.Text)]
        [MaxLength(150)]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DOB { get; set; }

        public Student() { }
    }
}