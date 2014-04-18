namespace UGE.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        public long RatingID { get; set; }

        public long ArticleID { get; set; }

        public int UserID { get; set; }

        public byte VideoQualtiy { get; set; }

        public byte TechingTechnique { get; set; }

        public byte Mateials { get; set; }

        public double AvgRating { get; set; }

        public virtual Article Article { get; set; }

        public virtual User User { get; set; }
    }
}
