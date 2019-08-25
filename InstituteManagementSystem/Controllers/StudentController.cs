using InstituteManagementSystem.Models;
using InstituteManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentRegistration()
        {
            List<SelectListItem> selectAllItemsOfClasses = new List<SelectListItem>();

            ClassService classService = new ClassService();
            List<ClassMaster> classes = classService.GetClasses();
            foreach(var currentClass in classes)
            {
                selectAllItemsOfClasses.Add(new SelectListItem() { Text = currentClass.Class, Value = (currentClass.Id).ToString() });

            }
            ViewBag.ClassMaster = selectAllItemsOfClasses;

            SubjectService subjectService = new SubjectService();
            StudentMaster student = new StudentMaster();

            return View(student);
        }
        [HttpPost]
        public ActionResult StudentRegistration(StudentMaster student)
        {
            StudentService add = new StudentService();
            add.AddStudent(student);
            return RedirectToAction("AllStudents");
        }
        public ActionResult AllStudents()
        {
            StudentService studentService = new StudentService();
            List<StudentMaster> listOfStudents = studentService.GetStudents();
            return View(listOfStudents);
        }
        public ActionResult InactiveStudent(int id)
        {
            StudentService delete = new StudentService();
            delete.InactiveStudent(id);
            return RedirectToAction("AllStudents");
        }
    }
}