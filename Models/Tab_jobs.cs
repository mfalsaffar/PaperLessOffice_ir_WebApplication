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
    
    public partial class Tab_jobs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tab_jobs()
        {
            this.tab_Options = new HashSet<tab_Options>();
            this.tab_Options1 = new HashSet<tab_Options>();
            this.Tab_UserJob = new HashSet<Tab_UserJob>();
            this.Tab_workflow = new HashSet<Tab_workflow>();
        }
    
        public long jobid { get; set; }
        public string jobname { get; set; }
        public Nullable<long> wuid { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> maxhours { get; set; }
        public Nullable<int> jobType { get; set; }
        public Nullable<long> RefrenceId { get; set; }
    
        public virtual Ref_JobType Ref_JobType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tab_Options> tab_Options { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tab_Options> tab_Options1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tab_UserJob> Tab_UserJob { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tab_workflow> Tab_workflow { get; set; }
    }
}
