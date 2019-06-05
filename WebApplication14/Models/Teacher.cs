using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }

        public Teacher() { }

        public Teacher(int id, string Teachername, string Teacheremail)
        {
            TeacherName = Teachername;
            TeacherEmail = Teacheremail;
            Id = id;
        }
    }
}
