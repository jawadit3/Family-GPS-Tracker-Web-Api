using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Dtos
{
	public class ChildDetailDto
	{
		public Guid childId { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public ParentDto parent { get; set; }
		public IEnumerable<GeofenceDto> geofences { get; set; }
	}
}
