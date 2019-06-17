using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace School.Models
{
    public interface ITeacherService
    {
        Teacher Create(Teacher teacher);
        Teacher FindById(int Id);
        List<Teacher> GetTeachers();
        bool Delete(int Id);
        bool Update(Teacher teacher);
        bool Update(Func<int, IActionResult> teacher);
    }
}
