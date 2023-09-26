using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblPostlPending
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid ModeratorId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual TblUser Moderator { get; set; } = null!;
        public virtual TblPostCommentation Post { get; set; } = null!;
    }
}
