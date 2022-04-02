using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Dtos
{
	public class ParentDetailDto
	{
		public Guid parentId { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public string phoneNumber { get; set; }
		public IEnumerable<ChildDto> children { get; set; }
	}
}
