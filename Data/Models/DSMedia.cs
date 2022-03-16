using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Data.Entities;

namespace Data.Models
{
    public class DSMedia:BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }


        public Guid MonitorId { get; set; }
        [ForeignKey("MonitorId")]
        public DSMonitor Monitor { get; set; }
    }
}
