using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Photo : AuditableModelBase<Guid>
    {
        public string Name { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }

   
    }
}
