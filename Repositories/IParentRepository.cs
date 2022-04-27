using Family_GPS_Tracker_Api.Domain;
using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Repositories
{
	public interface IParentRepository
	{
		public Task<Parent> GetParentByIdAsync(Guid userId);
		public Task<bool> CreateParentAsync(Parent parent);
		public Task<Parent> GetParentDetailsByIdAsync(Guid userId);
		public Task<bool> UpdateDeviceTokenAsync(Parent parent, DeviceToken deviceToken);
	}
}
