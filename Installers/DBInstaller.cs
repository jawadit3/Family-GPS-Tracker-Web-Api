using CatalogWebApi.Models;
using CorePush.Apple;
using CorePush.Google;
using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using Family_GPS_Tracker_Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Installers
{
	public class DBInstaller : IInstaller
	{
		public void installServices(IServiceCollection services, IConfiguration Configuration)
		{
			services.AddScoped<FamilyTrackerDatabaseContext, FamilyTrackerDatabaseContext>();
			services.AddDbContext<FamilyTrackerDatabaseContext>(
			options => options.UseSqlServer("name=ConnectionStrings:FamilyTrackerDb"));
			services.AddScoped<UserRepository, UserRepository>();
			services.AddScoped<ParentRepository, ParentRepository>();
			services.AddScoped<ChildRepository, ChildRepository>();
			services.AddScoped<LocationRepository, LocationRepository>();
			services.AddScoped<NotificationRepository, NotificationRepository>();
			var appSettingsSection = Configuration.GetSection("FcmNotification");
			services.Configure<FcmNotificationOptions>(appSettingsSection);
			services.AddTransient<INotificationService, NotificationService>();
			services.AddHttpClient<FcmSender>();
			services.AddHttpClient<ApnSender>();
		}
	}
}
