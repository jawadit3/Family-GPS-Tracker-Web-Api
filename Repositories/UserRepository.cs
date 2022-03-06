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

		public void CreateEntity(Parent item)
		{
			_db.Parents.Add(item);
			_db.SaveChanges();
		}

		public void DeleteEntity(User item)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> GetEntities()
		{
			throw new NotImplementedException();
		}

		public User GetUser(String email) {
			return _db.Users
				.Include(user => user.UserType)
				.Where(user => user.Email == email)
				.FirstOrDefault();
		}

		public User GetUserDetails(Guid id) {
			return _db.Users.Include(user => user.UserType)
				.Include(user => user.Parent)
				.Include(user => user.Child)
				.Where(user => user.UserId == id)
				.FirstOrDefault();
				
		}

		public User GetParentDetails(Guid id)
		{
			return _db.Users
				.Include(user => user.Parent)
				.ThenInclude(parent => parent.Children)
				.Include(user => user.UserType)
				.Where(user => user.ParentId == id)
				.FirstOrDefault();

		}

		public void CreateParent(User user) {
			_db.Users.Add(user);
			_db.SaveChanges();
		}


	}
}
