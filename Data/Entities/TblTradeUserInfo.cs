using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblTradeUserInfo
    {
        public TblTradeUserInfo()
        {
            TblPostTrades = new HashSet<TblPostTrade>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblPostTrade> TblPostTrades { get; set; }
    }
}
