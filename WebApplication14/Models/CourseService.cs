using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace School.Models
{
    public class CourseService : ICourseService
    {
        readonly DBContextSchool _dBContextSchool;

        public CourseService(DBContextSchool dBContextSchool)
        {
            _dBContextSchool = dBContextSchool;
        }

        public List<course> GetCourses()
        {
           
            return _dBContextSchool.Course.Include(course => course.Teacher).ToList();

        }
        public List<Student> GetStudents()
        {

            return _dBContextSchool.Course.Include(course => course.student).ToList();
        }
        public course Create(course course)
        {


            _dBContextSchool.Course.Add(course);
            _dBContextSchool.SaveChanges();

            return course;
        }

        public bool Delete(int id)
        {
            course course = _dBContextSchool.Course.SingleOrDefault(p => p.Id == id);

            _dBContextSchool.Course.Remove(course);
            _dBContextSchool.SaveChanges();

            return true;
        }

        public course FindById(int id)
        {
            return _dBContextSchool.Course.Include(c => c.Teacher).SingleOrDefault(p => p.Id == id);
        }
        public course CourseDetails(int id)
        {
            return _dBContextSchool.Course
                .Include(x => x.Teacher)
                .SingleOrDefault(p => p.Id == id);
        }


        public bool Update(course course)
        {
            course Orginal = _dBContextSchool.Course.Include(c => c.Teacher).SingleOrDefault(p => p.Id == course.Id);
            if (Orginal == null)
            {
                return false;
            }
            Orginal.CourseName = course.CourseName;
            Orginal.Assigment = course.Assigment;
            Orginal.Id = course.Id;
            Orginal.Teacher = course.Teacher;
            _dBContextSchool.SaveChanges();
            return true;
        }


    }
}





