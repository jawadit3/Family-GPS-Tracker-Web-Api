using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Contracts
{
	public static class ApiRoutes
	{
		public const string Root = "api";
		public const string Version = "v1";
		public const string Base = Root + "/" + Version;

		public static class Identity
		{
			public const string RegisterParent = Base + "/identity/register-parent";
			public const string RegisterChild = Base + "/identity/register-child";
			public const string Login = Base + "/identity/login";
			public const string RefreshToken = Base + "/identity/refresh";
		}

		public static class Parent {
			public const string Get = Base + "/parent/{parentId}";
			public const string GetDetails = Base + "/parent/details/{parentId}";
			public const string UpdateToken = Base + "/parent/update-token/{parentId}";
			public const string LinkChild = Base + "/parent/link-child/{parentId}";
		}

		public static class Child
		{
			public const string Get = Base + "/children/{childId}";
			public const string GetDetails = Base + "/children/details/{childId}";
			public const string GetPairingCode = Base + "/children/pairing-code/{childId}";
			
		}

		public static class Notification
		{
			public const string SendNotification = Base + "/notifications/send";
			public const string GetNotificationsByParentId = Base + "/notifications/{parentId}";
			public const string GetNotificationsByChildId = Base + "/notifications/{childId}";

		}

		public static class Location
		{
			public const string CreateLocation = Base + "/locations";
			public const string GetLocationByChildId = Base + "/locations/{child-id}";
			public const string GetLastLocation = Base + "/locations/last-location";
			public const string GetLastTenLocations = Base + "/locations/last-ten-locations";
			
		}
	}
}
