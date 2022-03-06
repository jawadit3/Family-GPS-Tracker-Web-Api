/*using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Repositories
{
	public class ParentRepository : IRepository<Parent>
	{
		private readonly FamilyTrackerDatabaseContext _db;

		public ParentRepository(FamilyTrackerDatabaseContext db) {
			_db = db;
		}

		public void CreateEntity(Parent item)
		{
			_db.Parents.Add(item);
			_db.SaveChanges();
		}

		public void DeleteEntity(Parent item)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Parent> GetEntities()
		{
			throw new NotImplementedException();
		}

		public Parent GetEntity(Guid id)
		{
			return _db.Parents.SingleOrDefault(parent => parent.ParentId == id);
		}

		public void UpdateEntity(Parent item)
		{
			_db.Parents.ToList().Single().
			throw new NotImplementedException();
		}
	}
}
*/