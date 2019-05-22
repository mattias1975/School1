﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using WebApplication14.Models;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
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
        public IActionResult Edit(int id, string Name, string Course)
        {
            Student student = _studentService.FindById(id);
            if (student == null)
            {
                return NotFound();
            }
            return PartialView("Edit", student);
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
        public IActionResult Delete(int id)
        {

            Student student = _studentService.FindById(id);
            if (student == null)
            {
                return NotFound();
            }
            _studentService.Delete(id);
            return Content("");
        }
        public IActionResult Sort(string sort)

        {
            return View("Student", _studentService.GetStudents()
      .Where(p => p.Name.ToLower().Contains(sort) || p.CourseName.ToLower().Contains(sort))
                .ToList());

        }

    }
}