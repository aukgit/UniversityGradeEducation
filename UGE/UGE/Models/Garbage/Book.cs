namespace UGE.Models.Garbage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public Book()
        {
            Chapters = new HashSet<Chapter>();
        }

        public int BookID { get; set; }

        public byte SubjectID { get; set; }

        [Required]
        [StringLength(80)]
        public string BookName { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
