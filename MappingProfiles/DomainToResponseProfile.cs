using AutoMapper;
using Family_GPS_Tracker_Api.Contracts.V1.ResponseDtos;
using Family_GPS_Tracker_Api.Domain;
using Family_GPS_Tracker_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.MappingProfiles
{
	public class DomainToResponseProfile : Profile
	{
		public DomainToResponseProfile()
		{

			CreateMap<Parent, ParentResponse>()
				.ForMember(des => des.Name,
				opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(des => des.Email,
				opt => opt.MapFrom(src => src.User.Email))
				.ForMember(des => des.PhoneNumber,
				opt => opt.MapFrom(src => src.User.PhoneNumber))
				.ForMember(des => des.Roles,
				opt => opt.MapFrom(src => src.User.UserRoles
				.Select(ur => ur.Role).ToList()
				.Select(r => r.Name).ToList()));

			CreateMap<Parent, ParentDetailDto>()
				.ForMember(des => des.Name,
				opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(des => des.Email,
				opt => opt.MapFrom(src => src.User.Email))
				.ForMember(des => des.PhoneNumber,
				opt => opt.MapFrom(src => src.User.PhoneNumber))
				.ForMember(des => des.Roles,
				opt => opt.MapFrom(src => src.User.UserRoles
				.Select(ur => ur.Role).ToList()
				.Select(r => r.Name).ToList()));

			CreateMap<Child, ChildResponse>()
				.ForMember(des => des.Name,
				opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(des => des.Email,
				opt => opt.MapFrom(src => src.User.Email))
				.ForMember(des => des.Roles,
				opt => opt.MapFrom(src => src.User.UserRoles
				.Select(ur => ur.Role).ToList()
				.Select(r => r.Name).ToList()));

			CreateMap<PairingCode, PairingCodeResponse>();
				
		}
	}
}
