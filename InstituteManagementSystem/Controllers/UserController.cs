using InstituteManagementSystem.Models;
using InstituteManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagementSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllUsers()
        {
            UserService userService = new UserService();
            List<UserMaster> listOfClasses = userService.GetUsers();
            return View(listOfClasses);
        }
        public ActionResult InactiveUser(int id)
        {
            UserService delete = new UserService();
            delete.InactiveUser(id);
            return RedirectToAction("AllUsers");
        }

        public ActionResult UserRegistration()
        {
            List<SelectListItem> selectAllItemsOfDesignations = new List<SelectListItem>();

            DesignationService designationService = new DesignationService();
            List<DesignationMaster> designations = designationService.GetDesignation();
            foreach (var currentDesignation in designations)
            {
                selectAllItemsOfDesignations.Add(new SelectListItem() { Text = currentDesignation.Designation, Value = (currentDesignation.DesignationId).ToString() });

            }
            ViewBag.DesignationMaster = selectAllItemsOfDesignations;

            UserMaster user = new UserMaster();

            return View(user);
        }
        [HttpPost]
        public ActionResult UserRegistration(UserMaster userMaster)
        {

            UserService add = new UserService();
            add.AddUser(userMaster);
            return RedirectToAction("AllUsers");

        }
    }
}