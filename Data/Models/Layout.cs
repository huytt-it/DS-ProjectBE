using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class Layout
    {
        public Layout()
        {
            Area = new HashSet<Area>();
            Scenario = new HashSet<Scenario>();
        }

        public int LayoutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsHorizontal { get; set; }
        public string LayoutSrc { get; set; }
        public bool? IsPublic { get; set; }

        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<Scenario> Scenario { get; set; }
    }
}
