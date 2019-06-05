using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace School.Models
{
    public class TeacherService : ITeacherService
    {
        readonly DBContextSchool _dBContextSchool;

        public TeacherService(DBContextSchool dBContextSchool)
        {
            _dBContextSchool = dBContextSchool;
        }


        //static int idCounter = 1;
        static List<Teacher> Teachers;

        public TeacherService()
        {
      
            _dBContextSchool.Teacher.ToList();

        }
        public Teacher Create(Teacher teacher)
        {
      
            _dBContextSchool.Teacher.Add(teacher);
            _dBContextSchool.SaveChanges();

            return teacher;
        }

        public bool Delete(int id)
        {
            Teacher teeacher = _dBContextSchool.Teacher.SingleOrDefault(p => p.Id == id);

            _dBContextSchool.Teacher.Remove(teacher);
            _dBContextSchool.SaveChanges();

            return true;
        }

        public Teacher FindById(int id)
        {
            return _dBContextSchool.Teacher.SingleOrDefault(p => p.Id == id);
        }


        public List<Teacher> GetTeacher()
        {
            return teacher;
        }

        public List<Teacher> GetTeachers()
        {
            return _dBContextSchool.Teacher.ToList();
           
        }

        public bool Update(Teacher teacher)
        {
            Teacher Orginal = _dBContextSchool.Teacher.SingleOrDefault(p => p.Id == teacher.Id);
            if (Orginal == null)
            {
                return false;
            }
            Orginal.TeacherEmail = teacher.TeacherName;
            Orginal.TeacherEmail = teacher.TeacherEmail;

            return true;
        }
    }
}





