using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class MediaSrc
    {
        public MediaSrc()
        {
            PlaylistItem = new HashSet<PlaylistItem>();
        }

        public int MediaSrcId { get; set; }
        public int BrandId { get; set; }
        public string Title { get; set; }
        public bool? IsPublic { get; set; }
        public int TypeId { get; set; }
        public string Url { get; set; }
        public DateTime? UpdateDatetime { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string SecurityHash { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual MediaType Type { get; set; }
        public virtual ICollection<PlaylistItem> PlaylistItem { get; set; }
    }
}
