using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Photo : AuditableModelBase<Guid>
    {
        public string Name { get; set; }
        public long UserId { get; set; }
        [JsonIgnore] public User User { get; set; }

   
    }
}
