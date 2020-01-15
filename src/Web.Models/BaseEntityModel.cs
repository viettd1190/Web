using System;
using Web.Framework.Models;

namespace Web.Models
{
    public class BaseEntityModel : BaseModel

    {
        public int Id { get; set; }

        public int UserCreated { get; set; }

        public DateTime DateCreated { get; set; }

        public int UserUpdated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
