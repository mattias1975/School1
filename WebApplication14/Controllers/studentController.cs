
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;


namespace School.Controllers
{
    public class StudentController : Controller
    {
        IStudentService _studentService;
        ICourseService _courseService;
        ICourseService courseService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            return View(_studentService.GetStudents());
        }

        public IActionResult Student(int id)
        {
            Student stundent = _studentService.FindById(id);
            if (stundent == null)
            {
                return NotFound();
            }
            return PartialView("_Student", stundent);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student student = _studentService.FindById((int)id);
            if (student == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", student);
        }
        [HttpPost]
        public IActionResult ConfirmEdit(Student student)
        {
            if (student == null)
            {
                return NotFound();
            }
            if (_studentService.Update(student))
            {
                return PartialView("_student", student);
            }
            else
            {
                return PartialView("_edit", _studentService.FindById(student.Id));
            }
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            //if (name == null)
            //{
            //    return BadRequest(new { msg = "Write your name" });
            //}
            //if (email == null)
            //{
            //    return BadRequest(new { msg = "Write Email" });
            //}
            //Student student = _studentService.Create();

            _studentService.Create(student);

            return PartialView("_student", student);
        }

        [HttpPost]
        public IActionResult ConfirmCreate(Student student)
        {
            if (student == null)
            {
                return NoContent();
            }
            if (_studentService.Update(student))
            {
                return PartialView("_Student", student);
            }

            else
            {
                return PartialView("_Student", _studentService.FindById(student.Id));
            }
        }

        public IActionResult Delete(int id)
        {

            Student student = _studentService.FindById((int)id);
            //Student student = _studentService.FirstOrDefault(p => p.Id == id);

            if (student == null)
            {
                return BadRequest();
            }

            _studentService.Delete(id);//bara för spara


            return Ok();
        }
        public IActionResult DeleteStudentFromCourse(int id)
        {

            Course student = _courseService.FindById((int)id);
            //Student student = _studentService.FirstOrDefault(p => p.Id == id);

            if (student == null)
            {
                return BadRequest();
            }

            _courseService.Delete(student.Id);//bara för spara


            return Ok();
        }







    }
}







