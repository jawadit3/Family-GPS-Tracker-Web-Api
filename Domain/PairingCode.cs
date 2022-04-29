﻿using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Domain
{
	public class PairingCode
	{
		public Guid PairingCodeId { get; set; }
		public int Code { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime ExpiryDate { get; set; }
		public bool IsUsed { get; set; }
		public Guid ChildId { get; set; }
		public virtual Child Child { get; set; }
	}
}
