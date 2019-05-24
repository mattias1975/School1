using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Models;

namespace ListOfStudents.Models
{
    public class DBContextStudent: DbContext
    {
        public DBContextStudent(DbContextOptions<DBContextStudent> options) : base(options) { }
      

        public DbSet<Student> Student { get; set; }


    }
}

   
