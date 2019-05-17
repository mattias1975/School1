using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher : Student
    {
        public int id { get; set; }
        public string TecherName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public int Grade { get; set; }

    }

}
