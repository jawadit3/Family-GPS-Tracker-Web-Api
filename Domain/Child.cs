using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using static Family_GPS_Tracker_Api.Models.IdentityModels;

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
            User = new ApplicationUser();
        }

        public Guid ChildId { get; set; }
        public Guid? ParentId { get; set; }
        public Guid UserId { get; set; }
        public string PairingCode { get; set; }

        public virtual Parent Parent { get; set; }
        public virtual ICollection<Geofence> Geofences { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
