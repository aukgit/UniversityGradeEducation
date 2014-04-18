namespace UGE.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReplyAgainstMistake")]
    public partial class ReplyAgainstMistake
    {
        public ReplyAgainstMistake()
        {
            ReplyAgainstMistake1 = new HashSet<ReplyAgainstMistake>();
        }

        public long ReplyAgainstMistakeID { get; set; }

        public long ArticleMistakeID { get; set; }

        public int RepliedByWhomID { get; set; }

        [Required]
        [StringLength(800)]
        public string Reply { get; set; }

        public long LinkedReplyMistakeID { get; set; }

        public virtual ArticleMistake ArticleMistake { get; set; }

        public virtual ICollection<ReplyAgainstMistake> ReplyAgainstMistake1 { get; set; }

        public virtual ReplyAgainstMistake ReplyAgainstMistake2 { get; set; }
    }
}
