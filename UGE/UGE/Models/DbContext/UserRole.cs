namespace UGE.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRole")]
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int UserRoleID { get; set; }

        [Required]
        [StringLength(30)]
        public string RoleName { get; set; }

        public int RolePriority { get; set; }

        public virtual ICollection<User> Users { get; set; }
        
    }
}
