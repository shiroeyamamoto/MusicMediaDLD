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
    
    public partial class Track_Artist
    {
        public int ID { get; set; }
        public Nullable<int> TrackID { get; set; }
        public Nullable<int> ArtistID { get; set; }
    
        public virtual Artist Artist { get; set; }
        public virtual Track Track { get; set; }
    }
}