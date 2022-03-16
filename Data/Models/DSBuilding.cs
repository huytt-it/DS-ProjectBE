using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Data.Entities;

namespace Data.Models
{
    public class DSBuilding:BaseEntity
    {

        public string Name { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public DSUser DSUser { get; set; }
        public virtual ICollection<DSMonitor> Monitors { get; set; }
    }
}
