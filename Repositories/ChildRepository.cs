using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Family_GPS_Tracker_Api.Repositories
{
	public class ChildRepository
	{
		private readonly FamilyTrackerDatabaseContext _db;

		public ChildRepository(FamilyTrackerDatabaseContext db)
		{
			_db = db;
		}


		public Child Get(Guid id)
		{
			return _db.Children.SingleOrDefault(child => child.ChildId == id);
		}

		public Child GetDetails(Guid id)
		{
			return _db.Children
				.Include(child => child.Parent)
				.Include(child => child.Geofences)
				.SingleOrDefault(child => child.ChildId == id);
		}

		public Child GetDetails(String pairingCode)
		{
			return _db.Children
				.Include(child => child.Parent)
				.SingleOrDefault(child => child.Code == pairingCode);
		}

		public void Create(Child child)
		{
			User user = new User()
			{
				UserId = Guid.NewGuid(),

			};

			UserType userType = new UserType()
			{
				UserTypeId = Guid.NewGuid(),
				Name = "child"
			};

			user.Child = child;
			user.UserType = userType;
			_db.Users.Add(user);
			_db.SaveChanges();
		}

		public Child LinkParent(Guid parentId, Child child)
		{

			child.ParentId = parentId;
			_db.Children.Update(child);
			_db.SaveChanges();
			return child;
		}

		public String GeneratePairingCode(Child child)
		{

			child.Code = new Random().Next(10000, 99999).ToString();
			_db.Children.Update(child);
			_db.SaveChanges();
			return child.Code;

		}
	}
}
