using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.ViewModels
{
    public class EmployeeEducationTableVM
    {
        public int EmployeeEducationID { get; set; }
        [Required(ErrorMessage = "Please Select Your Institute or university")]
        public string InstituteUniversity { get; set; }
        [Required(ErrorMessage = "Please Select Your Title of diploma")]
        public string TitleOfDiploma { get; set; }
        [Required(ErrorMessage = "Please Select Your Degree")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "Please enter Start Year")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FromYear { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter End Year")]
        public Nullable<System.DateTime> ToYear { get; set; }
        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter country")]
        public string Country { get; set; }
        public Nullable<int> EmployeeResumeID { get; set; }
        public int UserID { get; set; }
        public List<SelectListItem> ListOfCountry { get; set; }
        public List<SelectListItem> ListOfCity { get; set; }
    }

}