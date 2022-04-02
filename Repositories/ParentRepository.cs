using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Family_GPS_Tracker_Api.Dtos;

namespace Family_GPS_Tracker_Api.Repositories
{
	public class ParentRepository
	{
		private readonly FamilyTrackerDatabaseContext _db;

		public ParentRepository(FamilyTrackerDatabaseContext db)
		{
			_db = db;
		}

		public void CreateParent(Parent item)
		{
			User user = new User()
			{
				UserId = Guid.NewGuid(),

			};

			UserType userType = new UserType()
			{
				UserTypeId = Guid.NewGuid(),
				Name = "parent"
			};

			user.Parent = item;
			user.UserType = userType;
			_db.Users.Add(user);
			_db.SaveChanges();

		}

		public IEnumerable<Parent> GetAll()
		{
			throw new NotImplementedException();
		}

		public Parent Get(Guid id)
		{

			return _db.Parents.SingleOrDefault(parent => parent.ParentId == id);

		}

		public Parent GetDetails(Guid id)
		{
			return _db.Parents
				.Include(parent => parent.Children)
				.SingleOrDefault(parent => parent.ParentId == id);

		}


		public String GetDeviceToken(Guid id)
		{
			return _db.Parents.Where(parent => parent.ParentId == id)
				.Select(parent => parent.DeviceToken)
				.SingleOrDefault();

		}

		public Parent UpdateDeviceToken(Parent parent, String deviceToken)
		{
			parent.DeviceToken = deviceToken;
			_db.Parents.Update(parent);
			_db.SaveChanges();
			return parent;

		}
	}
}
