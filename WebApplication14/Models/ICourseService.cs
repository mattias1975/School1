using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public interface ICourseService
    {
        Course Create(Course course);
        Course FindById(int ID);
        List<Course> GetCourses();
        bool Delete(int ID);
        bool Update(Course course);
        Course FindById(object ID);
        Course CourseDetails(int ID);
    }
}
