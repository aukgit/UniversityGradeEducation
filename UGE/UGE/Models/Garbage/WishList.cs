namespace UGE.Models.Garbage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WishList")]
    public partial class WishList
    {
        public long WishListID { get; set; }

        public int UserID { get; set; }

        public long ArticleID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Dated { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastNotified { get; set; }

        public virtual Article Article { get; set; }

        public virtual User User { get; set; }
    }
}
