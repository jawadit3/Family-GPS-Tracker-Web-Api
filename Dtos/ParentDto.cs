﻿using System;

namespace Family_GPS_Tracker_Api.Dtos
{
	public class ParentDto
	{
		public Guid ParentId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; }
		public string UserType { get; set; }

	}
}