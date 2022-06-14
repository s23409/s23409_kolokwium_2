using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s23409_kolokwium_2.Models
{
    public class MusicDbContext : DbContext
    {

        public MusicDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Album> albums { get; set; }
        public DbSet<Musician> musicians { get; set; }
        public DbSet<Musician_Track> musician_Tracks { get; set; }
        public DbSet<MusicLabel> musicLabels { get; set; }
        public DbSet<Track> tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var musicians = new List<Musician>
            {
                new Musician
            {
                IdMusician = 1,
                FirstName = "Mateusz",
                LastName = "Ciesielski",
                Nickname = "s23409"
            }
            };

            var tracks = new List<Track>
            {
                new Track
                {
                    IdTrack = 1,
                    TrackName = "Firsttrack",
                    Duration = 12,
                    IdMusicAlbum = 1
                }
            };

            var albums = new List<Album>
            {
                new Album
                {
                    IdAlbum = 1,
                    AlbumName = "Firstalbum",
                    PublishDate = new DateTime(2022,02,22),
                    IdMusicLabel = 1

                 
                }
            };

            var musiclabels = new List<MusicLabel> {
                new MusicLabel
                {
                    IdMusicLabel = 1,
                    Name = "Firstmusiclabel"
                }
            };

            var musiciantracks = new List<Musician_Track>
            {
                new Musician_Track
                {
                    IdTrack = 1,
                    IdMusician = 1
                }
            };


            


            modelBuilder.Entity<Musician>(e => {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.Nickname).HasMaxLength(20);

                e.HasData(musicians);
                e.ToTable("Musician");
            });

            modelBuilder.Entity<Musician_Track>(e => {

                e.HasKey(e => new { e.IdMusician, e.IdTrack });

                e.HasOne(e => e.Track)
                .WithMany(e => e.Musician_Tracks)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

                e.HasOne(e => e.Musician)
                .WithMany(e => e.Musician_Tracks)
                .HasForeignKey(e => e.IdMusician)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

                e.HasData(musiciantracks);
                e.ToTable("Musician_Track");
            });

            modelBuilder.Entity<Track>(e => {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();

                e.HasOne(e => e.Album)
                .WithMany(e => e.Tracks)
                .HasForeignKey(e => e.IdMusicAlbum)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasData(tracks);
                e.ToTable("Track");
            });

            modelBuilder.Entity<Album>(e => {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();

                e.HasOne(e => e.MusicLabel)
                .WithMany(e => e.Albums)
                .HasForeignKey(e => e.IdMusicLabel)
                .OnDelete(DeleteBehavior.Cascade).IsRequired();

                e.HasData(albums);
                e.ToTable("Album");
            });

            modelBuilder.Entity<MusicLabel>(e => {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();

                e.HasData(musiclabels);
                e.ToTable("MusicLabel");
            });
        }
    }
}
