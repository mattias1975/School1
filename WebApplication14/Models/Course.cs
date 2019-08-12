using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace School.Models
{
    public class Course
    {
        public Course(int Id, string CourseName, string Assigment)
        {
            Id = this.Id;
      
            CourseName = this.CourseName;
          
            Assigment = this.Assigment;

        }
        public Course() { }
        public List<CourseStudent> Students { get; set; }
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Assigment { get; set; }
        public Teacher Teacher { get; set; }

    }
}




