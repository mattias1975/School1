using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace School.Models
{
    public interface ICourseService
    {
        course Create(course course);
        course FindById(int ID);
        List<course> GetCourses();
        List<Student> GetStudents();
        bool Delete(int ID);
        bool Update(course course);

    }
}
