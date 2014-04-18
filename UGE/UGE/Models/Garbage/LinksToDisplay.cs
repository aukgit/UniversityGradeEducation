namespace UGE.Models.Garbage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LinksToDisplay")]
    public partial class LinksToDisplay
    {
        public long LinksToDisplayID { get; set; }

        public long ArticleID { get; set; }

        public int ChapterID { get; set; }

        public virtual Article Article { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}
