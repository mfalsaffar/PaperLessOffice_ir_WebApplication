using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaperLessOffice_ir_WebApplication.ViewModels
{
    public class JobViewModel
    {
        public long UserId { get; set; }
        public List<JobInfo> Jobs { get; set; }
        public IEnumerable<SelectListItem> JobsDropdown { get; set; }
        public long? SelectedJobId { get; set; }
        public JobInfo SelectedJob { get; set; }
    }

    public class JobInfo
    {
        public long JobId { get; set; }
        public string JobName { get; set; }
        public bool Active { get; set; }
        public long UsersAllowed { get; set; }
        public List<UserInfo> Users { get; set; }
    }

    public class UserInfo
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
    }
}
