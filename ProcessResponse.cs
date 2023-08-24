using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperLessOffice_ir_WebApplication.Models
{
    public class ProcessResponse
    {
        public long ProcId { get; set; }
        public string ProcName { get; set; }
        public bool ProcActive { get; set; }
    }
}
