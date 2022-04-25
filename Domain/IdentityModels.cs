using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Models
{
	public class IdentityModels
	{
		public class ApplicationUserToken : IdentityUserToken<Guid> { }
		public class ApplicationUserLogin : IdentityUserLogin<Guid> { }
		public class ApplicationRoleClaim : IdentityRoleClaim<Guid> { }
		public class ApplicationUserRole : IdentityUserRole<Guid> { }
		public class ApplicationUser : IdentityUser<Guid> {
			public virtual Parent Parent { get; set; }
			public virtual Child Child { get; set; }
		}
		public class ApplicationUserClaim : IdentityUserClaim<Guid> { }
		public class ApplicationRole : IdentityRole<Guid> { }
	}
}
