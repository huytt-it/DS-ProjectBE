using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class LocationModel
    {
        public int LocationId { get; set; }
        public int BrandId { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string Description { get; set; }
    }

    public class LocationCreateModel
    {
        public int BrandId { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string Description { get; set; }
    }

    public class LocationUpdateModel:BrandCreateModel
    {

    }

    public class LocationViewModel
    {
        public int LocationId { get; set; }
        public int BrandId { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDatetime { get; set; }
        public string Description { get; set; }
    }

}
