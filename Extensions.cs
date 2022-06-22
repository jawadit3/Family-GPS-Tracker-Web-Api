using Family_GPS_Tracker_Api.Dtos;
using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api
{
	public static class Extentions
	{
		// User Extention Methods

		public static UserDto AsUserDto(this User user)
		{

			return new UserDto
			{
				userId = user.UserId,
				userType = user.UserType.Name,
				parent = user.Parent.AsParentDto(),
				child = user.Child.AsChildDto(),


			};
		}

		// Location Extenion Methods
		public static LocationDto AsLocationDto(this Location location)
		{
			if (location != null)
			{
				return new LocationDto()
				{
					LocationId = location.LocationId,
					Latitude = location.Latitude,
					Longitude = location.Longitude,
					Time = location.Time,
					ChildName = location.Child.Name
				};
			}

			return null;

		}

		// Location Extenion Methods
		public static IEnumerable<LocationDto> AsLocationDtoList(this IEnumerable<Location> locationList)
		{
			var locationDtoList = new List<LocationDto>();

			if(locationList != null)
			{
				foreach (Location location in locationList)
				{

					locationDtoList.Add(new LocationDto()
					{
						LocationId = location.LocationId,
						Latitude = location.Latitude,
						Longitude = location.Longitude,
						Time = location.Time,
						ChildName = location.Child.Name

					});
				}

				return locationDtoList;
			}

			

			return null;
		}

		// Child Extension Methods

		public static ChildDto AsChildDto(this Child child)
		{
			if (child != null)
			{
				return new ChildDto()
				{
					childId = child.ChildId,
					name = child.Name,
					email = child.Email,
					password = child.Password,
					parentId = child.ParentId
					

				};
			}

			return null;

		}

		public static ChildDetailDto AsChildDetailDto(this Child child)
		{
			return new ChildDetailDto
			{
				childId = child.ChildId,
				name = child.Name,
				email = child.Email,
				password = child.Password,
				parent = child.Parent.AsParentDto(),
				geofences = child.Geofences.AsGeofenceDtoList()

			};
		}

		public static IEnumerable<ChildDto> AsChildDtoList(
			this ICollection<Child> children)
		{
			var childDtoList = new List<ChildDto>();

			foreach (Child child in children)
			{

				childDtoList.Add(new ChildDto
				{
					childId = child.ChildId,
					name = child.Name,
					email = child.Email,
					password = child.Password

				});
			}

			return childDtoList;
		}

		// Parent Extension Methods

		public static ParentDto AsParentDto(this Parent parent)
		{
			if (parent != null)
			{
				return new ParentDto()
				{
					parentId = parent.ParentId,
					name = parent.Name,
					email = parent.Email,
					password = parent.Password,
					phoneNumber = parent.PhoneNumber,
					deviceToken = parent.DeviceToken

				};
			}
			return null;
		}

		public static ParentDetailDto AsParentDetailDto(this Parent parent)
		{
			return new ParentDetailDto
			{
				parentId = parent.ParentId,
				name = parent.Name,
				email = parent.Email,
				password = parent.Password,
				phoneNumber = parent.PhoneNumber,
				children = parent.Children.AsChildDtoList()

			};
		}

		// PairingCode Extension Methods

		public static PairingCodeDto AsPairingCodeDto(this String pairingCode)
		{
			return new PairingCodeDto
			{
				code = pairingCode
			};
		}

		// Notification Extension Methods

		public static NotificationDto AsNotificationDto(this Notification notification)
		{
			return new NotificationDto
			{
				NotificationId = notification.NotificationId,
				SenderName = notification.Child.Name,
				Title = notification.Title,
				Message = notification.Message,
				CreatedAt = notification.CreatedAt
			};
		}



		public static List<NotificationDto> AsNotificationDtoList(this ICollection<Notification> notifications)
		{
			var notificationDtoList = new List<NotificationDto>();

			foreach (Notification notification in notifications)
			{

				notificationDtoList.Add(notification.AsNotificationDto());
			}

			return notificationDtoList;
		}

		public static IEnumerable<GeofenceDto> AsGeofenceDtoList(
			this IEnumerable<Geofence> geofences)
		{
			var geofenceDtoList = new List<GeofenceDto>();

			foreach (Geofence geofence in geofences)
			{

				geofenceDtoList.Add(new GeofenceDto
				{
					Category = geofence.Category,
					GeofenceId = geofence.GeofenceId,
					Latitude = geofence.Latitude,
					Longitude = geofence.Longitude,
					Radius = geofence.Radius,
					//Child = geofence.Child.AsChildDto()
					
				});
			}

			return geofenceDtoList;
		}

		public static GeofenceDto AsGeofenceDto(this Geofence geofence)
		{
			return new GeofenceDto
			{
				GeofenceId = geofence.GeofenceId,
				Category = geofence.Category,
				Radius = geofence.Radius,
				Latitude = geofence.Latitude,
				Longitude = geofence.Longitude,
				//Child = geofence.Child.AsChildDto()
			};
		}
	}
}
