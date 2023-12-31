//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class StudentPromotTable
    {
        public int StudentPromotID { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public int ProgrameSessionID { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime PromoteDate { get; set; }
        public int AnnualFee { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsSubmit { get; set; }
        public Nullable<int> SectionID { get; set; }
    
        public virtual ClassTable ClassTable { get; set; }
        public virtual ProgrameSessionTable ProgrameSessionTable { get; set; }
        public virtual SectionTable SectionTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
    }
}
