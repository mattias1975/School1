﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace School.Models
{

    public class TeacherSclass

    {
        public course Course { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Student { get; set; }
    }
}







