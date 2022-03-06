﻿using CatalogWebApi.Models;
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
		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		[Route("send")]
		[HttpPost]
		public async Task<IActionResult> SendNotification(NotificationModel notificationModel)
		{
			var result = await _notificationService.SendNotification(notificationModel);
			return Ok(result);
		}

	}
}
