using Family_GPS_Tracker_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Repositories
{
	public class GeofenceRepository
	{
		private readonly FamilyTrackerDatabaseContext _db;

		public GeofenceRepository(FamilyTrackerDatabaseContext db)
		{
			_db = db;
		}

		public IEnumerable<Geofence> GetGeofencesByChildId(Guid childId) {
			return _db.Geofences
				.Where(geofence => geofence.ChildId == childId)
				.Include(geofence => geofence.Child)
				.ToList();
		}

		public Geofence CreateGeofence(Geofence geofence)
		{
			_db.Geofences.Add(geofence);
			_db.SaveChanges();
			return geofence;
		}

		public Geofence GetGeofenceById(Guid id)
		{
			return _db.Geofences
				.Where(geofence => geofence.GeofenceId == id)
				.Include(geofence => geofence.Child)
				.FirstOrDefault();
		}
	}
}
