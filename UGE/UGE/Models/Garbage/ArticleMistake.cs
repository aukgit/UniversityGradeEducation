namespace UGE.Models.Garbage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArticleMistake")]
    public partial class ArticleMistake
    {
        public ArticleMistake()
        {
            ReplyAgainstMistakes = new HashSet<ReplyAgainstMistake>();
        }

        public long ArticleMistakeID { get; set; }

        public int UserID { get; set; }

        public long ArticleID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime SubmitedDated { get; set; }

        public virtual ICollection<ReplyAgainstMistake> ReplyAgainstMistakes { get; set; }
    }
}
