namespace UGE.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chapter")]
    public partial class Chapter
    {
        public Chapter()
        {
            Articles = new HashSet<Article>();
            LinksToDisplays = new HashSet<LinksToDisplay>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChapterID { get; set; }

        public int BookID { get; set; }

        [Required]
        [StringLength(150)]
        public string TopicName { get; set; }

        public int TotalArticles { get; set; }

        public long MasterArticleID { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual Book Book { get; set; }

        public virtual ICollection<LinksToDisplay> LinksToDisplays { get; set; }
    }
}
