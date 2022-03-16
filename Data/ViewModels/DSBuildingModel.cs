using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class DSBuildingModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }

    }

    public class DSBuildingCreateModel: DSBuildingModel
    {

    }
    public class DSBuildingUpdateModel : DSBuildingModel
    {
        public Guid Id { get; set; }

    }

    public class DSBuildingViewModel : DSBuildingModel
    {
        public Guid Id { get; set; }

    }


}
