using InstituteManagementSystem.Models;
using InstituteManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllClasses()
        {
            ClassService classService = new ClassService();
            List<ClassMaster> listOfClasses = classService.GetClasses();
            return View(listOfClasses);
        }
        public ActionResult DeleteClass(ClassMaster classMaster)
        {
            ClassService delete = new ClassService();
            delete.DeleteClass(classMaster.Id);
            return RedirectToAction("AllClasses");
        }
        public ActionResult ClassList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ClassList(ClassMaster classMaster)
        {
            ClassService add = new ClassService();
            add.AddClass(classMaster);
            return RedirectToAction("AllClasses");
        }

        public ActionResult AllDesignations()
        {
            DesignationService designationService = new DesignationService();
            List<DesignationMaster> listOfDesignations = designationService.GetDesignation();
            return View(listOfDesignations);
        }
        public ActionResult DeleteDesignation(DesignationMaster designationMaster)
        {
            DesignationService delete = new DesignationService();
            delete.DeleteDesignation(designationMaster.DesignationId);
            return RedirectToAction("AllDesignations");
        }
        public ActionResult DesignationList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DesignationList(DesignationMaster designationMaster)
        {
            DesignationService add = new DesignationService();
            add.AddDesignation(designationMaster);
            return RedirectToAction("AllDesignations");
        }
        public ActionResult AllSubjects()
        {
            SubjectService subjectService = new SubjectService();
            List<SubjectMaster> listOfSubjects = subjectService.GetSubjects();
            return View(listOfSubjects);
        }
        public ActionResult DeleteSubject(SubjectMaster subjectMaster)
        {
            SubjectService delete = new SubjectService();
            delete.DeleteSubject(subjectMaster.SubjectId);
            return RedirectToAction("AllSubjects");
        }
        public ActionResult SubjectList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubjectList(SubjectMaster subjectMaster)
        {
            SubjectService add = new SubjectService();
            add.AddSubject(subjectMaster);
            return RedirectToAction("AllSubjects");
        }

    }
}