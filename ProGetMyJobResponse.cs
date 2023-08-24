using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperLessOffice_ir_WebApplication.Models
{
    public class ProGetMyJobResponse
    {
        public string Fullname { get; set; }
        public string ProcName { get; set; }
        public long WfId { get; set; }
        public long ProcId { get; set; }
        public string WfStatus { get; set; }
        public DateTime TimeJobStart { get; set; }
        public DateTime AlarmTime { get; set; }
        public string Doc { get; set; }
        public long WfCurrentJob { get; set; }
        public int WfStatusCode { get; set; }
        public string JobName { get; set; }
    }
}
