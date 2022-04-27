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
			public const string Get = Base + "/parent/{userId}";
			public const string GetDetails = Base + "/parent/details/{userId}";
			public const string UpdateToken = Base + "/parent/updateToken/{userId}";
		}

		public static class Child
		{
			public const string Get = Base + "/child";
			public const string GetDetails = Base + "{Base}/child/details";
			public const string Create = Base + "/child/register";
			public const string UpdatePairingCode = Base + "/child/updatePairingCode";
			public const string LinkParent = Base + "/child/linkParent";
		}

		public static class Identity
		{
			public const string RegisterParent = Base + "/identity/registerParent";
			public const string RegisterChild = Base + "/identity/registerChild";
			public const string Login = Base + "/identity/login";
			public const string RefreshToken = Base + "/identity/refresh";
		}
	}
}
