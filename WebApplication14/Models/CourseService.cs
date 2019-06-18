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

        public List<Course> GetCourses()
        {
           
            return _dBContextSchool.Course.Include(course => course.Teacher).ToList();

        }
        public Course Create(Course course)
        {


            _dBContextSchool.Course.Add(course);
            _dBContextSchool.SaveChanges();

            return course;
        }

        public bool Delete(int id)
        {
            Course course = _dBContextSchool.Course.SingleOrDefault(p => p.Id == id);

            _dBContextSchool.Course.Remove(course);
            _dBContextSchool.SaveChanges();

            return true;
        }

        public Course FindById(int id)
        {
            return _dBContextSchool.Course.Include(c => c.Teacher).SingleOrDefault(p => p.Id == id);
        }
        public Course CourseDetails(int id)
        {
            return _dBContextSchool.Course
                .Include(x => x.Teacher)
                .SingleOrDefault(p => p.Id == id);
        }


        public bool Update(Course course)
        {
            Course Orginal = _dBContextSchool.Course.Include(c => c.Teacher).SingleOrDefault(p => p.Id == course.Id);
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





