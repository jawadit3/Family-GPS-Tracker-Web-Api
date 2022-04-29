using Family_GPS_Tracker_Api.Contracts;
using Family_GPS_Tracker_Api.Contracts.V1.DTOs.Requests;
using Family_GPS_Tracker_Api.Contracts.V1.RequestDtos;
using Family_GPS_Tracker_Api.Contracts.V1.Requests;
using Family_GPS_Tracker_Api.Contracts.V1.Responses;
using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Family_GPS_Tracker_Api.Models.IdentityModels;

namespace Family_GPS_Tracker_Api.Controllers
{
	[ApiController]
	public class IdentityController : ControllerBase
	{

		private readonly IIdentityRepository _identityRepository;
		private readonly IParentRepository _parentRepository;
		public IdentityController(IIdentityRepository identityRepository, IParentRepository parentRepository)
		{
			_identityRepository = identityRepository;
			_parentRepository = parentRepository;
		}

		// Handling Registration Request

		[HttpPost(ApiRoutes.Identity.RegisterParent)]
		public async Task<IActionResult> RegisterParent([FromBody] CreateParentDto createParentDto) {

			// Creating new Identity user

			var applicationUser = new ApplicationUser
			{
				UserName = createParentDto.Name,
				Email = createParentDto.Email,
				PhoneNumber = createParentDto.PhoneNumber
			};

			// Invoking RegisterParentAsync for registering parent

			var authResponse = await _identityRepository.RegisterParentAsync(
				applicationUser, createParentDto.Password);

			// Checking whether the action was successful

			if (!authResponse.IsSuccess) {
				return BadRequest(new AuthFailedResponse {
					Errors = authResponse.Errors
				});
			}

			
			// Returning Token on successfull registration

			return Ok(new AuthSuccessResponse { 
				Token = authResponse.Token,
				RefreshToken = authResponse.RefreshToken
			});
		}


		[HttpPost(ApiRoutes.Identity.RegisterChild)]
		public async Task<IActionResult> RegisterChild([FromBody] CreateChildDto createChildDto)
		{

			// Invoking RegisterParentAsync for registering parent

			var authResponse = await _identityRepository.RegisterChildAsync(
				new ApplicationUser
				{
					UserName = createChildDto.Name,
					Email = createChildDto.Email
				}, createChildDto.Password);

			// Checking whether the action was successful

			if (!authResponse.IsSuccess)
			{
				return BadRequest(new AuthFailedResponse
				{
					Errors = authResponse.Errors
				});
			}

			// Returning Token on successfull registration

			return Ok(new AuthSuccessResponse
			{
				Token = authResponse.Token,
				RefreshToken = authResponse.RefreshToken
			});
		}

		// Handling Login Request

		[HttpPost(ApiRoutes.Identity.Login)]
		public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
		{
			// Checking if user exists


			// Invoking LoginAsync for signing in the user

			var authResponse = await _identityRepository.LoginAsync(
				loginRequest.Email,
				loginRequest.Password);	

			// Checking whether the action was successful

			if (!authResponse.IsSuccess)
			{
				return BadRequest(new AuthFailedResponse
				{
					Errors = authResponse.Errors
				});
			}

			// Returning Token on successfull registration

			return Ok(new AuthSuccessResponse
			{
				Token = authResponse.Token,
				RefreshToken = authResponse.RefreshToken
			});
		}

		// Handling Refresh Token Request

		[HttpPost(ApiRoutes.Identity.RefreshToken)]
		public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
		{
			// Checking if user exists


			// Invoking LoginAsync for signing in the user

			var authResponse = await _identityRepository.RefreshTokenAsync(
				refreshTokenRequest.Token,
				refreshTokenRequest.RefreshToken);

			// Checking whether the action was successful

			if (!authResponse.IsSuccess)
			{
				return BadRequest(new AuthFailedResponse
				{
					Errors = authResponse.Errors
				});
			}

			// Returning Token on successfull registration

			return Ok(new AuthSuccessResponse
			{
				Token = authResponse.Token,
				RefreshToken = authResponse.RefreshToken
			});
		}

	}
}
