using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace School.Models
{
    public interface ICourseService
    {
        Course Create(Course course);
        Course FindById(int ID);
        List<Course> GetCourses();
        bool Delete(int ID);
        bool Update(Course course);

    }
}
