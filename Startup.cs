using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using CatalogWebApi.Models;
using CorePush.Apple;
using CorePush.Google;
using Family_GPS_Tracker_Api.Repositories;
using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Family_GPS_Tracker_Api.Services.NotificationService;

namespace Family_GPS_Tracker_Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Family_GPS_Tracker_Api", Version = "v1" });
			});
			services.AddControllersWithViews()
				.AddNewtonsoftJson(options =>
			options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			);
			services.AddScoped<FamilyTrackerDatabaseContext, FamilyTrackerDatabaseContext>();
			services.AddDbContext<FamilyTrackerDatabaseContext>(
			options => options.UseSqlServer("name=ConnectionStrings:FamilyTrackerDb"));
			services.AddScoped<UserRepository, UserRepository>();
			services.AddScoped<ParentRepository, ParentRepository>();
			services.AddScoped<ChildRepository, ChildRepository>();
			services.AddScoped<LocationRepository, LocationRepository>();
			services.AddScoped<GeofenceRepository, GeofenceRepository>();
			services.AddScoped<NotificationRepository, NotificationRepository>();
			var appSettingsSection = Configuration.GetSection("FcmNotification");
			services.Configure<FcmNotificationSetting>(appSettingsSection);
			services.AddTransient<INotificationService, NotificationService>();
			services.AddHttpClient<FcmSender>();
			services.AddHttpClient<ApnSender>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Family_GPS_Tracker_Api v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
