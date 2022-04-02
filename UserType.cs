using System;
using System.Collections.Generic;

#nullable disable

namespace Family_GPS_Tracker_Api
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public Guid UserTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
