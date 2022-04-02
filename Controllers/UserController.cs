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
	[Route("User")]
	public class UserController : ControllerBase
	{
		private UserRepository _repository;

		public UserController(UserRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("{email}")]
		public ActionResult<UserDto> GetUser(String email)
		{

			User user = _repository.GetUser(email);
			if (user == null)
			{
				return NotFound();
			}
			return Ok(user.AsUserDto());

		}
	}
}
