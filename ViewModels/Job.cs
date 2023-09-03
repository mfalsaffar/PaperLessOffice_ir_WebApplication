using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperLessOffice_ir_WebApplication.ViewModels
{
    public class Job
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Selected { get; set; }
    }
}