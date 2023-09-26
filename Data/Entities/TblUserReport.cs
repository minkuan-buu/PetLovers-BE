using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblUserReport
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TargetUserId { get; set; }
        public string Reason { get; set; } = null!;
        public Guid? ModeratorId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual TblUser TargetUser { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
    }
}
