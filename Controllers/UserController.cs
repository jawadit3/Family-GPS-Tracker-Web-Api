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
	[Route("User")]
	public class UserController : ControllerBase
	{
		private UserRepository repository;

		public UserController(UserRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet("{email}")]
		public ActionResult<UserDto> GetUser(String email)
		{	
			User user = repository.GetUser(email);
			if (user == null) {
				return NotFound();
			}
			return Ok(user.AsUserDto());	
		}

		[HttpGet("{id}/userDetails")]
		public ActionResult<User> GetUserDetails(Guid id)
		{
			User user = repository.GetUserDetails(id);
			if (user == null)
			{
				return NotFound();
			}
			return Ok(user.AsUserDetailDto());
		}

		[HttpGet("{id}/parentDetails")]
		public ActionResult<ParentDto> GetParent(Guid id)
		{
			User user = repository.GetParentDetails(id);
			return Ok(user.AsParentDto());
		}

		[HttpPost("/createParent")]
		public ActionResult<ParentDto> CreateParent(CreateParentDto dto)
		{
			User user = new User()
			{
				UserId = Guid.NewGuid(),
				Name = dto.Name,
				Email = dto.Email,
				Password = dto.Password
			};
				Parent parent = new Parent()
			{
				ParentId = Guid.NewGuid(),
				PhoneNumber = dto.PhoneNumber
			};

			UserType userType = new UserType()
			{
				UserTypeId = Guid.NewGuid(),
				Name = "parent"
			};

			user.Parent = parent;
			user.UserType = userType;
			 repository.CreateParent(user);
			 return CreatedAtAction(nameof(GetParent), new { id = parent.ParentId }, user.AsParentDto());
		}
	}
}
