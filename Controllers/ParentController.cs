/*using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using Family_GPS_Tracker_Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Family_GPS_Tracker_Api.Controllers
{
	[Route("/parent")]
	public class ParentController : ControllerBase
	{
		private ParentRepository _repository;
		public ParentController(ParentRepository repository) {
			_repository = repository;
		}

		[HttpGet]
		public ActionResult<ParentDto> GetParent(Guid id) {
			Parent parent = _repository.GetEntity(id);
			if (parent is null)
			{
				return NotFound();
			}
			return parent.AsParentDto();
		}
		[HttpPost("/register")]
		public ActionResult<ParentDto> SignUp(ParentDto dto) {
			var parent = new Parent
			{
				ParentId = dto.ParentId,
				Name = dto.Name,
				Email = dto.Email,
				Password = dto.Password,
				PhoneNumber = dto.PhoneNumber
			};
			_repository.CreateEntity(parent);
			return CreatedAtAction(nameof(GetParent), new { id = parent.ParentId }, parent.AsParentDto());
		}
	}
}
*/