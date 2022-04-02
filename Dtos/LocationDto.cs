using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Dtos
{
	public class LocationDto
	{
		public Guid LocationId { get; set; }
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public String Time { get; set; }
		public String ChildName { get; set; }
	}
}
