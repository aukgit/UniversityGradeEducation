namespace UGE.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRole")]
    public partial class UserRole
    {
        [Key]
        public byte UserRoleID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(40)]
        public string RoleName { get; set; }

        public virtual User User { get; set; }


    }
}
