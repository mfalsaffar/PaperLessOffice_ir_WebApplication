//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaperLessOffice_ir_WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tab_userProcess
    {
        public long upid { get; set; }
        public Nullable<long> userid { get; set; }
        public Nullable<long> procid { get; set; }
        public Nullable<bool> upactive { get; set; }
    
        public virtual Tab_Process Tab_Process { get; set; }
        public virtual Tab_users Tab_users { get; set; }
    }
}
