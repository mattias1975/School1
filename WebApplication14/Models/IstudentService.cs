using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace School.Models
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student FindById(int Id);
        List<Student> GetStudents();
        bool Delete(int Id);
        bool Update(Student student);
        //void saveChanges(int id);
    }
}
