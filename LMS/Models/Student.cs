using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string StudentName { get; set; }
        public string  Birthday { get; set; }
        public string Phone { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
    }
}
