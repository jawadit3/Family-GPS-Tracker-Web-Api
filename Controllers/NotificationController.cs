using CatalogWebApi.Models;
using Family_GPS_Tracker_Api;
using Family_GPS_Tracker_Api.Dtos;
using Family_GPS_Tracker_Api.Models;
using Family_GPS_Tracker_Api.Repositories;
using Family_GPS_Tracker_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
	[Route("notification")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly ParentRepository _parentRepository;
		private readonly ChildRepository _childRepository;

		public NotificationController(INotificationService notificationService,
			ParentRepository parentRepository,
			ChildRepository childRepository)
		{
			_notificationService = notificationService;
			_parentRepository = parentRepository;
			_childRepository = childRepository;
		}

		[Route("send")]
		[HttpPost]
		public async Task<IActionResult> SendNotification(CreateNotificationDto notificationModelDto)
		{
			var token = _parentRepository.GetDeviceToken(notificationModelDto.RecieverId);
			var parent = _parentRepository.Get(notificationModelDto.RecieverId);
			var child = _childRepository.Get(notificationModelDto.SenderId);
			if (token == null && child == null && parent == null)
			{
				NotFound();
			}
			var result = await _notificationService.SendNotification(new NotificationModel
			{
				DeviceId = token,
				Body = notificationModelDto.Body,
				IsAndroiodDevice = notificationModelDto.IsAndroiodDevice,
				Title = notificationModelDto.Title

			}, child, parent);
			return Ok(result);
		}


		[HttpGet]
		public ActionResult<ICollection<NotificationDto>> GetAll()
		{
			return _notificationService.GetNotifications().AsNotificationDtoList();
		}

	}
}
