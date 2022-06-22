using Family_GPS_Tracker_Api.Dtos;
using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Controllers
{
	[ApiController]
	[Route("geofences")]
	public class GeofenceController : ControllerBase
	{

		private readonly GeofenceRepository _geofenceRepository;
		private readonly ChildRepository _repository;

		public GeofenceController(GeofenceRepository geofenceRepository, ChildRepository repository)
		{
			_geofenceRepository = geofenceRepository;
			_repository = repository;
		}

		[HttpGet("{id}")]
		public GeofenceDto GetGeofenceById([FromRoute] Guid id)
		{
			return new GeofenceDto();
		}

		[HttpPost("{childId}")]
		public ActionResult<GeofenceDto> CreateGeofence([FromRoute] Guid childId, [FromBody] CreateGeofenceDto createGeofenceDto)
		{
			var child = _repository.Get(childId);
			if (child is null)
			{
				return NotFound();
			}

			var newGeofence = new Geofence
			{

				GeofenceId = Guid.NewGuid(),
				Category = createGeofenceDto.Category,
				Radius = createGeofenceDto.Radius,
				Latitude = createGeofenceDto.Latitude,
				Longitude = createGeofenceDto.Longitude,
				Child = child

			};
			var geofence = _geofenceRepository.CreateGeofence(newGeofence);
			return geofence.AsGeofenceDto();
		}

		[HttpGet("list/{childId}")]
		public ActionResult<IEnumerable<GeofenceDto>> GetGeofenceByChildId([FromRoute] Guid childId)
		{

			var child = _repository.Get(childId);
			if (child is null)
			{
				return NotFound();
			}

			var geofenceList = _geofenceRepository.GetGeofencesByChildId(childId);
			return Ok(geofenceList.AsGeofenceDtoList());

		}

	}
}
