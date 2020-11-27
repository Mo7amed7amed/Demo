using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public int Capacity { get; set; }


        public virtual List<Course> Courses { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}