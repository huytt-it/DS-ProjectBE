using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class Area
    {
        public int AreaId { get; set; }
        public int LayoutId { get; set; }
        public int? VisualTypeId { get; set; }
        public decimal? Scale { get; set; }
        public decimal? WidthPercent { get; set; }
        public int? DisplayOrder { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public virtual Layout Layout { get; set; }
    }
}
