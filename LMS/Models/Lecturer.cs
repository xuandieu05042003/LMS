using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Models
{
	public class Lecturer
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
        public string Image { get; set; }
    }
}