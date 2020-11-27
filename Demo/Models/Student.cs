using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Models
{
    public class Student
    {
        [Key]
        public int stdId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Min Lenght is 3 and Max 20")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Range(10, 40)]
        public int Age { get; set; }

        [RegularExpression(@"^[A-Za-z0-9_]+@[A-Za-z]+.[A-Za-z]{2,4}$")]
        public string Email { get; set; }

        [Required]
        [Remote("CheckUserName", "Student")]
        public string UserName { get; set; }


        [Required]
        public int Password { get; set; }

        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password")]

        public int ConfirmPassword { get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual List<StudentCourses> StudentCourses { get; set; }
    }
}