using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class Brand
    {
        public Brand()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            Location = new HashSet<Location>();
            MediaSrc = new HashSet<MediaSrc>();
            Resolution = new HashSet<Resolution>();
            Scenario = new HashSet<Scenario>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string CreateDateTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string PublicKey { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<MediaSrc> MediaSrc { get; set; }
        public virtual ICollection<Resolution> Resolution { get; set; }
        public virtual ICollection<Scenario> Scenario { get; set; }
    }
}
