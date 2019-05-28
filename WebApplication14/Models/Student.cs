using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace WebApplication14.Models
{
    
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string Email{ get; set; }

        public Student(){}

        public Student(int id,string name, string course, string email)
        {
            Name = name;
            Course = course;
            Email = email;
            Id = id;
                    }
    }
}



  