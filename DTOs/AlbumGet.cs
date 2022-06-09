using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Entities.Models;

namespace kol2.DTOs
{
    public class AlbumGet
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime publishDate { get; set; }
        public List<Track> Track { get; set; }
    }

    public class Track {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }

    }
}