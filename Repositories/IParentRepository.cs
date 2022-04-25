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
	}
}
