using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperLessOffice_ir_WebApplication.Models;

namespace PaperLessOffice_ir_WebApplication.Controllers
{
    public class UserProcessController : Controller
    {
        private PaperLessOffice_irEntities _db = new PaperLessOffice_irEntities(); // Adjust DbContext name

        // GET: UserProcess/ActiveUsers
        public ActionResult ActiveUsers()
        {
            var users = GetActiveUsersFromDatabase();
            ViewBag.UsersDropdown = new SelectList(users, "UserId", "FullName");

            var activeUsersRequest = new ActiveUsersRequest(); // Create an instance of the ActiveUsersRequest model
            return View(activeUsersRequest); // Pass the instance of the model to the view
        }



        private List<ActiveUsersResponse> GetActiveUsersFromDatabase()
        {
            var users = _db.Database.SqlQuery<ActiveUsersResponse>("EXEC Pro_GetActiveUsers").ToList();
            return users;
        }
        //public ActionResult GetProcessUserAllowed(long userId)
        //{
        //    var processAllowed = _db.Database.SqlQuery<ProcessResponse>("EXEC Pro_GetProcessUserAllowed @userid", new SqlParameter("@userid", userId)).ToList();
        //    ViewBag.ProcessAllowed = processAllowed;
        //    return View("ActiveUsers");
        //}
        public ActionResult GetProcessUserAllowed(long userId)
        {
            var processAllowed = _db.Database.SqlQuery<ProcessResponse>("EXEC Pro_GetProcessUserAllowed @userid", new SqlParameter("@userid", userId)).ToList();
            ViewBag.ProcessAllowed = processAllowed;

            // Return the appropriate view for displaying the lists of allowed processes
            return View("UserProcesses");
        }

        public ActionResult GetProcessUserNotAllowed(long userId)
        {
            var processNotAllowed = _db.Database.SqlQuery<ProcessResponse>("EXEC Pro_GetProcessUserNotAllowed @userid", new SqlParameter("@userid", userId)).ToList();
            ViewBag.ProcessNotAllowed = processNotAllowed;

            // Return the appropriate view for displaying the lists of not allowed processes
            return View("UserProcesses");
        }


        [HttpPost]
        public ActionResult ActiveUsers(ActiveUsersRequest request, string command)
        {
            if (ModelState.IsValid)
            {
                if (command == "GetProcessUserAllowed")
                {
                    var processAllowed = _db.Database.SqlQuery<ProcessResponse>("EXEC Pro_GetProcessUserAllowed @userid", new SqlParameter("@userid", request.UserId)).ToList();
                    ViewBag.ProcessAllowed = processAllowed;
                }
                else if (command == "GetProcessUserNotAllowed")
                {
                    var processNotAllowed = _db.Database.SqlQuery<ProcessResponse>("EXEC Pro_GetProcessUserNotAllowed @userid", new SqlParameter("@userid", request.UserId)).ToList();
                    ViewBag.ProcessNotAllowed = processNotAllowed;
                }
            }
            // Debug lines to print ViewBag data
            //Debug.WriteLine("Process Allowed Count: " + (ViewBag.ProcessAllowed?.Count ?? 0));
            //Debug.WriteLine("Process Not Allowed Count: " + (ViewBag.ProcessNotAllowed?.Count ?? 0));
            // Retrieve active users again to redisplay the dropdown
            var users = GetActiveUsersFromDatabase();
            ViewBag.UsersDropdown = new SelectList(users, "UserId", "FullName");
            return View("ActiveUsers", request); // Pass the instance of the model to the view
        }




    }
}
