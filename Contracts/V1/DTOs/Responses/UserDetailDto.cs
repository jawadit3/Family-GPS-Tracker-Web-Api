﻿using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Contracts.V1.ResponseDtos
{
	public class UserDetailDto
	{
		public Guid userId { get; set; }
		public ParentDetailResponse parent { get; set; }
		public ChildDetailDto child { get; set; }
		public string userType { get; set; }
	}
}
