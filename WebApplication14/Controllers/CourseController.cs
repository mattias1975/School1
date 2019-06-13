
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
        ICourseService _courseService;
        ITeacherService _teacherService;

        public CourseController(ICourseService courseService, ITeacherService teacherService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            return View(_courseService.GetCourses());
        }

        public IActionResult Course(int id)
        {
            Course Course = _courseService.FindById(id);
            if (Course == null)
            {
                return NotFound();
            }
            return PartialView("_Course", Course);
        }
        public IActionResult Teacher(int id)
        {
            Teacher teacher = _teacherService.FindById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return PartialView("_Teacher", teacher);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Course course = _courseService.FindById((int)Id);
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
            if (_courseService.Update(course))
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


            _courseService.Create(course);

            return PartialView("_Course", course);
        }

        [HttpPost]
        public IActionResult ConfirmCreate(Course course)
        {
            if (course == null)
            {
                return NoContent();
            }
            if (_courseService.Update(course))
            {
                return PartialView("_Course", course);
            }

            else
            {
                return PartialView("_Course", _courseService.FindById(course.Id));
            }
        }

        public IActionResult Delete(int Id)
        {

            Course course = _courseService.FindById((int)Id);


            if (course == null)
            {
                return Content("");
            }

            _courseService.Delete(Id);


            return Content("");
        }

        public IActionResult AddTeacherToCourse(int id)
        {
            Teacher teacher = _teacherService.FindById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return PartialView("_Teacher", teacher);
        }
        public IActionResult Details(int id)
        {

            Course Course = _courseService.CourseDetails(id);
            if (Course == null)
            {
                return NotFound();
            }

            return View(Course);
        }


    }
}