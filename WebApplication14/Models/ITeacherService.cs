using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public interface ITeacherService
    {
        Teacher Create(Teacher teacher);
        Teacher FindById(int Id);
        List<Teacher> GetTeachers();
        bool Delete(int Id);
        bool Update(Teacher teacher);
    }
}
