using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblNotifications = new HashSet<TblNotification>();
            TblPostCommentations = new HashSet<TblPostCommentation>();
            TblPostReactionions = new HashSet<TblPostReactionion>();
            TblPostReports = new HashSet<TblPostReport>();
            TblPostStoreds = new HashSet<TblPostStored>();
            TblPostTrades = new HashSet<TblPostTrade>();
            TblPostlPendings = new HashSet<TblPostlPending>();
            TblPosts = new HashSet<TblPost>();
            TblTradeRequestInfos = new HashSet<TblTradeRequestInfo>();
            TblTradeUserInfos = new HashSet<TblTradeUserInfo>();
            TblUserFollowerFollowings = new HashSet<TblUserFollower>();
            TblUserFollowerUsers = new HashSet<TblUserFollower>();
            TblUserReportTargetUsers = new HashSet<TblUserReport>();
            TblUserReportUsers = new HashSet<TblUserReport>();
            TblUserRewards = new HashSet<TblUserReward>();
            TblUserTimeoutModerators = new HashSet<TblUserTimeout>();
            TblUserTimeoutUsers = new HashSet<TblUserTimeout>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public Guid RoleId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual TblRole Role { get; set; } = null!;
        public virtual ICollection<TblNotification> TblNotifications { get; set; }
        public virtual ICollection<TblPostCommentation> TblPostCommentations { get; set; }
        public virtual ICollection<TblPostReactionion> TblPostReactionions { get; set; }
        public virtual ICollection<TblPostReport> TblPostReports { get; set; }
        public virtual ICollection<TblPostStored> TblPostStoreds { get; set; }
        public virtual ICollection<TblPostTrade> TblPostTrades { get; set; }
        public virtual ICollection<TblPostlPending> TblPostlPendings { get; set; }
        public virtual ICollection<TblPost> TblPosts { get; set; }
        public virtual ICollection<TblTradeRequestInfo> TblTradeRequestInfos { get; set; }
        public virtual ICollection<TblTradeUserInfo> TblTradeUserInfos { get; set; }
        public virtual ICollection<TblUserFollower> TblUserFollowerFollowings { get; set; }
        public virtual ICollection<TblUserFollower> TblUserFollowerUsers { get; set; }
        public virtual ICollection<TblUserReport> TblUserReportTargetUsers { get; set; }
        public virtual ICollection<TblUserReport> TblUserReportUsers { get; set; }
        public virtual ICollection<TblUserReward> TblUserRewards { get; set; }
        public virtual ICollection<TblUserTimeout> TblUserTimeoutModerators { get; set; }
        public virtual ICollection<TblUserTimeout> TblUserTimeoutUsers { get; set; }
    }
}
