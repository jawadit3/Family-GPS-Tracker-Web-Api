using Family_GPS_Tracker_Api.Domain;
using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Family_GPS_Tracker_Api.Models.IdentityModels;

namespace Family_GPS_Tracker_Api.Repositories
{
	public class IdentityRepository : IIdentityRepository
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly JwtOptions _jwtOptions;



		public IdentityRepository(UserManager<ApplicationUser> userManager, JwtOptions jwtOptions)
		{
			_userManager = userManager;
			_jwtOptions = jwtOptions;
		}

		public async Task<AuthResult> LoginAsync(string email, string password)
		{
			var user = await _userManager.FindByEmailAsync(email);

			if (user == null) {
				return new AuthResult { 
					Errors = new [] { "User doesn't exist with this email." }
				};
			}

			var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

			if (!userHasValidPassword) {
				return new AuthResult
				{
					Errors = new[] { "User/Password combination is wrong." }
				};
			}

			return GenerateAuthenticationResult(user);
		}

		public async Task<AuthResult> RefreshTokenAsync(string token, string refreshToken)
		{
			await ;
		}

		// Method for Child Registration
		public async Task<AuthResult> RegisterChildAsync(ApplicationUser user, string password)
		{
			// Checking if user exists with this credentials

			var existingUser = await _userManager.FindByEmailAsync(user.Email);

			if (existingUser != null)
			{

				return new AuthResult
				{
					Errors = new[] { "User with this email address already exists." }
				};
			}

			// Registering the user and checking if registration went successfully

			var createdUser = await _userManager.CreateAsync(user, password);

			if (!createdUser.Succeeded)
			{

				return new AuthResult
				{
					Errors = createdUser.Errors.Select(x => x.Description)
				};
			}

			// Returning token on successful registration

			return GenerateAuthenticationResult(user);


		}

		// Method for Parent Registration
		public async Task<AuthResult> RegisterParentAsync(ApplicationUser user, string password)
		{
			// Checking if user exists with this credentials

			var existingUser = await _userManager.FindByEmailAsync(user.Email);

			if (existingUser != null) {

				return new AuthResult
				{
					Errors = new[] { "User with this email address already exists." }
				};
			}

			// Registering the user and checking if registration went successfully

			var createdUser = await _userManager.CreateAsync(user, password);

			if (!createdUser.Succeeded) {

				return new AuthResult
				{
					Errors = createdUser.Errors.Select(x => x.Description)
				};
			}

			// Returning token on successful registration

			return GenerateAuthenticationResult(user);

		}

		private AuthResult GenerateAuthenticationResult(ApplicationUser user)
		{

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] {
					new Claim(JwtRegisteredClaimNames.Sub, user.Email),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					new Claim(JwtRegisteredClaimNames.Email, user.Email),
					new Claim("userId", user.Id.ToString())
				}),
				Expires = DateTime.Now.Add(_jwtOptions.TokenLifetime),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return new AuthResult
			{
				IsSuccess = true,
				Token = tokenHandler.WriteToken(token)
			};
		}

	}
}