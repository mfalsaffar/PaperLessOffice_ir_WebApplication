using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperLessOffice_ir_WebApplication
{
    using System.ComponentModel.DataAnnotations;

    public class MyJobViewModel
    {
        [Key] // Dummy key annotation
        public int DummyKey { get; set; }

        public string Fullname { get; set; }
        public string ProcName { get; set; }
        public long WfId { get; set; }
        // Add other properties as needed
    }

}