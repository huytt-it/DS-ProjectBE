using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class DeviceScenario
    {
        public int DeviceScenationId { get; set; }
        public int DeviceId { get; set; }
        public int ScenarioId { get; set; }
        public int? TimesToPlay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int LayoutId { get; set; }

        public virtual Device Device { get; set; }
        public virtual Scenario Scenario { get; set; }
    }
}
