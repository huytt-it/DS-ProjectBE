using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class PlaylistItem
    {
        public int PlaylistItemId { get; set; }
        public int MediaSrcId { get; set; }
        public int PlaylistId { get; set; }
        public int DisplayOrder { get; set; }
        public int Duration { get; set; }
        public bool IsDelete { get; set; }
        public virtual MediaSrc MediaSrc { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}
