using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class MediaType
    {
        public MediaType()
        {
            MediaSrc = new HashSet<MediaSrc>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MediaSrc> MediaSrc { get; set; }
    }
}
