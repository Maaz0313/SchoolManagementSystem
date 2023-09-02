using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.ViewModels
{
    public class EmployeeResumeTableVM
    {
        public int EmployeeResumeID { get; set; }
        [Required(ErrorMessage = "{0} is required field!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "{0} is required field!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} is required field!")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Nationality { get; set; }
        [Required(ErrorMessage = "{0} is required field!")]
        public string EducationalLevel { get; set; }
        [Required(ErrorMessage = "{0} is required field!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "{0} is required field!")]
        public string Tel { get; set; }
        [Required(ErrorMessage = "{0} is required field!")]
        public string Email { get; set; }
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
        [DataType(DataType.Url)]
        public string LinkedInProdil { get; set; }
        [DataType(DataType.Url)]
        public string FaceBookProfil { get; set; }
        [DataType(DataType.Url)]
        public string C_CornerProfil { get; set; }
        [DataType(DataType.Url)]
        public string TwitterProfil { get; set; }
        [Required(ErrorMessage = "{0} is required field!")]
        public byte[] Profil { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public List<SelectListItem> ListNationality { get; set; }
        public List<SelectListItem> ListEducationalLevel { get; set; }

    }
}