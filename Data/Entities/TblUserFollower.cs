using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblUserFollower
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FollowingId { get; set; }
        public string Status { get; set; } = null!;

        public virtual TblUser Following { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
    }
}
