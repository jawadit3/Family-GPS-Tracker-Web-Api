using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using static Family_GPS_Tracker_Api.Models.IdentityModels;

#nullable disable

namespace Family_GPS_Tracker_Api.Models
{
    public partial class Parent
    {
        public Parent()
        {
            Children = new HashSet<Child>();
            Notifications = new HashSet<Notification>();
            User = new ApplicationUser();
        }

        public Guid ParentId { get; set; }
        public Guid UserId { get; set; }
        public string DeviceToken { get; set; }
        public virtual ICollection<Child> Children { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ApplicationUser User { get; set; }
        

    }
}
