namespace UGE.Models.Garbage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bookmark")]
    public partial class Bookmark
    {
        public long BookmarkID { get; set; }

        public int UserID { get; set; }

        public long ArticleID { get; set; }

        public virtual Article Article { get; set; }

        public virtual User User { get; set; }
    }
}
