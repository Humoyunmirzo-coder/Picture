using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Users", Schema = "Picture_Sharing")]
    public class User : AuditableModelBase<long>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Surname  { get; set; }
        public Friend Friendid { get; set; }
        public List<Photo>? Photos { get; set; }



    }
}
