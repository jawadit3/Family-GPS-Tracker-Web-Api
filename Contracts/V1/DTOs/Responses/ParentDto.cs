using System;

namespace Family_GPS_Tracker_Api.Contracts.V1.ResponseDtos
{
	public class ParentDto
	{
		public Guid UserId { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string phoneNumber { get; set; }
		public string deviceToken { get; set; }
		
	}
}