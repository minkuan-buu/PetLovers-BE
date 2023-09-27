using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblPostReport
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? CommentId { get; set; }
        public string Reason { get; set; } = null!;
        public Guid? ModeratorId { get; set; }
        public string Status { get; set; } = null!;
        public bool IsProcessed { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual TblPostCommentation? Comment { get; set; }
        public virtual TblPost? Post { get; set; }
        public virtual TblUser User { get; set; } = null!;
    }
}
