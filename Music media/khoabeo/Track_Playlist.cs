//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Music_media.khoabeoenti
{
    using System;
    using System.Collections.Generic;
    
    public partial class Track_Playlist
    {
        public System.DateTime ReleaseDate { get; set; }
        public Nullable<int> TrackID { get; set; }
        public Nullable<int> PlaylistID { get; set; }
    
        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
    }
}
