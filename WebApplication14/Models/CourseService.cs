﻿using Microsoft.AspNetCore.Mvc;
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
            _dBContextSchool.SaveChanges();

            return _dBContextSchool.Course.ToList();

        }



        public List<Student> GetStudents()
        {

            return _dBContextSchool.Student.ToList();

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
        public bool DeleteStudentFromCourse(int course_Id, int student_Id)
     
        {
            var courseStudent = _dBContextSchool.CourseStudent.ToList();

            foreach (var item in courseStudent)
            {
                if (item.StudentId == student_Id && item.CourseId == course_Id)
                {
                    _dBContextSchool.CourseStudent.Remove(item);
                }
            }

             
            _dBContextSchool.SaveChanges();

            return true;
        }


        public Course FindById(int id)
        {
            return _dBContextSchool.Course
                                          .Include(c => c.Teacher)
                                          .Include(c => c.Students)
                                            .ThenInclude(s => s.student)
                                          .SingleOrDefault(p => p.Id == id);

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

        public void Delete(Course student)
        {
            throw new NotImplementedException();
        }
    }
}





