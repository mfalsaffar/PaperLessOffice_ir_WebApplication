using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperLessOffice_ir_WebApplication.ViewModels
{
    public class GetMyJobShortListResponse
    {
        public List<JobShortListItem> MyJobsShortList { get; set; }
    }

    public class JobShortListItem
    {
        public string JobType { get; set; }
        public int Count { get; set; }
    }

}