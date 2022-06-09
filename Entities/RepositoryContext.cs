using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Entities
{
    public class RepositoryContext: DbContext
    {
         public DbSet<Musician> Musician { get; set; }
        public DbSet<MusicianTrack> MusicianTrack { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>(e =>
            {
                e.ToTable("Musician");
                e.HasKey(e => e.IdMusician);

                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.Nickname).HasMaxLength(20).IsRequired();

                e.HasData(
                    new Musician
                    {
                        IdMusician = 1,
                        FirstName = "Michal",
                        LastName = "Kowalski",
                        Nickname="DAMN"
                    }
                );
            });
             modelBuilder.Entity<Track>(e =>
            {
                e.ToTable("Track");
                e.HasKey(e => e.IdTrack);

                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).HasMaxLength(50).IsRequired();
                
                e.HasOne(e => e.Album).WithMany(e => e.Track).HasForeignKey(e => e.IdMusicAlbum).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasData(
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "GANG",
                        Duration = 2,
                        IdMusicAlbum=1
                    }
                );
            });
            modelBuilder.Entity<MusicianTrack>(e =>
            {
                e.ToTable("MusicianTrack");
            
               e.HasOne(e => e.Musician).WithMany(e => e.MusicianTrack).HasForeignKey(e => e.IdMusician).OnDelete(DeleteBehavior.ClientSetNull);
               e.HasOne(e => e.Track).WithMany(e => e.MusicianTrack).HasForeignKey(e => e.IdTrack).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasData(
                    new Musician
                    {
                        IdMusician=1,
                        
                        
                    }
                );
            });
             modelBuilder.Entity<Album>(e =>
            {
                e.ToTable("Album");
                e.HasKey(e => e.IdAlbum);

                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.publishDate).IsRequired();
                
                e.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicalLabel).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasData(
                    new Album
                    {
                        IdAlbum = 1,
                        AlbumName = "Far",
                        publishDate = new System.DateTime(2022, 6, 5),
                        IdMusicalLabel=1
                    }
                );
            });
            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.ToTable("MusicLabel");
            e.HasKey(e => e.IdMusicLabel);
            e.Property(e => e.Name).HasMaxLength(50).IsRequired();
              
                e.HasData(
                    new MusicLabel
                    {
                        IdMusicLabel=1,
                        Name="GuguGang"
                        
                    }
                );
            });
        }
    }
}