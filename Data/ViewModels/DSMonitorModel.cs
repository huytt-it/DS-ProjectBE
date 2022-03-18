using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class DSMonitorModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public int TotalSlot { get; set; }
        public int AvailableSlot { get; set; }
    }

    public class DSMonitorCreateModel: DSMonitorModel
    {
        public Guid BuildingId { get; set; }
    }

    public class DSMonitorUpdateModel : DSMonitorModel
    {
        public Guid Id { get; set; }

    }

    public class DSMonitorViewModel : DSMonitorModel
    {
        public Guid Id { get; set; }

    }

}
