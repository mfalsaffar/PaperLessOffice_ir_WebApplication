using PaperLessOffice_ir_WebApplication.Models;
using PaperLessOffice_ir_WebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaperLessOffice_ir_WebApplication.Controllers
{
    public class UserJobsController : Controller
    {
        private PaperLessOffice_irEntities _db = new PaperLessOffice_irEntities();

        public ActionResult ActiveUsers(long? userId)
        {
            var users = GetActiveUsersFromDatabase();
            ViewBag.UsersDropdown = new SelectList(users, "UserId", "FullName");
            if (userId == null)
            {
                return View();
            }

            var allowed = _db.Database.SqlQuery<JobResponse>("EXEC Pro_GetJobsUserAllowed @userid", new SqlParameter("@userid", userId)).ToList();
            var notAllowed = _db.Database.SqlQuery<JobResponse>("EXEC Pro_GetJobsUserNotAllowed @userid", new SqlParameter("@userid", userId)).ToList();

            var model = new UserJobs()
            {
                UserId = userId.Value,
                Jobs = new List<Job>()
            };
            foreach (var i in allowed)
            {
                var t = new Job()
                {
                    Id = i.JobId,
                    Title = i.JobName,
                    Selected = false
                };
                model.Jobs.Add(t);
            }
            foreach (var i in notAllowed)
            {
                var t = new Job()
                {
                    Id = i.JobId,
                    Title = i.JobName,
                    Selected = true
                };
                model.Jobs.Add(t);
            }

            return View("ActiveUsers", model);
        }

        private List<ActiveUsersResponse> GetActiveUsersFromDatabase()
        {
            var users = _db.Database.SqlQuery<ActiveUsersResponse>("EXEC Pro_GetActiveUsers").ToList();
            return users;
        }

        // Add other methods here...
    }
}
