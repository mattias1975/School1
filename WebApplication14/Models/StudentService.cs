using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace School.Models
{
    public class StudentService : IStudentService
    {
        readonly DBContextSchool _dBContextSchool;

        public StudentService(DBContextSchool dBContextSchool)
        {
            _dBContextSchool = dBContextSchool;
        }


        //static int idCounter = 1;
        static List<Student> Students;

        public StudentService()
        {
            //Students = new List<Student>();
            //this.Create("xxxxxx", "Rävemåla", "a@a.a");
            _dBContextSchool.Student.ToList();

        }
        public Student Create(Student student)
        {
            //if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            //{
            //    return null;
            //}

            //Student student = new Student(name, email);

            //Students.Add(student);

            _dBContextSchool.Student.Add(student);
            _dBContextSchool.SaveChanges();

            return student;
        }

        public bool Delete(int id)
        {
            Student student = _dBContextSchool.Student.SingleOrDefault(p => p.Id == id);

            // kod saknas

            return false;
        }

        public Student FindById(int id)
        {
            return _dBContextSchool.Student.SingleOrDefault(p => p.Id == id);
        }


        public List<Student> GetPeople()
        {
            return Students;
        }

        public List<Student> GetStudents()
        {
            return _dBContextSchool.Student.ToList();
            //return Students;
        }

        public bool Update(Student student)
        {
            Student Orginal = _dBContextSchool.Student.SingleOrDefault(p => p.Id == student.Id);
            if (Orginal == null)
            {
                return false;
            }
            Orginal.Name = student.Name;
            Orginal.Email = student.Email;

            return true;
        }
    }
}





