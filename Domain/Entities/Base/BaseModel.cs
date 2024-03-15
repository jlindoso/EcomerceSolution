using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public abstract class BaseModel : Notifiable<Notification>
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = null;
        public bool Deleted { get; set; } = false;
    }
}
