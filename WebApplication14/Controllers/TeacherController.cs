
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;


namespace School.Controllers
{
    public class TeacherController : Controller
    {
        ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }



        public IActionResult Index()
        {
            return View(_teacherService.GetTeachers());
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
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Teacher teacher =_teacherService.FindById((int)id);     
            if (teacher == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", teacher);
        }
        [HttpPost]
        public IActionResult ConfirmEdit(Teacher teacher)
        {
            if (teacher == null)
            {
                return NotFound();
            }
            if (_teacherService.Update(teacher))
            {
                return PartialView("_Teacher", teacher);
            }
            else
            {
                return PartialView("_edit", _teacherService.FindById(teacher.Id));
            }
        }
        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
       

            _teacherService.Create(teacher);

            return PartialView("_Teacher", teacher);
        }

        [HttpPost]
        public IActionResult ConfirmCreate(Teacher teacher)
        {
            if (teacher == null)
            {
                return NoContent();
            }
            if (_teacherService.Update(teacher))
            {
                return PartialView("_Teacher", teacher);
            }

            else
            {
                return PartialView("_Teacher", _teacherService.FindById(teacher.Id));
            }
        }

        public IActionResult Delete(int id)
        {

           Teacher teacher = _teacherService.FindById((int)id);
           
            if (teacher == null)
            {
                return Content("");
            }

            _teacherService.Delete(id);

            return Content("");
        }
      

    }
}