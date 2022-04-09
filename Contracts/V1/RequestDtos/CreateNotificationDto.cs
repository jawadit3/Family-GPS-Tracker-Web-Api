﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Contracts.V1.RequestDtos
{
	public class CreateNotificationDto
	{

        [JsonProperty("senderId")]
        public Guid SenderId { get; set; }
        [JsonProperty("RecieverId")]
        public Guid RecieverId { get; set; }
        [JsonProperty("isAndroiodDevice")]
        public bool IsAndroiodDevice { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
