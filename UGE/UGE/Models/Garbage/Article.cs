namespace UGE.Models.Garbage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        public Article()
        {
            Article1 = new HashSet<Article>();
            Article11 = new HashSet<Article>();
            Bookmarks = new HashSet<Bookmark>();
            LinksToDisplays = new HashSet<LinksToDisplay>();
            MCQs = new HashSet<MCQ>();
            Ratings = new HashSet<Rating>();
            WatchedReferences = new HashSet<WatchedReference>();
            WatchedReferences1 = new HashSet<WatchedReference>();
            WishLists = new HashSet<WishList>();
        }

        public long ArticleID { get; set; }

        [Required]
        [StringLength(150)]
        public string ArticleName { get; set; }

        [Required]
        [StringLength(800)]
        public string Description { get; set; }

        public long? PreviousArticleID { get; set; }

        public long? NextArticleID { get; set; }

        public int ChapterID { get; set; }

        [Required]
        [StringLength(800)]
        public string VideoLink { get; set; }

        public short Height { get; set; }

        public short Width { get; set; }

        public double AvgRating { get; set; }

        public virtual ICollection<Article> Article1 { get; set; }

        public virtual Article Article2 { get; set; }

        public virtual ICollection<Article> Article11 { get; set; }

        public virtual Article Article3 { get; set; }

        public virtual Chapter Chapter { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }

        public virtual ICollection<LinksToDisplay> LinksToDisplays { get; set; }

        public virtual ICollection<MCQ> MCQs { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<WatchedReference> WatchedReferences { get; set; }

        public virtual ICollection<WatchedReference> WatchedReferences1 { get; set; }

        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
