namespace UGE.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subject")]
    public partial class Subject
    {
        public Subject()
        {
            Books = new HashSet<Book>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte SubjectID { get; set; }
        [DisplayName("Subject")]
        [Required]
        [StringLength(50)]
        public string SubjectName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
