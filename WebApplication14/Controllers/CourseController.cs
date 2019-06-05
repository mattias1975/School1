
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;


namespace School.Controllers
{
    public class CourseController : Controller
    {
        IStudentService _studentService;

        public CourseController(ICourseService courseService)
        {
            _CourseService = coursService;
        }

        public IActionResult Index()
        {
            return View(_courseService.GetCoureses());
        }

        public IActionResult Course(int id)
        {
            Student Course= _courseService.FindById(id);
            if (Course == null)
            {
                return NotFound();
            }
            return PartialView("_Course", Course);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student course = _courseService.FindById((int)id);
            if (course == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", course);
        }
        [HttpPost]
        public IActionResult ConfirmEdit(Course course)
        {
            if (course == null)
            {
                return NotFound();
            }
            if (_studentService.Update(course))
            {
                return PartialView("_course", course);
            }
            else
            {
                return PartialView("_edit", _courseService.FindById(course.Id));
            }
        }
        [HttpPost]
        public IActionResult Create(Course course)
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

            _studentService.Create(course);

            return PartialView("_student", course);
        }

        [HttpPost]
        public IActionResult ConfirmCreate(Course course)
        {
            if (course == null)
            {
                return NoContent();
            }
            if (_studentService.Update(course))
            {
                return PartialView("_Course", course);
            }

            else
            {
                return PartialView("_Course", _courseService.FindById(course.Id));
            }
        }

        public IActionResult Delete(int id)
        {

            Course course = _courseService.FindById((int)id);
            //Student student = _studentService.FirstOrDefault(p => p.Id == id);

            if (course == null)
            {
                return Content("");
            }

            _courseService.Delete(id);//bara för spara


            return Content("");
        }


        //public IActionResult Sort(string sort)
        //{
        //    if (string.IsNullOrWhiteSpace(sort))//if null or space return View index _studentservice
        //    {
        //        return View("Index", _studentService.GetStudents());
        //    }

        //    return View("Index", _studentService.GetStudents()
        //  .Where(p => p.Name.ToLower().Contains(sort) || p.Course.ToLower().Contains(sort))
        //        .ToList());

        //}



    }
}