using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public  class BaseEntity
    {
        public long Id { get; set; }
        public  DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
