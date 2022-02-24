using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class PlaylistReport
    {
        public int PlaylistId { get; set; }
        public string PlaylistTitle { get; set; }
        public string PlaylistDesc { get; set; }
        public int PlayedTimeCount { get; set; }
        public int LocationId { get; set; }
        public int BrandId { get; set; }
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; }
        public virtual Location Location { get; set; }
    }
}
