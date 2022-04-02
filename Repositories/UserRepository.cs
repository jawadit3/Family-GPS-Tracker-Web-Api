using Family_GPS_Tracker_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Repositories
{
	public class UserRepository
	{
		private readonly FamilyTrackerDatabaseContext _db;


		public UserRepository(FamilyTrackerDatabaseContext db)
		{
			_db = db;
			//_db.ChangeTracker.LazyLoadingEnabled = false;

		}

		public User GetUser(String email)
		{
			return _db.Users
				.Include(user => user.Parent)
				.Include(user => user.Child)
				.Include(user => user.UserType)
				.Where(user => user.Parent.Email == email || user.Child.Email == email)
				.FirstOrDefault();
		}

		public User GetUserDetails(String email)
		{
			return _db.Users.Include(user => user.UserType)
				.Include(user => user.Parent)
				.Include(user => user.Child)
				.Where(user => user.Parent.Email == email || user.Child.Email == email)
				.FirstOrDefault();

		}
	}
}
