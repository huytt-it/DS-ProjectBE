using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Data.Entities;

namespace Data.Models
{
    public class DSMonitor:BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public int TotalSlot { get; set; }
        public int AvailableSlot { get; set; }

        public Guid BuildingId { get; set; }
        [ForeignKey("BuildingId")]
        public DSBuilding DSBuilding { get; set; }


    }
}
