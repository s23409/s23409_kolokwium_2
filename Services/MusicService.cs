using s23409_kolokwium_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace s23409_kolokwium_2.Services
{
    public class MusicService : IMusicService
    {
        private readonly MusicDbContext _context;

        public MusicService(MusicDbContext musicDbContext)
        {
            _context = musicDbContext;
        }

        public async Task<Models.DTOs.Album> GetAlbum(int IdAlbum)
        {
            return  _context.albums.Where(e => e.IdAlbum == IdAlbum)
                .Select(e => new Models.DTOs.Album { 
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    tracklist = e.Tracks.Select(e=> e).OrderBy(e => e.Duration).ToList()
                }).FirstOrDefault();
        }
    }
}
