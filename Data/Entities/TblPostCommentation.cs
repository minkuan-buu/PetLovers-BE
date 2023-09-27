using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblPostCommentation
    {
        public TblPostCommentation()
        {
            TblPostReports = new HashSet<TblPostReport>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; } = null!;
        public string Attachment { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual TblPost Post { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblPostReport> TblPostReports { get; set; }
    }
}
