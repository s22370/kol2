using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Entities.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime publishDate { get; set; }
        public int IdMusicalLabel { get; set; }
        public virtual MusicLabel MusicLabel { get; set; }
        public virtual ICollection<Track> Track { get; set; }
        
    }
}