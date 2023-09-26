using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblPost
    {
        public TblPost()
        {
            TblNotifications = new HashSet<TblNotification>();
            TblPostCommentations = new HashSet<TblPostCommentation>();
            TblPostReactionions = new HashSet<TblPostReactionion>();
            TblPostReports = new HashSet<TblPostReport>();
            TblPostStoreds = new HashSet<TblPostStored>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string Content { get; set; } = null!;
        public string Attachment { get; set; } = null!;
        public string Hashtag { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblNotification> TblNotifications { get; set; }
        public virtual ICollection<TblPostCommentation> TblPostCommentations { get; set; }
        public virtual ICollection<TblPostReactionion> TblPostReactionions { get; set; }
        public virtual ICollection<TblPostReport> TblPostReports { get; set; }
        public virtual ICollection<TblPostStored> TblPostStoreds { get; set; }
    }
}
