using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace LMS.Models
{
    public class Course
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Instructor { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }
        public string Video { get; set; }
        public string Describe { get; set; }
        public string LecturerId { get; set; }
    }
}