using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Data.Models
{
    public class DSUser:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BirthDay { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<DSBuilding> DSBuilding { get; set; }
    }
}
