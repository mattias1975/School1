using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListOfStudents.Models
{
    public class Teacher
    {
        public Teacher()
        {
        }
        public Teacher(string TeacherName, string FirstName, string LastName, string Course, int CourseID)
        {
            TecherName = teachername;
            FirstName = firstname;
            LastName = lastName;
            Course = course;
            CourseID = courseID;
        }
        public Teacher(int id, string TeacherName, string FirstName, string LastName, string Course, int Courseid)
        {
            ID= id;
            TeacherName = teacherName;
            FirstName = firstName;
            LastName = lastName;
            Course = course;
            Courseid = courseid;

        }
        public int CourseID { get;  }
        public int ID{ get; set; }
        public string TeacherName { get; set; }
        public string FirstName { get; set; }
        public string LatName { get; set; }
        public string Course { get; set; }
    }
}
