namespace UGE.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LinksToDisplay")]
    public partial class LinksToDisplay
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LinksToDisplayID { get; set; }

        public long ArticleID { get; set; }

        public int ChapterID { get; set; }

        public virtual Article Article { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}
