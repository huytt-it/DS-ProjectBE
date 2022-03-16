using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class DSMediaModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }

    }

    public class DSMediaCreateModel: DSMediaModel
    {
        public Guid MonitorId { get; set; }
    }

    public class DSMediaUpdateModel : DSMediaModel
    {
        public Guid Id { get; set; }
    }

    public class DSMediaViewModel : DSMediaModel
    {
        public Guid Id { get; set; }
        public Guid MonitorId { get; set; }
    }

}
