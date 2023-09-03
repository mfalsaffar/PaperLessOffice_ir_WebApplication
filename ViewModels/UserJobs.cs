using PaperLessOffice_ir_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperLessOffice_ir_WebApplication.ViewModels
{
    public class UserJobs
    {
        public long UserId { get; set; }
        public List<Job> Jobs { get; set; }
    }
}