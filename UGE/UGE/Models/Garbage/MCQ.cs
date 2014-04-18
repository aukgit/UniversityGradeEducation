namespace UGE.Models.Garbage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MCQ")]
    public partial class MCQ
    {
        public MCQ()
        {
            Questions = new HashSet<Question>();
        }

        public int MCQID { get; set; }

        public short Duration { get; set; }

        public long ArticleID { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public int DisplayQuestion { get; set; }

        public virtual Article Article { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
