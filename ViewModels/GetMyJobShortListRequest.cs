using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperLessOffice_ir_WebApplication.ViewModels
{
    public class GetMyJobShortListRequest
    {
        public long UserId { get; set; }
        public int SortOrder { get; set; }
    }

}