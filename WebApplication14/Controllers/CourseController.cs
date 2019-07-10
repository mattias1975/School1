
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
        IStudentService _studentService;

        public CourseController(ICourseService courseService, ITeacherService teacherService, IStudentService studentService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
            _studentService = studentService;
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


        public IActionResult Details(int id)
        {

            Course Course = _courseService.FindById(id);
            if (Course == null)
            {
                return NotFound();
            }

            return View(Course);
        }
        //Get
        public IActionResult AddTeacherToCourse(int id)
        {
            Course course = _courseService.FindById(id);
            if (course == null)
            {
                return NotFound();
            }

            List<Teacher> teacher = _teacherService.GetTeachers();

            if (teacher == null)
            {
                return NotFound();
            }

            TeacherSclass vm = new TeacherSclass();

            vm.Course = course;
            vm.Teachers = teacher;

            return View(vm);

        }

        //Post
        [HttpPost]
        public IActionResult AddTeacherToCourse(int cId, int tId)

        {
            Course course = _courseService.FindById(cId);

            if (course == null)
            {
                return BadRequest();
            }

            Teacher teacher = _teacherService.FindById(tId);

            if (teacher == null)
            {
                return BadRequest();
            }

            course.Teacher = teacher;
            _courseService.Update(course);

            return Json(course.Teacher.Name);



        }

        [HttpGet]
        public IActionResult AddStudentToCourse(int id)
        {
            {
                Course course = _courseService.FindById(id);
                if (course == null)
                {
                    return NotFound();
                }

                List<Student> student = _studentService.GetStudents();

                if (student == null)
                {
                    return NotFound();
                }

                foreach (CourseStudent item in course.Students)
                {
                    student.Remove(item.Student);
                }

                StudentSclass vm = new StudentSclass();

                vm.Course = course;
                vm.Students = student;




                return View(vm);

            }
        }

        [HttpPost]
        public IActionResult AddStudentToCourse(int coId, int SoId)

        {
            Course course = _courseService.FindById(coId);

            if (course == null)
            {
                return BadRequest();
            }

            Student student = _studentService.FindById(SoId);


            if (student == null)
            {
                return BadRequest();
            }

            course.Students.Add(new CourseStudent() { CourseId = course.Id, StudentId = student.Id });
            _courseService.Update(course);

            student.Courses = null;




            return Json(student);



        }

        [HttpPost]
        public IActionResult DeleteStudentFromCourse(int id, int student_id)
        {

            Course course = _courseService.FindById(id);
            //Student student = _studentService.FirstOrDefault(p => p.Id == id);

            if (course == null || student_id == null)
            {
                return BadRequest();
            }

            _courseService.DeleteStudentFromCourse(id,student_id);//bara för spara


            return Ok();



        }
    }
}









