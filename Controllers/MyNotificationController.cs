using CatalogWebApi.Models;
using Family_GPS_Tracker_Api.Contracts;
using Family_GPS_Tracker_Api.Contracts.V1.RequestDtos;
using Family_GPS_Tracker_Api.Repositories;
using Family_GPS_Tracker_Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Controllers
{
	[ApiController]
	public class MyNotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IParentRepository _parentRepository;

		public MyNotificationController(INotificationService notificationService,
			IParentRepository parentRepository)
		{
			_notificationService = notificationService;
			_parentRepository = parentRepository;
		}

		[HttpPost(ApiRoutes.Notification.SendNotification)]
		public async Task<IActionResult> SendNotificationAsync(NotificationRequest notificationRequest)
		{
			var token = await _parentRepository.GetDeviceTokenAsync(notificationRequest.RecieverId);
			if (token == null)
			{
				NotFound();
			}

			var responseModel = await _notificationService.SendNotificationAsync(new NotificationModel
			{
				Title = notificationRequest.Title,
				Body = notificationRequest.Body,
				DeviceToken = token,
				IsAndroiodDevice = notificationRequest.IsAndroiodDevice,
				SenderId = notificationRequest.SenderId,
				RecieverId = notificationRequest.RecieverId
			});

			return Ok(responseModel);
		}

	}
}
