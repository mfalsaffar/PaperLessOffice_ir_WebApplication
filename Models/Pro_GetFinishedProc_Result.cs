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
    
    public partial class Pro_GetFinishedProc_Result
    {
        public long wfid { get; set; }
        public long procid { get; set; }
        public string username { get; set; }
        public string procname { get; set; }
        public string wfstatus { get; set; }
        public Nullable<System.DateTime> timeJobStart { get; set; }
        public long userid { get; set; }
        public long reportTo { get; set; }
        public string doc { get; set; }
    }
}