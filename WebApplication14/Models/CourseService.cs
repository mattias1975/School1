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


        //static int idCounter = 1;
        static List<Course> Course;

        public CourseService()
        {
        
            _dBContextSchool.course.ToList();

        }
        public Course Create(Course course)
        {
          
            _dBContextSchool.Course.Add(course);
            _dBContextSchool.SaveChanges();

            return course;
        }

        public bool Delete(int id)
        {
            Course Course = _dBContextSchool.Course.SingleOrDefault(p => p.Id == id);

             _dBContextSchool.Course.Remove(course);
            _dBContextSchool.SaveChanges();

            return true;
        }

        public Course FindById(int id)
        {
            return _dBContextSchool.Course.SingleOrDefault(p => p.Id == id);
        }


        public List<Course> GetCourse()
        {
            return Course;
        }

        public List<Course> Getcourse()
        {
            return _dBContextSchool.Courses.ToList();
            //return Students;
        }

        public bool Update(Course course)
        {
            Course Orginal = _dBContextSchool.Course.SingleOrDefault(p => p.Id == course.Id);
            if (Orginal == null)
            {
                return false;
            }
            Orginal.Name = course.Name;
            Orginal.Email = email.Email;

            return true;
        }

        public bool Update(Course course)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCourses()
        {
            throw new NotImplementedException();
        }
    }
}





