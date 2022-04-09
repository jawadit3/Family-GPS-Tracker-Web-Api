using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using Family_GPS_Tracker_Api.Contracts.V1.RequestDtos;
using Family_GPS_Tracker_Api.Contracts.V1.ResponseDtos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Family_GPS_Tracker_Api.Controllers
{
	[ApiController]
	[Route("parent")]
	public class ParentController : ControllerBase
	{
		private ParentRepository _repository;
		public ParentController(ParentRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("{id}")]
		public ActionResult<ParentDto> GetParent(Guid id)
		{
			Parent parent = _repository.Get(id);
			if (parent is null)
			{
				return NotFound();
			}
			return parent.AsParentDto();
		}

		[HttpGet("details/{id}")]
		public ActionResult<ParentDetailDto> GetParentDetails(Guid id)
		{
			Parent parent = _repository.GetDetails(id);
			if (parent is null)
			{
				return NotFound();
			}

			return parent.AsParentDetailDto();
		}

		[HttpPost("register")]
		public ActionResult<ParentDto> CreateParent(CreateParentDto dto)
		{

			Parent parent = new Parent()
			{
				ParentId = Guid.NewGuid(),
				Name = dto.Name,
				Email = dto.Email,
				Password = dto.Password,
				PhoneNumber = dto.PhoneNumber
			};

			_repository.CreateParent(parent);
			return CreatedAtAction(nameof(GetParent), new { id = parent.ParentId }, parent.AsParentDto());
		}

		[HttpPut("token/{id}")]
		public ActionResult<ParentDto> UpdateDeviceToken(Guid id, String deviceTokenDto)
		{
			var parent = _repository.Get(id);
			if (parent == null)
			{
				return NotFound();
			}
			return _repository.UpdateDeviceToken(parent, deviceTokenDto).AsParentDto();
		}
	}
}
