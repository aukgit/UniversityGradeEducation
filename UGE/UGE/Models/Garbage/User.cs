namespace UGE.Models.Garbage
{
    using System;
    using System.Collections.Generic;
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
            UserRoles = new HashSet<UserRole>();
            WishLists = new HashSet<WishList>();
        }

        public int UserID { get; set; }

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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        [StringLength(101)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(128)]
        public string AccountID { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
