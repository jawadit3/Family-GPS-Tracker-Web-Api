using System;
using System.Collections.Generic;

#nullable disable

namespace Family_GPS_Tracker_Api.Models
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public Guid UserTypeId { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? ChildId { get; set; }

        public virtual Child Child { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
