using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Models;

namespace ListofPeople.Models
{
    public class StudentService : IStudentService
    {
        static int idCounter = 1;
        static List<Student> Students;

        public StudentService()
        {
            Students = new List<Student>();
            this.Create("xxxxxx", "Rävemåla", "a@a.a");

        }
        public Student Create(string name, string course, string email)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(course) || string.IsNullOrWhiteSpace(email))
            {
                return null;
            }
            Student student = new Student(idCounter++,name, course,email);
            Students.Add(student);
            return student;
        }

        public bool Delete(int id)
        {
            return Students.Remove(Students.FirstOrDefault(p => p.Id == id));
        }

        public Student FindById(int id)
        {
            return Students.FirstOrDefault(p => p.Id == id);
        }


        public List<Student> GetPeople()
        {
            return Students;
        }

        public List<Student> GetStudents()
        {
            return Students;
        }

        public bool Update(Student student)
        {
            Student Orginal = Students.SingleOrDefault(p => p.Id == student.Id);
            if (Orginal == null)
            {
                return false;
            }
            Orginal.Name = student.Name;
            Orginal.CourseName = student.CourseName;
            Orginal.Email = student.Email;

            return true;
        }
    }
}





