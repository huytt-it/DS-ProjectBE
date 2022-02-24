using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int DeviceId { get; set; }
        public int ScenarioId { get; set; }
        public int LayoutId { get; set; }
        public int TimeFilter { get; set; }
        public int DayFilter { get; set; }
        public int Priority { get; set; }
        public bool IsEnable { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual Device Device { get; set; }
        public virtual Scenario Scenario { get; set; }
    }
}
