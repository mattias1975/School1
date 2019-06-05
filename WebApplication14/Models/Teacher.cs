using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Teacher() { }

        public Teacher(int id, string name, string email)
        {
          //Prop = input
            Name = name;
            Email = email;
            Id = id;
        }
    }
}
