/*
using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Family_GPS_Tracker_Api.Contracts.V1.RequestDtos;
using Family_GPS_Tracker_Api.Contracts.V1.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Controllers
{
	[ApiController]
	[Route("/child")]
	public class ChildController : ControllerBase
	{

		private ChildRepository _repository;
		public ChildController(ChildRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("{id}")]
		public ActionResult<ChildDto> Get(Guid id)
		{
			Child child = _repository.Get(id);
			if (child is null)
			{
				return NotFound();
			}
			return child.AsChildDto();
		}

		[HttpPost("register")]
		public ActionResult<ChildDto> CreateChild(CreateChildDto dto)
		{

			Child child = new Child()
			{
				ChildId = Guid.NewGuid(),
				Name = dto.Name,
				Email = dto.Email,
				Password = dto.Password
			};

			_repository.Create(child);
			return CreatedAtAction(nameof(Get), new { id = child.ChildId }, child.AsChildDto());
		}

		[HttpGet("details/{id}")]
		public ActionResult<ChildDetailDto> GetParentDetails(Guid id)
		{
			Child child = _repository.GetDetails(id);
			if (child is null)
			{
				return NotFound();
			}
			return child.AsChildDetailDto();
		}

		[HttpPost("LinkParent/{parentId}")]
		public ActionResult<ChildDetailDto> linkParent(Guid parentId, PairingCodeDto pairingCodeDto)
		{

			var child = _repository.GetDetails(pairingCodeDto.code);
			if (child == null) return NotFound();
			return _repository.LinkParent(parentId, child).AsChildDetailDto();

		}

		[HttpGet("code/{id}")]
		public ActionResult<PairingCodeDto> GetPairingCode(Guid id)
		{
			var child = _repository.GetDetails(id);
			if (child == null) return NotFound();
			return _repository.GeneratePairingCode(child).AsPairingCodeDto();
		}


	}
}

*/