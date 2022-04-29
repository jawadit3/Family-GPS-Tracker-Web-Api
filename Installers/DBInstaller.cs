using CatalogWebApi.Models;
using CorePush.Apple;
using CorePush.Google;
using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
//using Family_GPS_Tracker_Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Family_GPS_Tracker_Api.Models.IdentityModels;

namespace Family_GPS_Tracker_Api.Installers
{
	public class DBInstaller : IInstaller
	{
		public void installServices(IServiceCollection services, IConfiguration Configuration)
		{
			
			services.AddDbContext<AppDbContext>(
			options => options.UseSqlServer("name=ConnectionStrings:MyDb"));
			services.AddIdentity<ApplicationUser, ApplicationRole>()
			.AddEntityFrameworkStores<AppDbContext>()
			.AddDefaultTokenProviders();
			/*services.AddScoped<UserRepository, UserRepository>();*/
			services.AddScoped<IParentRepository, ParentRepository>();
			services.AddScoped<IChildRepository, ChildRepository>();
			services.AddScoped<LocationRepository, LocationRepository>();
			services.AddScoped<IIdentityRepository,IdentityRepository>();
			services.AddScoped<NotificationRepository, NotificationRepository>();
			var appSettingsSection = Configuration.GetSection("FcmNotification");
			//services.Configure<FcmNotificationOptions>(appSettingsSection);
			//services.AddTransient<INotificationService, NotificationService>();
			services.AddHttpClient<FcmSender>();
			services.AddHttpClient<ApnSender>();
		}
	}
}
