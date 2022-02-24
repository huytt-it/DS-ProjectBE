using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class ScenarioItem
    {
        public int PlaylistId { get; set; }
        public int ScenarioId { get; set; }
        public int AreaId { get; set; }
        public int LayoutId { get; set; }
        public int DisplayOrder { get; set; }
        public string Note { get; set; }
        public bool IsDelete { get; set; }
        public virtual Playlist Playlist { get; set; }
        public virtual Scenario Scenario { get; set; }
    }
}
