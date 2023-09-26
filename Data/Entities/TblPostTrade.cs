using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblPostTrade
    {
        public TblPostTrade()
        {
            TblNotifications = new HashSet<TblNotification>();
            TblTradeRequestInfos = new HashSet<TblTradeRequestInfo>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid InfoId { get; set; }
        public string Content { get; set; } = null!;
        public string Attachment { get; set; } = null!;
        public string Hashtag { get; set; } = null!;
        public decimal? Price { get; set; }
        public string Status { get; set; } = null!;
        public byte[] IsFree { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual TblTradeUserInfo Info { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblNotification> TblNotifications { get; set; }
        public virtual ICollection<TblTradeRequestInfo> TblTradeRequestInfos { get; set; }
    }
}
