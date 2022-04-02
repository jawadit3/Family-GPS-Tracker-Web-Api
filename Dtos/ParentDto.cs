using System;

namespace Family_GPS_Tracker_Api.Dtos
{
	public class ParentDto
	{
		public Guid parentId { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public string phoneNumber { get; set; }

		public string deviceToken { get; set; }
		

	}
}