using System;
using System.Collections.Generic;

#nullable disable

namespace Family_GPS_Tracker_Api.Models
{
    public partial class Location
    {
        public int LocationId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime Time { get; set; }
        public int ChildId { get; set; }

        public virtual Child Child { get; set; }
    }
}
