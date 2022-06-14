using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s23409_kolokwium_2.Services
{
    public interface IMusicService
    {
        public Task<Models.DTOs.Album> GetAlbum(int IdAlbum);
    }
}
