
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

            if (course.Teacher != null)//check if techer not=null
            {
                foreach (var item in vm.Teachers)//Check where Item in Tehachers is= Teacher
                {
                    if (item.Id == course.Teacher.Id)//check if Item.id is same ass course.Teacher.Id
                    {
                        vm.Teachers.Remove(item);//if last array is true remove item from list
                        break;
                    }
                    
                }
            }
            
            return View(vm);

        }

        //Post
        [HttpPost]
        public IActionResult AddTeacherToCourse(int cId, int tId)

        {
            Course course = _courseService.FindById(cId);// check after course by id

            if (course == null)//check if course= null
            {
                return BadRequest(); //if true return badrequest
            }

            Teacher teacher = _teacherService.FindById(tId);

            if (teacher == null)// same as Course but teacher
            {
                return BadRequest();
            }



            course.Teacher = teacher;//course.Teacher is same as teacher
            _courseService.Update(course);//update course
            
            return Json(course.Teacher.Name);//return a Json on teachers name in course



        }
        //check commens about teacher it´s same but course
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
                    student.Remove(item.student);
                }

                StudentSclass vm = new StudentSclass();

                vm.Course = course;
                vm.Students = student;
                _courseService.Update(course);

                return View(vm);

            }
        }
        //check commens about teacher it´s same but Student
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
            CourseStudent courseStudent = new CourseStudent() { CourseId = course.Id, StudentId = student.Id };
            course.Students.Add(courseStudent);
            _courseService.Update(course);

            student.Courses = null;

            return PartialView("_StudentInClass", courseStudent);



        }

        [HttpPost]
        public IActionResult DeleteStudentFromCourse(int course_id, int student_id)
        {

            Course course = _courseService.FindById(course_id);
            Student student = _studentService.FindById(student_id);
            if (course == null || student == null)
            {
                return BadRequest();
            }

            _courseService.DeleteStudentFromCourse(course_id, student_id);//bara för spara



            return PartialView("_AddStudentCourseRow", new StudentSclass() { student = student, Course = course });




        }
    }
}









