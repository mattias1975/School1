using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace School.Models
{
    public class DbInit
    {
        public static void init(DBContextSchool context)
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

