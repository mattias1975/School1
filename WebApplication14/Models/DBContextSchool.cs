using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace School.Models
{
    public class DBContextSchool : DbContext
    {
        public DBContextSchool(DbContextOptions<DBContextSchool> options) : base(options) { }


        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>()
                .HasKey(c => new { c.CourseId, c.StudentId });

            modelBuilder.Entity<CourseStudent>()
                .HasOne(c => c.Course)
                .WithMany(p => p.Students)
                .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<CourseStudent>()
                .HasOne(c => c.Student)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.StudentId);
        }
    }



   
}


