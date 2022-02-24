using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class Resolution
    {
        public int ResolutionId { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Note { get; set; }
        public int BrandId { get; set; }
        public bool IsDelete { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
