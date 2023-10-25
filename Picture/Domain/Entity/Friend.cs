using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace  Domain.Entity
{
    public class Friend : AuditableModelBase<long>
    {
        public long UserId { get; set; }
        public long FriendId { get; set; }
        [JsonIgnore]
        public User Owner { get; set; }

        [JsonIgnore] 
        public long Userid { get; set; }
        public FriendStatus Status { get; set; }
    }
}
