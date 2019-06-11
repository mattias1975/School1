using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace School.Models
{
    
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }

        public Student(){}

        public Student(int id,string name, string email)
        {
            Name = name;
            Email = email;
            Id = id;
        }
        //public List<Student> students { get; set; }
    }
}



  