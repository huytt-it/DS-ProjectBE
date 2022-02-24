using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class Location
    {
        public Location()
        {
            Device = new HashSet<Device>();
            PlaylistReport = new HashSet<PlaylistReport>();
        }

        public int LocationId { get; set; }
        public int BrandId { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<PlaylistReport> PlaylistReport { get; set; }
    }
}
