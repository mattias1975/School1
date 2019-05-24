using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Models;

namespace ListOfStudents.Models
{
    public class DbInit
    {
        public static void init(DBContextStudent context)
        {
            context.Database.EnsureCreated();

            if (context.Student.Any())
            {
                return;
            }
            else
            {
                context.Add(new Student());
          
                context.SaveChanges();
            }
            }
        }
    }

