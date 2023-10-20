using Domain.Enum;

namespace Domain.Entity
{
    public class Friend : AuditableModelBase<long>
    {
        public long UserId { get; set; }
        public long FriendId { get; set; }
        public User Owner { get; set; }
        public User Friends { get; set; }
        public FriendStatus Status { get; set; }

    }
}
