using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistItem = new HashSet<PlaylistItem>();
            ScenarioItem = new HashSet<ScenarioItem>();
        }

        public int PlaylistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public bool? IsPublic { get; set; }
        public int? VisualTypeId { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<PlaylistItem> PlaylistItem { get; set; }
        public virtual ICollection<ScenarioItem> ScenarioItem { get; set; }
    }
}
