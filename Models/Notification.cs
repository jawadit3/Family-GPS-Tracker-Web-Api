using System;
using System.Collections.Generic;

#nullable disable

namespace Family_GPS_Tracker_Api.Models
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ChildId { get; set; }
        public int ParentId { get; set; }

        public virtual Child Child { get; set; }
        public virtual Parent Parent { get; set; }
    }
}
