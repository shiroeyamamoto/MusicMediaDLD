//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL_MusicMedia
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Playlists = new HashSet<Playlist>();
            this.Playlists1 = new HashSet<Playlist>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> ngaySinh { get; set; }
        public string Userpassword { get; set; }
        public string ho { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public Nullable<bool> Admin { get; set; }
        public Nullable<decimal> Coin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Playlist> Playlists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Playlist> Playlists1 { get; set; }
    }
}
