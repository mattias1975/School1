﻿using System;
using System.Collections.Generic;
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
        //public ICollection<Student> Student { get; set; }
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Assigment { get; set; }
        public Teacher Teacher { get; set; }
        public Student student { get; set; }

    }
}




