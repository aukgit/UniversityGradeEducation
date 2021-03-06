//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UGE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public Article()
        {
            this.Article1 = new HashSet<Article>();
            this.Article11 = new HashSet<Article>();
            this.Bookmarks = new HashSet<Bookmark>();
            this.MCQs = new HashSet<MCQ>();
            this.WatchedReferences = new HashSet<WatchedReference>();
            this.WatchedReferences1 = new HashSet<WatchedReference>();
            this.WishLists = new HashSet<WishList>();
        }
    
        public long ArticleID { get; set; }
        public string ArticleName { get; set; }
        public string Description { get; set; }
        public Nullable<long> PreviousArticleID { get; set; }
        public Nullable<long> NextArticleID { get; set; }
        public int TopicID { get; set; }
    
        public virtual ICollection<Article> Article1 { get; set; }
        public virtual Article Article2 { get; set; }
        public virtual ICollection<Article> Article11 { get; set; }
        public virtual Article Article3 { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<MCQ> MCQs { get; set; }
        public virtual ICollection<WatchedReference> WatchedReferences { get; set; }
        public virtual ICollection<WatchedReference> WatchedReferences1 { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
