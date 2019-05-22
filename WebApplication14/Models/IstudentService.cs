using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Models;

namespace School.Models
{
    public interface IStudentService
    {
        Student Create(string name, string course);
        Student FindById(int Id);
        List<Student> GetStudents();
        bool Delete(int Id);
        bool Update(Student student);
    }
}
