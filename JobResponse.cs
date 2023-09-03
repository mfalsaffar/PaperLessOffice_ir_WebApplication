using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperLessOffice_ir_WebApplication.Models
{
    public class JobResponse
    {
        public long JobId { get; set; }
        public string JobName { get; set; }
        public bool ProcActive { get; set; }
        public long UsersAllowed { get; internal set; }
    }
}