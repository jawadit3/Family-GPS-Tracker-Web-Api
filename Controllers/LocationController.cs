/*using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using Family_GPS_Tracker_Api.Contracts.V1.RequestDtos;
using Family_GPS_Tracker_Api.Contracts.V1.ResponseDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Controllers
{
	[Route("location")]
	[ApiController]
	public class LocationController : ControllerBase
	{
		private readonly LocationRepository _locationRepository;
		private readonly ChildRepository _childRepository;

		public LocationController(LocationRepository locationRepository,
			ChildRepository childRepository)
		{
			_locationRepository = locationRepository;
			_childRepository = childRepository;
		}


		[HttpPost("{childId}")]
		public ActionResult<LocationDto> CreateLocation(Guid childId, CreateLocationDto createLocationDto)
		{

			var child = _childRepository.Get(childId);

			if (child == null)
			{
				return NotFound();
			}

			var location = _locationRepository.Create(childId, new Location
			{
				LocationId = Guid.NewGuid(),
				Latitude = createLocationDto.Latitude,
				Longitude = createLocationDto.Longitude,
				Time = DateTime.Now.ToString("yyyy-MM-dd hh:mm"),
				ChildId = childId
			});

			return CreatedAtAction(nameof(GetLocation), new { childId = child.ChildId }, location.AsLocationDto());
		}

		[HttpGet("{childId}")]
		public ActionResult<LocationDto> GetLocation(Guid childId)
		{
			var location = _locationRepository.Get(childId);

			if (location == null)
			{
				return NotFound();
			}
			return Ok(location.AsLocationDto());
		}

		[HttpGet("lastLocation/{childId}")]
		public ActionResult<LocationDto> GetLastLocation(Guid childId)
		{
			var lastLocation = _locationRepository.GetLast(childId);
			if (lastLocation == null)
			{
				return NotFound();
			}

			return Ok(lastLocation.AsLocationDto());
		}

		[HttpGet("lastTenLocations/{childId}")]
		public ActionResult<IEnumerable<LocationDto>> GetLastTenLocation(Guid childId)
		{
			
			var lastTenLocations = _locationRepository.GetLastTen(childId);
			if (lastTenLocations == null) {
				return NotFound();
			}
			return Ok(lastTenLocations.AsLocationDtoList());
		}
	}
}
*/