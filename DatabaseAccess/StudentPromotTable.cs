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
        [Required(ErrorMessage = "Please Select Student")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Please Select Class")]
        public int ClassID { get; set; }
        [Required(ErrorMessage = "Please Select Programe Session")]
        public int ProgrameSessionID { get; set; }
        [Required(ErrorMessage = "Please Select Promote Date")]
        [DataType(DataType.Date)]
        public System.DateTime PromoteDate { get; set; }
        [Required(ErrorMessage = "Please Enter Annual Fee")]
        public int AnnualFee { get; set; }
        [Display(Name = "Promote Status")]
        public Nullable<bool> IsActive { get; set; }
        [Display(Name = "Annual Fee Status")]
        public Nullable<bool> IsSubmit { get; set; }
        [Required(ErrorMessage = "Please Select Section")]
        public Nullable<int> SectionID { get; set; }
    
        public virtual ClassTable ClassTable { get; set; }
        public virtual ProgrameSessionTable ProgrameSessionTable { get; set; }
        public virtual SectionTable SectionTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
    }
}
