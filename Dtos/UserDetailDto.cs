using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Dtos
{
	public class UserDetailDto
	{
		public Guid UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string UserType { get; set; }
		public Child Child { get; set; }
		public Parent Parent { get; set; }
	}
}
