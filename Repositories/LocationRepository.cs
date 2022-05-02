using Family_GPS_Tracker_Api.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Repositories
{
	public class LocationRepository
	{
		private readonly AppDbContext _db;

		public LocationRepository(AppDbContext db)
		{
			_db = db;
		}

		public Location Create(Guid childId, Location location) {
			
			_db.Locations.Add(location);
			_db.SaveChanges();
			return location;
		}

		public Location Get(Guid childId)
		{
			return _db.Locations
				.Include(location => location.Child)
				.FirstOrDefault(location => location.ChildId == childId);
		}

		public Location GetAll(Guid childId)
		{
			return _db.Locations
				.Include(location => location.Child)
				.SingleOrDefault(location => location.ChildId == childId);
		}

		public Location GetLast(Guid childId)
		{
			var location = _db.Locations
				.Include( location => location.Child)
				.Where(location => location.ChildId == childId)
				.OrderByDescending(Location => Location.UniqueNumber)
				.FirstOrDefault();
			return location;
		}

		public IEnumerable<Location> GetLastTen(Guid childId)
		{
			return _db.Locations
				.Include(location => location.Child)
				.Where(location => location.ChildId == childId)
				.OrderByDescending(location => location.UniqueNumber)
				.Take(10);
		}
	}
}
