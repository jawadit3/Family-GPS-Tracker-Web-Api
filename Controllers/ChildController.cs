
using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Family_GPS_Tracker_Api.Contracts.V1.RequestDtos;
using Family_GPS_Tracker_Api.Contracts.V1.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Family_GPS_Tracker_Api.Contracts;
using AutoMapper;
using Family_GPS_Tracker_Api.Domain;

namespace Family_GPS_Tracker_Api.Controllers
{
	[ApiController]
	public class ChildController : ControllerBase
	{

		private IChildRepository _childRepository;
		private IMapper _mapper;
		public ChildController(IChildRepository childRepository, IMapper mapper)
		{
			_childRepository = childRepository;
			_mapper = mapper;
		}
		
				[HttpGet(ApiRoutes.Child.Get)]
				public async Task<ActionResult<ChildResponse>> GetChildByIdAsync([FromRoute] Guid childId)
				{
					Child child = await _childRepository.GetChildByIdAsync(childId);
					if (child is null)
					{
						return NotFound();
					}
					return _mapper.Map<ChildResponse>(child);
				}
		/*
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
				public ActionResult<ChildDetailDto> linkParent(Guid parentId, PairingCodeResponse pairingCodeDto)
				{

					var child = _repository.GetDetails(pairingCodeDto.code);
					if (child == null) return NotFound();
					return _repository.LinkParent(parentId, child).AsChildDetailDto();

				}
		*/
		[HttpGet(ApiRoutes.Child.GetPairingCode)]
		public async Task<ActionResult<PairingCodeResponse>> GetPairingCodeAsync([FromRoute] Guid childId)
		{
			var existingPairingCode = await _childRepository.GetPairingCodeAsyncByChildId(childId);

			if (existingPairingCode == null)
			{
				var newPairingCode = new PairingCode
				{
					ChildId = childId,
					Code = new Random().Next(10000, 99999).ToString(),
					CreationDate = DateTime.UtcNow,
					ExpiryDate = DateTime.UtcNow.AddHours(2)
				};

				var isCreated = await _childRepository.CreatePairingCodeAsync(newPairingCode);

				if (isCreated) {
					return Ok(_mapper.Map<PairingCodeResponse>(newPairingCode));
				}
			}

			else if (existingPairingCode != null)
			{
				var updatedPairingCode = existingPairingCode;
				updatedPairingCode.Code = new Random().Next(10000, 99999).ToString();
				updatedPairingCode.CreationDate = DateTime.UtcNow;
				updatedPairingCode.ExpiryDate = DateTime.UtcNow.AddHours(2);
				updatedPairingCode.IsUsed = false;

				var isUpdated = await _childRepository.UpdatePairingCodeAsync(updatedPairingCode);

				if (isUpdated)
				{
					return Ok(_mapper.Map<PairingCodeResponse>(updatedPairingCode));
				}
			}

			return NotFound(new { message = "Pairing code couldn't be generated." });

		}
	}
}

