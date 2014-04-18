namespace UGE.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WatchedReference")]
    public partial class WatchedReference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long WatchedReferenceID { get; set; }

        public long WhichFromArticleID { get; set; }

        public long WhichToArticleID { get; set; }

        public virtual Article Article { get; set; }

        public virtual Article Article1 { get; set; }
    }
}
