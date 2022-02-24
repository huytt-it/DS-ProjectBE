using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Data.Models
{
    public partial class Scenario
    {
        public Scenario()
        {
            DeviceScenario = new HashSet<DeviceScenario>();
            ScenarioItem = new HashSet<ScenarioItem>();
            Schedule = new HashSet<Schedule>();
        }

        public int ScenarioId { get; set; }
        public int LayoutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public bool? IsPublic { get; set; }
        public int AudioArea { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public bool IsDelete { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Layout Layout { get; set; }
        public virtual ICollection<DeviceScenario> DeviceScenario { get; set; }
        public virtual ICollection<ScenarioItem> ScenarioItem { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
