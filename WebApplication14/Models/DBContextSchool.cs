﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace School.Models
{
    public class DBContextSchool : DbContext
    {
        internal object course;

        public DBContextSchool(DbContextOptions<DBContextSchool> options) : base(options) { }


        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
    
        