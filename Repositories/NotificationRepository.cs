using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Repositories
{
	public class NotificationRepository
	{
		private readonly FamilyTrackerDatabaseContext _db;

		public NotificationRepository(FamilyTrackerDatabaseContext db)
		{
			_db = db;
		}

		public Notification CreateNotification(Notification notification)
		{
			_db.Notifications.Add(notification);
			_db.SaveChanges();
			return notification;
		}

		public ICollection<Notification> GetNotifications()
		{
			return _db.Notifications
				.Include(notification => notification.Child)
				.ToList();
		}
	}
}
