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

		public static class Parent {
			public const string Get = Base + "/parent/{parentId}";
			public const string GetDetails = Base + "/parent/details/{parentId}";
			public const string UpdateToken = Base + "/parent/updateToken/{parentId}";
			public const string LinkChild = Base + "/parent/linkChild/{parentId}";
		}

		public static class Child
		{
			public const string Get = Base + "/child/{childId}";
			public const string GetDetails = Base + "/child/details/{childId}";
			public const string GetPairingCode = Base + "/child/pairingCode/{childId}";
			
		}

		public static class Identity
		{
			public const string RegisterParent = Base + "/identity/registerParent";
			public const string RegisterChild = Base + "/identity/registerChild";
			public const string Login = Base + "/identity/login";
			public const string RefreshToken = Base + "/identity/refresh";
		}

		public static class Notification
		{
			public const string SendNotification = Base + "/notification/send";
			public const string GetNotificationsByParentId = Base + "/notification/{parentId}";
			public const string GetNotificationsByChildId = Base + "/notification/{childId}";

		}
	}
}
