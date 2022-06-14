using s23409_kolokwium_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s23409_kolokwium_2.Models.DTOs
{
    public class Album
    {
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public List<Track> tracklist { get; set; }
    }
}
