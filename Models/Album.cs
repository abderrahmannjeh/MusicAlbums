using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mouzikty.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Music> Musics { get; set; }
    }
}
