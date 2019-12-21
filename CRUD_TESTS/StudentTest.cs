using CRUD_MVC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRUD_TESTS
{
    [TestClass]
    class StudentTest
    {

        [TestMethod]
        public void TestStudentExists_Sending_Int_Parameter_Returns_True()
        {
            StudentService studentService = new StudentService();

            var result = studentService.IsStudentActive(1);

            Assert.IsTrue(result);
        }
    }
}
