using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogWebApi.Models
{
        public class NotificationModel
        {
            [JsonProperty("senderId")]
            public Guid SenderId { get; set; }
            [JsonProperty("RecieverId")]
            public Guid RecieverId { get; set; }
            [JsonProperty("deviceToken")]
            public string DeviceToken { get; set; }
            [JsonProperty("isAndroiodDevice")]
            public bool IsAndroiodDevice { get; set; }
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("body")]
            public string Body { get; set; }
        }
    }

