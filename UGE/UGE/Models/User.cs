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
    
    public partial class User
    {
        public User()
        {
            this.Bookmarks = new HashSet<Bookmark>();
            this.WishLists = new HashSet<WishList>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
