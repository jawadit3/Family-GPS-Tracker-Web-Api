using System;
using System.Collections.Generic;

#nullable disable

namespace Family_GPS_Tracker_Api.Models
{
    public partial class Geofence
    {
        public Guid GeofenceId { get; set; }
        public string Category { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        public Guid ChildId { get; set; }

        public virtual Child Child { get; set; }
    }
}
