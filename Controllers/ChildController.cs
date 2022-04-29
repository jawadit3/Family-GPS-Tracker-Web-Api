﻿
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
	[Route("/child")]
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
			var existingPairingCode = await _childRepository.GetPairingCodeAsync(childId);

			if (existingPairingCode == null) {
				var newPairingCode = new PairingCode {
					ChildId = childId,
					Code = 
				};
				return NotFound(new { message = "Pairing code doesnt exist." });
			}


			
			return _mapper.Map<PairingCodeResponse>(pairingCode);
		}


	}
}

