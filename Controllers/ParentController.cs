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
using AutoMapper;

namespace Family_GPS_Tracker_Api.Controllers
{

	[ApiController]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class ParentController : ControllerBase
	{
		private IParentRepository _parentRepository;
		private readonly IMapper _mapper;
		public ParentController(IParentRepository parentRepository, IMapper mapper)
		{
			_parentRepository = parentRepository;
			_mapper = mapper;
		}

		[HttpGet(ApiRoutes.Parent.Get)]
		public async Task<ActionResult<ParentResponse>> GetParentById([FromRoute] Guid parentId)
		{
			Parent parent = await _parentRepository.GetParentByIdAsync(parentId);
			if (parent is null)
			{
				return NotFound(new { message = "Parent doesn't exist with this userId" });
			}
			return Ok(_mapper.Map<ParentResponse>(parent));
		}

		[HttpGet(ApiRoutes.Parent.GetDetails)]
		public async Task<ActionResult<ParentDetailResponse>> GetParentDetailsById([FromRoute] Guid parentId)
		{
			Parent parent = await _parentRepository.GetParentDetailsByIdAsync(parentId);
			if (parent is null)
			{
				return NotFound(new { message = "Parent doesn't exist with this userId" });
			}

			return Ok(_mapper.Map<ParentDetailResponse>(parent));
		}



		[HttpPut(ApiRoutes.Parent.UpdateToken)]
		public async Task<ActionResult<DeviceTokenResponse>> UpdateDeviceToken([FromRoute] Guid userId, [FromBody] UpdateDeviceTokenRequest updateDeviceTokenRequest)
		{
			var parent = await _parentRepository.GetParentByIdAsync(userId);
			if (parent == null)
			{
				return NotFound(new { message = "Parent doesn't exist with this userId" });
			}

			if (!userId.ToString().Equals(HttpContext.GetUserId()))
			{

				return BadRequest(new { message = "You cannot perform this operation" });
			}

			var deviceToken = new DeviceToken
			{
				Token = updateDeviceTokenRequest.Token
			};
			var isDeviceTokenUpdated = await _parentRepository.UpdateDeviceTokenAsync(parent, deviceToken);

			if (!isDeviceTokenUpdated)
			{
				return BadRequest(new { message = "Token couldn't be updated" });
			}

			return Ok(deviceToken.AsDeviceTokenResponse());
		}
	}
}
