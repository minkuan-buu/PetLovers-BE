using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class TblPostReactionion
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual TblPost Post { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
    }
}
