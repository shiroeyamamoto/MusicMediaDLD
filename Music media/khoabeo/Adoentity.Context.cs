﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Music_media.khoabeo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MusicMediaDLDEntities1 : DbContext
    {
        public MusicMediaDLDEntities1()
            : base("name=MusicMediaDLDEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Track_Artist> Track_Artist { get; set; }
        public virtual DbSet<Track_Playlist> Track_Playlist { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
