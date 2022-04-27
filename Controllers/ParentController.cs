using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using Family_GPS_Tracker_Api.Contracts.V1.RequestDtos;
using Family_GPS_Tracker_Api.Contracts.V1.ResponseDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Family_GPS_Tracker_Api.Contracts;
using System.Threading.Tasks;
using Family_GPS_Tracker_Api.Domain;
using Family_GPS_Tracker_Api.Contracts.V1.DTOs.Responses;

namespace Family_GPS_Tracker_Api.Controllers
{

	[ApiController]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class ParentController : ControllerBase
	{
		private IParentRepository _parentRepository;
		public ParentController(IParentRepository parentRepository)
		{
			_parentRepository = parentRepository;
		}

		[HttpGet(ApiRoutes.Parent.Get)]
		public async Task<ActionResult<ParentDto>> GetParentById([FromRoute] Guid userId)
		{
			Parent parent = await _parentRepository.GetParentByIdAsync(userId);
			if (parent is null)
			{
				return NotFound(new { message = "Parent doesn't exist with this userId" });
			}
			return parent.AsParentDto();
		}

		[HttpGet(ApiRoutes.Parent.GetDetails)]
		public async Task<ActionResult<ParentDetailDto>> GetParentDetailsById([FromRoute] Guid userId)
		{
			Parent parent = await _parentRepository.GetParentDetailsByIdAsync(userId);
			if (parent is null)
			{
				return NotFound(new { message = "Parent doesn't exist with this userId" });
			}

			return parent.AsParentDetailDto();
		}

		

		[HttpPut(ApiRoutes.Parent.UpdateToken)]
		public async Task<ActionResult<DeviceTokenResponse>> UpdateDeviceToken([FromRoute] Guid userId, [FromBody] UpdateDeviceTokenRequest updateDeviceTokenRequest)
		{
			var parent = await _parentRepository.GetParentByIdAsync(userId);
			if (parent == null)
			{
				return NotFound(new { message = "Parent doesn't exist with this userId"});
			}

			if (!userId.ToString().Equals(HttpContext.GetUserId())) {

				return BadRequest(new { message = "You cannot perform this operation" });
			}

			var deviceToken = new DeviceToken
			{
				Token = updateDeviceTokenRequest.Token
			};
			var isDeviceTokenUpdated  = await _parentRepository.UpdateDeviceTokenAsync(parent, deviceToken);

			if (!isDeviceTokenUpdated) {
				return BadRequest(new { message = "Token couldn't be updated" });
			}

			return Ok(deviceToken.AsDeviceTokenResponse());
		}
	}
}
