﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;


#nullable disable

namespace Family_GPS_Tracker_Api.Models
{
    public partial class Parent
    {
        public Parent()
        {
            Children = new HashSet<Child>();
            Notifications = new HashSet<Notification>();
            Users = new HashSet<User>();
        }

        public Guid ParentId { get; set; }
        public string PhoneNumber { get; set; }
        public string DeviceToken { get; set; }

      
        public virtual ICollection<Child> Children { get; set; }
        
        public virtual ICollection<Notification> Notifications { get; set; }
       
        public virtual ICollection<User> Users { get; set; }
    }
}
