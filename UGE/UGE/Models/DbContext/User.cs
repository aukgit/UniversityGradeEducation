namespace UGE.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public User()
        {
            Bookmarks = new HashSet<Bookmark>();
            Ratings = new HashSet<Rating>();
            WishLists = new HashSet<WishList>();
        }

        public int UserID { get; set; }

        [DisplayName("User Name")]
        [Required]
        [StringLength(40)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string AccountID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        [StringLength(101)]
        public string DisplayName { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
