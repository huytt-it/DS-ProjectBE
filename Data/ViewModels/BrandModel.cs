using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class BrandModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string CreateDateTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string PublicKey { get; set; }
    }

    public class BrandCreateModel
    {
        public string BrandName { get; set; }
        public string CreateDateTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string PublicKey { get; set; }
    }

    public class BrandUpdateModel : BrandViewModel
    {

    }


    public class BrandViewModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string CreateDateTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string PublicKey { get; set; }
    }
}
