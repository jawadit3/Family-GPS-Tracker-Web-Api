using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace Family_GPS_Tracker_Api.Models
{
    public partial class Child
    {
        public Child()
        {
            Geofences = new HashSet<Geofence>();
            Locations = new HashSet<Location>();
            Notifications = new HashSet<Notification>();
            Users = new HashSet<User>();
        }

        public Guid ChildId { get; set; }
        public Guid? ParentId { get; set; }
        public string Code { get; set; }

        [JsonIgnore]
        public virtual Parent Parent { get; set; }
        public virtual ICollection<Geofence> Geofences { get; set; }
        public virtual ICollection<Location> Locations { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
