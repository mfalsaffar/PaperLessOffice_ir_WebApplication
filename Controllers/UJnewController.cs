// UJnewController.cs
using PaperLessOffice_ir_WebApplication.Models;
using PaperLessOffice_ir_WebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace PaperLessOffice_ir_WebApplication.Controllers
{
    public class UJnewController : Controller
    {
        private PaperLessOffice_irEntities _db = new PaperLessOffice_irEntities();

        public ActionResult UserJobs(long? userId)
        {
            var users = GetActiveUsersFromDatabase();
            ViewBag.UsersDropdown = new SelectList(users, "UserId", "FullName");

            if (userId == null)
            {
                return View();
            }

            var jobs = GetJobsWithUsers(userId.Value);
            var model = new JobViewModel
            {
                UserId = userId.Value,
                Jobs = jobs
            };

            return View("UserJobs", model);
        }

        private List<JobInfo> GetJobsWithUsers(long userId)
        {
            var jobs = new List<JobInfo>();
            var allowedJobs = _db.Database.SqlQuery<JobResponse>("EXEC Pro_GetJobsUserAllowed @userid", new SqlParameter("@userid", userId)).ToList();

            foreach (var job in allowedJobs)
            {
                var jobInfo = new JobInfo
                {
                    JobId = job.JobId,
                    JobName = job.JobName,
                    //Active = job.Active,
                    UsersAllowed = job.UsersAllowed,
                    Users = GetUsersForJob(job.JobId)
                };
                jobs.Add(jobInfo);
            }

            return jobs;
        }

        private List<UserInfo> GetUsersForJob(long jobId)
        {
            var users = new List<UserInfo>();
            var userJobs = _db.Database.SqlQuery<UserJobResponse>("EXEC GetUsersAllowedForJob @jobid", new SqlParameter("@jobid", jobId)).ToList();

            foreach (var userJob in userJobs)
            {
                var user = new UserInfo
                {
                    UserId = userJob.UserId,
                    UserName = userJob.UserName
                };
                users.Add(user);
            }

            return users;
        }

        private List<ActiveUsersResponse> GetActiveUsersFromDatabase()
        {
            var users = _db.Database.SqlQuery<ActiveUsersResponse>("EXEC Pro_GetActiveUsers").ToList();
            return users;
        }


        public JsonResult GetUsersAllowedForJob(long jobId)
        {
            var usersAllowed = GetUsersForJob(jobId);
            return Json(usersAllowed, JsonRequestBehavior.AllowGet);
        }

        // Add other methods here...
        public ActionResult DisplayUsersForJob()
        {
            var model = new JobViewModel();
            model.JobsDropdown = GetJobsDropdown();
            return View(model);
        }


        [HttpPost]
        public ActionResult DisplayUsersForJob(JobViewModel model)
        {
            if (model.SelectedJobId != null)
            {
                model.SelectedJob = GetJobInfo(model.SelectedJobId.Value);
            }

            model.JobsDropdown = GetJobsDropdown();
            return View(model);
        }


        private IEnumerable<SelectListItem> GetJobsDropdown()
        {
            var jobs = _db.Database.SqlQuery<JobDropdownItem>("EXEC GetJobsDropdown").ToList();
            return jobs.Select(j => new SelectListItem
            {
                Value = j.JobId.ToString(),
                Text = j.JobName
            });
        }

        // Other methods...
      


        private JobInfo GetJobInfo(long jobId)
        {
            var job = _db.Database.SqlQuery<JobResponse>("EXEC GetJobInfo @jobid", new SqlParameter("@jobid", jobId)).FirstOrDefault();

            if (job != null)
            {
                var jobInfo = new JobInfo
                {
                    JobId = job.JobId,
                    JobName = job.JobName,
                  //  Active = job.Active,
                    UsersAllowed = job.UsersAllowed,
                    Users = GetUsersForJob(job.JobId)
                };
                return jobInfo;
            }

            return null;
        }

    }
}
