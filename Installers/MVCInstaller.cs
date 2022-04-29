using Family_GPS_Tracker_Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Installers
{
	public class MvcInstaller : IInstaller
	{
		public void installServices(IServiceCollection services, IConfiguration Configuration)
		{


			services.AddControllers();

			var jwtOptions = new JwtOptions();
			Configuration.Bind(nameof(jwtOptions), jwtOptions);
			services.AddSingleton(jwtOptions);

			var tokenValidationParameter = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),
				ValidateIssuer = false,
				ValidateAudience = false,
				RequireExpirationTime = true,
				ValidateLifetime = false,
				ClockSkew = TimeSpan.Zero
			};

			services.AddSingleton(tokenValidationParameter);
			services.AddAuthentication(x => {
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(x => {
					x.SaveToken = true;
					x.TokenValidationParameters = tokenValidationParameter;
				});
			

			
			services.AddControllersWithViews()
				.AddNewtonsoftJson(options =>
			options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			);
		}
	}
}
