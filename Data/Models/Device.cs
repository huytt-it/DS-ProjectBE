using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class Device
    {
        public Device()
        {
            DeviceScenario = new HashSet<DeviceScenario>();
            PlaylistReport = new HashSet<PlaylistReport>();
            Schedule = new HashSet<Schedule>();
        }

        public int DeviceId { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int? BrandId { get; set; }
        public string MatchingCode { get; set; }
        public int? LocationId { get; set; }
        public string BoxName { get; set; }
        public string ScreenName { get; set; }
        public bool? IsHorizontal { get; set; }
        public bool IsDelete { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<DeviceScenario> DeviceScenario { get; set; }
        public virtual ICollection<PlaylistReport> PlaylistReport { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
