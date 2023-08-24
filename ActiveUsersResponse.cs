using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperLessOffice_ir_WebApplication.Models
{
    
        public class ActiveUsersResponse
        {
            public long UserId { get; set; }
            public string FullName { get; set; }
            public string UnitCode { get; set; }
            public string UnitName { get; set; }
        }
    

}