using System;

namespace PaperLessOffice_ir_WebApplication.ViewModels
{
    public class DetailedJobInfo
    {
        public string FullName { get; set; }
        public string ProcName { get; set; }
        public long WFId { get; set; }
        public long ProcId { get; set; }
        public string WFStatus { get; set; }
        public DateTime TimeJobStart { get; set; }
        public DateTime AlarmTime { get; set; }
        public string Doc { get; set; }
        public long WFCurrentJob { get; set; }
        public int WFStatusCode { get; set; }
    }
}
