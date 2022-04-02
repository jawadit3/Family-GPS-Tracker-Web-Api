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
		public static readonly string Base = $"{Root}/{Version}";

		public static class Parent {
			public static readonly string Get = $"{Base}/parent/{{parentId}}";
			public static readonly string GetDetails = $"{Base}/parent/details/{{parentId}}";
			public static readonly string Create = $"{Base}/parent/register";
			public static readonly string UpdateToken = $"{Base}/parent/token/{{parentId}}";
		}
	}
}
