using Family_GPS_Tracker_Api.Dtos;
using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api
{
	public static class Extentions
	{
		public static ParentDto AsParentDto(this User user)
		{
			return new ParentDto()
			{
				ParentId = user.Parent.ParentId,
				Name = user.Name,
				Email = user.Email,
				Password = user.Password,
				PhoneNumber = user.Parent.PhoneNumber,
				UserType = user.UserType.Name
			};
		}

		public static UserDto AsUserDto(this User user)
		{
			return new UserDto
			{
				UserId = user.UserId,
				Name = user.Name,
				Email = user.Email,
				Password = user.Password,
				UserType = user.UserType.Name
			};
		}

		public static UserDetailDto AsUserDetailDto(this User user)
		{
			return new UserDetailDto
			{
				UserId = user.UserId,
				Name = user.Name,
				Email = user.Email,
				Password = user.Password,
				UserType = user.UserType.Name,
				Parent = user.Parent,
				Child = user.Child
			};
		}
	}
}
