using CatalogWebApi.Models;
using Family_GPS_Tracker_Api.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static CatalogWebApi.Models.GoogleNotification;

namespace Family_GPS_Tracker_Api.Services
{
	public class MyNotificationService : INotificationService
	{
		public readonly IHttpClientFactory _httpClientFactory;

		public MyNotificationService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<ResponseModel> SendNotificationAsync(NotificationModel notificationModel)
		{
			var jsonData = MakePayload(notificationModel);
			var httpClient = _httpClientFactory.CreateClient("FCM");
			var response = await httpClient.PostAsync("/fcm/send", new StringContent(jsonData, Encoding.UTF8, "application/json"));
			if (response.IsSuccessStatusCode)
			{
				

				return new ResponseModel
				{
					Message = "Notification sent!",
					StatusCode = response.StatusCode.ToString()
				};

			}

			return new ResponseModel
			{
				Message = "something went wrong!",
				StatusCode = response.StatusCode.ToString()
			};




		}
		private string MakePayload(NotificationModel notificationModel)
		{
			DataPayload dataPayload = new DataPayload();
			dataPayload.Title = notificationModel.Title;
			dataPayload.Body = notificationModel.Body;

			GoogleNotification notification = new GoogleNotification();
			notification.Data = dataPayload;
			notification.Notification = dataPayload;
			notification.DeviceToken = "2109309013";

			return JsonConvert.SerializeObject(notification,
				new JsonSerializerSettings
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				});
		}
	}
}
