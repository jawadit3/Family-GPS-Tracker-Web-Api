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
        }

        public int ChildId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ParentId { get; set; }

        public virtual Parent Parent { get; set; }
        public virtual ICollection<Geofence> Geofences { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
