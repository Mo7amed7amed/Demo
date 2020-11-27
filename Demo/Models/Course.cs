using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class Course
    {
        [Key]
        public int CrsId { get; set; }

        [Display(Name ="Course Name")]
        public string CrsName { get; set; }

        public virtual List<Department> Departments { get; set; }

        public virtual List<StudentCourses> CourseStudents { get; set; }

    }
}