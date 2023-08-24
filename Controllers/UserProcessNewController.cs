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
    public class UPnewController : Controller
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

            var allowed = _db.Database.SqlQuery<ProcessResponse>("EXEC Pro_GetProcessUserAllowed @userid", new SqlParameter("@userid", userId)).ToList();
            var notAllowed = _db.Database.SqlQuery<ProcessResponse>("EXEC Pro_GetProcessUserNotAllowed @userid", new SqlParameter("@userid", userId)).ToList();

            var model = new UserProcesses()
            {
                UserId = userId.Value,
                Processes = new List<Process>()
            };
            foreach (var i in allowed)
            {
                var t = new Process()
                {
                    Id = i.ProcId,
                    Title = i.ProcName,
                    Selected = false
                };
                model.Processes.Add(t);
            }
            foreach (var i in notAllowed)
            {
                var t = new Process()
                {
                    Id = i.ProcId,
                    Title = i.ProcName,
                    Selected = true
                };
                model.Processes.Add(t);
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
