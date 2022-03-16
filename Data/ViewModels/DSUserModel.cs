using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class DSUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BirthDay { get; set; }
        public string Avatar { get; set; }
    }
    public class DSUserCreateModel : DSUserModel
    {

    }

    public class DSUserUpdateModel : DSUserModel
    {
        public Guid Id { get; set; }
    }

    public class DSUserViewModel : DSUserModel
    {
        public Guid Id { get; set; }
    }
}
