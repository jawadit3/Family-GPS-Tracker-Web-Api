using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Dtos
{
	public class NotificationDto
	{
		public Guid NotificationId { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
		public string CreatedAt { get; set; }
	}
}
