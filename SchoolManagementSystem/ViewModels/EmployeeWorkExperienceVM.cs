using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.ViewModels
{
    public class EmployeeWorkExperienceVM
    {
        public int EmployeeWorkExperienceID { get; set; }
        [Required(ErrorMessage = "Please Enter Your Company")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Please Enter Your Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter Your country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Enter Start Date")]
        public Nullable<System.DateTime> FromYear { get; set; }
        [Required(ErrorMessage = "Please Enter End Date")]
        public Nullable<System.DateTime> ToYear { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
        public Nullable<int> EmployeeResumeID { get; set; }
        public int UserID { get; set; }
        public List<SelectListItem> ListeOfCountries { get; set; }
    }
}