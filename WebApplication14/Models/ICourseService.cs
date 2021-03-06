﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace School.Models
{
    public interface ICourseService
    {
        Course Create(Course course);
        Course FindById(int Id);
        List<Course> GetCourses();
        bool Delete(int Id);
        bool Update(Course course);
        void Delete(Course student);
        bool DeleteStudentFromCourse(int course_Id, int student_Id);
    }
}
