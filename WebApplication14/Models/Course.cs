using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace School.Models
{ 
 public class Course
    {
        public Course(int CourseID, string Name, string Assigment)
        {
            CourseID = this.CourseID;
            Name = this.Name;
            Assigment = this.Assigment;

        }
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Assigment { get; set; }
    }

}





